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

namespace PagoElectronico.ABM_Rol
{
    public partial class frmCrearRol : Form
    {
        public static Funcionalidad funcionalidad;

        public static char operacion;

        public frmCrearRol()
        {
            InitializeComponent();
        }

        private void cargarEstado()
        {
            comboEstado.Items.Add("Activado");
            comboEstado.Items.Add("Descativado");
        }

        private void cargarFuncionalidades()
        {
            DataTable dbFuncionalidades = DataBase.ExecuteReader("Select * From NOLARECURSO.Funcionalidad");

            foreach (DataRow dr in dbFuncionalidades.Rows)
            {
                funcionalidad = new Funcionalidad();
                string idFunc = dr["id_func"].ToString();
                string desc = dr["descripcion"].ToString();
                listaFuncionalidades.Items.Add(new Funcionalidad(idFunc, desc));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCrearRol_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(334, 432);
            this.MinimumSize = new System.Drawing.Size(334, 432);
            cargarFuncionalidades();
            cargarEstado();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMRol nuevo = new frmABMRol();
            nuevo.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}
