namespace User_Interface_UI
{
    partial class UI_Pagos_Prorroga
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pagos_Prorroga));
            this.panelBuscarDatos = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstudianteNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstEstudiantes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.panelRegistroPago = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpprorroga = new System.Windows.Forms.DateTimePicker();
            this.btnNuevaBusqueda = new System.Windows.Forms.Button();
            this.labelEstudiante = new System.Windows.Forms.Label();
            this.lstPagos = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnaplicarprorroga = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panelBuscarDatos.SuspendLayout();
            this.panelRegistroPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBuscarDatos
            // 
            this.panelBuscarDatos.Controls.Add(this.label2);
            this.panelBuscarDatos.Controls.Add(this.txtEstudianteNumeroDocumento);
            this.panelBuscarDatos.Controls.Add(this.label1);
            this.panelBuscarDatos.Controls.Add(this.lstEstudiantes);
            this.panelBuscarDatos.Controls.Add(this.btnBuscar);
            this.panelBuscarDatos.Controls.Add(this.btnSeleccionar);
            this.panelBuscarDatos.Location = new System.Drawing.Point(0, 0);
            this.panelBuscarDatos.Name = "panelBuscarDatos";
            this.panelBuscarDatos.Size = new System.Drawing.Size(717, 298);
            this.panelBuscarDatos.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prorrogas";
            // 
            // txtEstudianteNumeroDocumento
            // 
            this.txtEstudianteNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstudianteNumeroDocumento.Location = new System.Drawing.Point(284, 56);
            this.txtEstudianteNumeroDocumento.MaxLength = 12;
            this.txtEstudianteNumeroDocumento.Name = "txtEstudianteNumeroDocumento";
            this.txtEstudianteNumeroDocumento.Size = new System.Drawing.Size(182, 29);
            this.txtEstudianteNumeroDocumento.TabIndex = 2;
            this.txtEstudianteNumeroDocumento.TextChanged += new System.EventHandler(this.txtEstudianteNumeroDocumento_TextChanged);
            this.txtEstudianteNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstudianteNumeroDocumento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estudiante Numero Documento";
            // 
            // lstEstudiantes
            // 
            this.lstEstudiantes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstEstudiantes.BackColor = System.Drawing.Color.Gainsboro;
            this.lstEstudiantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstEstudiantes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEstudiantes.FullRowSelect = true;
            this.lstEstudiantes.GridLines = true;
            this.lstEstudiantes.HideSelection = false;
            this.lstEstudiantes.Location = new System.Drawing.Point(53, 102);
            this.lstEstudiantes.MultiSelect = false;
            this.lstEstudiantes.Name = "lstEstudiantes";
            this.lstEstudiantes.Size = new System.Drawing.Size(483, 179);
            this.lstEstudiantes.TabIndex = 4;
            this.lstEstudiantes.UseCompatibleStateImageBehavior = false;
            this.lstEstudiantes.View = System.Windows.Forms.View.Details;
            this.lstEstudiantes.SelectedIndexChanged += new System.EventHandler(this.lstEstudiantes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombres y Apellidos";
            this.columnHeader1.Width = 322;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "N° Documento";
            this.columnHeader2.Width = 155;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(472, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(163, 44);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Enabled = false;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(542, 134);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(161, 42);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // panelRegistroPago
            // 
            this.panelRegistroPago.Controls.Add(this.label3);
            this.panelRegistroPago.Controls.Add(this.dtpprorroga);
            this.panelRegistroPago.Controls.Add(this.btnNuevaBusqueda);
            this.panelRegistroPago.Controls.Add(this.labelEstudiante);
            this.panelRegistroPago.Controls.Add(this.lstPagos);
            this.panelRegistroPago.Controls.Add(this.btnCancelar);
            this.panelRegistroPago.Controls.Add(this.btnaplicarprorroga);
            this.panelRegistroPago.Location = new System.Drawing.Point(12, 304);
            this.panelRegistroPago.Name = "panelRegistroPago";
            this.panelRegistroPago.Size = new System.Drawing.Size(731, 358);
            this.panelRegistroPago.TabIndex = 25;
            this.panelRegistroPago.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(249, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Dar prorroga hasta:";
            // 
            // dtpprorroga
            // 
            this.dtpprorroga.Enabled = false;
            this.dtpprorroga.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprorroga.Location = new System.Drawing.Point(400, 237);
            this.dtpprorroga.Name = "dtpprorroga";
            this.dtpprorroga.Size = new System.Drawing.Size(295, 29);
            this.dtpprorroga.TabIndex = 26;
            this.dtpprorroga.ValueChanged += new System.EventHandler(this.dtpprorroga_ValueChanged);
            // 
            // btnNuevaBusqueda
            // 
            this.btnNuevaBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaBusqueda.Location = new System.Drawing.Point(509, 8);
            this.btnNuevaBusqueda.Name = "btnNuevaBusqueda";
            this.btnNuevaBusqueda.Size = new System.Drawing.Size(163, 44);
            this.btnNuevaBusqueda.TabIndex = 25;
            this.btnNuevaBusqueda.Text = "&Nueva Busqueda";
            this.btnNuevaBusqueda.UseVisualStyleBackColor = true;
            this.btnNuevaBusqueda.Click += new System.EventHandler(this.btnNuevaBusqueda_Click);
            // 
            // labelEstudiante
            // 
            this.labelEstudiante.AutoSize = true;
            this.labelEstudiante.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstudiante.Location = new System.Drawing.Point(17, 20);
            this.labelEstudiante.Name = "labelEstudiante";
            this.labelEstudiante.Size = new System.Drawing.Size(0, 21);
            this.labelEstudiante.TabIndex = 7;
            // 
            // lstPagos
            // 
            this.lstPagos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstPagos.BackColor = System.Drawing.Color.Gainsboro;
            this.lstPagos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstPagos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPagos.FullRowSelect = true;
            this.lstPagos.GridLines = true;
            this.lstPagos.HideSelection = false;
            this.lstPagos.Location = new System.Drawing.Point(21, 61);
            this.lstPagos.MultiSelect = false;
            this.lstPagos.Name = "lstPagos";
            this.lstPagos.Size = new System.Drawing.Size(674, 155);
            this.lstPagos.TabIndex = 22;
            this.lstPagos.UseCompatibleStateImageBehavior = false;
            this.lstPagos.View = System.Windows.Forms.View.Details;
            this.lstPagos.SelectedIndexChanged += new System.EventHandler(this.lstPagos_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "N°";
            this.columnHeader4.Width = 59;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Descripcion";
            this.columnHeader3.Width = 199;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "F. Vencimiento";
            this.columnHeader5.Width = 115;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Estado";
            this.columnHeader6.Width = 167;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Monto";
            this.columnHeader7.Width = 110;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(371, 292);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 49);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnaplicarprorroga
            // 
            this.btnaplicarprorroga.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaplicarprorroga.Location = new System.Drawing.Point(515, 292);
            this.btnaplicarprorroga.Name = "btnaplicarprorroga";
            this.btnaplicarprorroga.Size = new System.Drawing.Size(180, 49);
            this.btnaplicarprorroga.TabIndex = 16;
            this.btnaplicarprorroga.Text = "&Aplicar prorroga";
            this.btnaplicarprorroga.UseVisualStyleBackColor = true;
            this.btnaplicarprorroga.Click += new System.EventHandler(this.btnAplicarProrroga_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.InitialImage")));
            this.btnCerrar.Location = new System.Drawing.Point(756, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // UI_Pagos_Prorroga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 706);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelRegistroPago);
            this.Controls.Add(this.panelBuscarDatos);
            this.Name = "UI_Pagos_Prorroga";
            this.Text = "UI_Pagos_Prorroga";
            this.panelBuscarDatos.ResumeLayout(false);
            this.panelBuscarDatos.PerformLayout();
            this.panelRegistroPago.ResumeLayout(false);
            this.panelRegistroPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBuscarDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstudianteNumeroDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstEstudiantes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Panel panelRegistroPago;
        private System.Windows.Forms.Button btnNuevaBusqueda;
        private System.Windows.Forms.Label labelEstudiante;
        private System.Windows.Forms.ListView lstPagos;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnaplicarprorroga;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpprorroga;
    }
}