using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsPago
    {
        public long Numero { get; set; }
        public float Monto { get; set; }
        public DateTime Fecha { get; set; }

        public clsPago(long numero, float monto, DateTime fecha)
        {
            Numero = numero;
            Monto = monto;
            Fecha = fecha;
        }
        public clsPago(long numero)
        {
            Numero = numero;
        }

        public static clsPago Registrar(float argMonto)
        {
            clsPago miPago = null;
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Pagos_Registrar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parMonto", argMonto);

            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();


            while (LOSDATOS.Read() == true)
            {
                miPago = new clsPago(
                           Convert.ToInt64(LOSDATOS["Numero"]));
            }
            miConexion.Close();

            return miPago;
        }
        public void RegistrarMultiple(string argNumDoc,byte argMontoCodigo,
                                        byte argFechaCodigo, long argNumeroPago,
                                        float argMontoPagado)
        {
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_MultiplePago_Registrar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parEstudiante_NDocumeto", argNumDoc);
            elComando.Parameters.AddWithValue("@parMonto_Codigo", argMontoCodigo);
            elComando.Parameters.AddWithValue("@parFechaPago_Codigo", argFechaCodigo);
            elComando.Parameters.AddWithValue("@parPago_Numero", argNumeroPago);
            elComando.Parameters.AddWithValue("@parMontoPagado", argMontoPagado);

            miConexion.Open();
            elComando.ExecuteNonQuery();
            miConexion.Close();

        }
    }
}
