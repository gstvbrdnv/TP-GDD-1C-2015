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
using PagoElectronico.Comun;
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
        Validador validador = Validador.Instance;
        public static Cuenta cuenta;
        public static Tarjeta tarjeta;

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
                lblDisponible.Text = "(No hay tarjetas disponibles)";
            }
        }

        private void frmDesasociar_Load(object sender, EventArgs e)
        {
            comboTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarTarjetas();
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
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }

            validador.hayUnoSeleccionado("Tarjeta", comboTarjeta);
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
    }
}
