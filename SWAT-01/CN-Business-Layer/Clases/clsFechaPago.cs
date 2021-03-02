using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsFechaPago
    {
        public byte Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public clsFechaPago(byte argCodigo, DateTime argFechaVenc)
        {
            Codigo = argCodigo;
            FechaVencimiento = argFechaVenc;
        }
    }
}
