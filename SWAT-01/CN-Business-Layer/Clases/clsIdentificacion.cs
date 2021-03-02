using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsIdentificacion
    {
        public byte codigo { get; set; }
        public string Nombre { get; set; }

        public clsIdentificacion(byte argCodigo, string argNombre)
        {
            codigo = argCodigo;
            Nombre = argNombre;
        }
    }
}
