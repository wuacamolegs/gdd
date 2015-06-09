namespace FrbaCommerce.Generar_Publicacion
{
    partial class frmDetallePublic
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCreacion = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblVisibilidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkPregs = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbVisibilidad = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lstRubros = new System.Windows.Forms.CheckedListBox();
            this.btnAumentarStock = new System.Windows.Forms.Button();
            this.btnRestarStock = new System.Windows.Forms.Button();
            this.dtFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(489, 413);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(80, 46);
            this.btnVolver.TabIndex = 62;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(166, 60);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(125, 23);
            this.txtStock.TabIndex = 60;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(50, 63);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(112, 15);
            this.lblStock.TabIndex = 58;
            this.lblStock.Text = "Stock                      *";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(167, 29);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(199, 23);
            this.txtDescripcion.TabIndex = 56;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(48, 32);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(114, 15);
            this.lblDescripcion.TabIndex = 55;
            this.lblDescripcion.Text = "Descripción          *";
            // 
            // lblCreacion
            // 
            this.lblCreacion.AutoSize = true;
            this.lblCreacion.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreacion.Location = new System.Drawing.Point(48, 128);
            this.lblCreacion.Name = "lblCreacion";
            this.lblCreacion.Size = new System.Drawing.Size(95, 15);
            this.lblCreacion.TabIndex = 63;
            this.lblCreacion.Text = "Fecha creación";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(50, 161);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(112, 15);
            this.lblTipo.TabIndex = 67;
            this.lblTipo.Text = "Tipo                        *";
            // 
            // lblVisibilidad
            // 
            this.lblVisibilidad.AutoSize = true;
            this.lblVisibilidad.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisibilidad.Location = new System.Drawing.Point(48, 192);
            this.lblVisibilidad.Name = "lblVisibilidad";
            this.lblVisibilidad.Size = new System.Drawing.Size(114, 15);
            this.lblVisibilidad.TabIndex = 69;
            this.lblVisibilidad.Text = "Visibilidad            *";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(48, 224);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(114, 15);
            this.lblEstado.TabIndex = 71;
            this.lblEstado.Text = "Estado                    *";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(167, 91);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(125, 23);
            this.txtPrecio.TabIndex = 77;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(48, 99);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(114, 15);
            this.lblPrecio.TabIndex = 76;
            this.lblPrecio.Text = "Precio                     *";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(396, 413);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(87, 46);
            this.btnGuardar.TabIndex = 78;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkPregs
            // 
            this.chkPregs.AutoSize = true;
            this.chkPregs.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPregs.Location = new System.Drawing.Point(51, 389);
            this.chkPregs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPregs.Name = "chkPregs";
            this.chkPregs.Size = new System.Drawing.Size(88, 19);
            this.chkPregs.TabIndex = 75;
            this.chkPregs.Text = "Preguntas";
            this.chkPregs.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(166, 224);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(140, 23);
            this.cmbEstado.TabIndex = 80;
            // 
            // cmbVisibilidad
            // 
            this.cmbVisibilidad.FormattingEnabled = true;
            this.cmbVisibilidad.Location = new System.Drawing.Point(167, 192);
            this.cmbVisibilidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVisibilidad.Name = "cmbVisibilidad";
            this.cmbVisibilidad.Size = new System.Drawing.Size(140, 23);
            this.cmbVisibilidad.TabIndex = 81;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(166, 161);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(140, 23);
            this.cmbTipo.TabIndex = 82;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRubro.Location = new System.Drawing.Point(48, 254);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(114, 15);
            this.lblRubro.TabIndex = 73;
            this.lblRubro.Text = "Rubro                     *";
            // 
            // lstRubros
            // 
            this.lstRubros.BackColor = System.Drawing.Color.Lavender;
            this.lstRubros.FormattingEnabled = true;
            this.lstRubros.Location = new System.Drawing.Point(166, 255);
            this.lstRubros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstRubros.Name = "lstRubros";
            this.lstRubros.Size = new System.Drawing.Size(231, 112);
            this.lstRubros.TabIndex = 79;
            // 
            // btnAumentarStock
            // 
            this.btnAumentarStock.AutoSize = true;
            this.btnAumentarStock.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAumentarStock.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnAumentarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAumentarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentarStock.Location = new System.Drawing.Point(297, 60);
            this.btnAumentarStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAumentarStock.Name = "btnAumentarStock";
            this.btnAumentarStock.Size = new System.Drawing.Size(30, 27);
            this.btnAumentarStock.TabIndex = 84;
            this.btnAumentarStock.Text = "+";
            this.btnAumentarStock.UseVisualStyleBackColor = false;
            this.btnAumentarStock.Click += new System.EventHandler(this.btnAumentarStock_Click);
            // 
            // btnRestarStock
            // 
            this.btnRestarStock.AutoSize = true;
            this.btnRestarStock.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRestarStock.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnRestarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestarStock.Location = new System.Drawing.Point(333, 60);
            this.btnRestarStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestarStock.Name = "btnRestarStock";
            this.btnRestarStock.Size = new System.Drawing.Size(30, 27);
            this.btnRestarStock.TabIndex = 85;
            this.btnRestarStock.Text = "-";
            this.btnRestarStock.UseVisualStyleBackColor = false;
            this.btnRestarStock.Click += new System.EventHandler(this.btnRestarStock_Click);
            // 
            // dtFechaCreacion
            // 
            this.dtFechaCreacion.Enabled = false;
            this.dtFechaCreacion.Location = new System.Drawing.Point(167, 128);
            this.dtFechaCreacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFechaCreacion.Name = "dtFechaCreacion";
            this.dtFechaCreacion.Size = new System.Drawing.Size(233, 23);
            this.dtFechaCreacion.TabIndex = 86;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Location = new System.Drawing.Point(396, 413);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(87, 46);
            this.btnGenerar.TabIndex = 87;
            this.btnGenerar.Text = "Generar publicación";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 14);
            this.label1.TabIndex = 88;
            this.label1.Text = "*   Campos Obligatorios";
            // 
            // frmDetallePublic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(598, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtFechaCreacion);
            this.Controls.Add(this.btnRestarStock);
            this.Controls.Add(this.btnAumentarStock);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbVisibilidad);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lstRubros);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.chkPregs);
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblVisibilidad);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCreacion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDetallePublic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Publicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCreacion;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblVisibilidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chkPregs;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbVisibilidad;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.CheckedListBox lstRubros;
        private System.Windows.Forms.Button btnAumentarStock;
        private System.Windows.Forms.Button btnRestarStock;
        private System.Windows.Forms.DateTimePicker dtFechaCreacion;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label1;
    }
}