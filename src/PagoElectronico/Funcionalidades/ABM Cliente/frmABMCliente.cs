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
using PagoElectronico.Funcionalidades.ABM_Cliente;

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmABMCliente : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        public static Cliente cliente;

        public frmABMCliente()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(658, 576);
            this.MinimumSize = new System.Drawing.Size(658, 576);
            this.ControlBox = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCrearCliente.operacion = 'A';
            this.Hide();
            frmCrearCliente newCliente = new frmCrearCliente();
            newCliente.Show();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtNroId.Text = "";
            gridCliente.Rows.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (gridCliente.SelectedRows.Count != 0)
            {
                frmCrearCliente.operacion = 'M';
                DataGridViewRow row = this.gridCliente.SelectedRows[0];
                frmCrearCliente.cli_id = row.Cells["numCliente"].Value.ToString();
                this.Hide();
                frmCrearCliente newCliente = new frmCrearCliente();
                newCliente.Show();
            }
            else MessageBox.Show("No seleccionó ningun rol a modificar.");

        }

        private void cargarClientes()
        {

            //var clientes = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Cliente");
            DataTable clientes = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Cliente");

            // Cargar los clientes a la grilla
            gridCliente.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            //Object[] columnas = new Object[4];
            Object[] columnas = new Object[4];

            foreach (DataRow row in clientes.Rows)
            {
                //columnas[0] = row["id_cli"];
                //columnas[1] = row["nombre"];
                //columnas[2] = row["apellido"];
                //columnas[2] = row["estado"];
                
                columnas[0] = row["id_cli"];
                columnas[1] = row["nombre"];
                columnas[2] = row["apellido"];
                if (row["estado"].ToString() == "True")
                {
                    columnas[3] = "Activado";
                }
                else columnas[3] = "Desactivado";

                filas.Add(new DataGridViewRow());
                filas[filas.Count - 1].CreateCells(gridCliente, columnas);
            }

            gridCliente.Rows.AddRange(filas.ToArray());

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            cargarClientes();
        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridCliente.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridCliente.SelectedRows[0];
                if (MessageBox.Show(string.Format("Confirma que desea eliminar el ciente {0}?", row.Cells["numCliente"].Value.ToString()),
                "Eliminar cliente", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (row.Cells["numCliente"].Value.ToString() == "1")
                    {
                        MessageBox.Show("No se puede borrar el cliente debido a una regla de negocio",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.BorrarCliente", SqlDataAccessArgs
                        .CreateWith("@ID_Cli", row.Cells["numCliente"].Value.ToString())
                    .Arguments);

                    cargarClientes();
                    MessageBox.Show("El cliente fue dado de baja correctamente.");
                }
            }
            else MessageBox.Show("No seleccionó ningun cliente a modificar.");
        }
    }
}
