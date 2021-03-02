using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsFechaPago
    {
        public byte Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public clsFechaPago(byte argCodigo, DateTime argFechaVenc)
        {
            Codigo = argCodigo;
            FechaVencimiento = argFechaVenc;
        }
        public static List<clsFechaPago> ListarFechasActuales()
        {
            List<clsFechaPago> milistado = new List<clsFechaPago>();
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_FechaPago_listaractuales", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            while (LOSDATOS.Read() == true)
            {

                clsFechaPago filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsFechaPago(
                        Convert.ToByte(LOSDATOS["Codigo"]),
                        Convert.ToDateTime(LOSDATOS["FechaVenc"])
                    );
                milistado.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();
            return milistado;
        }
    }
}
