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
using PagoElectronico.Funcionalidades.ABM_Cuenta;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class frmABMCuenta : Form
    {
        public frmABMCuenta()
        {
            InitializeComponent();
        }

        private void frmABMCuenta_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

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
            txtIdCuenta.Text = "";
            gridCuentas.Rows.Clear();
        }

        private void cargarClientes()
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

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAltaEditCuenta.operacion = 'A';
            this.Hide();
            frmAltaEditCuenta newCuenta = new frmAltaEditCuenta();
            newCuenta.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (gridCuentas.SelectedRows.Count != 0)
            {
                frmAltaEditCuenta.operacion = 'M';
                DataGridViewRow row = this.gridCuentas.SelectedRows[0];
                frmAltaEditCuenta.id_cuenta = row.Cells["numCuenta"].Value.ToString();
                this.Hide();
                frmAltaEditCuenta newCuenta = new frmAltaEditCuenta();
                newCuenta.Show();
            }
            else MessageBox.Show("No seleccionó ninguna cuenta a modificar.");
        }
    }
}
