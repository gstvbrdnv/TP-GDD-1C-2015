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
using PagoElectronico.Funcionalidades.Facturacion;

namespace PagoElectronico.Facturacion
{
    public partial class frmFacturacion : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;
        Validador validadorAbono = Validador.Instance;

        public frmFacturacion()
        {
            InitializeComponent();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(819, 442);
            this.MinimumSize = new System.Drawing.Size(819, 442);
            this.ControlBox = false;
        }

        private void cargarClientes()
        {
            var clientes = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Cliente ORDER BY id_cli ASC");

            foreach (DataRow dataRow in clientes.Rows)
            {
                string idCliente = dataRow["id_cli"].ToString();
                string nombre = dataRow["nombre"].ToString();
                string apellido = dataRow["apellido"].ToString();
                //string desc = dataRow["nombre"].ToString() + " " + dataRow["apellido"].ToString();
                comboCliente.Items.Add(new Cliente(idCliente, nombre, apellido));
            }
        }

        private void validarDatos()
        {
            validador.hayUnoSeleccionado("Cliente", comboCliente);
        }

        private void cargarTransCliente()
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            string idCliente = ((Cliente)comboCliente.SelectedItem).IDCliente;

            var transacciones = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetComisionesSinFacturar", SqlDataAccessArgs
                        .CreateWith("@ID_CLIENTE", idCliente)
                .Arguments);

            if (transacciones != null && transacciones.Rows != null)
            {
                gridTransacciones.Rows.Clear();
                List<DataGridViewRow> filas = new List<DataGridViewRow>();

                Object[] columnas = new Object[6];

                foreach (DataRow row in transacciones.Rows)
                {
                    columnas[0] = row["id_cliente"];
                    columnas[1] = row["cliente"];
                    columnas[2] = row["id_cuenta"];
                    columnas[3] = row["id_transaccion"];
                    columnas[4] = row["descripcion"];
                    columnas[5] = row["importe"];

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridTransacciones, columnas);
                }

                gridTransacciones.Rows.AddRange(filas.ToArray());
            }
            else
            {
                gridTransacciones.Rows.Clear();
                MessageBox.Show("No hay transacciones pendientes de facturar para el cliente.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargarTransCliente();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            cargarClientes();

            if ((sessionRol == "1") || (sessionRol == "3"))
            {
                comboCliente.Enabled = true;
                btnCargar.Enabled = true;
                btnCargarMias.Enabled = false;
            }
            else
            {
                comboCliente.Enabled = false;
                btnCargar.Enabled = false;
                btnCargarMias.Enabled = true;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (gridTransacciones.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridTransacciones.SelectedRows[0];
                string idCliente = row.Cells["numCliente"].Value.ToString();

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.FacturarTransacciones", SqlDataAccessArgs
                    .CreateWith("@ID_CLIENTE", idCliente)
                .Arguments);

                MessageBox.Show("Todas las transacciones han sido facturadas correctamente.");
                gridTransacciones.Rows.Clear();
            }
            else MessageBox.Show("No hay transacciones para facturar.");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cargarMias()
        {
            var Id_Cliente = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetClienteUsuario", SqlDataAccessArgs
                .CreateWith("@USERNAME", sessionUsername)
            .Arguments);

            var transacciones = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetComisionesSinFacturar", SqlDataAccessArgs
                        .CreateWith("@ID_CLIENTE", Id_Cliente)
                .Arguments);

            if (transacciones != null && transacciones.Rows != null)
            {
                gridTransacciones.Rows.Clear();
                List<DataGridViewRow> filas = new List<DataGridViewRow>();

                Object[] columnas = new Object[6];

                foreach (DataRow row in transacciones.Rows)
                {
                    columnas[0] = row["id_cliente"];
                    columnas[1] = row["cliente"];
                    columnas[2] = row["id_cuenta"];
                    columnas[3] = row["id_transaccion"];
                    columnas[4] = row["descripcion"];
                    columnas[5] = row["importe"];

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridTransacciones, columnas);
                }

                gridTransacciones.Rows.AddRange(filas.ToArray());
            }
            else
            {
                gridTransacciones.Rows.Clear();
                MessageBox.Show("No hay transacciones pendientes de facturar para el cliente.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCargarMias_Click(object sender, EventArgs e)
        {
            cargarMias();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gridTransacciones.Rows.Clear();
        }

        private void validarDatosAbono()
        {
            validadorAbono.estaVacioOEsNulo(txtCantSuscr);
            validadorAbono.esNumerico(txtCantSuscr);
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            this.validarDatosAbono();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            if (gridTransacciones.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridTransacciones.SelectedRows[0];

                var tipoCuenta = DataBase.ExecuteCardinal("SELECT id_tipo_cta from NOLARECURSO.Cuenta WHERE nro_cuenta = '" +
                    row.Cells["numCuenta"].Value.ToString() + "'");

                if (tipoCuenta == 4)
                {
                    MessageBox.Show("La cuenta seleccionada es de tipo gratuita.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.FacturarTransaccion", SqlDataAccessArgs
                            .CreateWith("@ID_TRANSACCION", row.Cells["colTransaccion"].Value.ToString())
                    .Arguments);

                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.AbonarSuscripcion", SqlDataAccessArgs
                            .CreateWith("@ID_CUENTA", row.Cells["numCuenta"].Value.ToString())
                            .And("@CANTIDAD_ABONOS", txtCantSuscr.Text)
                    .Arguments);

                    MessageBox.Show("Las suscripciones fueron abonadas correctamente.");

                    if ((sessionRol == "1") || (sessionRol == "3"))
                    {
                        cargarTransCliente();
                    }
                    else
                    {
                        cargarMias();
                    }
                }
            }
            else MessageBox.Show("No se seleccionó ninguna cuenta.");
        }
    }
}
