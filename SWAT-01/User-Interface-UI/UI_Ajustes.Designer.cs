namespace User_Interface_UI
{
    partial class UI_Ajustes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Ajustes));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMenuHiden = new System.Windows.Forms.Button();
            this.btnAjustesGenerales = new System.Windows.Forms.Button();
            this.btnGrado = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(15)))), ((int)(((byte)(10)))));
            this.panelContenedor.Controls.Add(this.panelFormularios);
            this.panelContenedor.Controls.Add(this.panelMenu);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(579, 321);
            this.panelContenedor.TabIndex = 2;
            // 
            // panelFormularios
            // 
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(40, 0);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(539, 321);
            this.panelFormularios.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(138)))), ((int)(((byte)(8)))));
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnGrado);
            this.panelMenu.Controls.Add(this.btnCerrar);
            this.panelMenu.Controls.Add(this.btnMenuHiden);
            this.panelMenu.Controls.Add(this.btnAjustesGenerales);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(40, 321);
            this.panelMenu.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(3, 286);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMenuHiden
            // 
            this.btnMenuHiden.FlatAppearance.BorderSize = 0;
            this.btnMenuHiden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHiden.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHiden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnMenuHiden.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuHiden.Image")));
            this.btnMenuHiden.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnMenuHiden.Location = new System.Drawing.Point(0, 0);
            this.btnMenuHiden.Name = "btnMenuHiden";
            this.btnMenuHiden.Size = new System.Drawing.Size(40, 40);
            this.btnMenuHiden.TabIndex = 12;
            this.btnMenuHiden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuHiden.UseVisualStyleBackColor = true;
            this.btnMenuHiden.Click += new System.EventHandler(this.btnMenuHiden_Click);
            // 
            // btnAjustesGenerales
            // 
            this.btnAjustesGenerales.FlatAppearance.BorderSize = 0;
            this.btnAjustesGenerales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustesGenerales.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustesGenerales.ForeColor = System.Drawing.Color.Black;
            this.btnAjustesGenerales.Image = ((System.Drawing.Image)(resources.GetObject("btnAjustesGenerales.Image")));
            this.btnAjustesGenerales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjustesGenerales.Location = new System.Drawing.Point(0, 47);
            this.btnAjustesGenerales.Name = "btnAjustesGenerales";
            this.btnAjustesGenerales.Size = new System.Drawing.Size(200, 43);
            this.btnAjustesGenerales.TabIndex = 9;
            this.btnAjustesGenerales.Text = "&Periodo Academico";
            this.btnAjustesGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjustesGenerales.UseVisualStyleBackColor = true;
            this.btnAjustesGenerales.Click += new System.EventHandler(this.btnNuevoEstudiante_Click);
            // 
            // btnGrado
            // 
            this.btnGrado.FlatAppearance.BorderSize = 0;
            this.btnGrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrado.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrado.ForeColor = System.Drawing.Color.Black;
            this.btnGrado.Image = ((System.Drawing.Image)(resources.GetObject("btnGrado.Image")));
            this.btnGrado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrado.Location = new System.Drawing.Point(0, 96);
            this.btnGrado.Name = "btnGrado";
            this.btnGrado.Size = new System.Drawing.Size(200, 43);
            this.btnGrado.TabIndex = 13;
            this.btnGrado.Text = "&Grados y Secciones";
            this.btnGrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrado.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "&Fechas de pago";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UI_Ajustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(579, 321);
            this.Controls.Add(this.panelContenedor);
            this.Name = "UI_Ajustes";
            this.Text = "UI_Ajustes";
            this.Load += new System.EventHandler(this.UI_Ajustes_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Button btnMenuHiden;
        private System.Windows.Forms.Button btnAjustesGenerales;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGrado;
    }
}