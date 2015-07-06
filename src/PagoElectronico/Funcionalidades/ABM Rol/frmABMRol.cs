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
using PagoElectronico.Data;
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
                if (dr["estado"].ToString() == "True")
                {
                    columnas[2] = "Activado";
                }
                else columnas[2] = "Desactivado";

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dGrid_Roles.SelectedRows.Count != 0)
            {
                frmCrearRol.operacion = 'M';
                DataGridViewRow row = this.dGrid_Roles.SelectedRows[0];
                if (row.Cells["ColNombre"].Value.ToString() == "Administrador general")
                {
                    MessageBox.Show("No se puede editar el rol Administrador general debido a una regla de negocio",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmCrearRol.rol_Id_u = row.Cells["id_rol"].Value.ToString();
                frmCrearRol.rol_desc = row.Cells["ColNombre"].Value.ToString();
                frmCrearRol.rol_estado = row.Cells["ColEstado"].Value.ToString();
                this.Hide();
                frmCrearRol newRol = new frmCrearRol();
                newRol.Show();
            }
            else MessageBox.Show("No seleccionó ningun rol a modificar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dGrid_Roles.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dGrid_Roles.SelectedRows[0];
                if (MessageBox.Show(string.Format("Confirma que desea eliminar el rol {0}?", row.Cells["ColNombre"].Value.ToString()),
                "Eliminar rol", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (row.Cells["ColNombre"].Value.ToString() == "Administrador general")
                    {
                        MessageBox.Show("No se puede borrar el rol Administrador general debido a una regla de negocio",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.BorrarRol", SqlDataAccessArgs
                        .CreateWith("@Rol_ID", row.Cells["id_rol"].Value.ToString())
                    .Arguments);

                    cargarRoles();
                    MessageBox.Show("El rol fue dado de baja correctamente.");
                }
            }
            else MessageBox.Show("No seleccionó ningun rol a modificar.");
        }
    }
}
