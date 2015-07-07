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

        public frmEstadisticas()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 506);
            this.MinimumSize = new System.Drawing.Size(675, 506);
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


        }
    }
}
