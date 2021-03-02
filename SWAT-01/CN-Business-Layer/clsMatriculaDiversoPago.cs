using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CN_Business_Layer
{
    public class clsMatriculaDiversoPago
    {
        public clsMatricula Matricula_Estudiante_NumDocuemnto { get; set; }
        public clsMonto Monto_codigo { get; set; }
        public clsFechaPago Fechapago_Codigo { get; set; }
        public byte Prorroga { get; set; }
        public clsEstadoPago EstadoPago_Codigo { get; set; }
        public float Deuda { get; set; }

        public clsMatriculaDiversoPago()
        {

        }

        public clsMatriculaDiversoPago(clsMatricula matricula_Estudiante_NumDocuemnto,
                                        clsFechaPago fechapago_Codigo,
                                        clsEstadoPago estadoPago_Codigo,
                                        float deuda)
        {
            Matricula_Estudiante_NumDocuemnto = matricula_Estudiante_NumDocuemnto;
            Fechapago_Codigo = fechapago_Codigo;
            EstadoPago_Codigo = estadoPago_Codigo;
            Deuda = deuda;
        }

        public static DatosGenerales.dtblDiversosPagosDataTable listarPagos_porEstudiante_NumDoc(string argNumDoc)
        {
            DatosGenerales.dtblDiversosPagosDataTable MitablaDeResultados = new DatosGenerales.dtblDiversosPagosDataTable();
            SqlConnection miconexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elcomando = new SqlCommand("usp_MatriculaDiversoPago_listar_porEstudiante", miconexion);
            elcomando.CommandType = System.Data.CommandType.StoredProcedure;
            elcomando.Parameters.AddWithValue("@parNumDoc", argNumDoc);

            miconexion.Open();
            SqlDataReader LOSDATOS = elcomando.ExecuteReader();
            while (LOSDATOS.Read() == true)
            {
                DataRow fila = MitablaDeResultados.NewRow();
                fila["EstudianteNumeroDoc"] = Convert.ToString(LOSDATOS["Estudiante_NDocumeto"]);
                fila["DetallePago"] = Convert.ToString(LOSDATOS["Detalle"]);
                fila["FechaVencimiento"] = Convert.ToString(LOSDATOS["FV"]);
                fila["Descripcion"] = Convert.ToString(LOSDATOS["Descripcion"]);
                if (LOSDATOS["Monto"] == DBNull.Value)
                    fila["Monto"] = Convert.ToString(LOSDATOS["DEF"]);
                else
                    fila["Monto"] = Convert.ToString(LOSDATOS["Monto"]);
                fila["CodigoMonto"] = Convert.ToByte(LOSDATOS["MontoCodigo"]);
                fila["CodigoFecha"] = Convert.ToByte(LOSDATOS["FechaCodigo"]);
                fila["Prorroga"] = Convert.ToByte(LOSDATOS["Prorroga"]);

                MitablaDeResultados.Rows.Add(fila);
            }
            miconexion.Close();

            return MitablaDeResultados;
        }
        public static DatosGenerales.dtblDiversosPagosDataTable listarPagosSinPagar_porEstudiante_NumDoc(string argNumDoc)
        {
            DatosGenerales.dtblDiversosPagosDataTable MitablaDeResultados = new DatosGenerales.dtblDiversosPagosDataTable();
            SqlConnection miconexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elcomando = new SqlCommand("usp_MatriculaDiversoPago_listar_SinPagar_porEstudiante", miconexion);
            elcomando.CommandType = System.Data.CommandType.StoredProcedure;
            elcomando.Parameters.AddWithValue("@parNumDoc", argNumDoc);

            miconexion.Open();
            SqlDataReader LOSDATOS = elcomando.ExecuteReader();
            while (LOSDATOS.Read() == true)
            {
                DataRow fila = MitablaDeResultados.NewRow();
                fila["EstudianteNumeroDoc"] = Convert.ToString(LOSDATOS["Estudiante_NDocumeto"]);
                fila["DetallePago"] = Convert.ToString(LOSDATOS["Detalle"]);
                fila["FechaVencimiento"] = Convert.ToString(LOSDATOS["FV"]);
                fila["Descripcion"] = Convert.ToString(LOSDATOS["Descripcion"]);
                if (LOSDATOS["Monto"] == DBNull.Value)
                    fila["Monto"] = Convert.ToString(LOSDATOS["DEF"]);
                else
                    fila["Monto"] = Convert.ToString(LOSDATOS["Monto"]);
                fila["CodigoMonto"] = Convert.ToByte(LOSDATOS["MontoCodigo"]);
                fila["CodigoFecha"] = Convert.ToByte(LOSDATOS["FechaCodigo"]);
                fila["Prorroga"] = Convert.ToByte(LOSDATOS["Prorroga"]);

                MitablaDeResultados.Rows.Add(fila);
            }
            miconexion.Close();

            return MitablaDeResultados;
        }
        public void AsignarProrroga(string argEstudianteNumDoc,
                                    byte argMontoCodigo,
                                    byte argFechaCodigo,
                                    byte argDias)
        {
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Matricula_DiversoPago_Asignarprorroga", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parEstudiante_NDocumeto", argEstudianteNumDoc);
            elComando.Parameters.AddWithValue("@parMonto_Codigo", argMontoCodigo);
            elComando.Parameters.AddWithValue("@parFechaPago_Codigo", argFechaCodigo);
            elComando.Parameters.AddWithValue("@parDias", argDias);

            miConexion.Open();
            elComando.ExecuteNonQuery();
            miConexion.Close();

        }
    }
}
