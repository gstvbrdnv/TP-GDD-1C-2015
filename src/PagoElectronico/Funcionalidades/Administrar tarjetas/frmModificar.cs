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
using System.Security.Cryptography;
using PagoElectronico.Modelos;
using PagoElectronico.Core;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace PagoElectronico.Tarjetas
{
    public partial class frmModificar : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador1 = Validador.Instance;
        Validador validador2 = Validador.Instance;
        public static Cuenta cuenta;
        public static Tarjeta tarjeta;

        public frmModificar()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(287, 267);
            this.MinimumSize = new System.Drawing.Size(287, 267);
            this.ControlBox = false;
        }

        private void cargarTarjetas()
        {
            //Obtener cliente
            int idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" + sessionUsername + "'");
            
            //Obtener tarjetas sin vencer
            string fecha = DateTime.Now.ToString();
            var tarjetasCliente = DataBase.ExecuteReader("SELECT nro_tarjeta from NOLARECURSO.Tarjeta WHERE " +
                "id_cli = '" + idCliente + "' AND fec_vto > '" + fecha + "' " +
                "AND estado = 1");

            foreach (DataRow dataRow in tarjetasCliente.Rows)
            {
                tarjeta = new Tarjeta();
                tarjeta.nro_tarjeta = dataRow["nro_tarjeta"].ToString();
                comboTarjeta.Items.Add(tarjeta.nro_tarjeta);
            }

            if (comboTarjeta.Items.Count == 0)
            {
                comboTarjeta.Enabled = false;
                lblDisponible.Text = "(No hay tarjetas)";
            }
        }

        private void frmDesasociar_Load(object sender, EventArgs e)
        {
            comboTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarTarjetas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void validarDatos1()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador1.estaVacioOEsNulo((TextBox)control); }

            validador1.hayUnoSeleccionado("Tarjeta", comboTarjeta);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {




        }

        private void frmModificar_Load(object sender, EventArgs e)
        {

        }

        private void frmModificar_Load_1(object sender, EventArgs e)
        {
            cargarTarjetas();
            comboTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            this.validarDatos1();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            dateTimePicker1.Enabled = true;
            comboTarjeta.Enabled = false;
            btnSeleccionar.Enabled = false;
            btnModificar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Cambiar fecha vencimiento tarjeta
            DateTime fechaNueva = dateTimePicker1.Value;
            int darDeBajaTarjeta = DataBase.ExecuteNonQuery("update NOLARECURSO.Tarjeta set fec_vto = '"
                + fechaNueva + "' where nro_tarjeta = '" + comboTarjeta.SelectedItem.ToString() + "'");

            // Imprimir mensaje
            MessageBox.Show("La tarjeta ha sido modificada satisfactoriamente.\n\n" +
                "Número de tarjeta: " + comboTarjeta.SelectedItem.ToString() + "\n" +
                "Nueva fecha de vencimiento: " + dateTimePicker1.Value.ToString() + "\n",
                "", MessageBoxButtons.OK);

            // Cerrar ventana
            this.Hide();
            frmTarjetas newOpcionesTarjetas = new frmTarjetas();
            newOpcionesTarjetas.Show();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmTarjetas nuevo = new frmTarjetas();
            nuevo.Show();
        }
    }
}
