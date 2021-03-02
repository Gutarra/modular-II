using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsInasistencia
    {
        public DateTime FechaInsidencia { get; set; }
        public clsEstudiante Estudiante_NumDocumento { get; set; }
        public clsTipoInsidencia TipoInsidencia_Codigo { get; set; }

        public clsInasistencia(DateTime argFechaIsidencia, clsEstudiante argEstudiante_NumDocuemnto, clsTipoInsidencia argTipoInsidencia_Codigo)
        {
            FechaInsidencia = argFechaIsidencia;
            Estudiante_NumDocumento = argEstudiante_NumDocuemnto;
            TipoInsidencia_Codigo = argTipoInsidencia_Codigo;
        }
    }
}
