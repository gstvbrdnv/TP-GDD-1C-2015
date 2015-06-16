using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelos
{
    public class Pais
    {
        public string idPais;
        public string descripcion;

        public Pais() { }

        public Pais(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public Pais(string idPais, string descripcion)
        {
            this.idPais = idPais;
            this.descripcion = descripcion;
        }

        public string IDPais
        {
            get
            {
                return idPais;
            }
        }

        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Pais)))) return false;
            return ((Pais)obj).idPais == idPais;
        }

        public override int GetHashCode()
        {
            return idPais.GetHashCode();
        }
    }
}
