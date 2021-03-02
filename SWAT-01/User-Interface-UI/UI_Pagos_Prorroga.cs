using CN_Business_Layer;
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
    public partial class UI_Pagos_Prorroga : Form
    {
        #region Listas en formulario
        private DatosGenerales.dtblDiversosPagosDataTable _ListadePago = new DatosGenerales.dtblDiversosPagosDataTable();

        public DatosGenerales.dtblDiversosPagosDataTable ListadePago
        {
            get { return _ListadePago; }
            set { _ListadePago = value; }
        }


        private DatosGenerales.dtblDiversosPagosDataTable _SinCancelar = new DatosGenerales.dtblDiversosPagosDataTable();

        public DatosGenerales.dtblDiversosPagosDataTable SinCancelar
        {
            get { return _SinCancelar; }
            set { _SinCancelar = value; }
        }

        private List<clsEstudiante> _Estudiantes = new List<clsEstudiante>();

        public List<clsEstudiante> Estudiantes
        {
            get { return _Estudiantes; }
            set { _Estudiantes = value; }
        }

        #endregion
        public UI_Pagos_Prorroga()
        {
            InitializeComponent();
        }

        private bool ischanged = false;
        private void Reset()
        {
            txtEstudianteNumeroDocumento.Focus();
            panelRegistroPago.Visible = true;
            Mostrar_Ocultar();
            ischanged = false;
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

        public string estudianteseleccionado = "";
        private void txtEstudianteNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudianteNumeroDocumento.Text.Length >= 6)
            {
                Estudiantes.Clear();
                lstEstudiantes.Items.Clear();
                int contador = 0;
                foreach (clsEstudiante item in clsEstudiante.listar_por_NumeroDocumento(txtEstudianteNumeroDocumento.Text))
                {
                    lstEstudiantes.Items.Add(item.ApellidosNombres);
                    lstEstudiantes.Items[contador].SubItems.Add(item.NumeroDocumento);
                    Estudiantes.Add(item);
                    contador += 1;
                }
            }
            else
            {
                lstEstudiantes.Items.Clear();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtEstudianteNumeroDocumento_TextChanged(sender, e);
        }

        private void lstEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSeleccionar.Enabled = true;
            AcceptButton = btnSeleccionar;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            labelEstudiante.Text = Estudiantes[lstEstudiantes.SelectedIndices[0]].ApellidosNombres + " - " +
                Estudiantes[lstEstudiantes.SelectedIndices[0]].NumeroDocumento;
            estudianteseleccionado = lstEstudiantes.SelectedItems[0].SubItems[1].Text;
            MostrarDatos();
            Mostrar_Ocultar();
        }

        private void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            txtEstudianteNumeroDocumento.Text = "";
            btnSeleccionar.Enabled = false;
            Mostrar_Ocultar();
        }

        private void MostrarDatos()
        {
            lstPagos.Items.Clear();
            SinCancelar.Rows.Clear();
            ListadePago.Rows.Clear();
            int contador = 0;
            SinCancelar = clsMatriculaDiversoPago.listarPagosSinPagar_porEstudiante_NumDoc(estudianteseleccionado);
            byte ultimomes = SinCancelar[0].CodigoFecha;
            foreach (DatosGenerales.dtblDiversosPagosRow item in SinCancelar)
            {
                if (item.CodigoFecha == ultimomes)
                {
                    lstPagos.Items.Add(Convert.ToString(contador + 1));
                    lstPagos.Items[contador].SubItems.Add(item.Descripcion);
                    lstPagos.Items[contador].SubItems.Add(Convert.ToString(item.FechaVencimiento).Substring(0, 10));
                    lstPagos.Items[contador].SubItems.Add(item.DetallePago);
                    lstPagos.Items[contador].SubItems.Add(Convert.ToString(item.Monto));
                    ListadePago.ImportRow(item);
                    contador += 1;
                }
            }
        }
        private void Mostrar_Ocultar()
        {
            if (panelRegistroPago.Visible)
            {
                panelRegistroPago.Visible = false;
            }
            else
            {
                panelRegistroPago.Location = new Point(20, label2.Location.Y + label2.Size.Height);
                panelRegistroPago.Visible = true;
            }
        }

        private void lstPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPagos.SelectedIndices.Count != 0)
            {
                int prorroga = ListadePago[lstPagos.SelectedIndices[0]].Prorroga;
                DateTime fecha_inicial = ListadePago[lstPagos.SelectedIndices[0]].FechaVencimiento.AddDays(-prorroga);
                DateTime lafecha = ListadePago[lstPagos.SelectedIndices[0]].FechaVencimiento;
                DateTime fechamaxima = fecha_inicial.AddMonths(2).AddDays(-fecha_inicial.Day);
                if (lafecha < fechamaxima)
                {
                    dtpprorroga.MaxDate = fechamaxima;
                    dtpprorroga.MinDate = lafecha;
                    dtpprorroga.Value = lafecha;
                    dtpprorroga.Enabled = true;
                    btnaplicarprorroga.Enabled = true;
                }
                else
                {
                    dtpprorroga.Enabled = false;
                    btnaplicarprorroga.Enabled = false;
                    dtpprorroga.Value = lafecha;
                    MessageBox.Show("Llego al maximo de días en prorrogas \nYa no puede asignar mas tiempo.");
                }
            }
        }

        private void btnAplicarProrroga_Click(object sender, EventArgs e)
        {
            string numdocEstudiante = Estudiantes[lstEstudiantes.SelectedIndices[0]].NumeroDocumento;

            clsMatriculaDiversoPago mispagos = new clsMatriculaDiversoPago();
            mispagos.AsignarProrroga(numdocEstudiante,
                ListadePago[lstPagos.SelectedIndices[0]].CodigoMonto,
                ListadePago[lstPagos.SelectedIndices[0]].CodigoFecha,
                Convert.ToByte((dtpprorroga.Value - ListadePago[lstPagos.SelectedIndices[0]].FechaVencimiento).Days + ListadePago[lstPagos.SelectedIndices[0]].Prorroga)
                );
            lstPagos.SelectedItems.Clear();
            dtpprorroga.Enabled = false;
            btnaplicarprorroga.Enabled = false;
            DialogResult result;
            result = MessageBox.Show("Se aplicaron correctamente los cambios", "Operacipon Exitosa", MessageBoxButtons.OK);
            MostrarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ischanged)
            {
                DialogResult result;
                result = MessageBox.Show("Desea Cancelar Operacion ? \nEs posible que se pierdan los cambios realizados", "Cancelar", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Reset();
                }
            }
            else
                this.Reset();
        }

        private void dtpprorroga_ValueChanged(object sender, EventArgs e)
        {
            this.ischanged = true;
        }

        private void txtEstudianteNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
