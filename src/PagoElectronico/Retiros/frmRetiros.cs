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

namespace PagoElectronico.Retiros
{
    public partial class frmRetiros : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;
        public static Cuenta cuenta;
        public static Banco banco;
        int idCliente;

        public frmRetiros()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 260);
            this.MinimumSize = new System.Drawing.Size(410, 260);
            this.ControlBox = false;
        }

        private void cargarControles()
        {
            comboCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBanco.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargarCuentas()
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
                comboCuenta.Items.Add(cuenta.nro_cuenta);
            }
        }

        private void cargarBancos()
        {
            var bancos = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Banco");

            foreach (DataRow dataRow in bancos.Rows)
            {
                string idBco = dataRow["id_banco"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboBanco.Items.Add(new Banco(idBco, desc));
            }
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esDecimal(txtMonto);
            validador.hayUnoSeleccionado("Cuenta", comboCuenta);
            validador.hayUnoSeleccionado("Banco", comboBanco);
            validador.esCero(txtMonto);
            validador.validarNumDoc(txtDocumento.Text, idCliente.ToString());
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            // Validar
            // 1. Cuenta habilitada OK
            // 2. Saldo > 0 OK
            // 3. Monto <= Saldo OK
            // 4. Monto en dólares OK
            // Numero documento = NumDoc usuario logueado OK
            // No requiere comision (no se factura)
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
                "where nro_cuenta = '" + comboCuenta.SelectedItem.ToString() + "'");
            string saldoStr = "0";
            foreach (DataRow dataRow in saldoTable.Rows)
            { saldoStr = dataRow["saldo"].ToString(); }
            saldoStr = saldoStr.Replace(",", ".");
            decimal saldoDecimal = decimal.Parse(saldoStr, CultureInfo.InvariantCulture);

            // Verificar saldo
            if (saldoDecimal < montoDecimal)
            {
                validador.agregarError("El monto a extraer '" + monto + "' excede el saldo de la cuenta '" +
                    comboCuenta.SelectedItem.ToString() + "'.\n\nSaldo disponible: '" + saldoDecimal + "'.");
                if (Validador.Instance.hayErrores())
                {
                    Validador.Instance.mostrarErrores();
                    return;
                }
            }
            else
            {
                // Realizar extracción
                // Descontar monto a la cuenta
                int debitarMonto = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Cuenta SET saldo = saldo - " + montoDecimal.ToString() +
                    "WHERE nro_cuenta = '" + comboCuenta.SelectedItem.ToString() + "'");

                string fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).ToString();
                string idBanco = ((Banco)comboBanco.SelectedItem).IDBanco;
                //MessageBox.Show(idBanco);
                
                // Generar extracción
                // 1. Cargar cheque
                Int64 nroCheque = DataBase.ExecuteCardinal64("SELECT * from NOLARECURSO.Cheque order BY 1 DESC") + 1;
                
                DataTable insertCheque = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Cheque " +
                    "(nro_cheque, importe, fec_emision) VALUES ('" +
                    nroCheque + "', '" + montoDecimal.ToString() + "', '" + fecha + "')");
                
                /*DataTable insertCheque = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Cheque " +
                    "(nro_cheque, id_bco, importe, fec_emision) VALUES ('" +
                    nroCheque + "', '" + idBanco + "', '" + montoDecimal.ToString() + "', '" + fecha + "')");*/
                
                // 2. Cargar retiro
                Int64 idRetiro = DataBase.ExecuteCardinal64("SELECT * from NOLARECURSO.Retiro_efectivo order BY 1 DESC") + 1;

                DataTable insertRetiro = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Retiro_efectivo " +
                    "(id_retiro, importe, fec_retiro, nro_cheque, id_bco, nro_cuenta) VALUES " +
                     "('" + idRetiro + "', '" + montoDecimal.ToString() + "', '" + fecha + "', '" +
                    nroCheque + "', '" + idBanco + "', '" + comboCuenta.SelectedItem.ToString() + "')");
                
                /*DataTable insertRetiro = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Retiro_efectivo " +
                    "(id_retiro, importe, fec_retiro, nro_cheque, nro_cuenta) VALUES " +
                    "('" + idRetiro + "', '" + montoDecimal.ToString() + "', '" + fecha + "', '" +
                    nroCheque + "', '" + comboCuenta.SelectedItem.ToString() + "')");*/
                
                // 3. Imprimir mensaje
                MessageBox.Show("La extracción ha sido realizada satisfactoriamente.\n\n" +
                    "Cuenta: " + comboCuenta.SelectedItem.ToString() + "\n" +
                    "Número de documento: " + txtDocumento.Text + "\n" +
                    "Importe: U$S" + montoDecimal.ToString() + "\n" +
                    "Cheque: " + nroCheque + "\n" +
                    "Banco: " + idBanco + "\n\n" +
                    "Fecha: " + fecha, "", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtMonto.Text = "";
        }

        private void frmRetiros_Load(object sender, EventArgs e)
        {
            cargarControles();
            cargarCuentas();
            cargarBancos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
