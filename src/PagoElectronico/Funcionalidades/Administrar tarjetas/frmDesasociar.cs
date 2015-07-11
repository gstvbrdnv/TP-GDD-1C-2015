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
    public partial class frmDesasociar : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador1 = Validador.Instance;
        Validador validador2 = Validador.Instance;
        public static Cuenta cuenta;
        public static Tarjeta tarjeta;
        int idCliente;

        public frmDesasociar()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(269, 177);
            this.MinimumSize = new System.Drawing.Size(269, 177);
            this.ControlBox = false;
        }

        private void cargarTarjetas()
        {
            //Obtener cliente
            int idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" + sessionUsername + "'");
            //Obtener tarjetas sin vencer
            DateTime fecha = DateTime.Now;
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
                lblDisponible.Text = "(No hay tarjetas disponibles)";
            }
        }

        private void frmDesasociar_Load(object sender, EventArgs e)
        {
            comboTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarTarjetas();

            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" +
            sessionUsername + "'");

            if (sessionRol == "1" || sessionRol == "3")
            {
                lblCliente.Visible = true;
                txtCliente.Visible = true;
                btnBuscar.Enabled = true;
                btnBuscar.Visible = true;
            }
            else
            {
                lblCliente.Visible = false;
                txtCliente.Enabled = false;
                txtCliente.Visible = false;
                btnBuscar.Enabled = false;
                btnBuscar.Visible = false;
                txtCliente.Text = idCliente.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTarjetas nuevo = new frmTarjetas();
            nuevo.Show();
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador1.estaVacioOEsNulo((TextBox)control); }

            validador1.hayUnoSeleccionado("Tarjeta", comboTarjeta);
            validador1.esNumerico(txtCliente);
        }

        private void validarDatos2()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador2.estaVacioOEsNulo((TextBox)control); }

            validador2.esNumerico(txtCliente);
        }

        private void btnDesasociar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea desasociar la tarjeta?",
                "Confirmar baja de tarjeta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Cambiar estado tarjeta
                int darDeBajaTarjeta = DataBase.ExecuteNonQuery("update NOLARECURSO.Tarjeta set estado = 0 " +
                    "where nro_tarjeta = '" + comboTarjeta.SelectedItem.ToString() + "'");

                // Imprimir mensaje
                MessageBox.Show("La tarjeta ha sido desasociada satisfactoriamente.\n\n" +
                    "Número de tarjeta: " + comboTarjeta.SelectedItem.ToString() + "\n",
                    "", MessageBoxButtons.OK);

                // Cerrar ventana
                this.Hide();
                frmTarjetas newOpcionesTarjetas = new frmTarjetas();
                newOpcionesTarjetas.Show();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.validarDatos2();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            idCliente = int.Parse(txtCliente.Text);
            cargarTarjetas();
        }
    }
}
