using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelos
{
    public class TipoCuenta
    {
        public string idTipoCuenta;
        public string descripcion;

        public TipoCuenta() { }

        public TipoCuenta(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public TipoCuenta(string idTipoCuenta, string descripcion)
        {
            this.idTipoCuenta = idTipoCuenta;
            this.descripcion = descripcion;
        }

        public string IDTipoCuenta
        {
            get
            {
                return idTipoCuenta;
            }
        }

        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(TipoCuenta)))) return false;
            return ((TipoCuenta)obj).idTipoCuenta == idTipoCuenta;
        }

        public override int GetHashCode()
        {
            return idTipoCuenta.GetHashCode();
        }
    }
}
