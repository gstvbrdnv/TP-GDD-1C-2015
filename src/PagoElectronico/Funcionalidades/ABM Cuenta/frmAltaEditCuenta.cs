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
        public static Pais pais;
        public static TipoDocumento tipoDoc;
        public static char operacion;
        public static string id_cuenta;
        public static string estado;

        public frmAltaEditCuenta()
        {
            InitializeComponent();
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

            if (operacion == 'M')
            {
                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetCuentaInfo", SqlDataAccessArgs
                    .CreateWith("@ID_Cuenta", id_cuenta).Arguments);

                if (resultado != null && resultado.Rows != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        txtNumCuenta.Text = row["nro_cuenta"].ToString();
                        txtNumCuenta.Enabled = false;



                    }
                }
            }

            if (operacion == 'A')
            {
                var newCuentaID = SqlDataAccess.ExecuteScalarQuery<Int64>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetIdCuenta");

                txtNumCuenta.Text = newCuentaID.ToString();
                txtNumCuenta.Enabled = false;
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
                ActualizarTipoCuenta
            }
            else if (operacion == 'M')
            {

            }
        }

    }
}
