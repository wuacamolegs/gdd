namespace FrbaCommerce.Editar_Publicacion
{
    partial class frmMisPublicaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtgListado = new System.Windows.Forms.DataGridView();
            this.btnResponderPregs = new System.Windows.Forms.Button();
            this.btnRespuestas = new System.Windows.Forms.Button();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.txtDescripcion);
            this.grpFiltros.Controls.Add(this.lblDescripcion);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(41, 13);
            this.grpFiltros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFiltros.Size = new System.Drawing.Size(425, 135);
            this.grpFiltros.TabIndex = 38;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(97, 40);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(116, 23);
            this.txtDescripcion.TabIndex = 30;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(19, 44);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 15);
            this.lblDescripcion.TabIndex = 29;
            this.lblDescripcion.Text = "Descripción";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(97, 94);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 26);
            this.btnLimpiar.TabIndex = 26;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(22, 94);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 26);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtgListado
            // 
            this.dtgListado.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgListado.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgListado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListado.Location = new System.Drawing.Point(41, 205);
            this.dtgListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgListado.MultiSelect = false;
            this.dtgListado.Name = "dtgListado";
            this.dtgListado.ReadOnly = true;
            this.dtgListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListado.Size = new System.Drawing.Size(819, 267);
            this.dtgListado.TabIndex = 41;
            this.dtgListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListado_CellContentClick);
            // 
            // btnResponderPregs
            // 
            this.btnResponderPregs.BackColor = System.Drawing.Color.PowderBlue;
            this.btnResponderPregs.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnResponderPregs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResponderPregs.Location = new System.Drawing.Point(773, 157);
            this.btnResponderPregs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResponderPregs.Name = "btnResponderPregs";
            this.btnResponderPregs.Size = new System.Drawing.Size(87, 40);
            this.btnResponderPregs.TabIndex = 43;
            this.btnResponderPregs.Text = "Responder Preguntas";
            this.btnResponderPregs.UseVisualStyleBackColor = false;
            this.btnResponderPregs.Click += new System.EventHandler(this.btnResponderPregs_Click);
            // 
            // btnRespuestas
            // 
            this.btnRespuestas.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRespuestas.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnRespuestas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRespuestas.Location = new System.Drawing.Point(680, 157);
            this.btnRespuestas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRespuestas.Name = "btnRespuestas";
            this.btnRespuestas.Size = new System.Drawing.Size(87, 40);
            this.btnRespuestas.TabIndex = 44;
            this.btnRespuestas.Text = "Ver Respuestas";
            this.btnRespuestas.UseVisualStyleBackColor = false;
            this.btnRespuestas.Click += new System.EventHandler(this.btnRespuestas_Click);
            // 
            // frmMisPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(916, 485);
            this.Controls.Add(this.btnRespuestas);
            this.Controls.Add(this.btnResponderPregs);
            this.Controls.Add(this.dtgListado);
            this.Controls.Add(this.grpFiltros);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMisPublicaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis Publicaciones";
            this.Load += new System.EventHandler(this.frmMisPublicaciones_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblDescripcion;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.DataGridView dtgListado;
        private System.Windows.Forms.Button btnResponderPregs;
        private System.Windows.Forms.Button btnRespuestas;
    }
}