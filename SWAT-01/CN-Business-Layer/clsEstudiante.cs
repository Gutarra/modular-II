using CAD_Access_to_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;

namespace CN_Business_Layer
{
    public class clsEstudiante
    {
        public clsIdentificacion Identificacion_Codigo { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidosNombres { get; set; }
        public clsPadre PadreApoderado_NumDoc { get; set; }
        public clsPadre Padre_NumDoc { get; set; }
        public string ColegioProcedencia { get; set; }
        public float Peso { get; set; }
        public short Talla { get; set; }
        public string CondicionSalud { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }

        public clsEstudiante(clsIdentificacion argIdentificacion_Codigo, string argNumeroDocumento, string argApellidosNombres,
            clsPadre argPadreApoderado_NumDoc, clsPadre argPadre_NumDoc, string argColegioProcedencia, float argPeso, short argTalla, string argCondicionSalud, DateTime argFechaNacimineto, string argCelular)
        {
            Identificacion_Codigo = argIdentificacion_Codigo;
            NumeroDocumento = argNumeroDocumento;
            ApellidosNombres = argApellidosNombres;
            PadreApoderado_NumDoc = argPadreApoderado_NumDoc;
            Padre_NumDoc = argPadre_NumDoc;
            ColegioProcedencia = argColegioProcedencia;
            Peso = argPeso;
            Talla = argTalla;
            CondicionSalud = argCondicionSalud;
            FechaNacimiento = argFechaNacimineto;
            Celular = argCelular;
        }
        public clsEstudiante( string argNumeroDocumento, string argApellidosNombres)
        {
            NumeroDocumento = argNumeroDocumento;
            ApellidosNombres = argApellidosNombres;
        }
        public clsEstudiante( string argNumeroDocumento, string argApellidosNombres,
            string argColegioProcedencia, float argPeso, short argTalla,
            string argCondicionSalud, DateTime argFechaNacimineto, string argCelular)
        {
            NumeroDocumento = argNumeroDocumento;
            ApellidosNombres = argApellidosNombres;
            ColegioProcedencia = argColegioProcedencia;
            Peso = argPeso;
            Talla = argTalla;
            CondicionSalud = argCondicionSalud;
            FechaNacimiento = argFechaNacimineto;
            Celular = argCelular;
        }
        public clsEstudiante( string argNumeroDocumento, string argApellidosNombres,
            clsPadre argPadreApoderado_NumDoc, clsPadre argPadre_NumDoc, string argColegioProcedencia, float argPeso, short argTalla, string argCondicionSalud, DateTime argFechaNacimineto)
        {
            NumeroDocumento = argNumeroDocumento;
            ApellidosNombres = argApellidosNombres;
            PadreApoderado_NumDoc = argPadreApoderado_NumDoc;
            Padre_NumDoc = argPadre_NumDoc;
            ColegioProcedencia = argColegioProcedencia;
            Peso = argPeso;
            Talla = argTalla;
            CondicionSalud = argCondicionSalud;
            FechaNacimiento = argFechaNacimineto;
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
            elComando = new SqlCommand("usp_Estudiante_insertar", miConexion);

            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parId_codigo", Identificacion_Codigo.codigo); // LAVE FORANEA
            elComando.Parameters.AddWithValue("@parNdocumento", NumeroDocumento);
            elComando.Parameters.AddWithValue("@parApellidosNombres", ApellidosNombres);
            elComando.Parameters.AddWithValue("@parPadreAp_NDocumento", PadreApoderado_NumDoc.NumeroDocumento);
            if (Padre_NumDoc == null)
            {
                elComando.Parameters.AddWithValue("@parPadre_NDocumento", DBNull.Value);
            }
            else
            {
                elComando.Parameters.AddWithValue("@parPadre_NDocumento", Padre_NumDoc.NumeroDocumento);
            }
            elComando.Parameters.AddWithValue("@parColegioProcedencia", ColegioProcedencia);
            elComando.Parameters.AddWithValue("@parPeso", Peso);
            elComando.Parameters.AddWithValue("@parTalla", Talla);
            if (string.IsNullOrEmpty(CondicionSalud))
            {
                elComando.Parameters.AddWithValue("@parCondicionSalud", DBNull.Value);
            }
            else
            {
                elComando.Parameters.AddWithValue("@parCondicionSalud", CondicionSalud);
            }
            elComando.Parameters.AddWithValue("@parFechaNacimineto", FechaNacimiento);
            if (string.IsNullOrEmpty(Celular))
            {
                elComando.Parameters.AddWithValue("@parNumeroCelular", DBNull.Value);
            }
            else
            {
                elComando.Parameters.AddWithValue("@parNumeroCelular", Celular);
            }


            //Paso 03: Ejecutar el comando
            miConexion.Open(); //Abrir la conexión
            elComando.ExecuteNonQuery(); //Ejecutar el comando
            miConexion.Close(); //Cerrar la conexión

        }

        public static List<clsEstudiante> listar_por_NumeroDocumento(string argNumDoc)
        {
            List<clsEstudiante> milistado = new List<clsEstudiante>();
            SqlConnection miconeccion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elcomando = new SqlCommand("usp_Estudiante_listar_porDocumento", miconeccion);
            elcomando.CommandType = System.Data.CommandType.StoredProcedure;
            elcomando.Parameters.AddWithValue("@parNumDoc", argNumDoc);

            miconeccion.Open();
            SqlDataReader LosDatos = elcomando.ExecuteReader();
            while (LosDatos.Read() == true)
            {
                clsEstudiante fila = new clsEstudiante(
                    Convert.ToString(LosDatos["NDocumeto"]),
                    Convert.ToString(LosDatos["ApellidosNombres"])
                    );
                milistado.Add(fila);
            }
            miconeccion.Close();
            
            return milistado;
        }
        public static clsEstudiante Comprobar_siExiste(string argNDoc)
        {
            clsEstudiante elEstudiante = null;
            SqlConnection miconexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elcomando = new SqlCommand("usp_Estudiante_comprobar_siExiste", miconexion);
            elcomando.CommandType = System.Data.CommandType.StoredProcedure;
            elcomando.Parameters.AddWithValue("@parNumDoc", argNDoc);

            miconexion.Open();
            SqlDataReader LosDatos = elcomando.ExecuteReader();
            while (LosDatos.Read() == true)
            {
                elEstudiante = new clsEstudiante(
                    Convert.ToString(LosDatos["NDocumeto"]),
                    Convert.ToString(LosDatos["ApellidosNombres"]),
                    Convert.ToString(LosDatos["ColegioProcedencia"]),
                    Convert.ToSingle(LosDatos["Peso"]),
                    Convert.ToInt16(LosDatos["Talla"]),
                    Convert.ToString(LosDatos["CondicionSalud"]),
                    Convert.ToDateTime(LosDatos["FechaNacimiento"]),
                    Convert.ToString(LosDatos["NumeroCelular"])
                    );
            }
            miconexion.Close();

            return elEstudiante;
        }
        public static clsEstudiante MostrarDatos(string argNDoc)
        {
            clsEstudiante elEstudiante = null;
            SqlConnection miconexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elcomando = new SqlCommand("usp_Estudiante_mostrar", miconexion);
            elcomando.CommandType = System.Data.CommandType.StoredProcedure;
            elcomando.Parameters.AddWithValue("@parNumDoc", argNDoc);

            miconexion.Open();
            SqlDataReader LosDatos = elcomando.ExecuteReader();
            while (LosDatos.Read() == true)
            {
                clsPadre primerpadre = new clsPadre(Convert.ToString(LosDatos["Padre1"]));
                clsPadre segundopadre = null;
                if (LosDatos["Padre2"] != DBNull.Value)
                   segundopadre = new clsPadre(Convert.ToString(LosDatos["Padre2"]));
                elEstudiante = new clsEstudiante(
                    Convert.ToString(LosDatos["NDocumeto"]),
                    Convert.ToString(LosDatos["ApellidosNombres"]),
                    primerpadre,
                    segundopadre,
                    Convert.ToString(LosDatos["ColegioProcedencia"]),
                    Convert.ToSingle(LosDatos["Peso"]),
                    Convert.ToInt16(LosDatos["Talla"]),
                    Convert.ToString(LosDatos["CondicionSalud"]),
                    Convert.ToDateTime(LosDatos["FechaNacimiento"])
                    );
            }
            miconexion.Close();

            return elEstudiante;
        }
        public void ModificarDatos(String apellidosNombres, string colegio,float peso, short talla, string condicion, DateTime fecha,string celular)
        {
            SqlConnection miConexion;
            miConexion = new SqlConnection(mdlCadenaConeccion.MiCadenaConexion);
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Estudiante_Modificar", miConexion);

            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parNdocumento", NumeroDocumento);
            elComando.Parameters.AddWithValue("@parApellidosNombres", apellidosNombres);
            elComando.Parameters.AddWithValue("@parColegioProcedencia", colegio);
            elComando.Parameters.AddWithValue("@parPeso", peso);
            elComando.Parameters.AddWithValue("@parTalla", talla);
            if (string.IsNullOrEmpty(CondicionSalud))
                elComando.Parameters.AddWithValue("@parCondicionSalud", DBNull.Value);
            else
                elComando.Parameters.AddWithValue("@parCondicionSalud", condicion);
            
            elComando.Parameters.AddWithValue("@parFechaNacimineto", fecha);
            if (string.IsNullOrEmpty(Celular))
                elComando.Parameters.AddWithValue("@parNumeroCelular", DBNull.Value);
            else
                elComando.Parameters.AddWithValue("@parNumeroCelular", celular);


            miConexion.Open();
            elComando.ExecuteNonQuery();
            miConexion.Close();

        }
    }
}
