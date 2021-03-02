using CN_Business_Layer;
using CN_Business_Layer.Report;
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
    public partial class UI_Reportes_ReportePagos : Form
    {
        private bool ischanged = false;

        public UI_Reportes_ReportePagos()
        {
            InitializeComponent();
        }

        private void Cargarcombos()
        {
            cmbGrado.Items.Clear();
            cmbGradoEspecifico.Items.Clear();
            foreach (clsGradoAcademico item in clsGradoAcademico.ListarGrados())
            {
                cmbGrado.Items.Add(item.Grado);
                cmbGradoEspecifico.Items.Add(item.Grado);
            }
            cmbSeccion.Text = "selecione grado ...";
        }

        private void GenerarReporteEspecifico(char grado, char seccion)
        {
            panelReportesGenerales.Visible = false;
            panelReportesGenerales.Enabled = false;
            panelReporteEspecifico.Visible = true;
            panelReporteEspecifico.Enabled = true;
            ReportePagos reporte = new ReportePagos();
            reporte.CrearReporteEspecifico(grado, seccion);
            ReportePagosBindingSource.DataSource = reporte;
            EstudiantePagosBindingSource.DataSource = reporte.ListaEstudiantePagos;
            MontoBindingSource.DataSource = reporte.ListaMontos;
            PorcentajeBindingSource.DataSource = reporte.ListaPorcentaje;
            this.ischanged = true;
            rpvPagos.RefreshReport();
        }
        private void GenerarReporteporGrado(char grado)
        {
            panelReportesGenerales.Visible = true;
            panelReportesGenerales.Enabled = true;
            panelReporteEspecifico.Visible = false;
            panelReporteEspecifico.Enabled = false;
            ReportePagos reporte = new ReportePagos();
            reporte.CrearReporteporGrado(grado);
            ReportePagosBindingSource.DataSource = reporte;
            EstudiantePagosBindingSource.DataSource = reporte.ListaEstudiantePagos;
            MontoBindingSource.DataSource = reporte.ListaMontos;
            PorcentajeBindingSource.DataSource = reporte.ListaPorcentaje;
            this.ischanged = true;
            rptvGenerales.RefreshReport();
        }

        private void GenerarReporteGeneral()
        {
            panelReportesGenerales.Visible = true;
            panelReportesGenerales.Enabled = true;
            panelReporteEspecifico.Visible = false;
            panelReporteEspecifico.Enabled = false;
            ReportePagos reporte = new ReportePagos();
            reporte.CrearReporteGeneral();
            ReportePagosBindingSource.DataSource = reporte;
            EstudiantePagosBindingSource.DataSource = reporte.ListaEstudiantePagos;
            MontoBindingSource.DataSource = reporte.ListaMontos;
            PorcentajeBindingSource.DataSource = reporte.ListaPorcentaje;
            this.ischanged = true;
            rptvGenerales.RefreshReport();
        }

        private void prueba_Load(object sender, EventArgs e)
        {
            Cargarcombos();
            ocultarmenus();
            this.rptvGenerales.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocultarmenus();
            panelGrado.Height = 140;
            btncrearGrado.Enabled = true;
            cmbGrado.Enabled = true;
        }

        private void btnEspecifico_Click(object sender, EventArgs e)
        {
            ocultarmenus();
            panelGradoSeccion.Height = 180;
            cmbGradoEspecifico.Enabled = true;
            cmbSeccion.Enabled = true;
            btncrearEspecifico.Enabled = true;
        }

        private void cmbGradoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSeccion.Items.Clear();
            char gradoselectcionado = Convert.ToChar(cmbGradoEspecifico.Text);
            foreach (clsGradoAcademico item in clsGradoAcademico.ListarSecciones_porgrado(gradoselectcionado))
            {
                cmbSeccion.Items.Add(item.Seccion);
            }
        }

        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            char grado = Convert.ToChar(cmbGradoEspecifico.Text);
            char seccion = Convert.ToChar(cmbSeccion.Text);
            GenerarReporteEspecifico(grado,seccion);
        }

        private void btncrearEspecifico_Click(object sender, EventArgs e)
        {
            if (cmbGradoEspecifico.SelectedIndex < 0)
            {
                MessageBox.Show("seleccione grado");
            }
            else
            {
                if (cmbSeccion.SelectedIndex < 0)
                {
                    MessageBox.Show("seleccione sección");
                }
                else
                {
                    char grado = Convert.ToChar(cmbGradoEspecifico.Text);
                    char seccion = Convert.ToChar(cmbSeccion.Text);
                    GenerarReporteEspecifico(grado, seccion);
                }
            }
        }
        private void ocultarmenus()
        {
            panelGradoSeccion.Height = 43;
            panelGrado.Height = 43;
            cmbGrado.Enabled = false;
            cmbGradoEspecifico.Enabled = false;
            cmbSeccion.Enabled = false;
            btncrearEspecifico.Enabled = false;
            btncrearGrado.Enabled = false;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            ocultarmenus();
            GenerarReporteGeneral();
        }

        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            char grado = Convert.ToChar(cmbGrado.Text);
            GenerarReporteporGrado(grado);
        }

        private void btncrearGrado_Click(object sender, EventArgs e)
        {
            if (cmbGrado.SelectedIndex < 0)
            {
                MessageBox.Show("selecione Grado Por favor");
            }
            else
            {
                char grado = Convert.ToChar(cmbGrado.Text);
                GenerarReporteporGrado(grado);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (this.ischanged)
            {
                DialogResult result;
                result = MessageBox.Show("Desea Cancelar Operacion ? \nEs posible que se pierdan los cambios realizados", "Cerrar", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }
    }
}
