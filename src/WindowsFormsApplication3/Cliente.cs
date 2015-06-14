using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PagoElectronico.Comun
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public int email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public List<Functionalities> Functionalities { get; set; }

        public Cliente()
        { }

        

        /*
        public override string ToString()
        {
            return estado + " (Perfil: " + estado + ")";
        }*/
 
    }
}
