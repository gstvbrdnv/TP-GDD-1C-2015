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
    public class Banco
    {
        public string idBanco;
        public string descripcion;

        public Banco() { }

        public Banco(string idBanco, string descripcion)
        {
            this.idBanco = idBanco;
            this.descripcion = descripcion;
        }

        public string IDBanco
        {
            get
            {
                return idBanco;
            }
        }

        public override string ToString()
        {
            return descripcion + " (" + idBanco + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Banco)))) return false;
            return ((Banco)obj).idBanco == idBanco;
        }

        public override int GetHashCode()
        {
            return idBanco.GetHashCode();
        }
    }
}
