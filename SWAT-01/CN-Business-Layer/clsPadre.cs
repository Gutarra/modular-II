using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD_Access_to_Data;

namespace CN_Business_Layer
{
    public class clsPadre
    {
        public clsIdentificacion Identificacion_Codigo { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public clsDistrito Distrito { get; set; }
        public string NumeroCelular { get; set; }
        public string Trabajo { get; set; }
        public string Correo { get; set; }

        public clsPadre(string numeroDocumento, string nombreCompleto, string direccion, clsDistrito distrito, string numeroCelular, string trabajo, string correo) : this(numeroDocumento)
        {
            NombreCompleto = nombreCompleto;
            Direccion = direccion;
            Distrito = distrito;
            NumeroCelular = numeroCelular;
            Trabajo = trabajo;
            Correo = correo;
        }

        public clsPadre(            clsIdentificacion argIdCod,
                                    string argNDoc,                        
                                    string argNombre,
                                    string argDireccion,
                                    clsDistrito argDistrito,
                                    string argNumeroCel,
                                    string argTrabajo,
                                    string argCorreo
                                )
        {
            Identificacion_Codigo = argIdCod;
            NumeroDocumento = argNDoc;        
            NombreCompleto = argNombre;
            Direccion = argDireccion;
            Distrito = argDistrito;
            NumeroCelular = argNumeroCel;
            Trabajo = argTrabajo;
            Correo = argCorreo;
        }
        public clsPadre(clsIdentificacion argIdCod,
                                    string argNDoc,
                                    string argNombre,
                                    string argDireccion,
                                    string argNumeroCel,
                                    string argTrabajo,
                                    string argCorreo
                                )
        {
            Identificacion_Codigo = argIdCod;
            NumeroDocumento = argNDoc;
            NombreCompleto = argNombre;
            Direccion = argDireccion;
            NumeroCelular = argNumeroCel;
            Trabajo = argTrabajo;
            Correo = argCorreo;
        }

        public clsPadre(string numeroDocumento)
        {
            NumeroDocumento = numeroDocumento;
        }

        public void Insertar()
        {
            //Paso 01: Crear la conexión
            SqlConnection miConexion;
            // Servidor, Base de datos y modo de autenticación
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            //miConexion = new SqlConnection("SERVER=WA27-2;DATABASE=EjercicioSemanaCero;Integrated security=true");

            //Paso 02: Definir el comando (Qué harás en la BD?)
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Padre_insertar", miConexion);
            //Con esta línea le indico al Visual Studio que se trata de un P.A.

            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            //CUIDADO - Recuerda -------- PARA TU EXAMEN.........
            elComando.Parameters.AddWithValue("@parId_codigo", Identificacion_Codigo.codigo);
            //CUIDADO - Recuerda -------- PARA TU EXAMEN.........
            elComando.Parameters.AddWithValue("@parNdocumento", NumeroDocumento);
            elComando.Parameters.AddWithValue("@parNombreCompleto", NombreCompleto);
            elComando.Parameters.AddWithValue("@parDireccion", Direccion);
            elComando.Parameters.AddWithValue("@parDistrito", Distrito.IdDistrito);
            elComando.Parameters.AddWithValue("@parNumeroCelular", NumeroCelular);
            elComando.Parameters.AddWithValue("@parTrabajo", Trabajo);
            //Como el correo permite valores NULL, se tiene que verificar 
            //el valor ingresado
            if (string.IsNullOrEmpty(Correo))
            {
                elComando.Parameters.AddWithValue("@parCorreo", DBNull.Value);
            }
            else
            {
                elComando.Parameters.AddWithValue("@parCorreo", Correo);
            }
            

            //Paso 03: Ejecutar el comando
            miConexion.Open(); //Abrir la conexión
            elComando.ExecuteNonQuery(); //Ejecutar el comando
            miConexion.Close(); //Cerrar la conexión

        }
        public static List<clsPadre> listar_porDNI(string argDNI)
        {
            List<clsPadre> milistado = new List<clsPadre>();
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Padre_Listar_por_DNI_o_NumeroDocumento", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parNumeroDoc", argDNI);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsIdentificacion aux1 = new clsIdentificacion(Convert.ToByte(LOSDATOS["Identificacion_Codigo"]));

                clsPadre filaDeBaseDeDatos;
                filaDeBaseDeDatos = new clsPadre(
                        aux1,
                        Convert.ToString(LOSDATOS["NDocumento"]),
                        Convert.ToString(LOSDATOS["NombreCompleto"]),
                        Convert.ToString(LOSDATOS["Direccion"]),
                        Convert.ToString(LOSDATOS["NumeroCelular"]),
                        Convert.ToString(LOSDATOS["Trabajo"]),
                        Convert.ToString(LOSDATOS["Correo"])
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cliente a Milistado
                milistado.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();
            return milistado;
        }
        public static clsPadre Padre_Comprobar_siExiste(string argDNI)
        {
            clsPadre mipadre = null;
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Padre_comprobar_siExiste", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parNumDoc", argDNI);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsIdentificacion aux1 = new clsIdentificacion(Convert.ToByte(LOSDATOS["Identificacion_Codigo"]));

                mipadre = new clsPadre(
                        aux1,
                        Convert.ToString(LOSDATOS["NDocumento"]),
                        Convert.ToString(LOSDATOS["NombreCompleto"]),
                        Convert.ToString(LOSDATOS["Direccion"]),
                        Convert.ToString(LOSDATOS["NumeroCelular"]),
                        Convert.ToString(LOSDATOS["Trabajo"]),
                        Convert.ToString(LOSDATOS["Correo"])
                                                );
            }
            miConexion.Close();
            return mipadre;
        }
        public static clsPadre MostrarDatos(string argDNI)
        {
            clsPadre mipadre = null;
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Padre_mostrar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parNumDoc", argDNI);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                clsDepartemento departemento = new clsDepartemento(
                    Convert.ToByte(LOSDATOS["IDDep"]),
                    Convert.ToString(LOSDATOS["DepNombre"]));
                clsProvincia provincia = new clsProvincia(
                    Convert.ToByte(LOSDATOS["IDProvincia"]), 
                    Convert.ToString(LOSDATOS["PNombre"]),
                    departemento);
                clsDistrito distrito = new clsDistrito(
                    Convert.ToInt16(LOSDATOS["Distrito"]),
                    Convert.ToString(LOSDATOS["DNombre"]),
                    provincia);

                mipadre = new clsPadre(
                        Convert.ToString(LOSDATOS["NDocumento"]),
                        Convert.ToString(LOSDATOS["NombreCompleto"]),
                        Convert.ToString(LOSDATOS["Direccion"]),
                        distrito,
                        Convert.ToString(LOSDATOS["NumeroCelular"]),
                        Convert.ToString(LOSDATOS["Trabajo"]),
                        Convert.ToString(LOSDATOS["Correo"])
                                                );
            }
            miConexion.Close();
            return mipadre;
        }
        public void ModificarDatos(string nombreCompleto,string direccion, short idDistrito,string celular, string trabajo,string correo)
        {
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Padre_Modificar", miConexion);

            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parNdocumento", NumeroDocumento);
            elComando.Parameters.AddWithValue("@parNombreCompleto", nombreCompleto);
            elComando.Parameters.AddWithValue("@parDireccion", direccion);
            elComando.Parameters.AddWithValue("@parDistrito", idDistrito);
            elComando.Parameters.AddWithValue("@parNumeroCelular", celular);
            elComando.Parameters.AddWithValue("@parTrabajo", trabajo);
            if (string.IsNullOrEmpty(Correo))
                elComando.Parameters.AddWithValue("@parCorreo", DBNull.Value);
            else
                elComando.Parameters.AddWithValue("@parCorreo", correo);


            miConexion.Open();
            elComando.ExecuteNonQuery();
            miConexion.Close();

        }
    }
}
