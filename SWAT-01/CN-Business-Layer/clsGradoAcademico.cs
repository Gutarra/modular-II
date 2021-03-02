using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsGradoAcademico
    {
        public char Grado { get; set; }
        public char Seccion { get; set; }
        public byte Capacidad { get; set; }

        public clsGradoAcademico(byte capacidad)
        {
            Capacidad = capacidad;
        }

        public clsGradoAcademico(char argGrado, char argSeccion, byte argCapacidad)
        {
            Grado = argGrado;
            Seccion = argSeccion;
            Capacidad = argCapacidad;
        }
        public clsGradoAcademico(char argGrado)
        {
            Grado = argGrado;
        }
        public clsGradoAcademico(char argGrado, char argSeccion)
        {
            Grado = argGrado;
            Seccion = argSeccion;
        }
        public static List<clsGradoAcademico> ListarGrados()
        {
            List<clsGradoAcademico> MilistaGradosAcademicos = new List<clsGradoAcademico>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_GragoAcademico_listarGrados", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsGradoAcademico filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsGradoAcademico(
                           Convert.ToChar(LOSDATOS["Grado"])
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cliente a Milistado
                MilistaGradosAcademicos.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MilistaGradosAcademicos;
        }

        public static List<clsGradoAcademico> ListarSecciones_porgrado(char grado)
        {
            List<clsGradoAcademico> MilistaSeccionesAcademicos = new List<clsGradoAcademico>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_GradoAcademico_listarSecciones", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parGrado", grado);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                byte total = Convert.ToByte(LOSDATOS["Capacidad"]);
                byte matriculados = Convert.ToByte(LOSDATOS["Matriculados"]);
                int capacidadrestante = 0;
                capacidadrestante = total - matriculados;
                clsGradoAcademico filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsGradoAcademico(
                           Convert.ToChar(LOSDATOS["Grado"]),
                           Convert.ToChar(LOSDATOS["Seccion"]),
                           Convert.ToByte(capacidadrestante)
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cliente a Milistado
                MilistaSeccionesAcademicos.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MilistaSeccionesAcademicos;
        }
        public static clsGradoAcademico Vacantes(char grado, char Seccion)
        {
            clsGradoAcademico elgrado = null;
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_GradoAcademico_confirmar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parGrado", grado);
            elComando.Parameters.AddWithValue("@parSeccion", Seccion);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            while (LOSDATOS.Read() == true)
            {
                byte total = Convert.ToByte(LOSDATOS["Disponible"]);
                elgrado = new clsGradoAcademico(total);
            }
            miConexion.Close();

            return elgrado;
        }
    }
}
