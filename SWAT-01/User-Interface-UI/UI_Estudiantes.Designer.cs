﻿namespace User_Interface_UI
{
    partial class UI_Estudiantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Estudiantes));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnModificarDatos = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMenuHiden = new System.Windows.Forms.Button();
            this.btnNuevoEstudiante = new System.Windows.Forms.Button();
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
            this.panelMenu.Controls.Add(this.btnModificarDatos);
            this.panelMenu.Controls.Add(this.btnCerrar);
            this.panelMenu.Controls.Add(this.btnMenuHiden);
            this.panelMenu.Controls.Add(this.btnNuevoEstudiante);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(40, 321);
            this.panelMenu.TabIndex = 0;
            // 
            // btnModificarDatos
            // 
            this.btnModificarDatos.FlatAppearance.BorderSize = 0;
            this.btnModificarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDatos.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDatos.ForeColor = System.Drawing.Color.Black;
            this.btnModificarDatos.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarDatos.Image")));
            this.btnModificarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarDatos.Location = new System.Drawing.Point(0, 96);
            this.btnModificarDatos.Name = "btnModificarDatos";
            this.btnModificarDatos.Size = new System.Drawing.Size(200, 43);
            this.btnModificarDatos.TabIndex = 13;
            this.btnModificarDatos.Text = "&Modificar datos";
            this.btnModificarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarDatos.UseVisualStyleBackColor = true;
            this.btnModificarDatos.Click += new System.EventHandler(this.btnModificarDatos_Click);
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
            // btnNuevoEstudiante
            // 
            this.btnNuevoEstudiante.FlatAppearance.BorderSize = 0;
            this.btnNuevoEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEstudiante.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEstudiante.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoEstudiante.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoEstudiante.Image")));
            this.btnNuevoEstudiante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoEstudiante.Location = new System.Drawing.Point(0, 47);
            this.btnNuevoEstudiante.Name = "btnNuevoEstudiante";
            this.btnNuevoEstudiante.Size = new System.Drawing.Size(200, 43);
            this.btnNuevoEstudiante.TabIndex = 9;
            this.btnNuevoEstudiante.Text = "&Nuevo estudiante";
            this.btnNuevoEstudiante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoEstudiante.UseVisualStyleBackColor = true;
            this.btnNuevoEstudiante.Click += new System.EventHandler(this.btnNuevoEstudiante_Click);
            // 
            // UI_Estudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(579, 321);
            this.Controls.Add(this.panelContenedor);
            this.Name = "UI_Estudiantes";
            this.Text = "UI_Estudiantes";
            this.Load += new System.EventHandler(this.UI_Estudiantes_Load);
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
        private System.Windows.Forms.Button btnNuevoEstudiante;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnModificarDatos;
    }
}