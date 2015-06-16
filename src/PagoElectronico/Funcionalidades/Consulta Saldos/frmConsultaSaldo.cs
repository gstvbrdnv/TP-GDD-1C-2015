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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class frmConsultaSaldo : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        public static Cuenta cuenta;
        int idCliente;
        Validador validador1 = Validador.Instance;
        Validador validador2 = Validador.Instance;

        public frmConsultaSaldo()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(967, 642);
            this.MinimumSize = new System.Drawing.Size(967, 642);
            this.ControlBox = false;
        }

        private void cargarCuentasPropias()
        {
            //Obtener cuentas
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario where username = '" + sessionUsername + "'");
            //MessageBox.Show(idCliente.ToString());
            var cuentasUsuario = DataBase.ExecuteReader("Select nro_cuenta from NOLARECURSO.Cuenta " +
                "WHERE id_cli = '" + idCliente + "'");

            // Carga todas las cuentas del cliente
            foreach (DataRow dataRow in cuentasUsuario.Rows)
            {
                cuenta = new Cuenta();
                cuenta.nro_cuenta = dataRow["nro_cuenta"].ToString();
                comboCuenta.Items.Add(cuenta.nro_cuenta.ToString());
            }
        }

        private void frmConsultaSaldo_Load(object sender, EventArgs e)
        {
            comboCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarCuentasPropias();
            gridRetiro.AllowUserToResizeColumns = false;
            gridRetiro.AllowUserToResizeRows = false;
            gridDeposito.AllowUserToResizeColumns = false;
            gridDeposito.AllowUserToResizeRows = false;
            gridTransferencias.AllowUserToResizeColumns = false;
            gridTransferencias.AllowUserToResizeRows = false;

            if (sessionRol == "1")
            {
                lblCuentaTercero.Visible = true;
                txtCuentaTercero.Visible = true;
                txtCuentaTercero.Enabled = true;
                btnBuscar.Visible = true;
                btnBuscar.Enabled = true;
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblNumCuenta.Text = "Cuenta: ";
            lblTitular.Text = "Titular: ";
            lblSaldo.Text = "Saldo: U$S ";
            lblEstado.Text = "Estado: ";
            txtCuentaTercero.Text = "";
            gridRetiro.Rows.Clear();
            gridDeposito.Rows.Clear();
            gridTransferencias.Rows.Clear();
        }

        //Validar datos de los campos
        private void validarDatosTercero()
        {
            validador2.estaVacioOEsNulo(txtCuentaTercero);
            validador2.esNumerico(txtCuentaTercero);
            // Existe la cuenta destino?
            validador2.existeLaCuenta(txtCuentaTercero.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.validarDatosTercero();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            string numCuenta = txtCuentaTercero.Text;
            cargarRetiros(numCuenta);
            cargarDepositos(numCuenta);
            cargarTransferencias(numCuenta);
            cargarSaldo(numCuenta);
        }

        //Validar datos de los campos
        private void validarDatosPropios()
        {
            validador1.hayUnoSeleccionado("Cuenta", comboCuenta);
        }

        private void btnConsultarPropia_Click(object sender, EventArgs e)
        {
            this.validarDatosPropios();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            string numCuenta = comboCuenta.SelectedItem.ToString();
            cargarRetiros(numCuenta);
            cargarDepositos(numCuenta);
            cargarTransferencias(numCuenta);
            cargarSaldo(numCuenta);
        }

        private void cargarSaldo(string cuenta)
        {

            var datosCuenta = DataBase.ExecuteReader("select nro_cuenta, nombre, apellido, saldo, id_estado " +
                "from NOLARECURSO.Cliente cl, NOLARECURSO.Cuenta cu " +
                "where nro_cuenta = '" + cuenta + "' and cu.id_cli = cl.id_cli");

            foreach (DataRow dataRow in datosCuenta.Rows)
            {
                lblNumCuenta.Text = "Cuenta: " + cuenta;
                lblTitular.Text = "Titular: " + dataRow["apellido"].ToString() + ", " + dataRow["nombre"].ToString();
                lblSaldo.Text = "Saldo: U$S " + dataRow["saldo"].ToString();

                switch(dataRow["id_estado"].ToString())
                {
                    case "1":
                        lblEstado.Text = "Estado: Habilitada";
                        break;
                    case "2":
                        lblEstado.Text = "Estado: Inhabilitada";
                        break;
                    case "3":
                        lblEstado.Text = "Estado: Cerrada";
                        break;
                    default:
                        lblEstado.Text = "Estado: Pendiente de activación";
                        break;
                }
            }
        }

        private void cargarRetiros(string cuenta)
        {
            //Obtener retiros en efectivo
            var depositos = DataBase.ExecuteReader("select top 5 fec_retiro, id_retiro, r.nro_cheque, descripcion, r.importe " +
            "from NOLARECURSO.Retiro_efectivo r, NOLARECURSO.Banco b, NOLARECURSO.Cheque c " +
            "where r.nro_cuenta = '" + cuenta + "' and r.nro_cheque = c.nro_cheque and b.id_banco = c.id_banco " +
            "order by 2 desc");

            // Cargar los retiros a la grilla
            gridRetiro.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            Object[] columnas = new Object[5];

            foreach (DataRow row in depositos.Rows)
            {
                columnas[0] = row["id_retiro"];
                columnas[1] = row["nro_cheque"];
                columnas[2] = row["descripcion"];
                columnas[3] = row["importe"];
                columnas[4] = row["fec_retiro"];

                filas.Add(new DataGridViewRow());
                filas[filas.Count - 1].CreateCells(gridRetiro, columnas);
            }
            gridRetiro.Rows.AddRange(filas.ToArray());
        }

        private void cargarDepositos(string cuenta)
        {
            //Obtener depositos
            var depositos = DataBase.ExecuteReader("select top 5 fec_deposito, id_deposito, importe " +
            "from NOLARECURSO.Deposito d " +
            "where d.nro_cuenta ='" + cuenta + "' " +
            "order by 2 desc");

            // Cargar los depositos a la grilla
            gridDeposito.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            Object[] columnas = new Object[3];

            foreach (DataRow row in depositos.Rows)
            {
                columnas[0] = row["id_deposito"];
                columnas[1] = row["importe"];
                columnas[2] = row["fec_deposito"];

                filas.Add(new DataGridViewRow());
                filas[filas.Count - 1].CreateCells(gridDeposito, columnas);
            }
            gridDeposito.Rows.AddRange(filas.ToArray());
        }

        private void cargarTransferencias(string cuenta)
        {
            //Obtener transferencias
            var transferencias = DataBase.ExecuteReader("select top 10 fecha, id_transferencia, cta_origen, cta_destino, " +
                "importe, costo from NOLARECURSO.Transferencia t where t.cta_origen = '" + cuenta +
                "' order by 2 desc");

            // Cargar las transferencias a la grilla
            gridTransferencias.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            Object[] columnas = new Object[6];

            foreach (DataRow row in transferencias.Rows)
            {
                columnas[0] = row["id_transferencia"];
                columnas[1] = row["cta_origen"];
                columnas[2] = row["cta_destino"];
                columnas[3] = row["importe"];
                columnas[4] = row["costo"];
                columnas[5] = row["fecha"];

                filas.Add(new DataGridViewRow());
                filas[filas.Count - 1].CreateCells(gridTransferencias, columnas);
            }
            gridTransferencias.Rows.AddRange(filas.ToArray());
        }

        private void gridDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
