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
        int idCliente;

        public frmABMCliente()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 498);
            this.MinimumSize = new System.Drawing.Size(557, 498);
            this.ControlBox = false;
        }

        private void cargarClientes()
        {
            //Obtener clientes
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario");
            //MessageBox.Show(idCliente.ToString());
            var clientes = DataBase.ExecuteReader("Select * from NOLARECURSO.Cliente");
            var documentos = DataBase.ExecuteReader("Select descripcion from NOLARECURSO.Tipo_documento");

            // Carga todos los clientes
            foreach (DataRow dataRow in clientes.Rows)
            {
                cliente = new Cliente();
                cliente.nombre = dataRow["id_cli"].ToString();
                cliente.apellido = dataRow["id_cli"].ToString();
                //comboTipo.Items.Add(documentos);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            cargarClientes(idCliente);
        }
        private void cargarClientes(int idCliente)
        {
            //Obtener retiros en efectivo
            var clientes = DataBase.ExecuteReader("select nombre, apellido, email" + "from NOLARECURSO.cliente" +
            "where nombre = '" + txtNombre + "' and apellido = '" + txtApellido + "and email = '" + txtEmail +
            "order by 2 asc");

            // Cargar los clientes a la grilla
            gridCliente.Rows.Clear();
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            Object[] columnas = new Object[4];

            foreach (DataRow row in clientes.Rows)
            {
                columnas[0] = row["nombre"];
                columnas[1] = row["apellido"];
                columnas[2] = row["email"];

                filas.Add(new DataGridViewRow());
                filas[filas.Count - 1].CreateCells(gridCliente, columnas);
            }
            gridCliente.Rows.AddRange(filas.ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gridCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtApellido_Click(object sender, EventArgs e)
        {

        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCrearCliente newCliente = new frmCrearCliente();
            newCliente.Show();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
