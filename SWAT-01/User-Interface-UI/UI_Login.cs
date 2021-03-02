using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CN_Business_Layer;

namespace User_Interface_UI
{
    public partial class UI_Login : Form
    {
        public UI_Login()
        {
            InitializeComponent();
        }
        #region Mover formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "user_name")
            {
                txtusername.Text = "";
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "user_name";
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "password")
            {
                txtpassword.Text = "";
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "password";
                txtpassword.UseSystemPasswordChar = false;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "user_name")
            {
                if (txtpassword.Text != "password" && txtpassword.Text.Length >= 1)
                {
                    clsUsuario elusuario = clsUsuario.ValidarUsuario(txtusername.Text, txtpassword.Text);
                    if (elusuario != null)
                    {
                        mdlVariablesAplicacion.UsuarioConectado = elusuario;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o clave incorrecta.");
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese su contraseña.");
                    txtpassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese su nombre de usuario.");
                txtusername.Focus();
            }
        }
    }
}
