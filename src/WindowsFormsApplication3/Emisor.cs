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

namespace PagoElectronico.Comun
{
    public class Emisor
    {
        public string idEmisor;
        public string descripcion;

        public Emisor() { }

        public Emisor(string idEmisor, string descripcion)
        {
            this.idEmisor = idEmisor;
            this.descripcion = descripcion;
        }

        public string IDEmisor
        {
            get
            {
                return idEmisor;
            }
        }

        public override string ToString()
        {
            return descripcion + " (" + idEmisor + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Emisor)))) return false;
            return ((Emisor)obj).idEmisor == idEmisor;
        }

        public override int GetHashCode()
        {
            return idEmisor.GetHashCode();
        }
    }
}