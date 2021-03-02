using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsPeriodoAcademico
    {
        public string Year { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public clsPeriodoAcademico(string argYear,DateTime argFechaInicio,DateTime argFechaFinal)
        {
            Year = argYear;
            FechaInicio = argFechaInicio;
            FechaFinal = argFechaFinal;
        }
    }
}
