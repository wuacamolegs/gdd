namespace PagoElectronico
{
    partial class Principal
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.pestanaInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMROLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCLIENTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEPOSITOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXTRACCIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRANSFERENCIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSOCIARDESASOCIARTARJETASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCUENTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCUENTAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cONSULTASALDOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fACTURACIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTADOESTADISTICOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAMBIARCONTRASEÑAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pestanaCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.GhostWhite;
            this.menu.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pestanaInicio,
            this.pestanaCerrarSesion});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1264, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // pestanaInicio
            // 
            this.pestanaInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMROLToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.aBMCLIENTEToolStripMenuItem,
            this.aBMCUENTAToolStripMenuItem,
            this.fACTURACIONToolStripMenuItem,
            this.lISTADOESTADISTICOToolStripMenuItem,
            this.cAMBIARCONTRASEÑAToolStripMenuItem});
            this.pestanaInicio.Name = "pestanaInicio";
            this.pestanaInicio.Size = new System.Drawing.Size(56, 21);
            this.pestanaInicio.Text = "Inicio";
            // 
            // aBMROLToolStripMenuItem
            // 
            this.aBMROLToolStripMenuItem.Name = "aBMROLToolStripMenuItem";
            this.aBMROLToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aBMROLToolStripMenuItem.Text = "ROL";
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aBMToolStripMenuItem.Text = "USUARIO";
            // 
            // aBMCLIENTEToolStripMenuItem
            // 
            this.aBMCLIENTEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMCLIENTESToolStripMenuItem,
            this.dEPOSITOSToolStripMenuItem,
            this.eXTRACCIONESToolStripMenuItem,
            this.tRANSFERENCIASToolStripMenuItem,
            this.aSOCIARDESASOCIARTARJETASToolStripMenuItem});
            this.aBMCLIENTEToolStripMenuItem.Name = "aBMCLIENTEToolStripMenuItem";
            this.aBMCLIENTEToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aBMCLIENTEToolStripMenuItem.Text = "CLIENTE";
            // 
            // aBMCLIENTESToolStripMenuItem
            // 
            this.aBMCLIENTESToolStripMenuItem.Name = "aBMCLIENTESToolStripMenuItem";
            this.aBMCLIENTESToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.aBMCLIENTESToolStripMenuItem.Text = "ABM CLIENTES";
            // 
            // dEPOSITOSToolStripMenuItem
            // 
            this.dEPOSITOSToolStripMenuItem.Name = "dEPOSITOSToolStripMenuItem";
            this.dEPOSITOSToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.dEPOSITOSToolStripMenuItem.Text = "DEPOSITOS";
            // 
            // eXTRACCIONESToolStripMenuItem
            // 
            this.eXTRACCIONESToolStripMenuItem.Name = "eXTRACCIONESToolStripMenuItem";
            this.eXTRACCIONESToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.eXTRACCIONESToolStripMenuItem.Text = "EXTRACCIONES";
            // 
            // tRANSFERENCIASToolStripMenuItem
            // 
            this.tRANSFERENCIASToolStripMenuItem.Name = "tRANSFERENCIASToolStripMenuItem";
            this.tRANSFERENCIASToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.tRANSFERENCIASToolStripMenuItem.Text = "TRANSFERENCIAS";
            // 
            // aSOCIARDESASOCIARTARJETASToolStripMenuItem
            // 
            this.aSOCIARDESASOCIARTARJETASToolStripMenuItem.Name = "aSOCIARDESASOCIARTARJETASToolStripMenuItem";
            this.aSOCIARDESASOCIARTARJETASToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.aSOCIARDESASOCIARTARJETASToolStripMenuItem.Text = "ASOCIAR/DESASOCIAR TARJETAS";
            // 
            // aBMCUENTAToolStripMenuItem
            // 
            this.aBMCUENTAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMCUENTAToolStripMenuItem1,
            this.cONSULTASALDOToolStripMenuItem});
            this.aBMCUENTAToolStripMenuItem.Name = "aBMCUENTAToolStripMenuItem";
            this.aBMCUENTAToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aBMCUENTAToolStripMenuItem.Text = "CUENTA";
            // 
            // aBMCUENTAToolStripMenuItem1
            // 
            this.aBMCUENTAToolStripMenuItem1.Name = "aBMCUENTAToolStripMenuItem1";
            this.aBMCUENTAToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.aBMCUENTAToolStripMenuItem1.Text = "ABM CUENTA";
            // 
            // cONSULTASALDOToolStripMenuItem
            // 
            this.cONSULTASALDOToolStripMenuItem.Name = "cONSULTASALDOToolStripMenuItem";
            this.cONSULTASALDOToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cONSULTASALDOToolStripMenuItem.Text = "CONSULTA SALDO";
            // 
            // fACTURACIONToolStripMenuItem
            // 
            this.fACTURACIONToolStripMenuItem.Name = "fACTURACIONToolStripMenuItem";
            this.fACTURACIONToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.fACTURACIONToolStripMenuItem.Text = "FACTURACION";
            // 
            // lISTADOESTADISTICOToolStripMenuItem
            // 
            this.lISTADOESTADISTICOToolStripMenuItem.Name = "lISTADOESTADISTICOToolStripMenuItem";
            this.lISTADOESTADISTICOToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.lISTADOESTADISTICOToolStripMenuItem.Text = "LISTADO ESTADISTICO";
            // 
            // cAMBIARCONTRASEÑAToolStripMenuItem
            // 
            this.cAMBIARCONTRASEÑAToolStripMenuItem.Name = "cAMBIARCONTRASEÑAToolStripMenuItem";
            this.cAMBIARCONTRASEÑAToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.cAMBIARCONTRASEÑAToolStripMenuItem.Text = "CAMBIAR CONTRASEÑA";
            // 
            // pestanaCerrarSesion
            // 
            this.pestanaCerrarSesion.Name = "pestanaCerrarSesion";
            this.pestanaCerrarSesion.Size = new System.Drawing.Size(102, 21);
            this.pestanaCerrarSesion.Text = "Cerrar sesión";
            this.pestanaCerrarSesion.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1264, 435);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem pestanaInicio;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pestanaCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem aBMROLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCLIENTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCUENTAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEPOSITOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXTRACCIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRANSFERENCIASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSOCIARDESASOCIARTARJETASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fACTURACIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCUENTAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cONSULTASALDOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTADOESTADISTICOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cAMBIARCONTRASEÑAToolStripMenuItem;

    }
}
