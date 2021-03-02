using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsCargo
    {
        public byte Codigo { get; set; }
        public string Nombre { get; set; }

        public clsCargo(byte argCodigo, string argNombre)
        {
            Codigo = argCodigo;
            Nombre = argNombre;
        }
    }
}
