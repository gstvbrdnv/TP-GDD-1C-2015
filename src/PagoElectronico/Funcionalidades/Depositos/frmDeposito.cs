﻿using System;
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

namespace PagoElectronico.Depositos
{
    public partial class frmDeposito : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;
        public static Cuenta cuenta;
        public static Tarjeta tarjeta;
        int idCliente;

        public frmDeposito()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(421, 444);
            this.MinimumSize = new System.Drawing.Size(421, 444);
            this.ControlBox = false;
        }

        private void frmDeposito_Load(object sender, EventArgs e)
        {
            cargarControles();
            cargarCuentas();
            cargarTiposMoneda();
            cargarTarjetas();
        }

        private void cargarControles()
        {
            comboCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargarTiposMoneda()
        {
            comboTipoMoneda.Enabled = false;
            comboTipoMoneda.Items.Add("U$S (Dólar)");
            comboTipoMoneda.SelectedIndex = 0;
            //comboTipoMoneda.SelectedItem = "U$S (Dólar)";
        }

        private void cargarCuentas()
        {
            //Obtener cuentas
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" + sessionUsername + "'");
            
            var cuentasUsuario = DataBase.ExecuteReader("Select nro_cuenta from NOLARECURSO.Cuenta " +
                "where id_cli = '" + idCliente +
                "' and id_estado = 1");

            // Carga solo las cuentas habilitadas:
            foreach (DataRow dataRow in cuentasUsuario.Rows)
            {
                cuenta = new Cuenta();
                cuenta.nro_cuenta = dataRow["nro_cuenta"].ToString();
                comboCuenta.Items.Add(cuenta.nro_cuenta);
            }
        }

        private void cargarTarjetas()
        {
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Text = "";
            lblDisponible.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esDecimal(txtMonto);
            validador.hayUnoSeleccionado("Cuenta", comboCuenta);
            validador.hayUnoSeleccionado("Tipo moneda", comboTipoMoneda);
            validador.hayUnoSeleccionado("Tarjeta de crédito", comboTarjeta);
            validador.esMayorA1(txtMonto);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (comboTarjeta.Items.Count == 0)
            {
                validador.agregarError("No posee tarjetas disponibles o todas sus tarjetas están vencidas.");
                comboTarjeta.Enabled = false;
                lblDisponible.Text = "(No hay tarjetas disponibles)";
            }
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            // Realizar depósito
            // 1. Acreditar monto
            string monto = txtMonto.Text;
            monto = monto.Replace(",", ".");
            decimal montoDecimal = decimal.Parse(monto, CultureInfo.InvariantCulture);

            // 1. Acreditar importe
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.IncrementarSaldoCuenta", SqlDataAccessArgs
                .CreateWith("@Cuenta", comboCuenta.SelectedItem)
                .And("@Importe", montoDecimal)
            .Arguments);

            // 2. Insertar deposito
            DateTime fechaDeposito = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.InsertarDeposito", SqlDataAccessArgs
                .CreateWith("@Importe", montoDecimal)
                .And("@Tipo_Moneda", 1)
                .And("@Fec_Deposito", fechaDeposito)
                .And("@Nro_Cuenta", comboCuenta.SelectedItem.ToString())
                .And("@Nro_Tarjeta", comboTarjeta.SelectedItem.ToString())
            .Arguments);

            //DataTable insertDeposito = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Deposito " +
            //    "(id_deposito, importe, tipo_moneda, fec_deposito, nro_cuenta, nro_tarjeta) VALUES ('" +
            //    idDeposito + "', '" + txtMonto.Text + "', '1', '" + fecha + "', '" + comboCuenta.SelectedItem.ToString() +
            //    "', '" + comboTarjeta.SelectedItem.ToString() + "')");

            // 3. Imprimir mensaje
            MessageBox.Show("El depósito ha sido realizado satisfactoriamente.\n", "", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
