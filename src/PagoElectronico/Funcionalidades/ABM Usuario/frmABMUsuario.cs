using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class frmABMUsuario : Form
    {
        public frmABMUsuario()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 228);
            this.MinimumSize = new System.Drawing.Size(300, 228);
            this.ControlBox = false;
        }

        private void frmABMUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
