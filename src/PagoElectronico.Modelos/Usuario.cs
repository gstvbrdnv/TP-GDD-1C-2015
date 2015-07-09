using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico;
using System.Security.Cryptography;

namespace PagoElectronico.Modelos
{
    public class Usuario
    {
        public string username;
        public string rol;
        public BindingList<Rol> Roles { get; set; }
        public bool FaltanDatos { get; set; }

        public Usuario() { }

        public Usuario(string username)
        {
            this.username = username;
        }

        public Usuario(string username, string rol)
        {
            this.username = username;
            this.rol = rol;
        }

        public string IDUsername
        {
            get
            {
                return username;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Usuario)))) return false;
            return ((Usuario)obj).username == username;
        }

        public override int GetHashCode()
        {
            return username.GetHashCode();
        }
    }
}
