using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Comun;

namespace PagoElectronico.ABM_Rol
{
    class AMB_Rol : EventArgs
    {
        public Rol Rol { get; set; }
    }
}
