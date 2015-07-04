using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.DB;

namespace PagoElectronico.Core
{
    class Validador
    {
        private static Validador instance;
        private HashSet<String> errores;


        public Validador()
        {
            this.errores = new HashSet<String>();
        }

        public static Validador Instance
        {
            get
            {
                if (instance == null) instance = new Validador();
                return instance;
            }
        }

        public void esCodigoSeguridadCorrecto(TextBox textBox)
        {
            if (textBox.Text.Length != 3)
            {
                errores.Add("El campo <" + textBox.Tag + "> no posee el formato correcto (3 dígitos).");
                return;
            }
        }

        public void esNumeroTarjetaCorrecta(TextBox textBox)
        {
            if (textBox.Text.Length != 16)
            {
                errores.Add("El campo <" + textBox.Tag + "> no posee el formato correcto (16 dígitos).");
                return;
            }
        }

        public void estaVacioOEsNulo(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text.Replace(" ", "")))
            {
                errores.Add("El campo <" + textBox.Tag + "> esta vacío o es nulo.");
                return;
            }
        }

        public void esNumerico(TextBox textBox)
        {
            if (!this.esNumerico(textBox.Text))
            {
                errores.Add("El campo <" + textBox.Tag + "> no es numérico.");
            }

        }

        public void esDecimal(TextBox textBox)
        {
            string numero = textBox.Text;
            decimal d;
            if (!(decimal.TryParse(numero, out d)))
            {
                errores.Add("El campo <" + textBox.Tag + "> no es decimal.");
                return; 
            }
        }

        public void esAlfabetico(TextBox textBox)
        {
            String text = textBox.Text;

            foreach (char car in text)
            {
                if (!Char.IsLetter(car) && ' ' != car)
                {
                    errores.Add("El campo <" + textBox.Tag + "> no es alfabético.");
                    return;
                }
            }
        }

        public void esCero(TextBox textBox)
        {
            string text = textBox.Text;
            if (!(String.IsNullOrEmpty(text)))
            {
                if (this.esNumerico(text))
                {
                    int value = Convert.ToInt32(text);
                    if (!(value > 0))
                    {
                        errores.Add("El valor del campo <" + textBox.Tag + "> debe ser mayor a 0 (Cero).");
                        return;
                    }
                }
            }
        }

        public bool esDecimalString(string numero)
        {
            decimal d;
            if (!(decimal.TryParse(numero, out d)))
            {
                errores.Add("El campo importe no es decimal.");
                return false;
            }
            return true;
        }

        public void esMayorA1(TextBox textBox)
        {
            string text = textBox.Text;
            text = text.Replace(",", ".");
            if (!(String.IsNullOrEmpty(text)))
            {
                if (this.esDecimalString(text))
                {
                    decimal value = Convert.ToDecimal(text);
                    if (value < 1)
                    {
                        errores.Add("El valor del campo <" + textBox.Tag + "> debe ser mayor o igual a 1.");
                        return;
                    }
                }
            }
        }

        public void esFechaMenor(DateTimePicker fechaEmision, DateTimePicker fechaVencimiento)
        {
            if (fechaVencimiento.Value < fechaEmision.Value)
            {
                errores.Add("La fecha de emisión es mayor a la fecha de vencimiento.");
                return;
            }
        }

        public void yaExisteLaTarjeta(TextBox textBox)
        {
            string tarjeta = textBox.Text;

            if (!(String.IsNullOrEmpty(tarjeta)))
            {
                if (this.esNumerico(tarjeta))
                {
                    DataTable resultado = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Tarjeta " +
                        "WHERE nro_tarjeta = '" + tarjeta + "'");
                    if (resultado.Rows.Count != 0)
                    {
                        errores.Add("La tarjeta '" + tarjeta + "' ya existe o está asociada a otra cuenta.");
                        return;
                    }
                    
                }
                
            }
            
        }

        public void yaExisteMail(TextBox textBox)
        {
            string mail = textBox.Text;

            if (!(String.IsNullOrEmpty(mail)))
            {
                DataTable resultado = DataBase.ExecuteReader("SELECT mail FROM NOLARECURSO.Cliente " +
                    "WHERE mail = '" + mail + "'");
                if (resultado.Rows.Count != 0)
                {
                    errores.Add("El mail " + mail + " ya existe.");
                    return;
                }
            }
        }

        public bool existeLaCuenta(string cuenta)
        {
            if (!(String.IsNullOrEmpty(cuenta)))
            {
                if (this.esNumerico(cuenta))
                {
                    DataTable resultado = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Cuenta " +
                        "WHERE nro_cuenta = '" + cuenta + "'");
                    if (resultado.Rows.Count == 0)
                    {
                        errores.Add("La cuenta <" + cuenta + "> no existe.");
                        return false;
                    }
                    else return true;
                }
                else return false;
            }
            else return false;
        }

        public void validarNumDoc(string numero, string cliente)
        {
            if (String.IsNullOrEmpty(numero))
            {
                errores.Add("No se seleccionó ninguna cuenta.");
            }
            else
            {
                var numDocumentoCliente = DataBase.ExecuteCardinal("SELECT nro_documento FROM NOLARECURSO.Cliente " +
                    "WHERE id_cli = '" + cliente + "'");
                if (!(numero.Equals(numDocumentoCliente.ToString())))
                {
                    errores.Add("El número de documento ingresado no coincide con el del cliente.");
                    return;
                }
            }
        }

        public void esCuentaCerradaOPendiente(string cuenta)
        {
            if (String.IsNullOrEmpty(cuenta))
            {
                errores.Add("No se seleccionó ninguna cuenta.");
            }
            else
            {
                if ((this.esNumerico(cuenta)) && (this.existeLaCuenta(cuenta)))
                {

                    int estadoCuenta = DataBase.ExecuteCardinal("SELECT id_estado FROM NOLARECURSO.Cuenta " +
                        "WHERE nro_cuenta = '" + cuenta + "'");
                    switch (estadoCuenta)
                    {
                        case 3:
                            errores.Add("La cuenta " + cuenta + " se encuentra cerrada.");
                            break;
                        case 4:
                            errores.Add("La cuenta " + cuenta + " se encuentra pendiente de activación.");
                            break;
                    }
                    return;
                }
            }
        }

        public void sonIguales(TextBox textBox, ComboBox comboBox, string nombreCampoComboBox)
        {
            if (!(String.IsNullOrEmpty(textBox.Text)))
            {
                if (this.esNumerico(textBox.Text))
                {
                    if (hayUnoSeleccionado(nombreCampoComboBox, comboBox))
                    {
                        if (comboBox.SelectedItem.ToString().Equals(textBox.Text))
                        {
                            errores.Add("Las cuentas origen y destino son iguales.");
                            return;
                        }
                    }
                }
            }
        }

        public void esAlfaNumerico(TextBox textBox)
        {
            String text = textBox.Text;

            foreach (char car in text)
            {
                if (!Char.IsLetterOrDigit(car) && ' ' != car)
                {
                    errores.Add("El campo <" + textBox.Tag + "> no es alfanumérico.");
                    return;
                }
            }
        }

        public void hayUnoChequeado(String nombreCampo, List<RadioButton> radioButtons)
        {
            bool bandera = true;

            foreach (RadioButton radioButton in radioButtons)
                if (!(bandera &= !radioButton.Checked))
                    return;
            errores.Add("No se seleccionó ninguna opción para el campo <" + nombreCampo + ">.");
        }

        public void mostrarErrores()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Ocurrieron algunos errores durante la ejecución:\n\n");
            foreach (String error in errores)
                stringBuilder.Append(error + "\n");

            MessageBox.Show(stringBuilder.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            errores.Clear();

        }

        private bool esNumerico(String cadena)
        {
            foreach (char car in cadena)
            {
                if (!Char.IsDigit(car))
                {
                    return false;
                }
            }
            return true;
        }

        public void esMail(TextBox textBox)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(textBox.Text);
            }
            catch
            {
                errores.Add("El campo <" + textBox.Tag + "> no es un mail.");
                return;
            }
        }

        public void hayUnaFechaSeleccionada(DateTimePicker dateTimePicker)
        {
            if (dateTimePicker.Value.ToString().Equals(""))
            {
                errores.Add("Por favor ingrese una fecha.");
                return;
            }
        }

        public void esElementoFechaValida(TextBox textBox, int limiteInferior, int limiteSuperior)
        {

            String text = textBox.Text;
            if (this.esNumerico(text) && text != "")
            {

                int num = int.Parse(text);
                if (num > limiteSuperior || num < limiteInferior)
                {
                    errores.Add("El campo <" + textBox.Tag + "> no pertenece a un rango valido.");
                }

            }
        }

        public bool hayErrores()
        {
            return this.errores.Count != 0;
        }

        public void agregarError(String error)
        {
            this.errores.Add(error);
        }

        public bool hayUnoSeleccionado(string nombreCampo, ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                errores.Add("No se seleccionó ninguna opción para el campo <" + nombreCampo + ">.");
                return false;
            }
            else return true;
        }

        public bool hayCheckBoxSeleccionado(string nombreCampo, CheckedListBox checkBox)
        {
            if (checkBox.CheckedItems.Count < 1)
            {
                errores.Add("No se seleccionó ninguna opción para el campo <" + nombreCampo + ">.");
                return false;
            }
            else return true;
        }
    }
}