namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class frmFacturar
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
            this.lblPublicacionesARendir = new System.Windows.Forms.Label();
            this.cmbFormaDePago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dtgPublicacionesARendir = new System.Windows.Forms.DataGridView();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.grpTarjeta = new System.Windows.Forms.GroupBox();
            this.lblNroTarj = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblFechaVto = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblCódigo = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtNroTarj = new System.Windows.Forms.TextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.cmbFecha = new System.Windows.Forms.DateTimePicker();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPublicacionesARendir)).BeginInit();
            this.grpTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPublicacionesARendir
            // 
            this.lblPublicacionesARendir.AutoSize = true;
            this.lblPublicacionesARendir.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicacionesARendir.Location = new System.Drawing.Point(25, 28);
            this.lblPublicacionesARendir.Name = "lblPublicacionesARendir";
            this.lblPublicacionesARendir.Size = new System.Drawing.Size(176, 19);
            this.lblPublicacionesARendir.TabIndex = 33;
            this.lblPublicacionesARendir.Text = "Publicaciones a rendir";
            // 
            // cmbFormaDePago
            // 
            this.cmbFormaDePago.FormattingEnabled = true;
            this.cmbFormaDePago.Location = new System.Drawing.Point(767, 115);
            this.cmbFormaDePago.Name = "cmbFormaDePago";
            this.cmbFormaDePago.Size = new System.Drawing.Size(140, 23);
            this.cmbFormaDePago.TabIndex = 34;
            this.cmbFormaDePago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaDePago_SelectedIndexChanged);
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(586, 118);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(175, 15);
            this.lblFormaPago.TabIndex = 35;
            this.lblFormaPago.Text = "Seleccione la Forma de Pago";
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFacturar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturar.Location = new System.Drawing.Point(589, 446);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(87, 27);
            this.btnFacturar.TabIndex = 36;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // dtgPublicacionesARendir
            // 
            this.dtgPublicacionesARendir.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgPublicacionesARendir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgPublicacionesARendir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPublicacionesARendir.Location = new System.Drawing.Point(29, 62);
            this.dtgPublicacionesARendir.Name = "dtgPublicacionesARendir";
            this.dtgPublicacionesARendir.Size = new System.Drawing.Size(535, 411);
            this.dtgPublicacionesARendir.TabIndex = 37;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(871, 59);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 23);
            this.txtCantidad.TabIndex = 38;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(586, 62);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(279, 15);
            this.lblCantidad.TabIndex = 39;
            this.lblCantidad.Text = "Ingrese la cantidad de publicaciones a rendir";
            // 
            // grpTarjeta
            // 
            this.grpTarjeta.Controls.Add(this.txtCodigo);
            this.grpTarjeta.Controls.Add(this.txtDni);
            this.grpTarjeta.Controls.Add(this.cmbFecha);
            this.grpTarjeta.Controls.Add(this.txtTitular);
            this.grpTarjeta.Controls.Add(this.txtNroTarj);
            this.grpTarjeta.Controls.Add(this.txtTarjeta);
            this.grpTarjeta.Controls.Add(this.lblCódigo);
            this.grpTarjeta.Controls.Add(this.lblDNI);
            this.grpTarjeta.Controls.Add(this.lblTitular);
            this.grpTarjeta.Controls.Add(this.lblFechaVto);
            this.grpTarjeta.Controls.Add(this.lblTarjeta);
            this.grpTarjeta.Controls.Add(this.lblNroTarj);
            this.grpTarjeta.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTarjeta.Location = new System.Drawing.Point(589, 181);
            this.grpTarjeta.Name = "grpTarjeta";
            this.grpTarjeta.Size = new System.Drawing.Size(431, 233);
            this.grpTarjeta.TabIndex = 40;
            this.grpTarjeta.TabStop = false;
            this.grpTarjeta.Text = "Datos de la Tarjeta";
            // 
            // lblNroTarj
            // 
            this.lblNroTarj.AutoSize = true;
            this.lblNroTarj.Location = new System.Drawing.Point(8, 64);
            this.lblNroTarj.Name = "lblNroTarj";
            this.lblNroTarj.Size = new System.Drawing.Size(102, 15);
            this.lblNroTarj.TabIndex = 0;
            this.lblNroTarj.Text = "Número Tarjeta";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(7, 29);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(50, 15);
            this.lblTarjeta.TabIndex = 1;
            this.lblTarjeta.Text = "Tarjeta";
            // 
            // lblFechaVto
            // 
            this.lblFechaVto.AutoSize = true;
            this.lblFechaVto.Location = new System.Drawing.Point(8, 130);
            this.lblFechaVto.Name = "lblFechaVto";
            this.lblFechaVto.Size = new System.Drawing.Size(137, 15);
            this.lblFechaVto.TabIndex = 2;
            this.lblFechaVto.Text = "Fecha de Vencimiento";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(7, 95);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(52, 15);
            this.lblTitular.TabIndex = 3;
            this.lblTitular.Text = "Titular ";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(7, 163);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(30, 15);
            this.lblDNI.TabIndex = 4;
            this.lblDNI.Text = "DNI";
            // 
            // lblCódigo
            // 
            this.lblCódigo.AutoSize = true;
            this.lblCódigo.Location = new System.Drawing.Point(6, 201);
            this.lblCódigo.Name = "lblCódigo";
            this.lblCódigo.Size = new System.Drawing.Size(129, 15);
            this.lblCódigo.TabIndex = 5;
            this.lblCódigo.Text = "Código de seguridad";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(63, 26);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(91, 23);
            this.txtTarjeta.TabIndex = 6;
            // 
            // txtNroTarj
            // 
            this.txtNroTarj.Location = new System.Drawing.Point(116, 61);
            this.txtNroTarj.Name = "txtNroTarj";
            this.txtNroTarj.Size = new System.Drawing.Size(91, 23);
            this.txtNroTarj.TabIndex = 7;
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(65, 90);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(100, 23);
            this.txtTitular.TabIndex = 8;
            // 
            // cmbFecha
            // 
            this.cmbFecha.Location = new System.Drawing.Point(151, 124);
            this.cmbFecha.Name = "cmbFecha";
            this.cmbFecha.Size = new System.Drawing.Size(261, 23);
            this.cmbFecha.TabIndex = 9;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(43, 160);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 23);
            this.txtDni.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(141, 198);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(66, 23);
            this.txtCodigo.TabIndex = 11;
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1032, 496);
            this.Controls.Add(this.grpTarjeta);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.dtgPublicacionesARendir);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbFormaDePago);
            this.Controls.Add(this.lblPublicacionesARendir);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFacturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturar Publicaciones";
            this.Load += new System.EventHandler(this.frmFacturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPublicacionesARendir)).EndInit();
            this.grpTarjeta.ResumeLayout(false);
            this.grpTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPublicacionesARendir;
        private System.Windows.Forms.ComboBox cmbFormaDePago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridView dtgPublicacionesARendir;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.GroupBox grpTarjeta;
        private System.Windows.Forms.Label lblNroTarj;
        private System.Windows.Forms.Label lblCódigo;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblFechaVto;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.TextBox txtNroTarj;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.DateTimePicker cmbFecha;
        private System.Windows.Forms.TextBox txtTitular;


    }
}