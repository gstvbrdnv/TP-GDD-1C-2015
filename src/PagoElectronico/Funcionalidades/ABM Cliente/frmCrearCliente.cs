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
using PagoElectronico.ABM_Cliente;

namespace PagoElectronico.Funcionalidades.ABM_Cliente
{
    public partial class frmCrearCliente : Form
    {
        Validador validador = Validador.Instance;
        public static Pais pais;
        public static TipoDocumento tipoDoc;
        public static char operacion;
        public static string cli_id;
        public static string estado;
        public static string paisID;
        public static string tipoDocID;
        public static string estadoID;

        public frmCrearCliente()
        {
            InitializeComponent();
        }

        private void frmCrearCliente_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 409);
            this.MinimumSize = new System.Drawing.Size(358, 409);
            this.ControlBox = false;
            cargarPaises();
            cargarTiposDocumento();
            cargarEstados();
            if (operacion == 'M')
            {
                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetClienteInfo", SqlDataAccessArgs
                    .CreateWith("@ID_Cliente", cli_id).Arguments);

                if (resultado != null && resultado.Rows != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        txtNombre.Text = row["nombre"].ToString();
                        txtApellido.Text = row["apellido"].ToString();
                        txtDocumento.Text = row["nro_documento"].ToString();
                        txtMail.Text = row["mail"].ToString()+"m";
                        txtTelefono.Text = row["telefono"].ToString();
                        txtDomicilio.Text = row["direccion"].ToString();
                        txtNumCalle.Text = row["dir_numero"].ToString();
                        txtPiso.Text = row["dir_piso"].ToString();
                        txtDepto.Text = row["dir_dpto"].ToString();
                        txtLocalidad.Text = row["localidad"].ToString();
                        txtTelefono.Text = row["telefono"].ToString();
                        paisID = row["id_pais"].ToString();
                        estadoID = row["estado"].ToString();
                        tipoDocID = row["id_tipo_doc"].ToString();
                        //dtFechaNacimiento.Value.Year = getyear(row["fec_nacimiento"].ToString());
                    }
                }

                var paisDESC = SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                            "NOLARECURSO.GetDescripcionPais", SqlDataAccessArgs
                            .CreateWith("@ID_PAIS", paisID).Arguments);

                var tipodocDESC = SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                                    "NOLARECURSO.GetTipoDocDescripcion", SqlDataAccessArgs
                                    .CreateWith("@ID_TIPO_DOC", tipoDocID).Arguments);

                if (estadoID == "1")
                {
                    comboEstado.SelectedIndex = 0;
                }
                else
                {
                    comboEstado.SelectedIndex = 1;
                }

                comboPais.SelectedIndex = comboPais.FindString(paisDESC);
                comboNacionalidad.SelectedIndex = comboNacionalidad.FindStringExact(paisDESC);
                comboTipoDocumento.SelectedIndex = comboTipoDocumento.FindStringExact(tipodocDESC);
            }
        }

        private void cargarEstados()
        {
            comboEstado.Items.Add("Activado");
            comboEstado.Items.Add("Desactivado");
        }

        private void cargarTiposDocumento()
        {
            var paises = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Tipo_documento");

            foreach (DataRow dataRow in paises.Rows)
            {
                string idPais = dataRow["id_tipo"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboTipoDocumento.Items.Add(new TipoDocumento(idPais, desc));
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
                comboNacionalidad.Items.Add(new Pais(idPais, desc));
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMCliente nuevo = new frmABMCliente();
            nuevo.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtMail.Text = "";
            this.txtDocumento.Text = "";
            this.txtDomicilio.Text = "";
            this.txtNumCalle.Text = "";
            this.txtPiso.Text = "";
            this.txtDepto.Text = "";
            this.txtTelefono.Text = "";
            comboPais.SelectedIndex = -1;
            comboNacionalidad.SelectedIndex = -1;
            comboEstado.SelectedIndex = -1;
            comboTipoDocumento.SelectedIndex = -1;
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esAlfabetico(txtNombre);
            validador.esAlfabetico(txtApellido);
            validador.esNumerico(txtDocumento);
            validador.hayUnoSeleccionado("Tipo documento", comboTipoDocumento);
            validador.esMail(txtMail);
            validador.hayUnoSeleccionado("Pais", comboPais);
            validador.esAlfabetico(txtDomicilio);
            validador.esNumerico(txtNumCalle);
            validador.esNumerico(txtPiso);
            validador.esAlfabetico(txtLocalidad);
            validador.esNumerico(txtTelefono);
            validador.hayUnoSeleccionado("Nacionalidad", comboNacionalidad);
            validador.hayUnaFechaSeleccionada(dtFechaNacimiento);
            validador.yaExisteMail(txtMail);
            validador.hayUnoSeleccionado("Estado", comboEstado);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            // Crear cliente
            if (operacion == 'A')
            {
                int newCliID = DataBase.ExecuteCardinal("SELECT * FROM NOLARECURSO.Cliente ORDER BY 1 DESC") + 1;
                string idPais = ((Pais)comboPais.SelectedItem).IDPais;
                string idTipoDoc = ((TipoDocumento)comboTipoDocumento.SelectedItem).IDTipoDoc;
                DateTime fechaNac = dtFechaNacimiento.Value;

                if (comboEstado.SelectedItem.ToString() == "Activado")
                { estado = "1"; }
                else { estado = "0"; }

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.CrearCliente", SqlDataAccessArgs
                    .CreateWith("@Nombre", txtNombre.Text)
                                .And("@Apellido", txtApellido.Text)
                                .And("@ID_Tipo_Doc", idTipoDoc)
                                .And("@Nro_Documento", txtDocumento.Text)
                                .And("@Mail", txtMail.Text)
                                .And("@Telefono", txtTelefono.Text)
                                .And("@Direccion", txtDomicilio.Text)
                                .And("@Dir_Numero", txtNumCalle.Text)
                                .And("@Dir_Piso", txtPiso.Text)
                                .And("@Dir_Depto", txtDepto.Text)
                                .And("@Estado", estado)
                                .And("@Localidad", txtLocalidad.Text)
                                .And("@ID_Pais", idPais)
                                .And("@Fec_Nacimiento", fechaNac)
                .Arguments);

                // Imprimir mensaje
                MessageBox.Show("El cliente ha sido creado satisfactoriamente.\n\n" +
                    "Número de cliente: " + newCliID.ToString() + "\n" +
                    "Nombre: " + txtNombre.Text + "\n" +
                    "Apellido: " + txtApellido.Text, "", MessageBoxButtons.OK);
            }
            else // Modificar cliente
            {
                string idPais = ((Pais)comboPais.SelectedItem).IDPais;
                string idTipoDoc = ((TipoDocumento)comboTipoDocumento.SelectedItem).IDTipoDoc;
                DateTime fechaNac = dtFechaNacimiento.Value;

                if (comboEstado.SelectedItem.ToString() == "Activado")
                { estado = "1"; }
                else { estado = "0"; }

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.ActualizarCliente", SqlDataAccessArgs
                    .CreateWith("@ID_Cli", cli_id)
                                .And("@Nombre", txtNombre.Text)
                                .And("@Apellido", txtApellido.Text)
                                .And("@ID_Tipo_Doc", idTipoDoc)
                                .And("@Nro_Documento", txtDocumento.Text)
                                .And("@Mail", txtMail.Text)
                                .And("@Telefono", txtTelefono.Text)
                                .And("@Direccion", txtDomicilio.Text)
                                .And("@Dir_Numero", txtNumCalle.Text)
                                .And("@Dir_Piso", txtPiso.Text)
                                .And("@Dir_Depto", txtDepto.Text)
                                .And("@Estado", estado)
                                .And("@Localidad", txtLocalidad.Text)
                                .And("@ID_Pais", idPais)
                                .And("@Fec_Nacimiento", fechaNac)
                .Arguments);

                MessageBox.Show("El cliente ha sido modificado satisfactoriamente.\n", "", MessageBoxButtons.OK);
            }

            // Cerrar formulario
            this.Close();
            frmABMCliente newABM = new frmABMCliente();
            newABM.Show();
        }


    }
}
