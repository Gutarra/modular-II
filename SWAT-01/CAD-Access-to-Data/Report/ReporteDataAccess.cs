using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CAD_Access_to_Data.Reports
{
    public class ReporteDataAccess
    {
        public DataTable GererarReporte_Especifico(char Grado, char Seccion)
        {
            using (var conexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion))
            {
                conexion.Open();
                SqlCommand elcomando = new SqlCommand("usp_Matricula_DiversoPago_ReporteEspecifico", conexion);
                elcomando.CommandType = CommandType.StoredProcedure;
                elcomando.Parameters.AddWithValue("@parGrado", Grado);
                elcomando.Parameters.AddWithValue("@parSeccion", Seccion);
                SqlDataReader reader = elcomando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                conexion.Close();

                return table;
            }

        }
        public DataTable GenerarReporte_porGrado(char Grado)
        {
            using (var conexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion))
            {
                conexion.Open();
                SqlCommand elcomando = new SqlCommand("usp_Matricula_DiversoPago_ReporteporGrado", conexion);
                elcomando.CommandType = CommandType.StoredProcedure;
                elcomando.Parameters.AddWithValue("@parGrado", Grado);
                SqlDataReader reader = elcomando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                conexion.Close();

                return table;
            }
        }
        public DataTable GenerarReporteGeneral()
        {
            using (var conexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion))
            {
                conexion.Open();
                SqlCommand elcomando = new SqlCommand("usp_Matricula_DiversoPago_ReporteGeneral", conexion);
                elcomando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = elcomando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                conexion.Close();

                return table;
            }
        }
    }
}
