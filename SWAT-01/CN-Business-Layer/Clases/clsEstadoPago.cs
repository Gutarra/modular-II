using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsEstadoPago
    {
        public byte Codigo { get; set; }
        public string Detalle { get; set; }
    
        public clsEstadoPago(byte argCodigo, string argDetalle)
        {
            Codigo = argCodigo;
            Detalle = argDetalle;
        }

    }
}
