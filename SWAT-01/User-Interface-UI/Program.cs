using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface_UI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UI_Estudiantes_ModificarDatos());
            Application.Run(new UI_Login());
            if (mdlVariablesAplicacion.UsuarioConectado != null)
            {
                Application.Run(new UI_Bienvenida());
                Application.Run(new UI_Principal());
            }
        }
    }
}
