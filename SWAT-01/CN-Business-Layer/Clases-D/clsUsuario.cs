using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer.Clases;

namespace CN_Business_Layer.Clases_D
{
    public class clsUsuario
    {
        public clsIdentificacion Identificacion_Codigo { get; set; }
        public string NumDocumento { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
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
    }
}
