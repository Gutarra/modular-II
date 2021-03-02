using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer;

namespace User_Interface_UI
{
    public class mdlVariablesAplicacion
    {
        public static clsUsuario UsuarioConectado;
        public static clsPeriodoAcademico PeriodoActual = clsPeriodoAcademico.listarPeriodo();
    }
}
