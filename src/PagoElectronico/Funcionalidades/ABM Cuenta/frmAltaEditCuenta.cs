using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Login;
using PagoElectronico.DB;
using PagoElectronico.Data;
using System.Security.Cryptography;
using PagoElectronico.Modelos;
using PagoElectronico.Core;
using System.Globalization;
using System.Threading;
using System.Configuration;
using PagoElectronico.ABM_Cuenta;

namespace PagoElectronico.Funcionalidades.ABM_Cuenta
{
    public partial class frmAltaEditCuenta : Form
    {
        Validador validador = Validador.Instance;
        public static TipoDocumento tipoDoc;
        public static char operacion;
        public static string id_cuenta;
        public static string tipoCuenta;
        public static string sessionUsername;
        public static string sessionRol;
        public static string idCliMsgBox;
        public static string usernameMsgBox;
        public static string paisID;
        public static string tipoCuentaID;

        public frmAltaEditCuenta()
        {
            InitializeComponent();
            sessionUsername = frmLogin.loginUsername;
            sessionRol = frmLogin.rolElegido;
        }

        private void frmAltaEditCuenta_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(338, 258);
            this.MinimumSize = new System.Drawing.Size(338, 258);
            this.ControlBox = false;
            cargarPaises();
            cargarTiposCuenta();
            cargarTiposMoneda();

            if (((sessionRol == "1") || (sessionRol == "3")) && (operacion == 'A'))
            {
                lblUsuario.Visible = true;
                comboUsuario.Visible = true;
                cargarUsuarios();
            }

            if (operacion == 'M')
            {
                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetCuentaInfo", SqlDataAccessArgs
                    .CreateWith("@ID_Cuenta", id_cuenta).Arguments);

                if (resultado != null && resultado.Rows != null)
                {
                    txtNumCuenta.Enabled = false;
                    comboPais.Enabled = true;
                    comboTipoCuenta.Enabled = true;

                    foreach (DataRow row in resultado.Rows)
                    {
                        txtNumCuenta.Text = row["nro_cuenta"].ToString();
                        paisID = row["id_pais"].ToString();
                        tipoCuentaID = row["id_tipo_cta"].ToString();
                    }

                    var pais = SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.GetDescripcionPais", SqlDataAccessArgs
                        .CreateWith("@ID_PAIS", paisID).Arguments);

                    var tipoCuenta = SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.GetDescripcionTipoCuenta", SqlDataAccessArgs
                        .CreateWith("@ID_TIPO_CUENTA", tipoCuentaID).Arguments);

                    comboPais.SelectedIndex = comboPais.FindStringExact(pais.ToString());
                    comboTipoCuenta.SelectedIndex = comboTipoCuenta.FindStringExact(tipoCuenta.ToString());
                }
            }

            if (operacion == 'A')
            {
                var newCuentaID = SqlDataAccess.ExecuteScalarQuery<Int64>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetIdCuenta");

                txtNumCuenta.Text = newCuentaID.ToString();
                txtNumCuenta.Enabled = false;
                comboPais.Enabled = true;
                comboTipoCuenta.Enabled = true;
            }
        }

        private void cargarPaises()
        {
            var paises = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Pais");

            foreach (DataRow dataRow in paises.Rows)
            {
                string idPais = dataRow["id_pais"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboPais.Items.Add(new Pais(idPais, desc));
            }
        }

        private void cargarUsuarios()
        {
            var usuarios = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Usuario");

            foreach (DataRow dataRow in usuarios.Rows)
            {
                string username = dataRow["username"].ToString();
                comboUsuario.Items.Add(username);
            }
        }

        private void cargarTiposMoneda()
        {
            comboMoneda.Enabled = false;
            comboMoneda.Items.Add("U$S (Dólar)");
            comboMoneda.SelectedIndex = 0;
            //comboTipoMoneda.SelectedItem = "U$S (Dólar)";
        }

        private void cargarTiposCuenta()
        {
            var tipocuenta = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Tipo_Cuenta");

            foreach (DataRow dataRow in tipocuenta.Rows)
            {
                string idTipoCuenta = dataRow["id_tipo"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboTipoCuenta.Items.Add(new TipoCuenta(idTipoCuenta, desc));
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMCuenta nuevo = new frmABMCuenta();
            nuevo.Show();
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.hayUnoSeleccionado("Tipo de cuenta", comboTipoCuenta);
            validador.hayUnoSeleccionado("Pais", comboPais);

            if (((sessionRol == "1") || (sessionRol == "3")) && (operacion == 'A'))
            {
                validador.hayUnoSeleccionado("Usuario", comboUsuario);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            string idPaisStr = ((Pais)comboPais.SelectedItem).IDPais;
            string idTipoCuentaStr = ((TipoCuenta)comboTipoCuenta.SelectedItem).IDTipoCuenta;

            // Crear cuenta
            if (operacion == 'A')
            {
                if ((sessionRol == "1") || (sessionRol == "3"))
                {   // Si esta logueado como admin o admin. gral., asigna la nueva cuenta
                    // al cliente del usuario especificado en el combo de usuarios.

                    //string username = ((Usuario)comboUsuario.SelectedItem).IDUsername;
                    string username = comboUsuario.SelectedItem.ToString();

                    var Id_Cliente = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                                     "NOLARECURSO.GetClienteUsuario", SqlDataAccessArgs
                                        .CreateWith("@USERNAME", username)
                                    .Arguments);

                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.CrearCuenta", SqlDataAccessArgs
                    .CreateWith("@CuentaID", txtNumCuenta.Text)
                                .And("@ID_Pais", idPaisStr)
                                .And("@ID_Tipo_Cuenta", idTipoCuentaStr)
                                .And("@ID_Cliente", Id_Cliente)
                    .Arguments);

                    idCliMsgBox = Id_Cliente.ToString();
                    usernameMsgBox = username;
                }
                else
                {   // Si esta logueado como cliente, asigna la nueva cuenta a su cliente
                    var Id_Cliente = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                                     "NOLARECURSO.GetClienteUsuario", SqlDataAccessArgs
                                        .CreateWith("@USERNAME", sessionUsername)
                                    .Arguments);

                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.CrearCuenta", SqlDataAccessArgs
                    .CreateWith("@CuentaID", txtNumCuenta.Text)
                                .And("@ID_Pais", idPaisStr)
                                .And("@ID_Tipo_Cuenta", idTipoCuentaStr)
                                .And("@ID_Cliente", Id_Cliente)
                    .Arguments);

                    idCliMsgBox = Id_Cliente.ToString();
                    usernameMsgBox = sessionUsername;
                }       

                // Imprimir mensaje
                MessageBox.Show("La cuenta " + txtNumCuenta.Text + " ha sido creada correctamente.\n\n" +
                    "Número de cliente: " + idCliMsgBox + "\n" +
                    "Usuario: " + usernameMsgBox + "\n" +
                    "Estado: Pendiente de activación", "", MessageBoxButtons.OK);
            }
            else if (operacion == 'M')
            {
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.ActualizarCuenta", SqlDataAccessArgs
                .CreateWith("@CuentaID", txtNumCuenta.Text)
                    .And("@Tipo_Cuenta_Nuevo", idTipoCuentaStr)
                    .And("@ID_Pais_Nuevo", idPaisStr)
                .Arguments);

                // Imprimir mensaje
                MessageBox.Show("La cuenta " + txtNumCuenta.Text + " ha sido actualizada correctamente.\n\n" +
                    "Nuevo tipo de cuenta: " + idTipoCuentaStr + "", "", MessageBoxButtons.OK);
            }

            this.Close();
            frmABMCuenta newABM = new frmABMCuenta();
            newABM.Show();
        }

    }
}
