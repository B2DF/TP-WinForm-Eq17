namespace TP_WinForm_Eq17
{
    partial class frmOtros
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiarCampo = new System.Windows.Forms.Button();
            this.lblContImg = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblContTotal = new System.Windows.Forms.Label();
            this.pbxCheckError = new System.Windows.Forms.PictureBox();
            this.gpbxArticulo = new System.Windows.Forms.GroupBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.lblIdArticulo = new System.Windows.Forms.Label();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbxOtros = new System.Windows.Forms.PictureBox();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCheckError)).BeginInit();
            this.gpbxArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOtros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(105, 473);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiarCampo
            // 
            this.btnLimpiarCampo.Location = new System.Drawing.Point(223, 22);
            this.btnLimpiarCampo.Name = "btnLimpiarCampo";
            this.btnLimpiarCampo.Size = new System.Drawing.Size(21, 20);
            this.btnLimpiarCampo.TabIndex = 1;
            this.btnLimpiarCampo.UseVisualStyleBackColor = true;
            this.btnLimpiarCampo.Click += new System.EventHandler(this.btnLimpiarCampo_Click);
            // 
            // lblContImg
            // 
            this.lblContImg.AutoSize = true;
            this.lblContImg.Location = new System.Drawing.Point(137, 413);
            this.lblContImg.Name = "lblContImg";
            this.lblContImg.Size = new System.Drawing.Size(19, 13);
            this.lblContImg.TabIndex = 22;
            this.lblContImg.Text = "aa";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(197, 408);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(23, 408);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblContTotal
            // 
            this.lblContTotal.AutoSize = true;
            this.lblContTotal.Location = new System.Drawing.Point(26, 447);
            this.lblContTotal.Name = "lblContTotal";
            this.lblContTotal.Size = new System.Drawing.Size(19, 13);
            this.lblContTotal.TabIndex = 21;
            this.lblContTotal.Text = "aa";
            // 
            // pbxCheckError
            // 
            this.pbxCheckError.Location = new System.Drawing.Point(250, 22);
            this.pbxCheckError.Name = "pbxCheckError";
            this.pbxCheckError.Size = new System.Drawing.Size(19, 20);
            this.pbxCheckError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCheckError.TabIndex = 19;
            this.pbxCheckError.TabStop = false;
            // 
            // gpbxArticulo
            // 
            this.gpbxArticulo.Controls.Add(this.tbxNombre);
            this.gpbxArticulo.Controls.Add(this.lblIdArticulo);
            this.gpbxArticulo.Controls.Add(this.tbxId);
            this.gpbxArticulo.Controls.Add(this.lblNombre);
            this.gpbxArticulo.Location = new System.Drawing.Point(23, 57);
            this.gpbxArticulo.Name = "gpbxArticulo";
            this.gpbxArticulo.Size = new System.Drawing.Size(249, 100);
            this.gpbxArticulo.TabIndex = 14;
            this.gpbxArticulo.TabStop = false;
            this.gpbxArticulo.Text = "Articulo";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(78, 31);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.ReadOnly = true;
            this.tbxNombre.Size = new System.Drawing.Size(140, 20);
            this.tbxNombre.TabIndex = 0;
            this.tbxNombre.TabStop = false;
            // 
            // lblIdArticulo
            // 
            this.lblIdArticulo.AutoSize = true;
            this.lblIdArticulo.Location = new System.Drawing.Point(28, 57);
            this.lblIdArticulo.Name = "lblIdArticulo";
            this.lblIdArticulo.Size = new System.Drawing.Size(21, 13);
            this.lblIdArticulo.TabIndex = 7;
            this.lblIdArticulo.Text = "ID:";
            // 
            // tbxId
            // 
            this.tbxId.Location = new System.Drawing.Point(78, 57);
            this.tbxId.Name = "tbxId";
            this.tbxId.ReadOnly = true;
            this.tbxId.Size = new System.Drawing.Size(71, 20);
            this.tbxId.TabIndex = 1;
            this.tbxId.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(28, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(197, 473);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(23, 473);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbxOtros
            // 
            this.pbxOtros.Location = new System.Drawing.Point(23, 163);
            this.pbxOtros.Name = "pbxOtros";
            this.pbxOtros.Size = new System.Drawing.Size(249, 239);
            this.pbxOtros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOtros.TabIndex = 16;
            this.pbxOtros.TabStop = false;
            // 
            // tbxSource
            // 
            this.tbxSource.Location = new System.Drawing.Point(76, 22);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.Size = new System.Drawing.Size(140, 20);
            this.tbxSource.TabIndex = 0;
            this.tbxSource.Leave += new System.EventHandler(this.tbxSource_Leave);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(26, 25);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 12;
            this.lblSource.Text = "Source:";
            // 
            // frmOtros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 519);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnLimpiarCampo);
            this.Controls.Add(this.lblContImg);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblContTotal);
            this.Controls.Add(this.pbxCheckError);
            this.Controls.Add(this.gpbxArticulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbxOtros);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.lblSource);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 558);
            this.MinimumSize = new System.Drawing.Size(310, 558);
            this.Name = "frmOtros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOtros";
            this.Load += new System.EventHandler(this.frmOtros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCheckError)).EndInit();
            this.gpbxArticulo.ResumeLayout(false);
            this.gpbxArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiarCampo;
        private System.Windows.Forms.Label lblContImg;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblContTotal;
        private System.Windows.Forms.PictureBox pbxCheckError;
        private System.Windows.Forms.GroupBox gpbxArticulo;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label lblIdArticulo;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pbxOtros;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.Label lblSource;
    }
}