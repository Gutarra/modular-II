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
    public partial class UI_Estudiantes_NuevoEstudiante : Form
    {
        #region Listas en formulario
        private List<clsIdentificacion> _tiposidentificaciones = new List<clsIdentificacion>();

        public List<clsIdentificacion> tiposidentificaciones
        {
            get { return _tiposidentificaciones; }
            set { _tiposidentificaciones = value; }
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


        private List<clsDepartemento> _Departamentos = new List<clsDepartemento>();

        public List<clsDepartemento> Departamentos
        {
            get { return _Departamentos; }
            set { _Departamentos = value; }
        }
        private List<clsProvincia> _ProvinciasPadre = new List<clsProvincia>();

        public List<clsProvincia> ProvinciasPadre
        {
            get { return _ProvinciasPadre; }
            set { _ProvinciasPadre = value; }
        }
        private List<clsDistrito> _DistritosPadre = new List<clsDistrito>();

        public List<clsDistrito> DistritosPadre
        {
            get { return _DistritosPadre; }
            set { _DistritosPadre = value; }
        }

        private List<clsProvincia> _provinciasPadreSec = new List<clsProvincia>();

        public List<clsProvincia> ProvinciasPadreSec
        {
            get { return _provinciasPadreSec; }
            set { _provinciasPadreSec = value; }
        }
        private List<clsDistrito> _DistritosPadreSec = new List<clsDistrito>();

        public List<clsDistrito> DistritosPadreSec
        {
            get { return _DistritosPadreSec; }
            set { _DistritosPadreSec = value; }
        }

        public clsPadre Padre,PadreSec;
        public clsEstudiante Estudiante;
        #endregion
        public UI_Estudiantes_NuevoEstudiante()
        {
            InitializeComponent();
        }
        #region Solo Numeros en txt o textbox
        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
        private void bloquearalborrar(object sender, KeyPressEventArgs e)
        {

        }
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumeroDocumento_KeyPress(sender, e);
        }
        private void txtEstudianteNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumeroDocumento_KeyPress(sender, e);
        }
        private void txtPadreSecCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumeroDocumento_KeyPress(sender, e);
        }
        private void txtPadreSecNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumeroDocumento_KeyPress(sender, e);
        }
        private void txtEstudianteTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumeroDocumento_KeyPress(sender, e);
        }
        #endregion
        #region Padre Secundario habilitar edicion
        private void chkPadreSecundario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPadreSecundario.Checked == true)
            {
                padre2_habilidato_desabilitado(true);
                txtPadreSecNumeroDocumento.Focus();
            }
            else
            {
                padre2_habilidato_desabilitado(false);
            }
        }
        private void padre2_habilidato_desabilitado(bool valor)
        {
            cmbPadreSecTipoDoc.Enabled = valor;
            //cmbPadreSecDepartamento.Enabled = valor;
            //txtPadreSecTrabajo.Enabled = valor;
            //txtPadreSecApellidosNombres.Enabled = valor;
            //txtPadreSecCelular.Enabled = valor;
            //txtPadreSecCorreo.Enabled = valor;
            //txtPadreSecDireccion.Enabled = valor;
            txtPadreSecNumeroDocumento.Enabled = valor;
            controlespadre2_desactivar(true);
        }
        #endregion
        #region Desplasarse en el formulario
        private void mostrarpanel_siguiente(Panel panel_a_mostrar)
        {
            panel_a_mostrar.Location = new Point(0, 0);
            panel_a_mostrar.Size = new System.Drawing.Size(600, 450);
            panel_a_mostrar.Visible = true;
        }
        private void ocultarpanel(Panel panel)
        {
            panel.Visible = false;
        }
        private void btnAvanzar1_Click(object sender, EventArgs e)
        {
            mostrarpanel_siguiente(panelSegundoPadre);
            ocultarpanel(panelPadreApoderado);
            this.AcceptButton = btnAvanzar2;
            chkPadreSecundario.Focus();
        }

        private void btnRetroceder1_Click(object sender, EventArgs e)
        {
            mostrarpanel_siguiente(panelPadreApoderado);
            ocultarpanel(panelSegundoPadre);
            this.AcceptButton = btnAvanzar1;
        }

        private void btnAvanzar2_Click(object sender, EventArgs e)
        {
            mostrarpanel_siguiente(panelEstudiante);
            ocultarpanel(panelSegundoPadre);
            this.AcceptButton = btnGuardar;
            txtEstudianteNumDoc.Focus();
        }

        private void btnRetroceder2_Click(object sender, EventArgs e)
        {
            mostrarpanel_siguiente(panelSegundoPadre);
            ocultarpanel(panelEstudiante);
            this.AcceptButton = btnAvanzar2;
        }
        #endregion
        #region Valores al cargar formulario
        private void UI_Estudiantes_NuevoEstudiante_Load(object sender, EventArgs e)
        {
            Valores_porDefecto();
            txtNumeroDocumento.Focus();
            controlesEstudiante_desactivar(true);
            controlespadre1_desactivar(true);
            controlespadre2_desactivar(true);
        }
        private void Valores_porDefecto()
        {
            dtpEstudianteFechaNac.MaxDate = new DateTime(System.DateTime.Now.Year - 1,12,31);
            padre2_habilidato_desabilitado(false);
            chkPadreSecundario.Checked = false;
            mostrarpanel_siguiente(panelPadreApoderado);
            ocultarpanel(panelEstudiante);
            ocultarpanel(panelSegundoPadre);
            this.AcceptButton = btnAvanzar1;

            //Cargar los combos con los tipos de identificaciones
            cmbTipoDoc.Items.Clear();
            cmbPadreSecTipoDoc.Items.Clear();
            cmbEstudianteTipoDoc.Items.Clear();
            tiposidentificaciones.Clear();
            foreach (clsIdentificacion elemento in clsIdentificacion.Listar())
            {
                cmbTipoDoc.Items.Add(elemento.Nombre);
                cmbPadreSecTipoDoc.Items.Add(elemento.Nombre);
                cmbEstudianteTipoDoc.Items.Add(elemento.Nombre);
                tiposidentificaciones.Add(elemento);
            }
            cmbEstudianteTipoDoc.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            cmbPadreSecTipoDoc.SelectedIndex = 0;

            //Cargar los combos con los GRADOS
            cmbGrado.Items.Clear();
            Grados.Clear();
            foreach (clsGradoAcademico elemento in clsGradoAcademico.ListarGrados())
            {
                cmbGrado.Items.Add(elemento.Grado);
                Grados.Add(elemento);
            }
            cmbSeccion.Items.Clear();
            cmbSeccion.Items.Add("Selecione Grado ...");
            cmbSeccion.SelectedIndex = 0;

            Departamentos.Clear();
            cmbDepartamento.Items.Clear();
            cmbPadreSecDepartamento.Items.Clear();
            foreach (clsDepartemento elemento in clsDepartemento.listar())
            {
                cmbPadreSecDepartamento.Items.Add(elemento.Nombre);
                cmbDepartamento.Items.Add(elemento.Nombre);
                Departamentos.Add(elemento);
            }

            txtNumeroDocumento.Focus();
        }
        #endregion
        #region Al Selecionar Grado
        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            char ellgradoselecionado = Grados[cmbGrado.SelectedIndex].Grado;
            cmbSeccion.Width = cmbGrado.Width;
            cmbSeccion.Items.Clear();
            Secciones.Clear();
            foreach (clsGradoAcademico item in clsGradoAcademico.ListarSecciones_porgrado(ellgradoselecionado))
            {
                if (item.Capacidad != 0)
                {
                    cmbSeccion.Items.Add(item.Seccion);
                    Secciones.Add(item);
                }
            }
            if (cmbSeccion.Items.Count == 0)
            {
                MessageBox.Show("No existen vacantes disponibles en \nninguna de las secciones de este grado", "Importante...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Salir del Formulario
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            mensaje_al_salir_o_camcelar("Esta Seguro de Cerrar ... ?", "Cerrar");
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
                    this.restart();
                // Closes the parent form.
                if (caption == "Cerrar")
                    this.Close();
            }
        }
        #endregion
        #region Registrar Datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsGradoAcademico gradoAcademico = clsGradoAcademico.Vacantes(Convert.ToChar(cmbGrado.Text), Convert.ToChar(cmbSeccion.Text));
            if (gradoAcademico.Capacidad != 0)
            {
                if (Confirmar_Registro())
                    RegistrarDatos();
            }
            else
            {
                MessageBox.Show("No existen vacantes disponibles en el grado y seccion selecionado", "Importante...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void RegistrarDatos()
        {
            if (txtApellidosNombresPadre.Enabled == false && txtNumeroDocumento.Text.Length == txtNumeroDocumento.MaxLength)
            {

            }
            else if (comprobar_datos_Padre())
            {
                Padre = new clsPadre(
                    tiposidentificaciones[cmbTipoDoc.SelectedIndex],
                    txtNumeroDocumento.Text,
                    txtApellidosNombresPadre.Text,
                    txtDirecion.Text,
                    DistritosPadre[cmbDistrito.SelectedIndex],
                    txtCelular.Text,
                    txtTrabajo.Text,
                    txtCorreo.Text);
                controlespadre1_desactivar(true);
            }
            else
            {
                MessageBox.Show("Compueve los Campos de Padre o Apoderado ...");
            }

            if (chkPadreSecundario.Checked == true)
            {
                if (txtPadreSecApellidosNombres.Enabled == false && txtPadreSecNumeroDocumento.Text.Length == txtPadreSecNumeroDocumento.MaxLength)
                {

                }
                else if (comprobar_datos_Padre2())
                {
                    PadreSec = new clsPadre(
                        tiposidentificaciones[cmbPadreSecTipoDoc.SelectedIndex],
                        txtPadreSecNumeroDocumento.Text,
                        txtPadreSecApellidosNombres.Text,
                        txtPadreSecDireccion.Text,
                        DistritosPadreSec[cmbPadreSecDistrito.SelectedIndex],
                        txtPadreSecCelular.Text,
                        txtPadreSecTrabajo.Text,
                        txtPadreSecCorreo.Text);
                    controlespadre2_desactivar(true);
                }
                else
                {
                    MessageBox.Show("Compueve los Campos de Segundo Padre o Apoderado ...");
                }
            }


            if (txtEstudianteApellidosNombres.Enabled == false && txtEstudianteNumDoc.Text.Length == txtEstudianteNumDoc.MaxLength)
            {
                MessageBox.Show("El estudiante ya existe ...");
                txtEstudianteNumDoc.Text = "";
                txtEstudianteNumDoc.ReadOnly = false;
                txtEstudianteNumDoc.Focus();
            }
            else if (comprobar_datos_Estudiante())
            {
                Estudiante = new clsEstudiante(
                    tiposidentificaciones[cmbEstudianteTipoDoc.SelectedIndex],
                    txtEstudianteNumDoc.Text,
                    txtEstudianteApellidosNombres.Text,
                    Padre, null,
                    txtEstudianteColegioProcedencia.Text,
                    Convert.ToSingle(nudEstudiantePeso.Value),
                    Convert.ToInt16(nudEstudianteTalla.Value),
                    txtEstudianteCondicionSalud.Text,
                    dtpEstudianteFechaNac.Value, "");
                if(chkPadreSecundario.Checked && txtPadreSecApellidosNombres.Enabled)
                    PadreSec.Insertar();
                if(txtApellidosNombresPadre.Enabled)
                    Padre.Insertar();
                    Estudiante.Insertar();

                clsMatricula nueva = new clsMatricula(mdlVariablesAplicacion.PeriodoActual, Estudiante, mdlVariablesAplicacion.UsuarioConectado,
                        false, Secciones[cmbSeccion.SelectedIndex], DateTime.Now);

                nueva.RegistrarMatricula();
                this.restart();
                MessageBox.Show("Registro de Datos Satisfactorio");
            }
            else
            {
                MessageBox.Show("Compueve los Campos del Estudiante ...");
            }
        }
        #endregion
        #region Mensaje para confirmar registro
        private bool Confirmar_Registro()
        {
            DialogResult result;
            result = MessageBox.Show("Desea guardar registro", "Confirme Registro", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
            {
                mostrarpanel_siguiente(panelPadreApoderado);
                ocultarpanel(panelEstudiante);
                ocultarpanel(panelSegundoPadre);
                this.AcceptButton = btnAvanzar1;
            }   
                return false;
            
        }
        #endregion
        #region Canlelar Operacion
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mensaje_al_salir_o_camcelar("Desea Cancelar operacion ... ?", "Cancelar");
        }
        #endregion
        #region Al Seleccionar Tipo de Docuemnto
        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combos_tipoDoc_alCambiar(cmbTipoDoc, txtNumeroDocumento);
        }

        private void cmbPadreSecTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combos_tipoDoc_alCambiar(cmbPadreSecTipoDoc, txtPadreSecNumeroDocumento);
        }

        private void cmbEstudianteTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combos_tipoDoc_alCambiar(cmbEstudianteTipoDoc, txtEstudianteNumDoc);
        }
        private void Combos_tipoDoc_alCambiar(ComboBox cmbDatos, TextBox txtNumero)
        {
            switch (cmbDatos.SelectedIndex)
            {
                case 0:
                    txtNumero.MaxLength = 8;
                    txtNumero.ReadOnly = false;
                    txtNumero.Text = "";
                    break;
                default:
                    txtNumero.MaxLength = 12;
                    txtNumero.ReadOnly = false;
                    txtNumero.Text = "";
                    break;
            }
            txtNumero.Focus();
        }
        #endregion
        #region Al Selecionar Departamentos y Provincias
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte DepartamentoSeleccionado = Departamentos[cmbDepartamento.SelectedIndex].IdDepartemento;

            cmbProvincia.Visible = true;
            ProvinciasPadre.Clear();
            cmbProvincia.Items.Clear();
            cmbDistrito.Items.Clear();
            foreach (clsProvincia item in clsProvincia.ListarProvincias(DepartamentoSeleccionado))
            {
                cmbProvincia.Items.Add(item.Nombre);
                ProvinciasPadre.Add(item);
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte ProvinciaSelecionada = ProvinciasPadre[cmbProvincia.SelectedIndex].IdProvincia;

            cmbDistrito.Visible = true;
            DistritosPadre.Clear();
            cmbDistrito.Items.Clear();

            foreach (clsDistrito item in clsDistrito.listarDistritos(ProvinciaSelecionada))
            {
                cmbDistrito.Items.Add(item.Nombre);
                DistritosPadre.Add(item);
            }

        }

        private void cmbPadreSecProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte ProvinciaSelecionada = ProvinciasPadreSec[cmbPadreSecProvincia.SelectedIndex].IdProvincia;

            cmbPadreSecDistrito.Visible = true;
            DistritosPadreSec.Clear();
            cmbPadreSecDistrito.Items.Clear();

            foreach (clsDistrito item in clsDistrito.listarDistritos(ProvinciaSelecionada))
            {
                cmbPadreSecDistrito.Items.Add(item.Nombre);
                DistritosPadreSec.Add(item);
            }
        }

        private void cmbPadreSecDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte DepartamentoSeleccionado = Departamentos[cmbPadreSecDepartamento.SelectedIndex].IdDepartemento;

            cmbPadreSecProvincia.Visible = true;
            ProvinciasPadreSec.Clear();
            cmbPadreSecProvincia.Items.Clear();
            cmbPadreSecDistrito.Items.Clear();
            foreach (clsProvincia item in clsProvincia.ListarProvincias(DepartamentoSeleccionado))
            {
                cmbPadreSecProvincia.Items.Add(item.Nombre);
                ProvinciasPadreSec.Add(item);
            }
        }
        #endregion
        #region Comprobar Datos de Estudiante y Padre SI EXISTEN
        private void Datos_Si_Existen(ComboBox cmbDatos, TextBox txtNDocumento)
        {
            if (cmbDatos.SelectedIndex == 0 && txtNDocumento.Text.Length != 8 && txtNDocumento.Text != "")
            {
                switch (txtNDocumento.Tag.ToString())
                {
                    case "primero":
                        controlespadre1_desactivar(true);
                        break;
                    case "estudiante":
                        controlesEstudiante_desactivar(true);
                        break;
                    case "secundario":
                        controlespadre2_desactivar(true);
                        break;
                    default:
                        break;
                }
            }
            else if (txtNDocumento.Text.Length != 12)
            {
                switch (txtNDocumento.Tag.ToString())
                {
                    case "primero":
                        controlespadre1_desactivar(true);
                        break;
                    case "estudiante":
                        controlesEstudiante_desactivar(true);
                        break;
                    case "secundario":
                        controlespadre2_desactivar(true);
                        break;
                    default:
                        break;
                }
            }
            
            if (cmbDatos.SelectedIndex == 0 && txtNDocumento.Text.Length == 8)
            {
                switch (txtNDocumento.Tag.ToString())
                {
                    case "primero":
                        Padre = clsPadre.Padre_Comprobar_siExiste(txtNDocumento.Text);
                        if (Padre != null)
                        {
                            controlespadre1_desactivar(true);
                            txtNumeroDocumento.ReadOnly = true;
                        }
                        else controlespadre1_desactivar(false);
                        break;
                    case "estudiante":
                        Estudiante = clsEstudiante.Comprobar_siExiste(txtNDocumento.Text);
                        if (Estudiante != null)
                        {
                            controlesEstudiante_desactivar(true);
                        }
                        else controlesEstudiante_desactivar(false);
                        break;
                    case "secundario":
                        PadreSec = clsPadre.Padre_Comprobar_siExiste(txtNDocumento.Text);
                        if (PadreSec != null)
                        {
                            controlespadre2_desactivar(true);
                            txtPadreSecNumeroDocumento.ReadOnly = true;
                        }
                        else controlespadre2_desactivar(false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (txtNDocumento.Text.Length == 12)
                {
                    switch (txtNDocumento.Tag.ToString())
                    {
                        case "primero":
                            Padre = clsPadre.Padre_Comprobar_siExiste(txtNDocumento.Text);
                            if (Padre != null)
                            {
                                controlespadre1_desactivar(true);
                                txtNumeroDocumento.ReadOnly = true;
                            }
                            else controlespadre1_desactivar(false);
                            break;
                        case "estudiante":
                            Estudiante = clsEstudiante.Comprobar_siExiste(txtNDocumento.Text);
                            if (Estudiante != null)
                            {
                                controlesEstudiante_desactivar(true);
                            }
                            else controlesEstudiante_desactivar(false);
                            break;
                        case "secundario":
                            PadreSec = clsPadre.Padre_Comprobar_siExiste(txtNDocumento.Text);
                            if (PadreSec != null)
                            {
                                controlespadre2_desactivar(true);
                                txtPadreSecNumeroDocumento.ReadOnly = true;
                            }
                            else controlespadre2_desactivar(false);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            Datos_Si_Existen(cmbTipoDoc, txtNumeroDocumento);
        }
        private void txtPadreSecNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            Datos_Si_Existen(cmbPadreSecTipoDoc, txtPadreSecNumeroDocumento);
        }

        private void txtEstudianteNumDoc_TextChanged(object sender, EventArgs e)
        {
            Datos_Si_Existen(cmbEstudianteTipoDoc, txtEstudianteNumDoc);
        }
        #endregion
        #region Al Activar o Desactivar Controles
        /// <summary>
        /// Este metodo se usa para habilitar o desabilitar los controles del Padre o Apoderado
        /// </summary>
        /// 
        /// <param name="valor"> true para desactivar controles </param>
        private void controlespadre1_desactivar(bool valor)
        {
            cmbDepartamento.Enabled = !valor;
            cmbProvincia.Enabled = !valor;
            cmbDistrito.Enabled = !valor;
            cmbProvincia.Visible = !valor;
            cmbDistrito.Visible = !valor;
            txtApellidosNombresPadre.Enabled = !valor;
            txtCelular.Enabled = !valor;
            txtCorreo.Enabled = !valor;
            txtDirecion.Enabled = !valor;
            txtTrabajo.Enabled = !valor;
            if (valor && Padre != null)
            {
                txtApellidosNombresPadre.Text = Padre.NombreCompleto;
                txtDirecion.Text = Padre.Direccion;
                txtCelular.Text = Padre.NumeroCelular;
                txtCorreo.Text = Padre.Correo;
                txtTrabajo.Text = Padre.Trabajo;
            }
            else
            {
                txtApellidosNombresPadre.Text = "";
                txtDirecion.Text = "";
                txtCelular.Text = "";
                txtCorreo.Text = "";
                txtTrabajo.Text = "";
            }
        }
        /// <summary>
        /// Este metodo se usa para habilitar o desabilitar los controles del Segundo Padre o Apoderado
        /// </summary>
        /// 
        /// <param name="valor"> true para desactivar controles </param>
        private void controlespadre2_desactivar(bool valor)
        {
            cmbPadreSecDepartamento.Enabled = !valor;
            cmbPadreSecProvincia.Enabled = !valor;
            cmbPadreSecDistrito.Enabled = !valor;
            cmbPadreSecProvincia.Visible = !valor;
            cmbPadreSecDistrito.Visible = !valor;
            txtPadreSecApellidosNombres.Enabled = !valor;
            txtPadreSecCelular.Enabled = !valor;
            txtPadreSecCorreo.Enabled = !valor;
            txtPadreSecDireccion.Enabled = !valor;
            txtPadreSecTrabajo.Enabled = !valor;
            if (valor && PadreSec != null)
            {
                txtPadreSecApellidosNombres.Text = PadreSec.NombreCompleto;
                txtPadreSecCelular.Text = PadreSec.NumeroCelular;
                txtPadreSecCorreo.Text = PadreSec.Correo;
                txtPadreSecDireccion.Text = PadreSec.Direccion;
                txtPadreSecTrabajo.Text = PadreSec.Trabajo; 
            }
            else
            {
                txtPadreSecApellidosNombres.Text = "";
                txtPadreSecCelular.Text = "";
                txtPadreSecCorreo.Text = "";
                txtPadreSecDireccion.Text = "";
                txtPadreSecTrabajo.Text = ""; 
            }
        }
        /// <summary>
        /// Este metodo se usa para habilitar o desabilitar los controles del Estudiante
        /// </summary>
        /// 
        /// <param name="valor"> true para desactivar controles </param>
        private void controlesEstudiante_desactivar(bool valor)
        {
            dtpEstudianteFechaNac.Enabled = !valor;
            cmbGrado.Enabled = !valor;
            cmbSeccion.Enabled = !valor;
            txtEstudianteApellidosNombres.Enabled = !valor;
            txtEstudianteCelular.Enabled = !valor;
            txtEstudianteColegioProcedencia.Enabled = !valor;
            txtEstudianteCondicionSalud.Enabled = !valor;
            nudEstudiantePeso.Enabled = !valor;
            nudEstudianteTalla.Enabled = !valor;

            if (valor && Estudiante != null)
            {
                MessageBox.Show("El estudinte ya existe,\n con el nombre de : "
                    + Estudiante.ApellidosNombres +
                    "\n No Puede Volver a Registrarlo");
                Estudiante = null;
                txtEstudianteNumDoc.Text = "";
                txtEstudianteNumDoc.Focus();
            }
            else
            {
                txtEstudianteApellidosNombres.Text = "";
                txtEstudianteCelular.Text = "";
                txtEstudianteColegioProcedencia.Text = "";
                txtEstudianteCondicionSalud.Text = "";
                dtpEstudianteFechaNac.Value = dtpEstudianteFechaNac.MaxDate;
                nudEstudiantePeso.Value = 0;
                nudEstudianteTalla.Value = 0;
            }
        }
        #endregion
        #region comprovar campos
        private bool comprobar_datos_Padre()
        {
            if (//datos obligatorios del Padre
                txtApellidosNombresPadre.Text != "" &&
                txtNumeroDocumento.Text != "" && 
                txtNumeroDocumento.Text.Length == txtNumeroDocumento.MaxLength &&
                txtDirecion.Text != "" &&
                cmbDistrito.Text != "" &&
                txtCelular.Text != "" &&
                txtTrabajo.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool comprobar_datos_Padre2()
        {
            if (chkPadreSecundario.Checked == true)
            {
                if (//Verificacion de datos del padre secundario
                        txtPadreSecApellidosNombres.Text != "" &&
                        txtPadreSecCelular.Text != "" &&
                        txtPadreSecDireccion.Text != "" &&
                        txtPadreSecNumeroDocumento.Text != "" && txtPadreSecNumeroDocumento.Text.Length == txtPadreSecNumeroDocumento.MaxLength &&
                        txtPadreSecTrabajo.Text != "" &&
                        cmbPadreSecDistrito.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool comprobar_datos_Estudiante()
        {
            if (//datos del estudiante
                txtEstudianteNumDoc.Text != "" 
                && txtEstudianteNumDoc.Text.Length == txtEstudianteNumDoc.MaxLength &&
                dtpEstudianteFechaNac.Value != dtpEstudianteFechaNac.MaxDate &&
                txtEstudianteApellidosNombres.Text != "" &&
                txtEstudianteColegioProcedencia.Text != "" &&
                nudEstudiantePeso.Value != 0 &&
                nudEstudianteTalla.Value != 0 &&
                cmbGrado.Text != "" &&
                cmbSeccion.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion        
        #region Reiniciar Formulario
        private void restart()
        {
            //limpiar los datos Almacenados
            Padre = null;
            PadreSec = null;
            Estudiante = null;
            // limpiar controles de Padre o Apoderado
            txtApellidosNombresPadre.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            txtDirecion.Text = "";
            txtTrabajo.Text = "";
            txtNumeroDocumento.Text = "";
            //limpiar controles de Segundo Padre o Apoderado
            txtPadreSecApellidosNombres.Text = "";
            txtPadreSecCelular.Text = "";
            txtPadreSecCorreo.Text = "";
            txtPadreSecDireccion.Text = "";
            txtPadreSecNumeroDocumento.Text = "";
            txtPadreSecTrabajo.Text = "";

            //limpiar controles de Estudiante
            txtEstudianteApellidosNombres.Text = "";
            txtEstudianteCelular.Text = "";
            txtEstudianteColegioProcedencia.Text = "";
            txtEstudianteCondicionSalud.Text = "";
            txtEstudianteNumDoc.Text = "";

            Valores_porDefecto();
        }
        #endregion
    }
}
