using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Clases
{
    public class clsGradoAcademico
    {
        public char Grado { get; set; }
        public char Seccion { get; set; }
        public byte Capacidad { get; set; }

        public clsGradoAcademico(char argGrado, char argSeccion, byte argCapacidad)
        {
            Grado = argGrado;
            Seccion = argSeccion;
            Capacidad = argCapacidad;
        }
    }
}
