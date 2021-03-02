using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularProgressBar;
using CN_Business_Layer;

namespace User_Interface_UI
{
    public partial class UI_DashBoard : Form
    {
        List<string> Grados = new List<string>() { "1", "2", "3", "4", "5" };
        public UI_DashBoard()
        {
            InitializeComponent();
        }

        private void UI_DashBoard_Load(object sender, EventArgs e)
        {
            Ver_Vacantes();
        }
        public void Ver_Vacantes()
        {
            List<byte> Capacidad = new List<byte>();
            List<byte> Matriculados = new List<byte>();
            List<byte> Vacantes = new List<byte>();
            foreach (string grado in Grados)
            {
                foreach (DatosGenerales.dtblEstdMatriculadosRow Elementos in clsPeriodoAcademico.VerVacantes(grado))
                {
                    Capacidad.Add(Elementos.Capacidad);
                    Matriculados.Add(Elementos.Matriculados);
                    Vacantes.Add(Convert.ToByte(Elementos.Capacidad - Elementos.Matriculados));
                }
            }
            #region mostrar Datos
            cpb1A.Maximum = Capacidad[0];
            cpb1A.Value = Matriculados[0];
            cpb1A.Text = Matriculados[0].ToString() + "/" + Capacidad[0].ToString();
            lbl1A.Text = "Disponible " + Vacantes[0].ToString();

            cpb1B.Maximum = Capacidad[1];
            cpb1B.Value = Matriculados[1];
            cpb1B.Text = Matriculados[1].ToString() + "/" + Capacidad[1].ToString();
            lbl1B.Text = "Disponible " + Vacantes[1].ToString();

            cpb1C.Maximum = Capacidad[2];
            cpb1C.Value = Matriculados[2];
            cpb1C.Text = Matriculados[2].ToString() + "/" + Capacidad[2].ToString();
            lbl1C.Text = "Disponible " + Vacantes[2].ToString();

            cpb2A.Maximum = Capacidad[3];
            cpb2A.Value = Matriculados[3];
            cpb2A.Text = Matriculados[3].ToString() + "/" + Capacidad[3].ToString();
            lbl2A.Text = "Disponible " + Vacantes[3].ToString();

            cpb2B.Maximum = Capacidad[4];
            cpb2B.Value = Matriculados[4];
            cpb2B.Text = Matriculados[4].ToString() + "/" + Capacidad[4].ToString();
            lbl2B.Text = "Disponible " + Vacantes[4].ToString();

            cpb2C.Maximum = Capacidad[5];
            cpb2C.Value = Matriculados[5];
            cpb2C.Text = Matriculados[5].ToString() + "/" + Capacidad[5].ToString();
            lbl2C.Text = "Disponible " + Vacantes[5].ToString();

            cpb3A.Maximum = Capacidad[6];
            cpb3A.Value = Matriculados[6];
            cpb3A.Text = Matriculados[6].ToString() + "/" + Capacidad[6].ToString();
            lbl3A.Text = "Disponible " + Vacantes[6].ToString();

            cpb3B.Maximum = Capacidad[7];
            cpb3B.Value = Matriculados[7];
            cpb3B.Text = Matriculados[7].ToString() + "/" + Capacidad[7].ToString();
            lbl3B.Text = "Disponible " + Vacantes[7].ToString();

            cpb3C.Maximum = Capacidad[8];
            cpb3C.Value = Matriculados[8];
            cpb3C.Text = Matriculados[8].ToString() + "/" + Capacidad[8].ToString();
            lbl3C.Text = "Disponible " + Vacantes[8].ToString();

            cpb4A.Maximum = Capacidad[9];
            cpb4A.Value = Matriculados[9];
            cpb4A.Text = Matriculados[9].ToString() + "/" + Capacidad[9].ToString();
            lbl4A.Text = "Disponible " + Vacantes[9].ToString();

            cpb4B.Maximum = Capacidad[10];
            cpb4B.Value = Matriculados[10];
            cpb4B.Text = Matriculados[10].ToString() + "/" + Capacidad[10].ToString();
            lbl4B.Text = "Disponible " + Vacantes[10].ToString();

            cpb4C.Maximum = Capacidad[11];
            cpb4C.Value = Matriculados[11];
            cpb4C.Text = Matriculados[11].ToString() + "/" + Capacidad[11].ToString();
            lbl4C.Text = "Disponible " + Vacantes[11].ToString();

            cpb5A.Maximum = Capacidad[12];
            cpb5A.Value = Matriculados[12];
            cpb5A.Text = Matriculados[12].ToString() + "/" + Capacidad[12].ToString();
            lbl5A.Text = "Disponible " + Vacantes[12].ToString();

            cpb5B.Maximum = Capacidad[13];
            cpb5B.Value = Matriculados[13];
            cpb5B.Text = Matriculados[13].ToString() + "/" + Capacidad[13].ToString();
            lbl5B.Text = "Disponible " + Vacantes[13].ToString();

            cpb5C.Maximum = Capacidad[14];
            cpb5C.Value = Matriculados[14];
            cpb5C.Text = Matriculados[14].ToString() + "/" + Capacidad[14].ToString();
            lbl5C.Text = "Disponible " + Vacantes[14].ToString();
            #endregion

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Ver_Vacantes();
        }
    }
}
