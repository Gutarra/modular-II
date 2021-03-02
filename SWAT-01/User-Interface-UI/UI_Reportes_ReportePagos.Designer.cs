namespace User_Interface_UI
{
    partial class UI_Reportes_ReportePagos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Reportes_ReportePagos));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportePagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstudiantePagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MontoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PorcentajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPagos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.panelGrado = new System.Windows.Forms.Panel();
            this.btncrearGrado = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.btnReporteGrado = new System.Windows.Forms.Button();
            this.panelGradoSeccion = new System.Windows.Forms.Panel();
            this.btncrearEspecifico = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSeccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGradoEspecifico = new System.Windows.Forms.ComboBox();
            this.btnEspecifico = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panelReporteEspecifico = new System.Windows.Forms.Panel();
            this.panelReportesGenerales = new System.Windows.Forms.Panel();
            this.rptvGenerales = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstudiantePagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MontoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PorcentajeBindingSource)).BeginInit();
            this.panelmenu.SuspendLayout();
            this.panelGrado.SuspendLayout();
            this.panelGradoSeccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panelReporteEspecifico.SuspendLayout();
            this.panelReportesGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportePagosBindingSource
            // 
            this.ReportePagosBindingSource.DataSource = typeof(CN_Business_Layer.Report.ReportePagos);
            // 
            // EstudiantePagosBindingSource
            // 
            this.EstudiantePagosBindingSource.DataSource = typeof(CN_Business_Layer.Report.EstudiantePagos);
            // 
            // MontoBindingSource
            // 
            this.MontoBindingSource.DataSource = typeof(CN_Business_Layer.Report.Monto);
            // 
            // PorcentajeBindingSource
            // 
            this.PorcentajeBindingSource.DataSource = typeof(CN_Business_Layer.Report.Porcentaje);
            // 
            // rpvPagos
            // 
            this.rpvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Generales";
            reportDataSource1.Value = this.ReportePagosBindingSource;
            reportDataSource2.Name = "ListaEstudiantePagos";
            reportDataSource2.Value = this.EstudiantePagosBindingSource;
            reportDataSource3.Name = "Montos";
            reportDataSource3.Value = this.MontoBindingSource;
            reportDataSource4.Name = "Porcentaje";
            reportDataSource4.Value = this.PorcentajeBindingSource;
            this.rpvPagos.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPagos.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvPagos.LocalReport.DataSources.Add(reportDataSource3);
            this.rpvPagos.LocalReport.DataSources.Add(reportDataSource4);
            this.rpvPagos.LocalReport.ReportEmbeddedResource = "User_Interface_UI.Report.ReporteEspecificoPagos.rdlc";
            this.rpvPagos.Location = new System.Drawing.Point(0, 0);
            this.rpvPagos.Name = "rpvPagos";
            this.rpvPagos.ServerReport.BearerToken = null;
            this.rpvPagos.Size = new System.Drawing.Size(814, 447);
            this.rpvPagos.TabIndex = 0;
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(4)))));
            this.panelmenu.Controls.Add(this.btnGeneral);
            this.panelmenu.Controls.Add(this.panelGrado);
            this.panelmenu.Controls.Add(this.panelGradoSeccion);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 447);
            this.panelmenu.TabIndex = 1;
            // 
            // btnGeneral
            // 
            this.btnGeneral.BackColor = System.Drawing.Color.Olive;
            this.btnGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGeneral.FlatAppearance.BorderSize = 0;
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.btnGeneral.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGeneral.Location = new System.Drawing.Point(0, 320);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(200, 43);
            this.btnGeneral.TabIndex = 14;
            this.btnGeneral.Text = "&Reporte General";
            this.btnGeneral.UseVisualStyleBackColor = false;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // panelGrado
            // 
            this.panelGrado.Controls.Add(this.btncrearGrado);
            this.panelGrado.Controls.Add(this.label3);
            this.panelGrado.Controls.Add(this.cmbGrado);
            this.panelGrado.Controls.Add(this.btnReporteGrado);
            this.panelGrado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrado.Location = new System.Drawing.Point(0, 180);
            this.panelGrado.Name = "panelGrado";
            this.panelGrado.Size = new System.Drawing.Size(200, 140);
            this.panelGrado.TabIndex = 1;
            // 
            // btncrearGrado
            // 
            this.btncrearGrado.BackColor = System.Drawing.Color.Olive;
            this.btncrearGrado.FlatAppearance.BorderSize = 0;
            this.btncrearGrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncrearGrado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrearGrado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.btncrearGrado.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btncrearGrado.Location = new System.Drawing.Point(28, 91);
            this.btncrearGrado.Name = "btncrearGrado";
            this.btncrearGrado.Size = new System.Drawing.Size(143, 43);
            this.btncrearGrado.TabIndex = 16;
            this.btncrearGrado.Text = "Crear Reporte  ";
            this.btncrearGrado.UseVisualStyleBackColor = false;
            this.btncrearGrado.Click += new System.EventHandler(this.btncrearGrado_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Grado";
            // 
            // cmbGrado
            // 
            this.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(71, 49);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(121, 29);
            this.cmbGrado.TabIndex = 14;
            this.cmbGrado.SelectedIndexChanged += new System.EventHandler(this.cmbGrado_SelectedIndexChanged);
            // 
            // btnReporteGrado
            // 
            this.btnReporteGrado.BackColor = System.Drawing.Color.Olive;
            this.btnReporteGrado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteGrado.FlatAppearance.BorderSize = 0;
            this.btnReporteGrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteGrado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteGrado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.btnReporteGrado.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReporteGrado.Location = new System.Drawing.Point(0, 0);
            this.btnReporteGrado.Name = "btnReporteGrado";
            this.btnReporteGrado.Size = new System.Drawing.Size(200, 43);
            this.btnReporteGrado.TabIndex = 13;
            this.btnReporteGrado.Text = "Por &Grado";
            this.btnReporteGrado.UseVisualStyleBackColor = false;
            this.btnReporteGrado.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelGradoSeccion
            // 
            this.panelGradoSeccion.Controls.Add(this.btncrearEspecifico);
            this.panelGradoSeccion.Controls.Add(this.label2);
            this.panelGradoSeccion.Controls.Add(this.cmbSeccion);
            this.panelGradoSeccion.Controls.Add(this.label1);
            this.panelGradoSeccion.Controls.Add(this.cmbGradoEspecifico);
            this.panelGradoSeccion.Controls.Add(this.btnEspecifico);
            this.panelGradoSeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGradoSeccion.Location = new System.Drawing.Point(0, 0);
            this.panelGradoSeccion.Name = "panelGradoSeccion";
            this.panelGradoSeccion.Size = new System.Drawing.Size(200, 180);
            this.panelGradoSeccion.TabIndex = 0;
            // 
            // btncrearEspecifico
            // 
            this.btncrearEspecifico.BackColor = System.Drawing.Color.Olive;
            this.btncrearEspecifico.FlatAppearance.BorderSize = 0;
            this.btncrearEspecifico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncrearEspecifico.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrearEspecifico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.btncrearEspecifico.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btncrearEspecifico.Location = new System.Drawing.Point(28, 131);
            this.btncrearEspecifico.Name = "btncrearEspecifico";
            this.btncrearEspecifico.Size = new System.Drawing.Size(143, 43);
            this.btncrearEspecifico.TabIndex = 12;
            this.btncrearEspecifico.Text = "Crear Reporte  ";
            this.btncrearEspecifico.UseVisualStyleBackColor = false;
            this.btncrearEspecifico.Click += new System.EventHandler(this.btncrearEspecifico_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sección";
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeccion.FormattingEnabled = true;
            this.cmbSeccion.Location = new System.Drawing.Point(81, 84);
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new System.Drawing.Size(111, 29);
            this.cmbSeccion.TabIndex = 10;
            this.cmbSeccion.SelectedIndexChanged += new System.EventHandler(this.cmbSeccion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Grado";
            // 
            // cmbGradoEspecifico
            // 
            this.cmbGradoEspecifico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradoEspecifico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGradoEspecifico.FormattingEnabled = true;
            this.cmbGradoEspecifico.Location = new System.Drawing.Point(71, 49);
            this.cmbGradoEspecifico.Name = "cmbGradoEspecifico";
            this.cmbGradoEspecifico.Size = new System.Drawing.Size(121, 29);
            this.cmbGradoEspecifico.TabIndex = 8;
            this.cmbGradoEspecifico.SelectedIndexChanged += new System.EventHandler(this.cmbGradoEspecifico_SelectedIndexChanged);
            // 
            // btnEspecifico
            // 
            this.btnEspecifico.BackColor = System.Drawing.Color.Olive;
            this.btnEspecifico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEspecifico.FlatAppearance.BorderSize = 0;
            this.btnEspecifico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecifico.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecifico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(107)))));
            this.btnEspecifico.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEspecifico.Location = new System.Drawing.Point(0, 0);
            this.btnEspecifico.Name = "btnEspecifico";
            this.btnEspecifico.Size = new System.Drawing.Size(200, 43);
            this.btnEspecifico.TabIndex = 7;
            this.btnEspecifico.Text = "&Especifico";
            this.btnEspecifico.UseVisualStyleBackColor = false;
            this.btnEspecifico.Click += new System.EventHandler(this.btnEspecifico_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(770, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelReporteEspecifico
            // 
            this.panelReporteEspecifico.Controls.Add(this.rpvPagos);
            this.panelReporteEspecifico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReporteEspecifico.Enabled = false;
            this.panelReporteEspecifico.Location = new System.Drawing.Point(200, 0);
            this.panelReporteEspecifico.Name = "panelReporteEspecifico";
            this.panelReporteEspecifico.Size = new System.Drawing.Size(814, 447);
            this.panelReporteEspecifico.TabIndex = 2;
            this.panelReporteEspecifico.Visible = false;
            // 
            // panelReportesGenerales
            // 
            this.panelReportesGenerales.Controls.Add(this.btnCerrar);
            this.panelReportesGenerales.Controls.Add(this.rptvGenerales);
            this.panelReportesGenerales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportesGenerales.Location = new System.Drawing.Point(200, 0);
            this.panelReportesGenerales.Name = "panelReportesGenerales";
            this.panelReportesGenerales.Size = new System.Drawing.Size(814, 447);
            this.panelReportesGenerales.TabIndex = 3;
            // 
            // rptvGenerales
            // 
            this.rptvGenerales.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "ListaPagos";
            reportDataSource5.Value = this.EstudiantePagosBindingSource;
            reportDataSource6.Name = "DatosGenerales";
            reportDataSource6.Value = this.ReportePagosBindingSource;
            reportDataSource7.Name = "ListaMonto";
            reportDataSource7.Value = this.MontoBindingSource;
            reportDataSource8.Name = "ListaPorcentajes";
            reportDataSource8.Value = this.PorcentajeBindingSource;
            this.rptvGenerales.LocalReport.DataSources.Add(reportDataSource5);
            this.rptvGenerales.LocalReport.DataSources.Add(reportDataSource6);
            this.rptvGenerales.LocalReport.DataSources.Add(reportDataSource7);
            this.rptvGenerales.LocalReport.DataSources.Add(reportDataSource8);
            this.rptvGenerales.LocalReport.ReportEmbeddedResource = "User_Interface_UI.Report.ReporteGeneralPagos.rdlc";
            this.rptvGenerales.Location = new System.Drawing.Point(0, 0);
            this.rptvGenerales.Name = "rptvGenerales";
            this.rptvGenerales.ServerReport.BearerToken = null;
            this.rptvGenerales.Size = new System.Drawing.Size(814, 447);
            this.rptvGenerales.TabIndex = 0;
            // 
            // UI_Reportes_ReportePagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1014, 447);
            this.Controls.Add(this.panelReportesGenerales);
            this.Controls.Add(this.panelReporteEspecifico);
            this.Controls.Add(this.panelmenu);
            this.Name = "UI_Reportes_ReportePagos";
            this.Text = "prueba";
            this.Load += new System.EventHandler(this.prueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportePagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstudiantePagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MontoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PorcentajeBindingSource)).EndInit();
            this.panelmenu.ResumeLayout(false);
            this.panelGrado.ResumeLayout(false);
            this.panelGrado.PerformLayout();
            this.panelGradoSeccion.ResumeLayout(false);
            this.panelGradoSeccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panelReporteEspecifico.ResumeLayout(false);
            this.panelReportesGenerales.ResumeLayout(false);
            this.panelReportesGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPagos;
        private System.Windows.Forms.BindingSource ReportePagosBindingSource;
        private System.Windows.Forms.BindingSource EstudiantePagosBindingSource;
        private System.Windows.Forms.BindingSource MontoBindingSource;
        private System.Windows.Forms.BindingSource PorcentajeBindingSource;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Panel panelGrado;
        private System.Windows.Forms.Panel panelGradoSeccion;
        private System.Windows.Forms.Button btncrearGrado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.Button btnReporteGrado;
        private System.Windows.Forms.Button btncrearEspecifico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSeccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGradoEspecifico;
        private System.Windows.Forms.Button btnEspecifico;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Panel panelReporteEspecifico;
        private System.Windows.Forms.Panel panelReportesGenerales;
        private Microsoft.Reporting.WinForms.ReportViewer rptvGenerales;
        private System.Windows.Forms.PictureBox btnCerrar;
    }
}