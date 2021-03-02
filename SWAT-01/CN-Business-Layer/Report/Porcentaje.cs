using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Report
{
    public class Porcentaje
    {
        public string Descripcion { get; set; }
        public float Total { get; set; }

        public Porcentaje(string descripcion, float total)
        {
            Descripcion = descripcion;
            Total = total;
        }
    }
}
