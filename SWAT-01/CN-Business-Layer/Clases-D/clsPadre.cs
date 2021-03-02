using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer.Clases;

namespace CN_Business_Layer.Clases_D
{
    public class clsPadre
    {
        public clsIdentificacion Identificacion_Codigo { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string NumeroCelular { get; set; }
        public string Trabajo { get; set; }
        public string Correo { get; set; }

        public clsPadre(            clsIdentificacion argIdCod,
                                    string argNDoc,                        
                                    string argNombre,
                                    string argDireccion,
                                    string argDistrito,
                                    string argProvincia,
                                    string argDepartamento,
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
            Provincia = argProvincia;
            Departamento = argDepartamento;
            NumeroCelular = argNumeroCel;
            Trabajo = argTrabajo;
            Correo = argCorreo;
        }
    }
}
