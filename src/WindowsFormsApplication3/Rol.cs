using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Comun
{
    public class Rol
    {
        public int id_rol { get; set; }
        public string descripcion { get; set; }
        public Boolean estado { get; set; }

        public List<Functionalities> Functionalities { get; set; }

        public Rol()
        { }

        public override bool Equals(object obj)
        {
            if (!(obj is Rol)) return false;
            return ((Rol)obj).id_rol == this.id_rol;
        }

        public override int GetHashCode()
        {
            return id_rol.GetHashCode();
        }

        public override string ToString()
        {
            return descripcion + " (Perfil: " + estado + ")";
        }
    }
}