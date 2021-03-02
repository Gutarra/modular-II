using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
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

        public static clsPeriodoAcademico listarPeriodo()
        {
            clsPeriodoAcademico PeriodoActual = null;

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_PeriodoPeriodoAcademico_listaractual", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();


            while (LOSDATOS.Read() == true)
            {
                
                PeriodoActual = new clsPeriodoAcademico(
                           Convert.ToString(LOSDATOS["Year"]),
                           Convert.ToDateTime(LOSDATOS["FechaInicio"]),
                           Convert.ToDateTime(LOSDATOS["FechaFinal"]));
            }
            miConexion.Close();

            return PeriodoActual;
        }

        public static DatosGenerales.dtblEstdMatriculadosDataTable VerVacantes(string argGrado)
        {
            DatosGenerales.dtblEstdMatriculadosDataTable misdatos = new DatosGenerales.dtblEstdMatriculadosDataTable();
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_GradoAcademico_verCantidadVacantes", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parGrado", argGrado);

            miConexion.Open();
            SqlDataReader LOSDATOS = elComando.ExecuteReader();
            while (LOSDATOS.Read() == true)
            {
                short año = 0;
                if (LOSDATOS["PeriodoAcademico_Year"] != DBNull.Value)
                    año = Convert.ToInt16(LOSDATOS["PeriodoAcademico_Year"]);

                DataRow fila = misdatos.NewRow();
                if ( año == Convert.ToInt16(DateTime.Today.Year))
                {
                    fila["Matriculados"] = Convert.ToByte(LOSDATOS["Matriculados"]);
                }
                else
                {
                    fila["Matriculados"] = 0;
                }
                fila["Capacidad"] = Convert.ToByte(LOSDATOS["Capacidad"]);
                fila["Grado_Seccion"] = Convert.ToString(LOSDATOS["GradoSeccion"]);

                misdatos.Rows.Add(fila);
            }
            miConexion.Close();

            return misdatos;
        }
    }
}
