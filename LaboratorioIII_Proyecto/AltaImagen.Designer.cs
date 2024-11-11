namespace LaboratorioIII_Proyecto
{
    partial class AltaImagen
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
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.pcbImagenUrl = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnMostrarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(70, 21);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(341, 20);
            this.txtUrlImagen.TabIndex = 0;
            this.txtUrlImagen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUrl.Location = new System.Drawing.Point(32, 28);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "URL:";
            // 
            // pcbImagenUrl
            // 
            this.pcbImagenUrl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pcbImagenUrl.Location = new System.Drawing.Point(70, 76);
            this.pcbImagenUrl.Name = "pcbImagenUrl";
            this.pcbImagenUrl.Size = new System.Drawing.Size(341, 273);
            this.pcbImagenUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenUrl.TabIndex = 2;
            this.pcbImagenUrl.TabStop = false;
            this.pcbImagenUrl.Click += new System.EventHandler(this.pcbImagenUrl_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(70, 366);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(94, 24);
            this.btnAgregarImagen.TabIndex = 3;
            this.btnAgregarImagen.Text = "Agregar";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(314, 366);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 24);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnMostrarImagen
            // 
            this.btnMostrarImagen.Location = new System.Drawing.Point(183, 47);
            this.btnMostrarImagen.Name = "btnMostrarImagen";
            this.btnMostrarImagen.Size = new System.Drawing.Size(109, 23);
            this.btnMostrarImagen.TabIndex = 5;
            this.btnMostrarImagen.Text = "Mostrar Imagen";
            this.btnMostrarImagen.UseVisualStyleBackColor = true;
            this.btnMostrarImagen.Click += new System.EventHandler(this.btnMostrarImagen_Click);
            // 
            // AltaImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(487, 428);
            this.Controls.Add(this.btnMostrarImagen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pcbImagenUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrlImagen);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(503, 467);
            this.MinimumSize = new System.Drawing.Size(503, 467);
            this.Name = "AltaImagen";
            this.Text = "AltaImagen";
            this.Load += new System.EventHandler(this.AltaImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenUrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.PictureBox pcbImagenUrl;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnMostrarImagen;
    }
}