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
    public partial class UI_Estudiantes_ModificarDatos : Form
    {
        #region Listas y propiedades

        public clsEstudiante Estudiante = null;
        public clsPadre PrimerPadre = null;
        public clsPadre SegundoPadre = null;
        private List<clsEstudiante> _Estudiantes = new List<clsEstudiante>();
        public List<clsEstudiante> Estudiantes
        {
            get { return _Estudiantes; }
            set { _Estudiantes = value; }
        }

        private List<clsDepartemento> _departamentos = new List<clsDepartemento>();

        public List<clsDepartemento> Departamentos
        {
            get { return _departamentos; }
            set { _departamentos = value; }
        }
        private List<clsProvincia> provinciasPadre = new List<clsProvincia>();

        public List<clsProvincia> ProvinciasPadre
        {
            get { return provinciasPadre; }
            set { provinciasPadre = value; }
        }

        private List<clsDistrito> distritosPadre = new List<clsDistrito>();

        public List<clsDistrito> DistritosPadre
        {
            get { return distritosPadre; }
            set { distritosPadre = value; }
        }

        private List<clsProvincia> provinciasPadreSec = new List<clsProvincia>();

        public List<clsProvincia> ProvinciasPadreSec
        {
            get { return provinciasPadreSec; }
            set { provinciasPadreSec = value; }
        }

        private List<clsDistrito> distritosPadreSec = new List<clsDistrito>();

        public List<clsDistrito> DistritosPadreSec
        {
            get { return distritosPadreSec; }
            set { distritosPadreSec = value; }
        }

        private List<clsGradoAcademico> _Grados = new List<clsGradoAcademico>();

        public List<clsGradoAcademico> Grados
        {
            get { return _Grados; }
            set { _Grados = value; }
        }
        private List<clsGradoAcademico> _Secciones = new List<clsGradoAcademico>();

        public List<clsGradoAcademico> Secciones
        {
            get { return _Secciones; }
            set { _Secciones = value; }
        }


        public string estudianteseleccionado = "";

        #endregion
        public UI_Estudiantes_ModificarDatos()
        {
            InitializeComponent();
        }
        #region Cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (btnguardar.Enabled)
            {
                 DialogResult result = MessageBox.Show("Esta seguro de cerrar ? ...", "Cerrar", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }
        #endregion
        #region buscar y seleccionar
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
            lblEstudiante.Text = Estudiantes[lstEstudiantes.SelectedIndices[0]].ApellidosNombres + " - " +
                Estudiantes[lstEstudiantes.SelectedIndices[0]].NumeroDocumento;
            estudianteseleccionado = lstEstudiantes.SelectedItems[0].SubItems[1].Text;
            MostrarDatos();
            Mostrar_Ocultar();
            AcceptButton = btnguardar;
        }

        private void txtEstudianteNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnbuscarotro_Click(object sender, EventArgs e)
        {
            Controles_padreSec(false);
            Mostrar_Ocultar();
        }
        #endregion
        #region Mostrar Datos       
        private void MostrarDatos()
        {
            Estudiante = clsEstudiante.MostrarDatos(estudianteseleccionado);
            if (Estudiante != null)
            {
                int cont = 0;
                txtEstudianteNombre.Text = Estudiante.ApellidosNombres;
                dtpEstudianteFechaNac.Value = Estudiante.FechaNacimiento;
                txtEstudianteColegioProcedencia.Text = Estudiante.ColegioProcedencia;
                nudEstudiantePeso.Value = Convert.ToDecimal(Estudiante.Peso);
                nudEstudianteTalla.Value = Estudiante.Talla;
                txtEstudianteCondicionSalud.Text = Estudiante.CondicionSalud;
                txtEstudianteCelular.Text = Estudiante.Celular;

                PrimerPadre = clsPadre.MostrarDatos(Estudiante.PadreApoderado_NumDoc.NumeroDocumento);
                lblpadre.Text = PrimerPadre.NombreCompleto + " - " + PrimerPadre.NumeroDocumento;
                txtApellidosNombresPadre.Text = PrimerPadre.NombreCompleto;
                txtDirecion.Text = PrimerPadre.Direccion;
                txtCelular.Text = PrimerPadre.NumeroCelular;
                txtTrabajo.Text = PrimerPadre.Trabajo;
                txtCorreo.Text = PrimerPadre.Correo;
                #region mostrar departamento del Primer Padre
                Departamentos.Clear();
                cmbDepartamento.Items.Clear();

                cont = 0;
                foreach (clsDepartemento departemento in clsDepartemento.listar())
                {
                    cmbDepartamento.Items.Add(departemento.Nombre);
                    Departamentos.Add(departemento);
                    if (departemento.IdDepartemento == PrimerPadre.Distrito.Provincia.Departamento.IdDepartemento)
                    {
                        cmbDepartamento.SelectedIndex = cont;
                    }
                    cont += 1;
                }
                cont = 0;
                cmbProvincia.Items.Clear();
                ProvinciasPadre.Clear();
                foreach (clsProvincia provincia in clsProvincia.ListarProvincias(PrimerPadre.Distrito.Provincia.Departamento.IdDepartemento))
                {
                    cmbProvincia.Items.Add(provincia.Nombre);
                    ProvinciasPadre.Add(provincia);
                    if (provincia.IdProvincia == PrimerPadre.Distrito.Provincia.IdProvincia)
                    {
                        cmbProvincia.SelectedIndex = cont;
                    }
                    cont += 1;
                }
                cont = 0;
                DistritosPadre.Clear();
                cmbDistrito.Items.Clear();
                foreach (clsDistrito distrito in clsDistrito.listarDistritos(PrimerPadre.Distrito.Provincia.IdProvincia))
                {
                    cmbDistrito.Items.Add(distrito.Nombre);
                    DistritosPadre.Add(distrito);
                    if (distrito.IdDistrito == PrimerPadre.Distrito.IdDistrito)
                    {
                        cmbDistrito.SelectedIndex = cont;
                    }
                    cont += 1;
                }
                #endregion

                if (Estudiante.Padre_NumDoc != null)
                {
                    panelModificarDatos.Height = 1080;
                    Controles_padreSec(true);

                    SegundoPadre = clsPadre.MostrarDatos(Estudiante.Padre_NumDoc.NumeroDocumento);
                    #region mostar combos del Segundo Padre
                    cont = 0;
                    foreach (clsDepartemento item in Departamentos)
                    {
                        cmbPadreSecDepartamento.Items.Add(item.Nombre);
                        if (item.IdDepartemento == SegundoPadre.Distrito.Provincia.Departamento.IdDepartemento)
                        {
                            cmbPadreSecDepartamento.SelectedIndex = cont;
                        }
                        cont += 1;
                    }
                    cont = 0;
                    ProvinciasPadreSec.Clear();
                    cmbPadreSecProvincia.Items.Clear();
                    foreach (clsProvincia item in clsProvincia.ListarProvincias(SegundoPadre.Distrito.Provincia.Departamento.IdDepartemento))
                    {
                        cmbPadreSecProvincia.Items.Add(item.Nombre);
                        ProvinciasPadreSec.Add(item);
                        if (item.IdProvincia == SegundoPadre.Distrito.Provincia.IdProvincia)
                        {
                            cmbPadreSecProvincia.SelectedIndex = cont;
                        }
                        cont += 1;
                    }
                    cont = 0;
                    DistritosPadreSec.Clear();
                    cmbPadreSecDistrito.Items.Clear();
                    foreach (clsDistrito item in clsDistrito.listarDistritos(SegundoPadre.Distrito.Provincia.IdProvincia))
                    {
                        cmbPadreSecDistrito.Items.Add(item.Nombre);
                        DistritosPadreSec.Add(item);
                        if (item.IdDistrito == SegundoPadre.Distrito.IdDistrito)
                        {
                            cmbPadreSecDistrito.SelectedIndex = cont;
                        }
                        cont += 1;
                    }
                    #endregion
                    lblpadresecundario.Text = SegundoPadre.NombreCompleto + " - " + SegundoPadre.NumeroDocumento;
                    txtPadreSecApellidosNombres.Text = SegundoPadre.NombreCompleto;
                    txtPadreSecCelular.Text = SegundoPadre.NumeroCelular;
                    txtPadreSecCorreo.Text = SegundoPadre.Correo;
                    txtPadreSecDireccion.Text = SegundoPadre.Direccion;
                    txtPadreSecTrabajo.Text = SegundoPadre.Trabajo;

                }
                else
                {

                    panelModificarDatos.Height = 700;
                    Controles_padreSec(false);
                }
            }
        }
        private void Mostrar_Ocultar()
        {
            if (panelModificarDatos.Visible)
            {
                panelModificarDatos.Visible = false;
                panelModificarDatos.Enabled = false;
            }
            else
            {
                panelModificarDatos.Enabled = true;
                panelModificarDatos.Location = new Point(20, label2.Location.Y + label2.Size.Height);
                panelModificarDatos.Visible = true;
                dtpEstudianteFechaNac.MaxDate = new  DateTime(DateTime.Today.AddYears(-1).Year,12,31);
            }
        }
        #endregion
        #region Controles de padre Sec
        private void Controles_padreSec(bool status)
        {
            txtPadreSecApellidosNombres.Enabled = status;
            txtPadreSecCelular.Enabled = status;
            txtPadreSecCorreo.Enabled = status;
            txtPadreSecDireccion.Enabled = status;
            txtPadreSecTrabajo.Enabled = status;
            cmbPadreSecDepartamento.Enabled = status;
            cmbPadreSecDistrito.Enabled = status;
            cmbPadreSecProvincia.Enabled = status;
        }
        #endregion
        #region ver si hay cambios        
        private void txtEstudianteNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudianteNombre.Text != Estudiante.ApellidosNombres)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtEstudianteNombre.Tag = true;
            }
            else
            {
                txtEstudianteNombre.Tag = false;
                Vercambios();
            }
        }

        private void dtpEstudianteFechaNac_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEstudianteFechaNac.Value != Estudiante.FechaNacimiento)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                dtpEstudianteFechaNac.Tag = true;
            }
            else
            {
                dtpEstudianteFechaNac.Tag = false;
                Vercambios();
            }
        }

        private void txtEstudianteColegioProcedencia_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudianteColegioProcedencia.Text != Estudiante.ColegioProcedencia)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtEstudianteColegioProcedencia.Tag = true;
            }
            else
            {
                txtEstudianteColegioProcedencia.Tag = false;
                Vercambios();
            }
        }

        private void nudEstudianteTalla_ValueChanged(object sender, EventArgs e)
        {
            if (nudEstudianteTalla.Value != Estudiante.Talla)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                nudEstudianteTalla.Tag = true;
            }
            else
            {
                nudEstudianteTalla.Tag = false;
                Vercambios();
            }
        }

        private void nudEstudiantePeso_ValueChanged(object sender, EventArgs e)
        {
            if (nudEstudiantePeso.Value != Convert.ToDecimal(Estudiante.Peso))
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                nudEstudiantePeso.Tag = true;
            }
            else
            {
                nudEstudiantePeso.Tag = false;
                Vercambios();
            }
        }

        private void txtEstudianteCondicionSalud_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudianteCondicionSalud.Text != Estudiante.CondicionSalud)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtEstudianteCondicionSalud.Tag = true;
            }
            else
            {
                txtEstudianteCondicionSalud.Tag = false;
                Vercambios();
            }
        }

        private void txtEstudianteCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudianteCelular.Text != Estudiante.Celular)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtEstudianteCelular.Tag = true;
            }
            else
            {
                txtEstudianteCelular.Tag = false;
                Vercambios();
            }
        }

        private void txtApellidosNombresPadre_TextChanged(object sender, EventArgs e)
        {
            if (txtApellidosNombresPadre.Text != PrimerPadre.NombreCompleto)
            {
                btnguardar.Enabled = true;
                btnDescartar.Enabled = true;
                txtApellidosNombresPadre.Tag = true;
            }
            else
            {
                txtApellidosNombresPadre.Tag = false;
                Vercambios();
            }
        }

        private void txtDirecion_TextChanged(object sender, EventArgs e)
        {
            if (txtDirecion.Text != PrimerPadre.Direccion)
            {
                btnguardar.Enabled = true;
                btnDescartar.Enabled = true;
                txtDirecion.Tag = true;
            }
            else
            {
                txtDirecion.Tag = false;
                Vercambios();
            }
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DistritosPadre[cmbDistrito.SelectedIndex].IdDistrito != PrimerPadre.Distrito.IdDistrito)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                cmbDistrito.Tag = true;
            }
            else
            {
                cmbDistrito.Tag = false;
                Vercambios();
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Departamentos[cmbDepartamento.SelectedIndex].IdDepartemento != PrimerPadre.Distrito.Provincia.Departamento.IdDepartemento)
            {
                provinciasPadre.Clear();
                cmbProvincia.Items.Clear();
                foreach (clsProvincia item in clsProvincia.ListarProvincias(Convert.ToByte(cmbDepartamento.SelectedIndex + 1)))
                {
                    provinciasPadre.Add(item);
                    cmbProvincia.Items.Add(item.Nombre);
                }
            }            
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinciasPadre[cmbProvincia.SelectedIndex].IdProvincia != PrimerPadre.Distrito.Provincia.IdProvincia)
            {
                DistritosPadre.Clear();
                cmbDistrito.Items.Clear();
                foreach (clsDistrito item in clsDistrito.listarDistritos(ProvinciasPadre[cmbDepartamento.SelectedIndex].IdProvincia))
                {
                    DistritosPadre.Add(item);
                    cmbDistrito.Items.Add(item.Nombre);
                }
            }
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtCelular.Text != PrimerPadre.NumeroCelular)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtCelular.Tag = true;
            }
            else
            {
                txtCelular.Tag = false;
                Vercambios();
            }
        }

        private void txtTrabajo_TextChanged(object sender, EventArgs e)
        {
            if (txtTrabajo.Text != PrimerPadre.Trabajo)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtTrabajo.Tag = true;
            }
            else
            {
                txtTrabajo.Tag = false;
                Vercambios();
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (txtCorreo.Text != PrimerPadre.Correo)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtCorreo.Tag = true;
            }
            else
            {
                txtCorreo.Tag = false;
                Vercambios();
            }
        }

        private void txtPadreSecApellidosNombres_TextChanged(object sender, EventArgs e)
        {
            if (txtPadreSecApellidosNombres.Text != SegundoPadre.NombreCompleto)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtPadreSecApellidosNombres.Tag = true;
            }
            else
            {
                txtPadreSecApellidosNombres.Tag = false;
                Vercambios();
            }
        }

        private void txtPadreSecDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtPadreSecDireccion.Text != SegundoPadre.Direccion)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtPadreSecDireccion.Tag = true;
            }
            else
            {
                txtPadreSecDireccion.Tag = false;
                Vercambios();
            }
        }

        private void txtPadreSecCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtPadreSecCelular.Text != SegundoPadre.NumeroCelular)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtPadreSecCelular.Tag = true;
            }
            else
            {
                txtPadreSecCelular.Tag = false;
                Vercambios();
            }
        }

        private void txtPadreSecTrabajo_TextChanged(object sender, EventArgs e)
        {
            if (txtPadreSecTrabajo.Text != SegundoPadre.Trabajo)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtPadreSecTrabajo.Tag = true;
            }
            else
            {
                txtPadreSecTrabajo.Tag = false;
                Vercambios();
            }
        }

        private void txtPadreSecCorreo_TextChanged(object sender, EventArgs e)
        {
            if (txtPadreSecCorreo.Text != SegundoPadre.Correo)
            {
                btnguardar.Enabled = true;  
                btnDescartar.Enabled = true;
                txtPadreSecCorreo.Tag = true;
            }
            else
            {
                txtPadreSecCorreo.Tag = false;
                Vercambios();
            }
        }
        private void Vercambios()
        {
            bool indicador = false;
            foreach (Control item in panelModificarDatos.Controls)
            {
                if (item.Tag != null)
                {
                    if (item.Tag.ToString() != false.ToString())
                    {
                        indicador = true;
                        break;
                    }
                }
            }
            btnguardar.Enabled = indicador;
            btnDescartar.Enabled = indicador;

        }
        #endregion
        #region Guardas Cambios
        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Displays the MessageBox.
            DialogResult result = MessageBox.Show("Desea Guardar los cambios registrados ?", "Guardar Cambios", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                GuardarDatos();
                txtEstudianteNumeroDocumento.Text = "";
                txtEstudianteNumeroDocumento_TextChanged(sender, e);
            }
        }

        private void GuardarDatos()
        {
            Estudiante.ModificarDatos(txtEstudianteNombre.Text,
                txtEstudianteColegioProcedencia.Text,
                Convert.ToSingle(nudEstudiantePeso.Value),
                Convert.ToInt16(nudEstudianteTalla.Value),
                txtEstudianteCondicionSalud.Text,
                dtpEstudianteFechaNac.Value,
                txtEstudianteCelular.Text);
            PrimerPadre.ModificarDatos(txtApellidosNombresPadre.Text,
                txtDirecion.Text,
                DistritosPadre[cmbDistrito.SelectedIndex].IdDistrito,
                txtCelular.Text,
                txtTrabajo.Text,
                txtCorreo.Text);
            if (SegundoPadre != null)
            {
                SegundoPadre.ModificarDatos(
                    txtPadreSecApellidosNombres.Text,
                    txtPadreSecDireccion.Text,
                    DistritosPadreSec[cmbPadreSecDistrito.SelectedIndex].IdDistrito,
                    txtPadreSecCelular.Text,
                    txtPadreSecTrabajo.Text,
                    txtPadreSecCorreo.Text);
            }
            MessageBox.Show("Se modificaron los datos correctamente");
            Controles_padreSec(false);
            Mostrar_Ocultar();
        }
        #endregion
        #region dercartar cambios
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            // Displays the MessageBox.
            DialogResult result = MessageBox.Show("Desea descartar los cambios realizados ?...", "Descartar cambios", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Controles_padreSec(false);
                Mostrar_Ocultar();
                txtEstudianteNumeroDocumento.Text = "";
                txtEstudianteNumeroDocumento_TextChanged(sender, e);
            }
        }
        #endregion
    }
}
