using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelos
{
    public class TipoDocumento
    {
        public string idTipoDoc;
        public string descripcion;

        public TipoDocumento() { }

        public TipoDocumento(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public TipoDocumento(string idTipoDoc, string descripcion)
        {
            this.idTipoDoc = idTipoDoc;
            this.descripcion = descripcion;
        }

        public string IDTipoDoc
        {
            get
            {
                return idTipoDoc;
            }
        }

        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(TipoDocumento)))) return false;
            return ((TipoDocumento)obj).idTipoDoc == idTipoDoc;
        }

        public override int GetHashCode()
        {
            return idTipoDoc.GetHashCode();
        }
    }
}
