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
            this.MaximumSize = new System.Drawing.Size(557, 576);
            this.MinimumSize = new System.Drawing.Size(557, 576);
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
            frmCrearCliente.operacion = 'M';
            this.Hide();
            frmCrearCliente newCliente = new frmCrearCliente();
            newCliente.Show();

        }

        private void cargarClientes()
        {

            //var clientes = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Cliente");
            DataTable clientes = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Cliente");

            // Cargar los clientes a la grilla
            gridCliente.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            //Object[] columnas = new Object[4];
            Object[] columnas = new Object[3];

            foreach (DataRow row in clientes.Rows)
            {
                //columnas[0] = row["id_cli"];
                //columnas[1] = row["nombre"];
                //columnas[2] = row["apellido"];
                //columnas[2] = row["estado"];
                
                columnas[0] = row["id_cli"];
                columnas[1] = row["nombre"];
                columnas[2] = row["apellido"];

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

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
