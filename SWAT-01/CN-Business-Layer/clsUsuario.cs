using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsUsuario
    {
        public clsIdentificacion Identificacion_Codigo { get; set; }
        public string NumDocumento { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public clsDistrito Distrito { get; set; }
        public string Correo { get; set; }
        public clsCargo Cargo_Codigo { get; set; }

        public clsUsuario(clsIdentificacion argIdCod, string argNumDocumento,
                            string argUsername, string argPassword,
                            string argNombres, string argApellidos,
                            string argCorreo, clsCargo argCargoCod
            )
        {
            Identificacion_Codigo = argIdCod;
            NumDocumento = argNumDocumento;
            Username = argUsername;
            Password = argPassword;
            Nombres = argNombres;
            Apellidos = argApellidos;
            Correo = argCorreo;
            Cargo_Codigo = argCargoCod;
        }
        public clsUsuario(string argNumDocumento,
                            string argUsername, string argPassword,
                            string argNombres, string argApellidos,
                            string argCorreo, clsCargo argCargoCod)
        {
            NumDocumento = argNumDocumento;
            Username = argUsername;
            Password = argPassword;
            Nombres = argNombres;
            Apellidos = argApellidos;
            Correo = argCorreo;
            Cargo_Codigo = argCargoCod;
        }

        public static clsUsuario ValidarUsuario(string argNombreUsuario,
                                                    string argClave)
        {
            clsUsuario MiUsuario = null;

            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Usuario_Validar", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;

            elComando.Parameters.AddWithValue("@parusername", argNombreUsuario);
            elComando.Parameters.AddWithValue("@parpassword", argClave);


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            

            while (LOSDATOS.Read() == true)
            {
                clsCargo auxiliar1 = new clsCargo(Convert.ToString(LOSDATOS["Cargo"]));
                MiUsuario = new clsUsuario( 
                           Convert.ToString(LOSDATOS["NDocumento"]),
                           Convert.ToString(LOSDATOS["username"]), "CualquierCosa",
                           Convert.ToString(LOSDATOS["Nombres"]),
                           Convert.ToString(LOSDATOS["Apellidos"]),
                           Convert.ToString(LOSDATOS["Correo"]),
                           auxiliar1);
            }
            miConexion.Close();

            return MiUsuario;
        }
    }
}
