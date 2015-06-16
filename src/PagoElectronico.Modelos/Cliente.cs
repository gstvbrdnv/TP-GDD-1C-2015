using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelos
{
    public class Cliente
    {
        public string idCliente;
        public string email;
        public string nombre;
        public string apellido;

        public Cliente() { }

        public Cliente(string idCliente, string email, string nombre, string apellido)
        {
            this.idCliente = idCliente;
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string IDCliente
        {
            get
            {
                return idCliente;
            }
        }

        public override string ToString()
        {
            return apellido + ", " + nombre;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(Cliente)))) return false;
            return ((Cliente)obj).idCliente == idCliente;
        }

        public override int GetHashCode()
        {
            return idCliente.GetHashCode();
        }
    }
}
