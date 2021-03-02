using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface_UI
{
    public partial class UI_Bienvenida : Form
    {
        public UI_Bienvenida()
        {
            InitializeComponent();
        }
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.04;
            circularProgressBar1.Value += 2;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            cont += 1;
            if (cont == 50)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;
            if (Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void UI_Bienvenida_Load(object sender, EventArgs e)
        {
            label2.Text = "Hola " + mdlVariablesAplicacion.UsuarioConectado.Nombres + "\n bienvenido ...";
            timer1.Start();
            circularProgressBar1.Value = 0;
        }
    }
}
