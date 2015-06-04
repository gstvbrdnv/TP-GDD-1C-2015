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

namespace PagoElectronico.Transferencias
{
    public partial class frmTransferencia : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        public static Cuenta cuenta;
        int idCliente; 

        public frmTransferencia()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
        }

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            cargarControles();
            cargarCuentasOrigen();
        }

        private void cargarCuentasOrigen()
        {
            //MessageBox.Show(sessionUsername);
            //Obtener cuentas
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" + sessionUsername + "'");
            //MessageBox.Show(idCliente.ToString());
            var cuentasUsuario = DataBase.ExecuteReader("Select nro_cuenta from NOLARECURSO.Cuenta " + 
                "where id_cli = '" + idCliente +
                "' and estado = 1" +
                " and saldo>0");

            // Carga solo las cuentas habilitadas y con saldo mayor a cero:
            foreach (DataRow dataRow in cuentasUsuario.Rows)
            {
                cuenta = new Cuenta();
                cuenta.nro_cuenta = dataRow["nro_cuenta"].ToString();
                comboOrigen.Items.Add(cuenta.nro_cuenta.ToString());
            }
        }

        private void cargarControles()
        {
           // comboDestino.Enabled = false;
            comboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboDestino.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Valida datos de los campos
        private void validarDatos()
        {
            Validador validador = Validador.Instance;

            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esNumerico(txtDestino);
            validador.esNumerico(txtMonto);
            validador.hayUnoSeleccionado("Cuenta origen", comboOrigen);
            // Existe la cuenta destino?
            validador.existeLaCuenta(txtDestino.Text);
            // Son la misma cuenta origen y destino?
            validador.sonIguales(txtDestino, comboOrigen, "Cuenta origen");
            // Cuenta destino esta habilitada o inhabilitada?
            validador.esCuentaCerradaOPendiente(txtDestino.Text);
            // Monto es mayor a cero?
            validador.esCero(txtMonto);
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }
            // Si no hay errores, chequear
            // Fecha transferencia del dia (inmediata)
            // Es cuenta propia o de tercero?
            if (esCuentaPropia(txtDestino.Text))
            {
                // Si es propia, costo transferencia = 0
                MessageBox.Show("Es cuenta propia");

            }
            else
            {
                // Si es de tercero, el costo se cobra a la cuenta origen y dependiendo del tipo de cuenta
                MessageBox.Show("Es cuenta de tercero");


            }
        }

        public bool esCuentaPropia(string cuentaDestino)
        {
            int idClienteDestino = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Cuenta " +
                "where nro_cuenta = '" + txtDestino.Text + "' and (estado = 1 or estado = 2)");
            //MessageBox.Show(idClienteDestino.ToString());
            if (idCliente == idClienteDestino)
                return true;
            else
                return false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        public void limpiarControles()
        {
            txtDestino.Text = "";
            txtMonto.Text = "";
        }

    }
}
