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
    public class Funcionalidad
    {
        public string id_func { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

        public Funcionalidad()
        { }

        public Funcionalidad(string idFunc, string descripcion)
        {
            this.id_func = idFunc;
            this.descripcion = descripcion;
        }

        public string IDFunc
        {
            get
            {
                return id_func;
            }
        }

        public override string ToString()
        {
            return descripcion + " (" + id_func + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Funcionalidad)) return false;
            return ((Funcionalidad)obj).id_func == this.id_func;
        }

        public override int GetHashCode()
        {
            return id_func.GetHashCode();
        }

    }
}
