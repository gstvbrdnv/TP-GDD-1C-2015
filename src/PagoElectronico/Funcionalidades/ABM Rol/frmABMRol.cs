using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelos;
using PagoElectronico.Core;
using System.Collections;

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
