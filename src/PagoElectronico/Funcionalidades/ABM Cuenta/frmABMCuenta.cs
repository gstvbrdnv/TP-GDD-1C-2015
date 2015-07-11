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
using PagoElectronico.ABM_Cuenta;
using PagoElectronico.Funcionalidades.ABM_Cuenta;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class frmABMCuenta : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;

        public frmABMCuenta()
        {
            InitializeComponent();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(659, 588);
            this.MinimumSize = new System.Drawing.Size(659, 588);
            this.ControlBox = false;
        }

        private void frmABMCuenta_Load(object sender, EventArgs e)
        {
            cargarCuentas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridCuentas.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridCuentas.SelectedRows[0];
                var transacciones = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetComisionesCuenta", SqlDataAccessArgs
                        .CreateWith("@ID_CUENTA", row.Cells["numCuenta"].Value.ToString())
                .Arguments);

                if (transacciones != null && transacciones.Rows != null)
                {
                    MessageBox.Show("Esta cuenta posee transacciones sin facturar, por favor procéselas para poder cerrar la cuenta.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    if (MessageBox.Show(string.Format("Confirma que desea cerrar la cuenta {0}?", row.Cells["numCuenta"].Value.ToString()),
                    "Cerrar cuenta", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                            "NOLARECURSO.CerrarCuenta", SqlDataAccessArgs
                            .CreateWith("@ID_Cuenta", row.Cells["numCuenta"].Value.ToString())
                        .Arguments);

                        cargarCuentas();
                        MessageBox.Show("La cuenta fue cerrada correctamente.");
                    }
                }
            }
            else MessageBox.Show("No seleccionó ninguna cuenta.");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtIdCliente.Text = "";
            gridCuentas.Rows.Clear();
        }

        private void cargarCuentas()
        {
            if ((sessionRol == "1") || (sessionRol == "3"))
            {
                var cuentas = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetCuentaInfoAll");

                // Cargar las cuentas a la grilla
                gridCuentas.Rows.Clear();
                List<DataGridViewRow> filas = new List<DataGridViewRow>();
                //Object[] columnas = new Object[4];
                Object[] columnas = new Object[3];

                foreach (DataRow row in cuentas.Rows)
                {
                    columnas[0] = row["nro_cuenta"];
                    columnas[1] = row["cliente"];
                    columnas[2] = row["estado"];

                    if (row["estado"].ToString() == "1")
                    {
                        columnas[2] = "Habilitada";
                    }
                    if (row["estado"].ToString() == "2")
                    {
                        columnas[2] = "Inhabilitada";
                    }
                    if (row["estado"].ToString() == "3")
                    {
                        columnas[2] = "Cerrada";
                    }
                    if (row["estado"].ToString() == "4")
                    {
                        columnas[2] = "Pendiente de activación";
                    }

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridCuentas, columnas);
                }

                gridCuentas.Rows.AddRange(filas.ToArray());
                lblResultado.Text = (gridCuentas.Rows.Count - 1).ToString() + " resultados.";
            }
            else
            {
                var Id_Cliente = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "NOLARECURSO.GetClienteUsuario", SqlDataAccessArgs
                    .CreateWith("@USERNAME", sessionUsername)
                .Arguments);

                var cuentas = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.GetCuentasCliente", SqlDataAccessArgs
                    .CreateWith("@ID_CLIENTE", Id_Cliente)
                .Arguments);

                // Cargar las cuentas a la grilla
                gridCuentas.Rows.Clear();
                List<DataGridViewRow> filas = new List<DataGridViewRow>();
                //Object[] columnas = new Object[4];
                Object[] columnas = new Object[3];

                foreach (DataRow row in cuentas.Rows)
                {
                    columnas[0] = row["nro_cuenta"];
                    columnas[1] = row["cliente"];
                    columnas[2] = row["estado"];

                    if (row["estado"].ToString() == "1")
                    {
                        columnas[2] = "Habilitada";
                    }
                    if (row["estado"].ToString() == "2")
                    {
                        columnas[2] = "Inhabilitada";
                    }
                    if (row["estado"].ToString() == "3")
                    {
                        columnas[2] = "Cerrada";
                    }
                    if (row["estado"].ToString() == "4")
                    {
                        columnas[2] = "Pendiente de activación";
                    }

                    filas.Add(new DataGridViewRow());
                    filas[filas.Count - 1].CreateCells(gridCuentas, columnas);
                }

                gridCuentas.Rows.AddRange(filas.ToArray());
                lblResultado.Text = (gridCuentas.Rows.Count - 1).ToString() + " resultados.";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAltaEditCuenta.operacion = 'A';
            this.Close();
            frmAltaEditCuenta newCuenta = new frmAltaEditCuenta();
            newCuenta.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (gridCuentas.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridCuentas.SelectedRows[0];
                if (row.Cells["colEstado"].Value.ToString() == "Cerrada")
                {
                    MessageBox.Show("No se puede modificar una cuenta cerrada.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmAltaEditCuenta.operacion = 'M';
                frmAltaEditCuenta.id_cuenta = row.Cells["numCuenta"].Value.ToString();
                this.Close();
                frmAltaEditCuenta newCuenta = new frmAltaEditCuenta();
                newCuenta.Show();
            }
            else MessageBox.Show("No seleccionó ninguna cuenta a modificar.");
        }


        private void validarDatos()
        {
            validador.esAlfabetico(txtNombre);
            validador.esAlfabetico(txtApellido);
            validador.esNumerico(txtIdCliente);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            if ((sessionRol == "1") || (sessionRol == "3"))
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string numeroCliente = txtIdCliente.Text;

                var cuentas = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.FiltroCuentas", SqlDataAccessArgs
                .CreateWith("@nombre", string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text)
                    .And("@apellido", string.IsNullOrEmpty(txtApellido.Text) ? null : txtApellido.Text)
                    .And("@num_cli", string.IsNullOrEmpty(txtIdCliente.Text) ? null : txtIdCliente.Text)
                    .And("@mail", string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text)
                .Arguments);

                if (cuentas != null && cuentas.Rows != null)
                {
                    // Cargar las cuentas a la grilla
                    gridCuentas.Rows.Clear();
                    List<DataGridViewRow> filas = new List<DataGridViewRow>();
                    //Object[] columnas = new Object[4];
                    Object[] columnas = new Object[3];

                    foreach (DataRow row in cuentas.Rows)
                    {
                        columnas[0] = row["nro_cuenta"];
                        columnas[1] = row["cliente"];
                        columnas[2] = row["descripcion"];
                        /*
                        if (row["estado"].ToString() == "1")
                        {
                            columnas[2] = "Habilitada";
                        }
                        if (row["estado"].ToString() == "2")
                        {
                            columnas[2] = "Inhabilitada";
                        }
                        if (row["estado"].ToString() == "3")
                        {
                            columnas[2] = "Cerrada";
                        }
                        if (row["estado"].ToString() == "4")
                        {
                            columnas[2] = "Pendiente de activación";
                        }
                        */
                        filas.Add(new DataGridViewRow());
                        filas[filas.Count - 1].CreateCells(gridCuentas, columnas);
                    }

                    gridCuentas.Rows.AddRange(filas.ToArray());
                    lblResultado.Text = (gridCuentas.Rows.Count - 1).ToString() + " resultados.";
                }
                else
                {
                    MessageBox.Show("No se encontraron cuentas.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                var cuentas = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "NOLARECURSO.FiltroCuentasUsuario", SqlDataAccessArgs
                .CreateWith("@nombre", string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text)
                    .And("@apellido", string.IsNullOrEmpty(txtApellido.Text) ? null : txtApellido.Text)
                    .And("@num_cli", string.IsNullOrEmpty(txtIdCliente.Text) ? null : txtIdCliente.Text)
                    .And("@mail", string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text)
                    .And("@username", sessionUsername)
                .Arguments);

                if (cuentas != null && cuentas.Rows != null)
                {
                    // Cargar las cuentas a la grilla
                    gridCuentas.Rows.Clear();
                    List<DataGridViewRow> filas = new List<DataGridViewRow>();
                    //Object[] columnas = new Object[4];
                    Object[] columnas = new Object[3];

                    foreach (DataRow row in cuentas.Rows)
                    {
                        columnas[0] = row["nro_cuenta"];
                        columnas[1] = row["cliente"];
                        columnas[2] = row["descripcion"];
                        /*
                        if (row["estado"].ToString() == "1")
                        {
                            columnas[2] = "Habilitada";
                        }
                        if (row["estado"].ToString() == "2")
                        {
                            columnas[2] = "Inhabilitada";
                        }
                        if (row["estado"].ToString() == "3")
                        {
                            columnas[2] = "Cerrada";
                        }
                        if (row["estado"].ToString() == "4")
                        {
                            columnas[2] = "Pendiente de activación";
                        }
                        */
                        filas.Add(new DataGridViewRow());
                        filas[filas.Count - 1].CreateCells(gridCuentas, columnas);
                    }

                    gridCuentas.Rows.AddRange(filas.ToArray());
                    lblResultado.Text = (gridCuentas.Rows.Count - 1).ToString() + " resultados.";
                }
                else
                {
                        MessageBox.Show("No se encontraron cuentas.",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }

        }
    }
}
