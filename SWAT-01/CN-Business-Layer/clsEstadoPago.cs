using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
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
