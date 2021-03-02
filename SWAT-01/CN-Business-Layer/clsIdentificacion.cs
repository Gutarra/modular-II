using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsIdentificacion
    {
        public byte codigo { get; set; }
        public string Nombre { get; set; }

        public clsIdentificacion(byte argCodigo, string argNombre)
        {
            codigo = argCodigo;
            Nombre = argNombre;
        }
        public clsIdentificacion(byte argCodigo)
        {
            codigo = argCodigo;
        }

        public static List<clsIdentificacion> Listar()
        {
            List<clsIdentificacion> MilistaIdentificaiones = new List<clsIdentificacion>();

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Identificacion_listar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsIdentificacion filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsIdentificacion(
                           Convert.ToByte(LOSDATOS["Codigo"]),
                           Convert.ToString(LOSDATOS["Nombre"])
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cliente a Milistado
                MilistaIdentificaiones.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return MilistaIdentificaiones;
        }

    }
}
