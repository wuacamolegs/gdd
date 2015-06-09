namespace FrbaCommerce.Login
{
    partial class LogIn
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
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.grpLogIn = new System.Windows.Forms.GroupBox();
            this.grpRol = new System.Windows.Forms.GroupBox();
            this.btnSelecRol = new System.Windows.Forms.Button();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.grpLogIn.SuspendLayout();
            this.grpRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.SystemColors.Window;
            this.txtClave.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(112, 52);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(116, 23);
            this.txtClave.TabIndex = 16;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(34, 55);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(75, 15);
            this.lblPass.TabIndex = 15;
            this.lblPass.Text = "Contraseña";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(112, 22);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(116, 23);
            this.txtUser.TabIndex = 14;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(55, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(54, 15);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "Usuario";
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLogIn.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Location = new System.Drawing.Point(101, 94);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(87, 27);
            this.btnLogIn.TabIndex = 12;
            this.btnLogIn.Text = "Ingresar";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // grpLogIn
            // 
            this.grpLogIn.Controls.Add(this.txtUser);
            this.grpLogIn.Controls.Add(this.txtClave);
            this.grpLogIn.Controls.Add(this.btnLogIn);
            this.grpLogIn.Controls.Add(this.lblPass);
            this.grpLogIn.Controls.Add(this.lblUser);
            this.grpLogIn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLogIn.Location = new System.Drawing.Point(35, 14);
            this.grpLogIn.Name = "grpLogIn";
            this.grpLogIn.Size = new System.Drawing.Size(285, 128);
            this.grpLogIn.TabIndex = 17;
            this.grpLogIn.TabStop = false;
            this.grpLogIn.Text = "Log In";
            // 
            // grpRol
            // 
            this.grpRol.Controls.Add(this.btnSelecRol);
            this.grpRol.Controls.Add(this.cmbRoles);
            this.grpRol.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRol.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpRol.Location = new System.Drawing.Point(35, 57);
            this.grpRol.Name = "grpRol";
            this.grpRol.Size = new System.Drawing.Size(285, 63);
            this.grpRol.TabIndex = 18;
            this.grpRol.TabStop = false;
            this.grpRol.Text = "Seleccionar rol";
            // 
            // btnSelecRol
            // 
            this.btnSelecRol.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSelecRol.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnSelecRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecRol.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecRol.Location = new System.Drawing.Point(182, 22);
            this.btnSelecRol.Name = "btnSelecRol";
            this.btnSelecRol.Size = new System.Drawing.Size(87, 27);
            this.btnSelecRol.TabIndex = 1;
            this.btnSelecRol.Text = "Seleccionar";
            this.btnSelecRol.UseVisualStyleBackColor = false;
            this.btnSelecRol.Click += new System.EventHandler(this.btnSelecRol_Click);
            // 
            // cmbRoles
            // 
            this.cmbRoles.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(23, 22);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(139, 23);
            this.cmbRoles.TabIndex = 0;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(363, 172);
            this.Controls.Add(this.grpRol);
            this.Controls.Add(this.grpLogIn);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.grpLogIn.ResumeLayout(false);
            this.grpLogIn.PerformLayout();
            this.grpRol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.GroupBox grpLogIn;
        private System.Windows.Forms.GroupBox grpRol;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnSelecRol;
    }
}