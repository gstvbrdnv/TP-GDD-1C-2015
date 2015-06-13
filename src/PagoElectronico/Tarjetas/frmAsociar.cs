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
    public partial class frmAsociar : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;
        public static Cuenta cuenta;
        public static Banco banco;
        int idCliente;

        public frmAsociar()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 303);
            this.MinimumSize = new System.Drawing.Size(435, 303);
            this.ControlBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esNumerico(txtNumTarjeta);
            validador.esNumerico(txtCodigoSeguridad);
            validador.hayUnoSeleccionado("Emisor", comboEmisor);
            validador.esCodigoSeguridadCorrecto(txtCodigoSeguridad);
            validador.esNumeroTarjetaCorrecta(txtNumTarjeta);
            validador.yaExisteLaTarjeta(txtNumTarjeta);
            validador.esFechaMenor(fechaEmision, fechaVencimiento);

        }

        private void cargarEmisorTarjeta()
        {
            //Obtener emisores de tarjetas
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" +
                sessionUsername + "'");

            var emisores = DataBase.ExecuteReader("Select * from NOLARECURSO.Emisor");

            foreach (DataRow dataRow in emisores.Rows)
            {
                string idEmisor = dataRow["id_emisor"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboEmisor.Items.Add(new Emisor(idEmisor, desc));
            }
        }

        private void frmAsociar_Load(object sender, EventArgs e)
        {
            cargarEmisorTarjeta();
            comboEmisor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
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

            string idEmisor = ((Emisor)comboEmisor.SelectedItem).IDEmisor;

            // Encriptar código de seguridad con SHA1
            string encrypterSecurityCode = Hash(txtCodigoSeguridad.Text);
            //MessageBox.Show(encrypterSecurityCode);

            // Crear registro en la tabla Tarjeta
            DataTable insertDeposito = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Tarjeta " +
                "(nro_tarjeta, id_emisor, fec_emision, fec_vto, cod_seguridad, id_cli, estado) VALUES ('" +
                txtNumTarjeta.Text.ToString() + "', '" + idEmisor + "', '" + fechaEmision.Value.ToString() + "', '" +
                fechaVencimiento.Value.ToString() + "', '" + encrypterSecurityCode +
                "', '" + idCliente + "', '1')");

            // Imprimir mensaje
            MessageBox.Show("La tarjeta ha sido asociada satisfactoriamente.\n\n" +
                "Número de tarjeta: " + txtNumTarjeta.Text + "\n" +
                "Emisor: " + idEmisor.ToString() + "\n" +
                "Fecha de emisión: " + fechaEmision.Value.ToString() + "\n" +
                "Fecha de vencimiento : " + fechaVencimiento.Value.ToString() + "\n" +
                "Código de seguridad: " + txtCodigoSeguridad.Text + "\n\n",
                "", MessageBoxButtons.OK);
            this.Close();
            frmTarjetas newOpcion = new frmTarjetas();
            newOpcion.Show();
        }

        private string ComputeHash(string p, SHA1Managed sHA1Managed)
        {
            throw new NotImplementedException();
        }


        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmTarjetas nuevo = new frmTarjetas();
            nuevo.Show();
        }

        private void frmAsociar_Load_1(object sender, EventArgs e)
        {
            cargarEmisorTarjeta();
            comboEmisor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            string idEmisor = ((Emisor)comboEmisor.SelectedItem).IDEmisor;

            // Encriptar código de seguridad con SHA1
            string encrypterSecurityCode = Hash(txtCodigoSeguridad.Text);
            //MessageBox.Show(encrypterSecurityCode);

            // Crear registro en la tabla Tarjeta
            DataTable insertDeposito = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Tarjeta " +
                "(nro_tarjeta, id_emisor, fec_emision, fec_vto, cod_seguridad, id_cli, estado) VALUES ('" +
                txtNumTarjeta.Text.ToString() + "', '" + idEmisor + "', '" + fechaEmision.Value.ToString() + "', '" +
                fechaVencimiento.Value.ToString() + "', '" + encrypterSecurityCode +
                "', '" + idCliente + "', '1')");

            // Imprimir mensaje
            MessageBox.Show("La tarjeta ha sido asociada satisfactoriamente.\n\n" +
                "Número de tarjeta: " + txtNumTarjeta.Text + "\n" +
                "Emisor: " + idEmisor.ToString() + "\n" +
                "Fecha de emisión: " + fechaEmision.Value.ToString() + "\n" +
                "Fecha de vencimiento : " + fechaVencimiento.Value.ToString() + "\n" +
                "Código de seguridad: " + txtCodigoSeguridad.Text + "\n\n",
                "", MessageBoxButtons.OK);
            this.Close();
            frmTarjetas newOpcion = new frmTarjetas();
            newOpcion.Show();
        }
    }
}