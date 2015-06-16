using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico;
using PagoElectronico.ABM_de_Usuario;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.ABM_Cuenta;
using PagoElectronico.ABM_Rol;
using PagoElectronico.Consulta_Saldos;
using PagoElectronico.DB;
using PagoElectronico.Depositos;
using PagoElectronico.Facturacion;
using PagoElectronico.Listados;
using PagoElectronico.Login;
using PagoElectronico.Retiros;
using PagoElectronico.Transferencias;
using PagoElectronico.Modelos;
using PagoElectronico.Tarjetas;

namespace PagoElectronico
{
    public partial class frmMain : Form
    {
        public static string sessionUsername;
        public static string sessionRol;

        public frmMain()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(391, 387);
            this.MinimumSize = new System.Drawing.Size(391, 387);
            this.ControlBox = false;
            frmLogin login = new frmLogin();
            sessionUsername = frmLogin.loginUsername;
            sessionRol = frmLogin.rolElegido;
            menuAdmin.Visible = false;
            menuCliente.Visible = false;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           //MessageBox.Show("Usuario: " + sessionUsername + ", Rol: " + sessionRol);          
            if (sessionRol == "1")
            {
                menuAdmin.Visible = true;
                menuCliente.Visible = true;
            }
            else
            {
                menuCliente.Visible = true;
                menuAdmin.Visible = false;
            }
        }

        private void consultarSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmConsultaSaldo()).Show();
        }

        private void aBMClienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            (new frmABMCliente()).Show();
        }

        private void aBMCuentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new frmABMCuenta()).Show();
        }

        private void aBMRolToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            (new AgregarRolForm()).Show();
        }

        private void facturaciónDeCostosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new frmFacturacion()).Show();
        }

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmEstadisticas()).Show();
        }

        private void aBMCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmABMCuenta()).Show();
        }

        private void asociarModificarODesaociarUnaTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmTarjetas()).Show();
        }

        private void realizarDepósitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmDeposito()).Show();
        }

        private void realizarUnaExtracciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmRetiros()).Show();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmTransferencia()).Show();
        }

        private void facturaciónDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmFacturacion()).Show();
        }

        private void consultarSaldoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new frmConsultaSaldo()).Show();
        }

        private void aBMUsuarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            (new frmABMUsuario()).Show();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea finalizar la sesión?",
                "Confirmar cierre de sesión", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmLogin newLogin = new frmLogin();
                newLogin.Show();
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "frmLogin")
                        Application.OpenForms[i].Close();
                }
                sessionUsername = "";
                sessionRol = "";
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
    }
}
