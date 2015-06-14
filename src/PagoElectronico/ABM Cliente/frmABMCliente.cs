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

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmABMCliente : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        public static Cliente cliente;
        int idCliente;
        Validador validador1 = Validador.Instance;
        Validador validador2 = Validador.Instance;

        public frmABMCliente()
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

        private void cargarClientes()
        {
            //Obtener clientes
            idCliente = DataBase.ExecuteCardinal("Select id_cli from NOLARECURSO.Usuario");
            //MessageBox.Show(idCliente.ToString());
            var clientes = DataBase.ExecuteReader("Select id_cli from NOLARECURSO.Cliente ");
            var documentos = DataBase.ExecuteReader("Select descripcion from NOLARECURSO.Tipo_documento");

            // Carga todas las cuentas del cliente
            foreach (DataRow dataRow in clientes.Rows)
            {
                cliente = new Cliente();
                cliente.nombre = dataRow["id_cli"].ToString();
                cliente.apellido = dataRow["id_cli"].ToString();
                comboTipo.Items.Add(documentos);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblNombre.Text = "Nombre: ";
            lblApellido.Text = "Apellido: ";
            lblEmail.Text = "Email: ";
            lblTipo.Text = "Tipo Identificacion: ";
            lblNroId.Text = "Nro. Identificacion";
            gridCliente.Rows.Clear();
        }
       
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            cargarClientes();
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
    }
}
