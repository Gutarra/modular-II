using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Report
{
    public class Monto
    {
        public string Descripcion { get; set; }
        public Decimal Total { get; set; }

        public Monto(string descripcion, decimal total)
        {
            Descripcion = descripcion;
            Total = total;
        }
    }
}
