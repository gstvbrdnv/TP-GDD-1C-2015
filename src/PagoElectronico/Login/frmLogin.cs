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
using System.Configuration;

namespace PagoElectronico.Login
{
    public partial class frmLogin : Form
    {
        public static string loginUsername;
        public bool resultadoLogin = false;
        public static Rol rol;
        public static string rolElegido;

        public frmLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.Size = new Size(238, 184);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Revisamos que los campos estén bien
            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Falta completar datos.");
                return;
            }

            //Encriptamos la contraseña
            string encryptedPassword = ComputeHash(txtPassword.Text, new SHA256Managed());

            //Entra a la BD, se fija si el usuario y contraseña de la base matchea con lo ingresado:
            DataTable dataTableLogin = DataBase.ExecuteReader("SELECT * FROM NOLARECURSO.Usuario WHERE username = '" +
                txtUsuario.Text + "' " + "AND password = '" + encryptedPassword + "'");

            //Si la contraseña es incorrecta o el usuario no existe, la consulta devuelve 0 filas, entonces:
            if (dataTableLogin.Rows.Count == 0)
            {
                //Nos fijamos el usuario y obtenemos su informacion de la tabla usuario:
                DataTable dataTable2 = DataBase.ExecuteReader("Select * From NOLARECURSO.Usuario WHERE username = '" +
                    txtUsuario.Text + "' ");

                string estadoUsuario2 = "False";

                //Obtenemos el estado del usuario
                foreach (DataRow dataRow in dataTable2.Rows)
                { estadoUsuario2 = dataRow["estado"].ToString(); }

                // True (1) está activo. False (0) está bloqueado.
                // Está activo?
                if (estadoUsuario2 == "True")
                {
                    if (dataTable2.Rows.Count != 0)
                    {
                        //Si entró aca, entonces el usuario existe, está activado y la contraseña es incorrecta

                        //Actualizo tabla de auditoria login con intento de login incorrecto:
                        DataTable insertTablaAuditIncorrecto = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Auditoria_Login " +
                            "(username, fec_correctos, int_correcto, fec_incorrecto, int_incorrecto) VALUES " +
                            "('" + txtUsuario.Text + "', NULL, '0', GETDATE(), '1')");

                        //Actualizo intentos de login
                        int updateIntentos = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Usuario SET intentos_login = intentos_login + 1" +
                            "WHERE username = '" + txtUsuario.Text + "'");

                        //Obtenemos cantidad de intentos del usuario
                        int intentos = DataBase.ExecuteCardinal("SELECT intentos_login " +
                            "From NOLARECURSO.Usuario WHERE username = '" + txtUsuario.Text + "'");

                        //Bloquea usuario si intentos > 2
                        if (intentos > 2)
                        {
                            int updateEstadoUsuario = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Usuario SET estado = 0" + 
                                "WHERE username = '" + txtUsuario.Text + "'");
                            int resetIntentosLogin = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Usuario SET intentos_login = 0" +
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

            string estadoUsuarioLogin = "False";

            //Obtenemos el estado del usuario
            foreach (DataRow dataRow in dataTableLogin.Rows)
            { estadoUsuarioLogin = dataRow["estado"].ToString(); }

            // Usuario bloqueado
            if (estadoUsuarioLogin == "False")
            {
                MessageBox.Show("El usuario ingresado está bloqueado, por favor contacte al administrador del sistema.");
                DataTable insertTablaAuditIncorrecto = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Auditoria_Login " +
                    "(username, fec_correctos, int_correcto, fec_incorrecto, int_incorrecto) VALUES " +
                    "('" + txtUsuario.Text + "', NULL, '0', GETDATE(), '1')");
                return;
            }

            //Logueo correcto => True & reseteamos login attempts
            resultadoLogin = true;
            int resetIntentosLogin2 = DataBase.ExecuteNonQuery("UPDATE NOLARECURSO.Usuario SET intentos_login = 0" + 
                "WHERE username = '" + txtUsuario.Text + "'");
            
            if (resultadoLogin != true)
            {
                this.Close();
            }
            else
            {
                //Actualizo tabla de auditoria login con intento de login correcto:
                DataTable insertTablaAuditCorrecto = DataBase.ExecuteReader("INSERT INTO NOLARECURSO.Auditoria_Login " +
                    "(username, fec_correctos, int_correcto, fec_incorrecto, int_incorrecto) VALUES " +
                    "('" + txtUsuario.Text + "', GETDATE(), '1', NULL, '0')");
                loginUsername = txtUsuario.Text;
                elegirRol(loginUsername);
            }
        }

        public void elegirRol(string user)
        {
            int cantidadRoles = 0;

            //Cargamos roles activos del usuario
            DataTable rolesUsuario = DataBase.ExecuteReader("SELECT rol.id_rol , rol.descripcion, rol.estado FROM NOLARECURSO.Rol_Usuario" +
                " rol_usuario JOIN NOLARECURSO.Rol rol ON rol.id_rol = rol_usuario.id_rol WHERE rol_usuario.username = '" + user +
                "' AND rol.estado = 1");

            //Calculamos cantidad de roles que tiene asignado el usuario
            foreach (DataRow dataRow in rolesUsuario.Rows)
            { cantidadRoles++; }

            //Chequeamos cantidad de roles que posee el usuario
            switch (cantidadRoles)
            {
                case (0):
                    MessageBox.Show("El usuario no tiene roles asignados, por favor contacte al administrador del sistema.");
                    break;
                case (1):
                    foreach (DataRow dataRow in rolesUsuario.Rows)
                    {
                        rolElegido = dataRow["id_rol"].ToString();
                    }
                    iniciarSesion(loginUsername, rolElegido);
                    break;
                default:
                    //Modificamos estado de los objetos del formulario
                    this.Size = new Size(238, 285);
                    txtUsuario.Enabled = false;
                    txtPassword.Enabled = false;
                    btnIngresar.Enabled = false;
                    comboRoles.Enabled = true;
                    comboRoles.DropDownStyle = ComboBoxStyle.DropDownList;

                    //Cargamos roles en el comboBox
                    foreach (DataRow dataRow in rolesUsuario.Rows)
                    {
                        rol = new Rol();
                        rol.id_rol =  dataRow["id_rol"].ToString();
                        rol.descripcion = dataRow["descripcion"].ToString();
                        rol.estado = dataRow["estado"].ToString();

                        comboRoles.Items.Add(rol.descripcion.ToString());
                    }
                    break;
            }
        }

        public void iniciarSesion(string user, string rol)
        {
            //MessageBox.Show("CANT ROLES = 1");
            this.Hide();
            frmMain nuevaSesion = new frmMain();
            nuevaSesion.Show();
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

        private void btnAceptarRol_Click(object sender, EventArgs e)
        {
            if (comboRoles.SelectedItem != null)
            {
                DataTable idRol = DataBase.ExecuteReader("SELECT id_rol FROM NOLARECURSO.Rol" +
                    " WHERE descripcion = '" + comboRoles.SelectedItem.ToString() + "'");
                foreach (DataRow dataRow in idRol.Rows)
                {
                    rolElegido = dataRow["id_rol"].ToString();
                }
                iniciarSesion(loginUsername, rolElegido);
            }
            else
                MessageBox.Show("Debe seleccionar un rol primero.");
        }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
