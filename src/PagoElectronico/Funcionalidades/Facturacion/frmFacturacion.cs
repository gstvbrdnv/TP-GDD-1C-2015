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

namespace PagoElectronico.Facturacion
{
    public partial class frmFacturacion : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;

        public frmFacturacion()
        {
            InitializeComponent();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(819, 708);
            this.MinimumSize = new System.Drawing.Size(819, 708);
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

        private void btnCargar_Click(object sender, EventArgs e)
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
                    columnas[2] = row["id_transaccion"];
                    columnas[3] = row["id_cuenta"];
                    columnas[4] = row["descripcion"];
                    columnas[5] = row["importe"];

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridTransacciones, columnas);
                }

                gridTransacciones.Rows.AddRange(filas.ToArray());
            }
            else
            {
                MessageBox.Show("No hay transacciones pendientes de facturar para el cliente.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void btnCargarMias_Click(object sender, EventArgs e)
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
                    columnas[2] = row["id_transaccion"];
                    columnas[3] = row["id_cuenta"];
                    columnas[4] = row["descripcion"];
                    columnas[5] = row["importe"];

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridTransacciones, columnas);
                }

                gridTransacciones.Rows.AddRange(filas.ToArray());
            }
            else
            {
                MessageBox.Show("No hay transacciones pendientes de facturar para el cliente.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gridFacturas.Rows.Clear();
            gridTransacciones.Rows.Clear();
        }
    }
}
