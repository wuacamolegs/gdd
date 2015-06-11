namespace FrbaCommerce
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
            this.pestanaAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ABMRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AbmEmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pestanaPublicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.AbmVisiblidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPublicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarOfertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarPublicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pestanaUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoEstadísticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misPublicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificarVendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pestanaAdmin,
            this.pestanaPublicacion,
            this.pestanaUsuario,
            this.pestanaCerrarSesion});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1264, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // pestanaAdmin
            // 
            this.pestanaAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ABMRolesToolStripMenuItem,
            this.AbmEmpresasToolStripMenuItem,
            this.aBMClientesToolStripMenuItem,
            this.administrarUsuariosToolStripMenuItem,
            this.cambiarClaveToolStripMenuItem});
            this.pestanaAdmin.Name = "pestanaAdmin";
            this.pestanaAdmin.Size = new System.Drawing.Size(116, 21);
            this.pestanaAdmin.Text = "Administración";
            // 
            // ABMRolesToolStripMenuItem
            // 
            this.ABMRolesToolStripMenuItem.Name = "ABMRolesToolStripMenuItem";
            this.ABMRolesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ABMRolesToolStripMenuItem.Text = "ABM Roles";
            this.ABMRolesToolStripMenuItem.Visible = false;
            this.ABMRolesToolStripMenuItem.Click += new System.EventHandler(this.ABMRolesToolStripMenuItem_Click);
            // 
            // AbmEmpresasToolStripMenuItem
            // 
            this.AbmEmpresasToolStripMenuItem.Name = "AbmEmpresasToolStripMenuItem";
            this.AbmEmpresasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.AbmEmpresasToolStripMenuItem.Text = "ABM Empresas";
            this.AbmEmpresasToolStripMenuItem.Visible = false;
            this.AbmEmpresasToolStripMenuItem.Click += new System.EventHandler(this.AbmEmpresasToolStripMenuItem_Click);
            // 
            // aBMClientesToolStripMenuItem
            // 
            this.aBMClientesToolStripMenuItem.Name = "aBMClientesToolStripMenuItem";
            this.aBMClientesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aBMClientesToolStripMenuItem.Text = "ABM Clientes";
            this.aBMClientesToolStripMenuItem.Visible = false;
            this.aBMClientesToolStripMenuItem.Click += new System.EventHandler(this.aBMClientesToolStripMenuItem_Click);
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.administrarUsuariosToolStripMenuItem.Text = "Usuarios";
            this.administrarUsuariosToolStripMenuItem.Visible = false;
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // cambiarClaveToolStripMenuItem
            // 
            this.cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            this.cambiarClaveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cambiarClaveToolStripMenuItem.Text = "Cambiar clave";
            this.cambiarClaveToolStripMenuItem.Visible = false;
            this.cambiarClaveToolStripMenuItem.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click);
            // 
            // pestanaPublicacion
            // 
            this.pestanaPublicacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AbmVisiblidadToolStripMenuItem,
            this.generarPublicacionToolStripMenuItem,
            this.comprarOfertarToolStripMenuItem,
            this.facturarPublicacionesToolStripMenuItem});
            this.pestanaPublicacion.Name = "pestanaPublicacion";
            this.pestanaPublicacion.Size = new System.Drawing.Size(94, 21);
            this.pestanaPublicacion.Text = "Publicación";
            // 
            // AbmVisiblidadToolStripMenuItem
            // 
            this.AbmVisiblidadToolStripMenuItem.Name = "AbmVisiblidadToolStripMenuItem";
            this.AbmVisiblidadToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.AbmVisiblidadToolStripMenuItem.Text = "ABM Visiblidad";
            this.AbmVisiblidadToolStripMenuItem.Visible = false;
            this.AbmVisiblidadToolStripMenuItem.Click += new System.EventHandler(this.AbmVisiblidadToolStripMenuItem_Click);
            // 
            // generarPublicacionToolStripMenuItem
            // 
            this.generarPublicacionToolStripMenuItem.Name = "generarPublicacionToolStripMenuItem";
            this.generarPublicacionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.generarPublicacionToolStripMenuItem.Text = "Generar Publicación";
            this.generarPublicacionToolStripMenuItem.Visible = false;
            this.generarPublicacionToolStripMenuItem.Click += new System.EventHandler(this.generarPublicacionToolStripMenuItem_Click);
            // 
            // comprarOfertarToolStripMenuItem
            // 
            this.comprarOfertarToolStripMenuItem.Name = "comprarOfertarToolStripMenuItem";
            this.comprarOfertarToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.comprarOfertarToolStripMenuItem.Text = "Comprar/Ofertar";
            this.comprarOfertarToolStripMenuItem.Visible = false;
            this.comprarOfertarToolStripMenuItem.Click += new System.EventHandler(this.comprarOfertarToolStripMenuItem_Click);
            // 
            // facturarPublicacionesToolStripMenuItem
            // 
            this.facturarPublicacionesToolStripMenuItem.Name = "facturarPublicacionesToolStripMenuItem";
            this.facturarPublicacionesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.facturarPublicacionesToolStripMenuItem.Text = "Facturar publicaciones";
            this.facturarPublicacionesToolStripMenuItem.Visible = false;
            this.facturarPublicacionesToolStripMenuItem.Click += new System.EventHandler(this.facturarPublicacionesToolStripMenuItem_Click);
            // 
            // pestanaUsuario
            // 
            this.pestanaUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialToolStripMenuItem1,
            this.listadoEstadísticoToolStripMenuItem,
            this.misPublicacionesToolStripMenuItem,
            this.calificarVendedoresToolStripMenuItem});
            this.pestanaUsuario.Name = "pestanaUsuario";
            this.pestanaUsuario.Size = new System.Drawing.Size(69, 21);
            this.pestanaUsuario.Text = "Usuario";
            // 
            // historialToolStripMenuItem1
            // 
            this.historialToolStripMenuItem1.Name = "historialToolStripMenuItem1";
            this.historialToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.historialToolStripMenuItem1.Text = "Historial";
            this.historialToolStripMenuItem1.Visible = false;
            this.historialToolStripMenuItem1.Click += new System.EventHandler(this.historialToolStripMenuItem1_Click);
            // 
            // listadoEstadísticoToolStripMenuItem
            // 
            this.listadoEstadísticoToolStripMenuItem.Name = "listadoEstadísticoToolStripMenuItem";
            this.listadoEstadísticoToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.listadoEstadísticoToolStripMenuItem.Text = "Listado Estadístico";
            this.listadoEstadísticoToolStripMenuItem.Visible = false;
            this.listadoEstadísticoToolStripMenuItem.Click += new System.EventHandler(this.listadoEstadísticoToolStripMenuItem_Click);
            // 
            // misPublicacionesToolStripMenuItem
            // 
            this.misPublicacionesToolStripMenuItem.Name = "misPublicacionesToolStripMenuItem";
            this.misPublicacionesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.misPublicacionesToolStripMenuItem.Text = "Mis Publicaciones";
            this.misPublicacionesToolStripMenuItem.Visible = false;
            this.misPublicacionesToolStripMenuItem.Click += new System.EventHandler(this.misPublicacionesToolStripMenuItem_Click);
            // 
            // calificarVendedoresToolStripMenuItem
            // 
            this.calificarVendedoresToolStripMenuItem.Name = "calificarVendedoresToolStripMenuItem";
            this.calificarVendedoresToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.calificarVendedoresToolStripMenuItem.Text = "Calificar Vendedores";
            this.calificarVendedoresToolStripMenuItem.Visible = false;
            this.calificarVendedoresToolStripMenuItem.Click += new System.EventHandler(this.calificarVendedoresToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem pestanaAdmin;
        private System.Windows.Forms.ToolStripMenuItem ABMRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AbmEmpresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pestanaPublicacion;
        private System.Windows.Forms.ToolStripMenuItem AbmVisiblidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pestanaUsuario;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem generarPublicacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoEstadísticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misPublicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarOfertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturarPublicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificarVendedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pestanaCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveToolStripMenuItem;

    }
}