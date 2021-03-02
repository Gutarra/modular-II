using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsDepartemento
    {
        public byte IdDepartemento { get; set; }
        public string Nombre { get; set; }

        public clsDepartemento(byte argIdDepartamento, string argNombre)
        {
            IdDepartemento = argIdDepartamento;
            Nombre = argNombre;
        }
        public clsDepartemento(byte argIdDepartamento)
        {
            IdDepartemento = argIdDepartamento;
        }

        public static List<clsDepartemento> listar()
        {
            List<clsDepartemento> MilistaDepartamentos = new List<clsDepartemento>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Departamento_listar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsDepartemento filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsDepartemento(
                           Convert.ToByte(LOSDATOS["IdDepartamento"]),
                           Convert.ToString(LOSDATOS["Nombre"])
                                                );
                MilistaDepartamentos.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MilistaDepartamentos;
        }
    }
}
