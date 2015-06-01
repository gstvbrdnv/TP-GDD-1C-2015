using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico;
using PagoElectronico.Comun;

namespace PagoElectronico.Core
{
    /// Representa los atributos aplicables a los formularios para determinar los permisos
    /// necesarios para poder navegar sobre cada uno. En base a estos permisos es que
    /// se muestran o no los formularios en el menu

    public class AtributoPermisosRequeridos : Attribute
    {
        /// Permisos requeridos para poder navegar el formulario

        //public Functionalities[] Permissions { get; set; }

        /// Crea una nueva instancia del atributo
        /// <param name="permissions">Permisos requeridos para poder navegar el formulario</param>
        //public AtributoPermisosRequeridos(params Functionalities[] permissions)
       // {
            //Permissions = permissions;
        //}
    }
}
