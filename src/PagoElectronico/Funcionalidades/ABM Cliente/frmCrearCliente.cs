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
using PagoElectronico.ABM_Cliente;

namespace PagoElectronico.Funcionalidades.ABM_Cliente
{
    public partial class frmCrearCliente : Form
    {
        Validador validador = Validador.Instance;
        public static Pais pais;
        public static TipoDocumento tipoDoc;

        public frmCrearCliente()
        {
            InitializeComponent();
        }

        private void frmCrearCliente_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 409);
            this.MinimumSize = new System.Drawing.Size(358, 409);
            this.ControlBox = false;
            cargarPaises();
            cargarTiposDocumento();
        }

        private void cargarTiposDocumento()
        {
            var paises = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Tipo_documento");

            foreach (DataRow dataRow in paises.Rows)
            {
                string idPais = dataRow["id_tipo"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboTipoDocumento.Items.Add(new TipoDocumento(idPais, desc));
            }
        }

        private void cargarPaises()
        {
            var paises = DataBase.ExecuteReader("SELECT * from NOLARECURSO.Pais");

            foreach (DataRow dataRow in paises.Rows)
            {
                string idPais = dataRow["id_pais"].ToString();
                string desc = dataRow["descripcion"].ToString();
                comboPais.Items.Add(new Pais(idPais, desc));
                comboNacionalidad.Items.Add(new Pais(idPais, desc));
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMCliente nuevo = new frmABMCliente();
            nuevo.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtMail.Text = "";
            this.txtDocumento.Text = "";
            this.txtDomicilio.Text = "";
            this.txtNumCalle.Text = "";
            this.txtPiso.Text = "";
            this.txtDepto.Text = "";
            this.txtTelefono.Text = "";
        }

        private void validarDatos()
        {
            foreach (Control control in Controls)
            { if (control is TextBox) validador.estaVacioOEsNulo((TextBox)control); }
            validador.esAlfabetico(txtNombre);
            validador.esAlfabetico(txtApellido);
            validador.esNumerico(txtDocumento);
            validador.hayUnoSeleccionado("Tipo documento", comboTipoDocumento);
            validador.esMail(txtMail);
            validador.hayUnoSeleccionado("Pais", comboPais);
            validador.esAlfabetico(txtDomicilio);
            validador.esNumerico(txtNumCalle);
            validador.esNumerico(txtPiso);
            validador.esAlfabetico(txtLocalidad);
            validador.esNumerico(txtTelefono);
            validador.hayUnoSeleccionado("Nacionalidad", comboNacionalidad);
            validador.hayUnaFechaSeleccionada(dtFechaNacimiento);
            validador.yaExisteMail(txtMail);            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.validarDatos();
            if (Validador.Instance.hayErrores())
            {
                Validador.Instance.mostrarErrores();
                return;
            }

            // Crear cliente
            int idCliente = DataBase.ExecuteCardinal("SELECT * FROM NOLARECURSO.Cliente ORDER BY 1 DESC") + 1;
            string idPais = ((Pais)comboPais.SelectedItem).IDPais;
            string idTipoDoc = ((TipoDocumento)comboTipoDocumento.SelectedItem).IDTipoDoc;

            DataTable insertCliente = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Cliente " +
                "(nombre, apellido, id_tipo_doc, nro_documento, mail, telefono, " +
                "direccion, dir_numero, dir_piso, dir_dpto, localidad, id_pais, fec_nacimiento) VALUES ('" +
                /*idCliente + "', '" + */txtNombre.Text + "', '" + txtApellido.Text + "', '" +
                idTipoDoc + "', '" + txtDocumento.Text + "', '" +
                txtMail.Text +  "', '" + txtTelefono.Text + "', '" + txtDomicilio.Text + "', '" +
                txtNumCalle.Text + "', '" + txtPiso.Text + "', '" + txtDepto.Text + "', '" +
                txtLocalidad.Text + "', '" + idPais + "', '" +
                dtFechaNacimiento.Value.ToString() + "')");

            // Imprimir mensaje
            MessageBox.Show("El cliente ha sido creado satisfactoriamente.\n\n" +
                "Número de cliente: " + idCliente.ToString() + "\n" +
                "Nombre: " + txtNombre.Text + "\n" +
                "Apellido: " + txtApellido.Text, "", MessageBoxButtons.OK);

            // Cerrar formulario
            this.Close();
            frmABMCliente newABM = new frmABMCliente();
            newABM.Show();
        }


    }
}
