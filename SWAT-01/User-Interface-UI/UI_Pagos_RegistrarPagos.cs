using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CN_Business_Layer;

namespace User_Interface_UI
{
    public partial class UI_Pagos_RegistrarPagos : Form
    {
        #region Listas en formulario
        private DatosGenerales.dtblDiversosPagosDataTable _DiversosPagos = new DatosGenerales.dtblDiversosPagosDataTable();

        public DatosGenerales.dtblDiversosPagosDataTable DiversosPagos
        {
            get { return _DiversosPagos; }
            set { _DiversosPagos = value; }
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
        public UI_Pagos_RegistrarPagos()
        {
            InitializeComponent();
        }
        #region Buscar Estudiantes
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

        private void txtEstudianteNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
        private void lstEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSeleccionar.Enabled = true;
            AcceptButton = btnSeleccionar;
        }
        #endregion
        #region Al Seleconar estudiante
        public string estudianteseleccionado = "";
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            labelEstudiante.Text = Estudiantes[lstEstudiantes.SelectedIndices[0]].ApellidosNombres + " - "+
                Estudiantes[lstEstudiantes.SelectedIndices[0]].NumeroDocumento;
            estudianteseleccionado = lstEstudiantes.SelectedItems[0].SubItems[1].Text;
            MostrarDatos();
            Mostrar_Ocultar();
            nudMonto.Focus();
            nudMonto.Select(0,nudMonto.Value.ToString().Length + 3);
        }
        private void MostrarDatos()
        {

            lstPagos.Items.Clear();
            DiversosPagos.Rows.Clear();
            SinCancelar.Rows.Clear();
            int contador = 0;
            SinCancelar = clsMatriculaDiversoPago.listarPagosSinPagar_porEstudiante_NumDoc(estudianteseleccionado);
            DiversosPagos = clsMatriculaDiversoPago.listarPagos_porEstudiante_NumDoc(estudianteseleccionado);
            foreach (DatosGenerales.dtblDiversosPagosRow item in DiversosPagos.Rows)
            {
                lstPagos.Items.Add(Convert.ToString(contador + 1));
                lstPagos.Items[contador].SubItems.Add(item.Descripcion);
                lstPagos.Items[contador].SubItems.Add(Convert.ToString(item.FechaVencimiento).Substring(0, 10));
                lstPagos.Items[contador].SubItems.Add(item.DetallePago);
                lstPagos.Items[contador].SubItems.Add(Convert.ToString(item.Monto));
                contador += 1;

            }
            if (SinCancelar.Rows.Count == 0)
            {
                btnPagar.Enabled = false;
            }
            else
            {
                btnPagar.Enabled = true;
            }
        }
        #endregion
        #region cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            mensaje_al_salir("Desea cancelar Operacion ... ?", "Cancelar Operacion");
        }
        private void mensaje_al_salir(string message, string caption)
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                this.Close();
            }
        }
        #endregion
        #region Registrar Pagos
        private void registrarPagos()
        {
            clsPago nuevoPago = clsPago.Registrar(Convert.ToSingle(nudMonto.Value));
            byte indices = 0;
            while (nudMonto.Value > 0 && indices < SinCancelar.Rows.Count)
            {
                byte MontoCodigo = SinCancelar[indices].CodigoMonto;
                byte FechaCodigo = SinCancelar[indices].CodigoFecha;
                float MontoPagado = Convert.ToSingle(nudMonto.Value);
                if (MontoPagado > SinCancelar[indices].Monto)
                {
                    MontoPagado = SinCancelar[indices].Monto;
                }
                nuevoPago.RegistrarMultiple(estudianteseleccionado,
                    MontoCodigo,FechaCodigo,nuevoPago.Numero,MontoPagado);
                nudMonto.Value -= Convert.ToDecimal(MontoPagado);
                indices += 1;
            }
            MessageBox.Show("Pagos Correctamente Registrados");
            if (nudMonto.Value != 0)
            {
                MessageBox.Show("su vuelto es : S/" + nudMonto.Value.ToString());
                nudMonto.Value = 0; 
            }
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (nudMonto.Value > 0 && SinCancelar.Rows.Count != 0)
            {
                registrarPagos();
                MostrarDatos();
            }
            
        }        
        #endregion

        private void UI_Pagos_RegistrarPagos_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            Reset();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea Cancelar Operacion ?","Cancelar",MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Reset();
            }
        }
        private void Reset()
        {
            txtEstudianteNumeroDocumento.Focus();
            panelRegistroPago.Visible = true;
            Mostrar_Ocultar();
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

        private void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            txtEstudianteNumeroDocumento.Text = "";
            btnSeleccionar.Enabled = false;
            Mostrar_Ocultar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtEstudianteNumeroDocumento_TextChanged(sender, e);
        }

    }
}
