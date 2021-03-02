using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer.Clases;

namespace CN_Business_Layer.Clases_D
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
        public float Talla { get; set; }
        public string CondicionSalud { get; set; }

        public clsEstudiante(clsIdentificacion argIdentificacion_Codigo, string argNumeroDocumento, string argApellidosNombres,
            clsPadre argPadreApoderado_NumDoc, clsPadre argPadre_NumDoc, string argColegioProcedencia, float argPeso, float argTalla, string argCondicionSalud)
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
        }
    }
}
