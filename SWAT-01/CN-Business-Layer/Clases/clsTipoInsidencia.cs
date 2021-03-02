using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsTipoInsidencia
    {
        public byte Codigo { get; set; }
        public string Descripcion { get; set; }

        public clsTipoInsidencia(byte argCodigo, string argDescripcion)
        {
            Codigo = argCodigo;
            Descripcion = argDescripcion;
        }
    }
}
