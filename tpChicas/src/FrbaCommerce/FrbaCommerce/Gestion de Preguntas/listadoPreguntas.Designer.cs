namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class listadoPreguntas
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
            this.dtgPreguntas = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnResponder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPreguntas
            // 
            this.dtgPreguntas.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgPreguntas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPreguntas.Location = new System.Drawing.Point(16, 56);
            this.dtgPreguntas.Name = "dtgPreguntas";
            this.dtgPreguntas.Size = new System.Drawing.Size(926, 303);
            this.dtgPreguntas.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(870, 365);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(70, 27);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnResponder
            // 
            this.btnResponder.BackColor = System.Drawing.Color.PowderBlue;
            this.btnResponder.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnResponder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResponder.Location = new System.Drawing.Point(785, 365);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(79, 27);
            this.btnResponder.TabIndex = 3;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = false;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Listado de preguntas a responder";
            // 
            // listadoPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(954, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dtgPreguntas);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "listadoPreguntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Preguntas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreguntas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPreguntas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnResponder;
        private System.Windows.Forms.Label label1;

    }
}