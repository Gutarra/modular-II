using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD_Access_to_Data;

namespace CN_Business_Layer
{
    public class clsCargo
    {
        public byte Codigo { get; set; }
        public string Nombre { get; set; }

        public clsCargo(byte argCodigo, string argNombre)
        {
            Codigo = argCodigo;
            Nombre = argNombre;
        }
        public clsCargo(string argNombre)
        {
            Nombre = argNombre;
        }

        public static List<clsCargo> ListarCargos()
        {
            List<clsCargo> Lista = new List<clsCargo>();

            SqlConnection miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Cargo_Listar_todo", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;

            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsCargo filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsCargo(
                           Convert.ToByte(LOSDATOS["CodCargo"]),
                           Convert.ToString(LOSDATOS["Nombre"])
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cargo a LisataCaros
                Lista.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();


            return Lista;
        }
    }
}
