using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Rol
{
    public partial class frmCrearRol : Form
    {
        public static char operacion;

        public frmCrearRol()
        {
            InitializeComponent();
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
    }
}
