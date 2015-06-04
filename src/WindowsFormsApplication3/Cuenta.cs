using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Comun
{
    public class Cuenta
    {
        public string nro_cuenta { get; set; }
        public string id_tipo_cta { get; set; }
        public string estado { get; set; }

        public List<Functionalities> Functionalities { get; set; }

        public Cuenta()
        { }

        public override bool Equals(object obj)
        {
            if (!(obj is Cuenta)) return false;
            return ((Cuenta)obj).nro_cuenta == this.nro_cuenta;
        }

        public override int GetHashCode()
        {
            return nro_cuenta.GetHashCode();
        }

        public override string ToString()
        {
            return estado + " (Perfil: " + estado + ")";
        }
    }
}
