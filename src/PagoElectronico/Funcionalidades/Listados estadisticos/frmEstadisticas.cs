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

namespace PagoElectronico.Listados
{
    public partial class frmEstadisticas : Form
    {
        Validador validador = Validador.Instance;
        public static string numTrimestre;
        public static string numAnio;

        public frmEstadisticas()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(631, 363);
            this.MinimumSize = new System.Drawing.Size(631, 363);
            this.ControlBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            cargarTrimestres();
            cargarNombresReportes();
        }

        private void cargarTrimestres()
        {
            comboTrimestre.Items.Insert(0, "Primer trimestre");
            comboTrimestre.Items.Insert(1, "Segundo trimestre");
            comboTrimestre.Items.Insert(2, "Tercer trimestre");
            comboTrimestre.Items.Insert(3, "Cuarto trimestre");
        }

        private void cargarNombresReportes()
        {
            comboReporte.Items.Insert(0, "Clientes con cuenta inhabilitada");
            comboReporte.Items.Insert(1, "Clientes más facturadores");
            comboReporte.Items.Insert(2, "Clientes transferencias propias");
            comboReporte.Items.Insert(3, "Paises con más movimientos");
            comboReporte.Items.Insert(4, "Facturación por tipo de cuenta");
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.hayUnoSeleccionado("Trimestre", comboTrimestre);
            validador.hayUnoSeleccionado("Listado", comboReporte);
            validador.esNumerico(txtYear);
            validador.esAnioValido(txtYear);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            numAnio = txtYear.Text;

            // Trimestre
            if (comboTrimestre.SelectedItem.ToString() == "Primer trimestre")
            {
                numTrimestre = "1";
            }
            if (comboTrimestre.SelectedItem.ToString() == "Segundo trimestre")
            {
                numTrimestre = "2";
            }
            if (comboTrimestre.SelectedItem.ToString() == "Tercer trimestre")
            {
                numTrimestre = "3";
            }
            if (comboTrimestre.SelectedItem.ToString() == "Cuarto trimestre")
            {
                numTrimestre = "4";
            }
            
            // Reporte
            if (comboReporte.SelectedItem.ToString() == "Clientes con cuenta inhabilitada")
            {
                datagridTOP5.Rows.Clear();

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetTopClientesMorosos", SqlDataAccessArgs
                    .CreateWith("@nroTrimestre", numTrimestre)
                    .And("@anioTrimestre", numAnio)
                .Arguments);

                datagridTOP5.Columns[0].HeaderText = "Ranking";
                datagridTOP5.Columns[0].Width = 75;
                datagridTOP5.Columns[1].HeaderText = "Cliente";
                datagridTOP5.Columns[1].Width = 150;
                datagridTOP5.Columns[2].HeaderText = "Cant. inhabilitaciones";
                datagridTOP5.Columns[2].Width = 200;
                datagridTOP5.Columns[0].Visible = true;
                datagridTOP5.Columns[1].Visible = true;
                datagridTOP5.Columns[2].Visible = true;
                datagridTOP5.Columns[3].Visible = false;
                datagridTOP5.Columns[4].Visible = false;


                if (resultado != null && resultado.Rows != null)
                {
                    Object[] columnas = new Object[3];
                    int ranking = 1;

                    foreach (DataRow dr in resultado.Rows)
                    {

                        columnas[0] = ranking.ToString();
                        columnas[1] = dr["cliente"].ToString();
                        columnas[2] = dr["cantidad"].ToString();

                        datagridTOP5.Rows.Add(columnas[0], columnas[1], columnas[2]);
                        ranking = ranking + 1;
                    }
                }
            }

            if (comboReporte.SelectedItem.ToString() == "Clientes más facturadores")
            {
                datagridTOP5.Rows.Clear();

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetTopClientesMayorFacturacion", SqlDataAccessArgs
                    .CreateWith("@nroTrimestre", numTrimestre)
                    .And("@anioTrimestre", numAnio)
                .Arguments);

                datagridTOP5.Columns[0].HeaderText = "Ranking";
                datagridTOP5.Columns[0].Width = 75;
                datagridTOP5.Columns[1].HeaderText = "Cliente";
                datagridTOP5.Columns[1].Width = 150;
                datagridTOP5.Columns[2].HeaderText = "Cant. comisiones facturadas";
                datagridTOP5.Columns[2].Width = 250;
                datagridTOP5.Columns[0].Visible = true;
                datagridTOP5.Columns[1].Visible = true;
                datagridTOP5.Columns[2].Visible = true;
                datagridTOP5.Columns[3].Visible = false;
                datagridTOP5.Columns[4].Visible = false;


                if (resultado != null && resultado.Rows != null)
                {
                    Object[] columnas = new Object[3];
                    int ranking = 1;

                    foreach (DataRow dr in resultado.Rows)
                    {

                        columnas[0] = ranking.ToString();
                        columnas[1] = dr["cliente"].ToString();
                        columnas[2] = dr["cant_comisiones"].ToString();

                        datagridTOP5.Rows.Add(columnas[0], columnas[1], columnas[2]);
                        ranking = ranking + 1;
                    }
                }
            }

            if (comboReporte.SelectedItem.ToString() == "Clientes transferencias propias")
            {
                datagridTOP5.Rows.Clear();

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetTopClientesTransferenciasPropias", SqlDataAccessArgs
                    .CreateWith("@nroTrimestre", numTrimestre)
                    .And("@anioTrimestre", numAnio)
                .Arguments);

                datagridTOP5.Columns[0].HeaderText = "Ranking";
                datagridTOP5.Columns[0].Width = 75;
                datagridTOP5.Columns[1].HeaderText = "Cliente";
                datagridTOP5.Columns[1].Width = 150;
                datagridTOP5.Columns[2].HeaderText = "Cant. transf. propias";
                datagridTOP5.Columns[2].Width = 250;
                datagridTOP5.Columns[0].Visible = true;
                datagridTOP5.Columns[1].Visible = true;
                datagridTOP5.Columns[2].Visible = true;
                datagridTOP5.Columns[3].Visible = false;
                datagridTOP5.Columns[4].Visible = false;


                if (resultado != null && resultado.Rows != null)
                {
                    Object[] columnas = new Object[3];
                    int ranking = 1;

                    foreach (DataRow dr in resultado.Rows)
                    {

                        columnas[0] = ranking.ToString();
                        columnas[1] = dr["cliente"].ToString();
                        columnas[2] = dr["cantidad"].ToString();

                        datagridTOP5.Rows.Add(columnas[0], columnas[1], columnas[2]);
                        ranking = ranking + 1;
                    }
                }
            }

            if (comboReporte.SelectedItem.ToString() == "Paises con más movimientos")
            {
                datagridTOP5.Rows.Clear();

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetTopPaisMovimientos", SqlDataAccessArgs
                    .CreateWith("@nroTrimestre", numTrimestre)
                    .And("@anioTrimestre", numAnio)
                .Arguments);

                datagridTOP5.Columns[0].HeaderText = "Ranking";
                datagridTOP5.Columns[0].Width = 75;
                datagridTOP5.Columns[1].HeaderText = "Pais";
                datagridTOP5.Columns[1].Width = 100;
                datagridTOP5.Columns[2].HeaderText = "Cant. movimientos";
                datagridTOP5.Columns[2].Width = 200;
                datagridTOP5.Columns[0].Visible = true;
                datagridTOP5.Columns[1].Visible = true;
                datagridTOP5.Columns[2].Visible = true;
                datagridTOP5.Columns[3].Visible = false;
                datagridTOP5.Columns[4].Visible = false;


                if (resultado != null && resultado.Rows != null)
                {
                    Object[] columnas = new Object[3];
                    int ranking = 1;

                    foreach (DataRow dr in resultado.Rows)
                    {

                        columnas[0] = ranking.ToString();
                        columnas[1] = dr["descripcion"].ToString();
                        columnas[2] = dr["cant_movimientos"].ToString();

                        datagridTOP5.Rows.Add(columnas[0], columnas[1], columnas[2]);
                        ranking = ranking + 1;
                    }
                }
            }

            if (comboReporte.SelectedItem.ToString() == "Facturación por tipo de cuenta")
            {
                datagridTOP5.Rows.Clear();

                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "NOLARECURSO.GetTopFacturacionTipoCuentas", SqlDataAccessArgs
                    .CreateWith("@nroTrimestre", numTrimestre)
                    .And("@anioTrimestre", numAnio)
                .Arguments);

                datagridTOP5.Columns[0].HeaderText = "Ranking";
                datagridTOP5.Columns[0].Width = 75;
                datagridTOP5.Columns[1].HeaderText = "Tipo de cuenta";
                datagridTOP5.Columns[1].Width = 150;
                datagridTOP5.Columns[2].HeaderText = "Total facturado";
                datagridTOP5.Columns[2].Width = 250;
                datagridTOP5.Columns[0].Visible = true;
                datagridTOP5.Columns[1].Visible = true;
                datagridTOP5.Columns[2].Visible = true;
                datagridTOP5.Columns[3].Visible = false;
                datagridTOP5.Columns[4].Visible = false;


                if (resultado != null && resultado.Rows != null)
                {
                    Object[] columnas = new Object[3];
                    int ranking = 1;

                    foreach (DataRow dr in resultado.Rows)
                    {

                        columnas[0] = ranking.ToString();
                        columnas[1] = dr["tipo_cuenta"].ToString();
                        columnas[2] = dr["total_facturado"].ToString();

                        datagridTOP5.Rows.Add(columnas[0], columnas[1], columnas[2]);
                        ranking = ranking + 1;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            datagridTOP5.Rows.Clear();
            txtYear.Text = "";
        }
    }
}
