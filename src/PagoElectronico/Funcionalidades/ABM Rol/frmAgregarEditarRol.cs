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
    public partial class frmCrearRol : Form
    {
        private Rol _rol = new Rol();
        public static Funcionalidad funcionalidad;
        Validador validador = Validador.Instance;
        public static string rol_Id_u;
        public static string rol_desc;
        public static string rol_estado;

        public static char operacion;

        public frmCrearRol()
        {
            InitializeComponent();
        }

        private void cargarEstado()
        {
            comboEstado.Items.Add("Activado");
            comboEstado.Items.Add("Desactivado");
        }

        private void validarDatos()
        {
            validador.estaVacioOEsNulo(txtNombre);
            validador.esAlfabetico(txtNombre);
            validador.hayUnoSeleccionado("Estado", comboEstado);
            validador.hayCheckBoxSeleccionado("Funcionalidades", listaFuncionalidades);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            if (operacion == 'A')
            {
                _rol.Funcionalidades = new List<String>();
                foreach (Funcionalidad item in listaFuncionalidades.CheckedItems)
                {
                    _rol.Funcionalidades.Add(item.IDFunc);
                }
                _rol.descripcion = txtNombre.Text;
                if (comboEstado.SelectedItem.ToString() == "Activado")
                { _rol.estado = "1"; }
                else { _rol.estado = "0"; }

                var rol_Id = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.InsertarRol", SqlDataAccessArgs
                    .CreateWith("@Descripcion", _rol.descripcion)
                           .And("@Estado", _rol.estado)
                .Arguments);

                foreach (String item in _rol.Funcionalidades)
                {
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.InsertarRolFuncionalidad", SqlDataAccessArgs
                        .CreateWith("@Rol_ID", rol_Id)
                               .And("@Funcionalidad_ID", item)
                    .Arguments);
                }

                MessageBox.Show("Rol creado correctamente.");

                this.Close();
            }
            else
            {
                _rol.Funcionalidades = new List<String>();
                foreach (Funcionalidad item in listaFuncionalidades.CheckedItems)
                {
                    _rol.Funcionalidades.Add(item.IDFunc);
                }
                
                _rol.descripcion = txtNombre.Text;

                if (comboEstado.SelectedItem.ToString() == "Activado")
                { _rol.estado = "1"; } else { _rol.estado = "0"; }

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.ActualizarRol", SqlDataAccessArgs
                    .CreateWith("@ID_Rol", rol_Id_u)
                           .And("@Descripcion", _rol.descripcion)
                           .And("@Estado", _rol.estado)
                .Arguments);

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.BorrarRolFuncionalidad", SqlDataAccessArgs
                    .CreateWith("@Rol_ID", rol_Id_u)
                .Arguments);

                foreach (String item in _rol.Funcionalidades)
                {
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "NOLARECURSO.InsertarRolFuncionalidad", SqlDataAccessArgs
                        .CreateWith("@Rol_ID", rol_Id_u)
                               .And("@Funcionalidad_ID", item)
                    .Arguments);
                }

                MessageBox.Show("Rol actualizado correctamente.");

                this.Close();
            }
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
            this.MaximumSize = new System.Drawing.Size(334, 488);
            this.MinimumSize = new System.Drawing.Size(334, 488);
            cargarFuncionalidades();
            cargarEstado();
            if (operacion == 'M')
            {
                txtNombre.Text = rol_desc;
                comboEstado.SelectedItem = rol_estado;
                if (rol_estado == "Activado")
                { comboEstado.SelectedIndex = 0; }
                else { comboEstado.SelectedIndex = 1; }

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetRolFuncionalidades", SqlDataAccessArgs
                    .CreateWith("@ID_Rol", rol_Id_u).Arguments);

                //Devuelve todos los roles que estan activos
                List<int> funcionalidades = new List<int>();

                if (resultado != null && resultado.Rows != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        //MessageBox.Show(row["id_func"].ToString());
                        int funcionalidad = Convert.ToInt32(row["id_func"].ToString());
                        //MessageBox.Show(funcionalidad.ToString());
                        funcionalidades.Add(funcionalidad);
                    }
                }
                
                for (int i = 0; i < listaFuncionalidades.Items.Count; i++)
                {   
                    if (funcionalidades.Contains(i+1))
                        listaFuncionalidades.SetItemChecked(i, true);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            for (int i = 0; i < listaFuncionalidades.Items.Count; i++)
            {
                listaFuncionalidades.SetItemChecked(i, false);
            }
            comboEstado.SelectedIndex = -1;
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaFuncionalidades.Items.Count; i++)
            {
                listaFuncionalidades.SetItemChecked(i, true);
            }
        }
    }
}
