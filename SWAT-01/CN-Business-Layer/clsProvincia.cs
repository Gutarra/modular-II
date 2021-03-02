using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsProvincia
    {
        public byte IdProvincia { get; set; }
        public string Nombre { get; set; }
        public clsDepartemento Departamento { get; set; }

        public clsProvincia(byte argidProvincia, string argNombre, clsDepartemento argDepartamento)
        {
            IdProvincia = argidProvincia;
            Nombre = argNombre;
            Departamento = argDepartamento;
        }
        public clsProvincia(byte argidProvincia)
        {
            IdProvincia = argidProvincia;
        }

        public static List<clsProvincia> ListarProvincias(byte argDepartamento)
        {
            List<clsProvincia> MiListaProvincias = new List<clsProvincia>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Provincia_listar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parIdDepartemento", argDepartamento);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsDepartemento aux1 = new clsDepartemento(Convert.ToByte(LOSDATOS["IdDepartamento"]));
                clsProvincia filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsProvincia(
                           Convert.ToByte(LOSDATOS["IdProvincia"]),
                           Convert.ToString(LOSDATOS["Nombre"]),
                           aux1
                                                );
                MiListaProvincias.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MiListaProvincias;
        }
    }
}
