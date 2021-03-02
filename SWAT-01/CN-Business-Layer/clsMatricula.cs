using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsMatricula
    {
        public clsPeriodoAcademico PeriodoAcademico { get; set; }
        public clsEstudiante Estudiante { get; set; }
        public clsUsuario Usuario { get; set; }
        public bool Verificacion{ get; set; }
        public clsGradoAcademico GradoAcademico { get; set; }
        public DateTime FechaRegistro { get; set; }

        public clsMatricula(clsPeriodoAcademico argPeriodoAcademico_year, clsEstudiante argEstudiante_NumDocumento,
            clsUsuario argUsuario_NumDocumento, bool argVerificacionLogro,
            clsGradoAcademico argGradoAcademico, DateTime argFechaRegistro)
        {
            PeriodoAcademico = argPeriodoAcademico_year;
            Estudiante = argEstudiante_NumDocumento;
            Usuario = argUsuario_NumDocumento;
            Verificacion = argVerificacionLogro;
            GradoAcademico = argGradoAcademico;
            FechaRegistro = argFechaRegistro;
        }

        public void RegistrarMatricula()
        {
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            //miConexion = new SqlConnection("SERVER=WA27-2;DATABASE=EjercicioSemanaCero;Integrated security=true");

            //Paso 02: Definir el comando (Qué harás en la BD?)
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Matricula_registrar", miConexion);

            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            // agregar valores a la base de datos atravez de parametros del procedimiento almacenado
            elComando.Parameters.AddWithValue("@parYear", PeriodoAcademico.Year);
            elComando.Parameters.AddWithValue("@parEstudiante", Estudiante.NumeroDocumento);
            elComando.Parameters.AddWithValue("@parUsuario", Usuario.NumDocumento);
            elComando.Parameters.AddWithValue("@parVerificacionMatricula", Verificacion);
            elComando.Parameters.AddWithValue("@parGrado",GradoAcademico.Grado );
            elComando.Parameters.AddWithValue("@parSeccion", GradoAcademico.Seccion);
            
            //Paso 03: Ejecutar el comando
            miConexion.Open(); //Abrir la conexión
            elComando.ExecuteNonQuery(); //Ejecutar el comando
            miConexion.Close(); //Cerrar la conexión
        }


    }
}
