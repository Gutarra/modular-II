using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer.Clases;

namespace CN_Business_Layer.Clases_D
{
    public class clsMatricula
    {
        public clsPeriodoAcademico PeriodoAcademico_year { get; set; }
        public clsEstudiante Estudiante_NumDocumento { get; set; }
        public clsUsuario Usuario_NumDocumento { get; set; }
        public string Tipo { get; set; }
        public bool VerificacionLogro { get; set; }
        public clsGradoAcademico GradoAcademico_Grado { get; set; }
        public clsGradoAcademico GradoAcademico_Seccion { get; set; }

        public clsMatricula(clsPeriodoAcademico argPeriodoAcademico_year, clsEstudiante argEstudiante_NumDocumento,
            clsUsuario argUsuario_NumDocumento, string argTipo, bool argVerificacionLogro, clsGradoAcademico argGradoAcademico_Grado, clsGradoAcademico argGradoAcademico_Seccion)
        {
            PeriodoAcademico_year = argPeriodoAcademico_year;
            Estudiante_NumDocumento = argEstudiante_NumDocumento;
            Usuario_NumDocumento = argUsuario_NumDocumento;
            Tipo = argTipo;
            VerificacionLogro = argVerificacionLogro;
            GradoAcademico_Grado = argGradoAcademico_Grado;
            GradoAcademico_Seccion = argGradoAcademico_Seccion;
        }
    }
}
