using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsMonto
    {
        public byte Codigo { get; set; }
        public string Descripcion { get; set; }
        public float Monto { get; set; }

        public clsMonto(byte argCodigo, string argDescripcion, float argMonto)
        {
            Codigo = argCodigo;
            Descripcion = argDescripcion;
            Monto = argMonto;
        }
    }
}
