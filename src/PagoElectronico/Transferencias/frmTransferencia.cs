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

namespace PagoElectronico.Transferencias
{
    public partial class frmTransferencia : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        public static Cuenta cuenta;
        int idCliente; 
        Validador validador = Validador.Instance;

        public frmTransferencia()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(313, 188);
            this.MinimumSize = new System.Drawing.Size(313, 188);
            this.ControlBox = false;
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
                "' and id_estado = 1" +
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

        //Validar datos de los campos
        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esNumerico(txtDestino);
            validador.esDecimal(txtMonto);
            //validador.esNumerico(txtMontoDecimal);
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

            string monto = txtMonto.Text;
            monto = monto.Replace(",", ".");
            decimal montoDecimal = decimal.Parse(monto, CultureInfo.InvariantCulture);

            var saldoTable = DataBase.ExecuteReader("SELECT saldo FROM NOLARECURSO.Cuenta " +
                "where nro_cuenta = '" + comboOrigen.SelectedItem.ToString() + "'");
            string saldoStr = "0";
            foreach (DataRow dataRow in saldoTable.Rows)
            { saldoStr = dataRow["saldo"].ToString(); }
            saldoStr = saldoStr.Replace(",", ".");

            decimal saldoDecimal = decimal.Parse(saldoStr, CultureInfo.InvariantCulture);

            // Validar si la cuenta destino es propia o de tercero:
            if (esCuentaPropia(txtDestino.Text))
            {
                // Si es propia, costo de transferencia = 0
                if (saldoDecimal < montoDecimal)
                {
                    validador.agregarError("El monto a transferir '" + monto + "' excede el saldo de la cuenta origen '" +
                        comboOrigen.SelectedItem.ToString() + "'.\n\nSaldo disponible: '" + saldoDecimal + "'.");
                    if (Validador.Instance.hayErrores())
                    {
                        Validador.Instance.mostrarErrores();
                        return;
                    }
                }
                else
                {
                    // Realizar transferencia
                    // Descontar monto a la cuenta origen
                    int debitarMonto = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Cuenta SET saldo = saldo - " + montoDecimal.ToString() +
                        "WHERE nro_cuenta = '" + comboOrigen.SelectedItem.ToString() + "'");
                    // Acreditar monto a la cuenta destino
                    int acreditarMonto = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Cuenta SET saldo = saldo + " + montoDecimal.ToString() +
                        "WHERE nro_cuenta = '" + txtDestino.Text.ToString() + "'");
                    // Generar transferencia
                    string fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).ToString();
                    DataTable insertTransferencia = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Transferencia " +
                        "(cta_origen, cta_destino, importe, fecha, costo) VALUES " +
                        "('" + comboOrigen.SelectedItem.ToString() + "', '" + txtDestino.Text.ToString() + "', '" +
                        montoDecimal.ToString() + "', '" + fecha + "', 0.00)");
                    // Imprimir mensaje
                    MessageBox.Show("La transferencia ha sido realizada satisfactoriamente.\n\n" +
                        "Importe: U$S" + montoDecimal.ToString() + "\n" +
                        "Cuenta origen: " + comboOrigen.SelectedItem.ToString() + "\n" +
                        "Cuenta destino: " + txtDestino.Text.ToString() + "\n\n" +
                        "Fecha: " + fecha, "", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else // es de tercero
            {
                // Si es de tercero, el costo se cobra a la cuenta origen dependiendo del tipo de cuenta
                // Calcular costo de transferencia
                decimal costoFijo;
                var idTipoCuenta = DataBase.ExecuteCardinal("SELECT id_tipo_cta FROM NOLARECURSO.Cuenta " +
                    "WHERE nro_cuenta = '" + comboOrigen.SelectedItem.ToString() + "'");
                
                switch (idTipoCuenta)
                {
                    case (4):
                        costoFijo = 0.02m;
                        break;
                    default:
                        costoFijo = 0.01m;
                        break;
                }

                if (saldoDecimal < montoDecimal)
                {
                    validador.agregarError("El monto a transferir '" + monto + "' excede el saldo de la cuenta origen '" +
                        comboOrigen.SelectedItem.ToString() + "'.\n\nSaldo disponible: '" + saldoDecimal + "'.");
                    if (Validador.Instance.hayErrores())
                    {
                        Validador.Instance.mostrarErrores();
                        return;
                    }
                }
                else
                {
                    // Realizar transferencia
                    // Descontar monto a la cuenta origen
                    decimal montoFinal = montoDecimal + costoFijo;
                    int debitarMonto = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Cuenta SET saldo = saldo - " + montoFinal.ToString() +
                        "WHERE nro_cuenta = '" + comboOrigen.SelectedItem.ToString() + "'");
                    // Acreditar monto a la cuenta destino
                    int acreditarMonto = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Cuenta SET saldo = saldo + " + montoDecimal.ToString() +
                        "WHERE nro_cuenta = '" + txtDestino.Text.ToString() + "'");
                    // Generar transferencia
                    string fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).ToString();
                    DataTable insertTransferencia = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Transferencia " +
                        "(cta_origen, cta_destino, importe, fecha, costo) VALUES " +
                        "('" + comboOrigen.SelectedItem.ToString() + "', '" + txtDestino.Text.ToString() + "', '" +
                        montoDecimal.ToString() + "', '" + fecha + "', '" + costoFijo + "')");
                    // Imprimir mensaje
                    MessageBox.Show("La transferencia ha sido realizada satisfactoriamente.\n\n" +
                        "Importe: U$S" + montoDecimal.ToString() + "\n" +
                        "Cuenta origen: " + comboOrigen.SelectedItem.ToString() + "\n" +
                        "Cuenta destino: " + txtDestino.Text.ToString() + "\n" +
                        "Costo fijo: U$S" + costoFijo.ToString() + "\n\n" +
                        "Fecha: " + fecha, "", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }

        public bool esCuentaPropia(string cuentaDestino)
        {
            int idClienteDestino = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Cuenta " +
                "where nro_cuenta = '" + txtDestino.Text + "' and (id_estado = 1 or id_estado = 2)");
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

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
