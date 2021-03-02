using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CN_Business_Layer
{
    public class clsDistrito
    {
        public short IdDistrito { get; set; }
        public string Nombre { get; set; }
        public clsProvincia Provincia { get; set; }

        public clsDistrito(short argIdDistrito, string argNombre, clsProvincia argProvincia)
        {
            IdDistrito = argIdDistrito;
            Nombre = argNombre;
            Provincia = argProvincia;
        }

        public static List<clsDistrito> listarDistritos(byte argIdProvincia)
        {
            List<clsDistrito> MilistaDistritos = new List<clsDistrito>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Distrito_listar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parIdProvincia", argIdProvincia);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsProvincia aux1 = new clsProvincia(Convert.ToByte(LOSDATOS["IdProvincia"]));
                clsDistrito filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsDistrito(
                           Convert.ToInt16(LOSDATOS["IdDistrito"]),
                           Convert.ToString(LOSDATOS["Nombre"]),
                           aux1
                                                );
                MilistaDistritos.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MilistaDistritos;
        }
    }
}
