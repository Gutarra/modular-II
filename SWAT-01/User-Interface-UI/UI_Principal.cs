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

namespace User_Interface_UI
{
    public partial class UI_Principal : Form
    {
        public UI_Principal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            #region mostrar mensajes de los elementos
            //var InfobtnEstudiante = new ToolTip();
            //InfobtnEstudiante.SetToolTip([elemento], "Texto a mostrar");
            #endregion
        }

    #region Funciones del formulario
        #region Redimencionar Formulario
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.PanelContenedor.Region = region;
            this.Invalidate();
        }
        #endregion
        #region botones de formulario
        int lx, ly;
        int sw, sh; 
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["UI_Pagos_RegistrarPagos"] == null)
                && (Application.OpenForms["UI_Pagos_Prorroga"] == null)
                && (Application.OpenForms["UI_Estudiantes_NuevoEstudiante"] == null)
                && (Application.OpenForms["UI_Estudiantes_ModificarDatos"] == null)
                && (Application.OpenForms["UI_Reportes_ReportePagos"] == null))
            Application.Exit();
            else
            {
                mensaje_al_salir_o_camcelar("hay ventanas en uso ... \nEsta Seguro de Cerrar ?", "Cerrar");
            }
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
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
                this.Close();
            }
        }
        #endregion
        #region Mover Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        #endregion
        #region AbrirFormularios o formulario menu
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelContenedor.Controls.Add(formulario);
                PanelContenedor.Tag = formulario;
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
            if (Application.OpenForms["UI_Estudiantes"] == null)
                btnEstudiantes.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Ajustes"] == null)
                btnAjustes.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Pagos"] == null)
                btnPagos.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Reportes"] == null)
                btnReportes.BackColor = Color.Transparent;
        }
        private void CloseForms2()
        {
            if (Application.OpenForms["UI_Estudiantes"] == null)
                btnEstudiantes.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Ajustes"] == null)
                btnAjustes.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Pagos"] == null)
                btnPagos.BackColor = Color.Transparent;
            if (Application.OpenForms["UI_Reportes"] == null)
                btnReportes.BackColor = Color.Transparent;
        }
        #endregion
        #region Menu desplegable
        private void btnMenuHiden_Click(object sender, EventArgs e)
        {
            switch (panelMenu.Width)
            {
                case 40:
                    panelMenu.Width = 190;
                    break;
                default:
                    panelMenu.Width = 40;
                    break;
            }
        }
        #endregion
        #region al seleccionar menu principal
        private Button BotonActual;
        private void Activebtn(object senderbtn)
        {
            if (senderbtn != null)
            {
                Disablebutton();
                BotonActual = (Button)senderbtn;
                BotonActual.BackColor = Color.FromArgb(129, 138, 8);
                //panelMenuPrincipal.Tag = current.Text;
            }

        }
        private void Disablebutton()
        {
            if (BotonActual != null)
            {
                BotonActual.BackColor = Color.FromArgb(71, 80, 21);
                CloseForms2();
            }
        }
        #endregion
    #endregion
        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Estudiantes>();
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Reportes>();
        }
        private void btnAjustes_Click(object sender, EventArgs e)
        {
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Ajustes>();
        }
        private void btnPagos_Click(object sender, EventArgs e)
        {
            Activebtn(sender);
            panelMenu.Width = 40;
            AbrirFormulario<UI_Pagos>();
        }
        #region Valores al cargar
        private void UI_Principal_Load(object sender, EventArgs e)
        {
            lblusuario.Text = mdlVariablesAplicacion.UsuarioConectado.Nombres +
                " (" + mdlVariablesAplicacion.UsuarioConectado.Cargo_Codigo.Nombre + ")";
            panelMenu.Width = 190;
            btnDashBoard_Click(sender,e);
        }

        #endregion
        #region DashBoard
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ReiniciarFormulario<UI_DashBoard>();
        }
        private void ReiniciarFormulario<MiForm>() where MiForm : UI_DashBoard, new()
        {
            UI_DashBoard formulario;
            formulario = PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelContenedor.Controls.Add(formulario);
                PanelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
                formulario.Ver_Vacantes();
            }
        }
        #endregion


    }
}
