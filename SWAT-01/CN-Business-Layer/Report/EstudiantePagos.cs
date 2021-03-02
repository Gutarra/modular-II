using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Report
{
    public class EstudiantePagos
    {
        public int Numero { get; set; }
        public string DNI { get; set; }
        public string Apellidos_Nombres { get; set; }
        public string Fecha { get; set; }
        public float Deuda { get; set; }
        public string Detallepago { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }

        public EstudiantePagos(int numero,
            string dNI, string apellidos_Nombres, 
            string fecha, float deuda, 
            string detallepago, string grado, 
            string seccion) : this(numero, dNI, apellidos_Nombres, fecha, deuda, detallepago)
        {
            Grado = grado;
            Seccion = seccion;
        }

        public EstudiantePagos(int numero,
            string dNI,
            string apellidos_Nombres,
            string fecha,
            float deuda,
            string detallepago)
        {
            Numero = numero;
            DNI = dNI;
            Apellidos_Nombres = apellidos_Nombres;
            Fecha = fecha;
            Deuda = deuda;
            Detallepago = detallepago;
        }
    }
}
