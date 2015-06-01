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

namespace PagoElectronico.Login
{
    public partial class frmLogin : Form
    {
        public string nombreUsuario;

        public frmLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {


            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Falta completar datos");
                return;
            }

            string encryptedPassword = ComputeHash(txtPassword.Text, new SHA256Managed());

            MessageBox.Show(encryptedPassword.ToString());
            //Entra a la BD, se fija si el usuario y contraseña de la base matchea con lo ingresado:
            DataTable dataTableLogin = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Usuario WHERE username = '" +
                txtUsuario.Text + "' " + "AND password = '" + encryptedPassword + "'");
            MessageBox.Show("cant row login: " + dataTableLogin.Rows.Count.ToString());
            
            //Si la contraseña es incorrecta o el usuario no existe la consulta devuelve 0 filas, entonces:
            if (dataTableLogin.Rows.Count == 0)
            {
                //Nos fijamos el usuario y obtenemos su informacion de la tabla usuario:
                DataTable dataTable2 = DataBase.ExecuteReader("Select * From NOLARECURSO.Usuario WHERE username = '" +
                    txtUsuario.Text + "' ");

                string estadoUsuario2 = "False";
                //Obtenemos el estado del usuario
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    estadoUsuario2 = dataRow["estado"].ToString();
                }
                //MessageBox.Show("cant rows username en tabla usuario: " + dataTable2.Rows.Count.ToString());
                //MessageBox.Show("estado usuario: " + estadoUsuario2);
                // True está activo. False está bloqueado.
                if (estadoUsuario2 == "True")
                {
                    if (dataTable2.Rows.Count != 0)
                    {
                        DataTable dataTableAuditoria = DataBase.ExecuteReader("Select * From NOLARECURSO.Auditoria_Login " +
                            "WHERE username = '" + txtUsuario.Text + "' ");
                        //Si el usuario no tiene registro en la tabla de auditoria, lo crea
                        if (dataTableAuditoria.Rows.Count == 0)
                        {
                            // TODO arreglar el generador de PK_username para la tabla de auditoria
                            DataTable auditoriaIdLogin = DB.DataBase.ExecuteReader("Select count(*) From NOLARECURSO.Auditoria_Login");
                            //MessageBox.Show("cant row audit: " + auditoriaIdLogin.Rows.Count.ToString());
                            int idLogin = 159 - auditoriaIdLogin.Rows.Count;
                            //MessageBox.Show("idLogin: " + idLogin.ToString());
                            //MessageBox.Show(DateTime.Now.ToString("yyyy/MM/dd"));
                            int crearRegistroAuditoria = DB.DataBase.ExecuteNonQuery("SET IDENTITY_INSERT NOLARECURSO.Auditoria_Login ON; Insert Into NOLARECURSO.Auditoria_Login " +
                                "(id_login, username, fec_intento, intento_correcto) Values " +
                                "('" + idLogin + "', '" + txtUsuario.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + 1 + "')");
                        }
                        else //Actualiza cantidad de intentos en tabla de auditoria
                        {
                            int updateIntentos = DataBase.ExecuteNonQuery("Update NOLARECURSO.Auditoria_Login " +
                                "SET intento_correcto = intento_correcto + 1 WHERE username = '" + txtUsuario.Text + "'");

                        }
                        //Devuelve cantidad de intentos del usuario
                        int intentos = DataBase.ExecuteCardinal("Select intento_correcto " +
                            "From NOLARECURSO.Auditoria_Login where username = '" + txtUsuario.Text + "'");

                        //Bloquea usuario
                        if (intentos > 2)
                        {
                            int updateEstadoUsuario = DataBase.ExecuteNonQuery("Update NOLARECURSO.Usuario SET estado = 0" + 
                                "WHERE username = '" + txtUsuario.Text + "'");
                            int updateIntentos2 = DataBase.ExecuteNonQuery("Update NOLARECURSO.Auditoria_Login SET intento_correcto = 0" +
                                "WHERE username = '" + txtUsuario.Text + "'");
                            MessageBox.Show("El usuario ingresado ha sido bloqueado, por favor contacte al administrador del sistema.");
                            return;
                        }

                        MessageBox.Show("La contraseña ingresada es incorrecta.");
                        return;
                    }
                }

                if (dataTable2.Rows.Count != 0)
                {
                    MessageBox.Show("El usuario ingresado está bloqueado, por favor contacte al administrador del sistema.");
                    return;
                }

                MessageBox.Show("El usuario no existe.");
                return;
            }


            string estadoUsuarioLogin = "";
            foreach (DataRow dataRow in dataTableLogin.Rows)
            {
                estadoUsuarioLogin = dataRow["estado"].ToString();
            }

            if (estadoUsuarioLogin == "0")
            {
                MessageBox.Show("El usuario ingresado ha sido bloqueado, por favor contacte al administrador del sistema.");
                return;
            }

            int updateIntentos3 = DataBase.ExecuteNonQuery("Update NOLARECURSO.Auditoria_Login SET intento_correcto = 0" + 
                "WHERE username = '" + txtUsuario.Text + "'");
            
            nombreUsuario = txtUsuario.Text;
            DialogResult = DialogResult.OK;

        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
        
        private string encriptar(string _pass)
        {
            SHA1Managed hashstring = new SHA1Managed();

            byte[] bytes = Encoding.Unicode.GetBytes(_pass);
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;

            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
                    
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
