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
    public partial class UI_Estudiantes : Form
    {
        public UI_Estudiantes()
        {
            InitializeComponent();
        }
        #region AbrirFormularios o formulario menu
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["UI_Estudiantes_NuevoEstudiante"] == null)
                btnNuevoEstudiante.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Estudiantes_ModificarDatos"] == null)
                btnModificarDatos.BackColor = Color.Transparent;

            panelMenu.Width = 200;
        }
        private void CloseForms2()
        {
             if (Application.OpenForms["UI_Estudiantes_NuevoEstudiante"] == null)
                 btnNuevoEstudiante.BackColor = Color.Transparent;
             if (Application.OpenForms["UI_Estudiantes_ModificarDatos"] == null)
                 btnModificarDatos.BackColor = Color.Transparent;

            panelMenu.Width = 200;
        }
        #endregion
        private void btnMenuHiden_Click(object sender, EventArgs e)
        {
            switch (panelMenu.Width)
            {
                case 40:
                    panelMenu.Width = 200;
                    break;
                default:
                    panelMenu.Width = 40;
                    break;
            }
        }
        #region al seleccionar un boton
        private Button BotonActual;
        private void Activebtn(object senderbtn)
        {
            if (senderbtn != null)
            {
                Disablebutton();
                BotonActual = (Button)senderbtn;
                BotonActual.BackColor = Color.FromArgb(189, 204, 64);
                //panelMenuPrincipal.Tag = current.Text;
            }

        }
        private void Disablebutton()
        {
            if (BotonActual != null)
            {
                BotonActual.BackColor = Color.FromArgb(144, 162, 47);
                CloseForms2();
            }
        }
        private void mensaje_al_salir_o_camcelar(string message, string caption)
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (caption == "Cancelar")
                { }
                // Closes the parent form.
                if (caption == "Cerrar")
                    this.Close();
            }
        }
        #endregion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["UI_Estudiantes_NuevoEstudiante"] == null)
                || (Application.OpenForms["UI_Estudiantes_ModificarDatos"] == null))
                this.Close();
            else
                mensaje_al_salir_o_camcelar("Ventanas en uso \nEsta Seguro de Cerrar?", "Cerrar");
        }

        private void btnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            Disablebutton();
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Estudiantes_NuevoEstudiante>();
        }
        

        private void btnModificarDatos_Click(object sender, EventArgs e)
        {
            Disablebutton();
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Estudiantes_ModificarDatos>();
        }

        private void UI_Estudiantes_Load(object sender, EventArgs e)
        {
            panelMenu.Width = 200;
        }
    }
}
