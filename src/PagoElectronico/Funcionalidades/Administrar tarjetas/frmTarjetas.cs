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

namespace PagoElectronico.Tarjetas
{
    public partial class frmTarjetas : Form
    {
        public frmTarjetas()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTarjetas_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(264, 262);
            this.MinimumSize = new System.Drawing.Size(264, 262);
            this.ControlBox = false;
        }

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAsociar asociarTarjeta = new frmAsociar();
            asociarTarjeta.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmModificar modificarTarjeta = new frmModificar();
            modificarTarjeta.Show();
        }

        private void btnDesasociar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDesasociar desasociarTarjeta = new frmDesasociar();
            desasociarTarjeta.Show();
        }
    }
}
