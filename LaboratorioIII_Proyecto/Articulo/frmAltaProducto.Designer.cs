﻿namespace LaboratorioIII_Proyecto
{
    partial class frmAltaProducto
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreAr = new System.Windows.Forms.Label();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cbxCat = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtbPrecio = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtbDescAr = new System.Windows.Forms.RichTextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelarProducto = new System.Windows.Forms.Button();
            this.txtbUrlImagen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxProductoImagen = new System.Windows.Forms.PictureBox();
            this.btnImagenModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductoImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CREAR Producto";
            // 
            // lblNombreAr
            // 
            this.lblNombreAr.AutoSize = true;
            this.lblNombreAr.Location = new System.Drawing.Point(17, 83);
            this.lblNombreAr.Name = "lblNombreAr";
            this.lblNombreAr.Size = new System.Drawing.Size(54, 13);
            this.lblNombreAr.TabIndex = 1;
            this.lblNombreAr.Text = "Nombre:";
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(121, 80);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(205, 20);
            this.txtbNombre.TabIndex = 1;
            // 
            // cbxMarca
            // 
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(121, 140);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(205, 21);
            this.cbxMarca.TabIndex = 3;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(17, 148);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(46, 13);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca:";
            // 
            // cbxCat
            // 
            this.cbxCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCat.FormattingEnabled = true;
            this.cbxCat.Location = new System.Drawing.Point(121, 171);
            this.cbxCat.Name = "cbxCat";
            this.cbxCat.Size = new System.Drawing.Size(205, 21);
            this.cbxCat.TabIndex = 4;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(17, 179);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(65, 13);
            this.lblCat.TabIndex = 8;
            this.lblCat.Text = "Categoria:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(17, 205);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 13);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtbPrecio
            // 
            this.txtbPrecio.Location = new System.Drawing.Point(121, 202);
            this.txtbPrecio.Name = "txtbPrecio";
            this.txtbPrecio.Size = new System.Drawing.Size(205, 20);
            this.txtbPrecio.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(17, 112);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(78, 13);
            this.lblDesc.TabIndex = 11;
            this.lblDesc.Text = "Descripción:";
            // 
            // txtbDescAr
            // 
            this.txtbDescAr.Location = new System.Drawing.Point(121, 109);
            this.txtbDescAr.Name = "txtbDescAr";
            this.txtbDescAr.Size = new System.Drawing.Size(205, 25);
            this.txtbDescAr.TabIndex = 2;
            this.txtbDescAr.Text = "";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 260);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 35);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.Location = new System.Drawing.Point(226, 260);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(100, 35);
            this.btnCancelarProducto.TabIndex = 8;
            this.btnCancelarProducto.Text = "Cancelar";
            this.btnCancelarProducto.UseVisualStyleBackColor = true;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtbUrlImagen
            // 
            this.txtbUrlImagen.Location = new System.Drawing.Point(121, 231);
            this.txtbUrlImagen.Name = "txtbUrlImagen";
            this.txtbUrlImagen.Size = new System.Drawing.Size(205, 20);
            this.txtbUrlImagen.TabIndex = 6;
            this.txtbUrlImagen.Leave += new System.EventHandler(this.txtbUrlImagen_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Url Imagen";
            // 
            // pbxProductoImagen
            // 
            this.pbxProductoImagen.Location = new System.Drawing.Point(347, 51);
            this.pbxProductoImagen.Name = "pbxProductoImagen";
            this.pbxProductoImagen.Size = new System.Drawing.Size(215, 240);
            this.pbxProductoImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProductoImagen.TabIndex = 17;
            this.pbxProductoImagen.TabStop = false;
            // 
            // btnImagenModificar
            // 
            this.btnImagenModificar.Location = new System.Drawing.Point(133, 260);
            this.btnImagenModificar.Name = "btnImagenModificar";
            this.btnImagenModificar.Size = new System.Drawing.Size(87, 35);
            this.btnImagenModificar.TabIndex = 18;
            this.btnImagenModificar.Text = "Modificar imagen";
            this.btnImagenModificar.UseVisualStyleBackColor = true;
            this.btnImagenModificar.Visible = false;
            this.btnImagenModificar.Click += new System.EventHandler(this.btnImagenModificar_Click);
            // 
            // frmAltaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(571, 344);
            this.Controls.Add(this.btnImagenModificar);
            this.Controls.Add(this.pbxProductoImagen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbUrlImagen);
            this.Controls.Add(this.btnCancelarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtbDescAr);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtbPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cbxCat);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cbxMarca);
            this.Controls.Add(this.txtbNombre);
            this.Controls.Add(this.lblNombreAr);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(587, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(587, 383);
            this.Name = "frmAltaProducto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Producto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductoImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreAr;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cbxCat;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtbPrecio;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.RichTextBox txtbDescAr;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelarProducto;
        private System.Windows.Forms.TextBox txtbUrlImagen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxProductoImagen;
        private System.Windows.Forms.Button btnImagenModificar;
    }
}