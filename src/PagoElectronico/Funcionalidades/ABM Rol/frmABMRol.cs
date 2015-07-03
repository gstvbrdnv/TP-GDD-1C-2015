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
    public partial class frmABMRol : Form
    {
        public static string sessionUsername;
        public static string sessionRol;
        Validador validador = Validador.Instance;

        //[PermissionRequired(Functionalities.AdministrarRoles)]
        public frmABMRol()
        {
            InitializeComponent();
            frmMain main = new frmMain();
            sessionUsername = frmMain.sessionUsername;
            sessionRol = frmMain.sessionRol;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(526, 407);
            this.MinimumSize = new System.Drawing.Size(526, 407);
        }

        private void cargarRoles()
        {
            dGrid_Roles.Rows.Clear();
            DataTable listadoRoles = DataBase.ExecuteReader("Select * From NOLARECURSO.Rol");

            Object[] columnas = new Object[4];

            foreach (DataRow dr in listadoRoles.Rows)
            {
                columnas[0] = dr["id_rol"].ToString();
                columnas[1] = dr["descripcion"].ToString();
                columnas[2] = dr["estado"].ToString();// == "True") ? true : false;

                dGrid_Roles.Rows.Add(columnas[0], columnas[1], columnas[2]);
            }
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        
{

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RolesForm_Load_1(object sender, EventArgs e)
        {
            cargarRoles();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCrearRol.operacion = 'A';
            this.Hide();
            frmCrearRol newRol = new frmCrearRol();
            newRol.Show();
        }
    }
}
