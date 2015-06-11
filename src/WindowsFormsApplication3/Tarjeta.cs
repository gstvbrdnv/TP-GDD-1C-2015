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
    public class Tarjeta
    {
        public string nro_tarjeta;
        public string descripcion;

        public Tarjeta() { }

        public Tarjeta(string nroTarjeta, string descripcion)
        {
            this.nro_tarjeta = nroTarjeta;
            this.descripcion = descripcion;
        }

        public string IDTarjeta
        {
            get
            {
                return nro_tarjeta;
            }
        }

        public override string ToString()
        {
            return nro_tarjeta;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Tarjeta)))) return false;
            return ((Tarjeta)obj).nro_tarjeta == nro_tarjeta;
        }

        public override int GetHashCode()
        {
            return nro_tarjeta.GetHashCode();
        }
    }
}
