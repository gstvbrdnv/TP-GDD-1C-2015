namespace PagoElectronico
{
    partial class frmMain
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
            this.barraMenu = new System.Windows.Forms.MenuStrip();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCuentaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónDeCostosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarDepósitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarUnaExtracciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdmin,
            this.menuCliente,
            this.menuCerrarSesion,
            this.menuSalir});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(371, 27);
            this.barraMenu.TabIndex = 0;
            this.barraMenu.Text = "mainMenu";
            // 
            // menuAdmin
            // 
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMUsuarioToolStripMenuItem,
            this.aBMClienteToolStripMenuItem,
            this.aBMCuentaToolStripMenuItem1,
            this.aBMRolToolStripMenuItem2,
            this.facturaciónDeCostosToolStripMenuItem1,
            this.consultarSaldoToolStripMenuItem,
            this.estadísticasToolStripMenuItem});
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(122, 23);
            this.menuAdmin.Text = "Administrador";
            // 
            // aBMUsuarioToolStripMenuItem
            // 
            this.aBMUsuarioToolStripMenuItem.Name = "aBMUsuarioToolStripMenuItem";
            this.aBMUsuarioToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.aBMUsuarioToolStripMenuItem.Text = "ABM Usuario";
            this.aBMUsuarioToolStripMenuItem.Click += new System.EventHandler(this.aBMUsuarioToolStripMenuItem_Click_1);
            // 
            // aBMClienteToolStripMenuItem
            // 
            this.aBMClienteToolStripMenuItem.Name = "aBMClienteToolStripMenuItem";
            this.aBMClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.aBMClienteToolStripMenuItem.Text = "ABM Cliente";
            this.aBMClienteToolStripMenuItem.Click += new System.EventHandler(this.aBMClienteToolStripMenuItem_Click_1);
            // 
            // aBMCuentaToolStripMenuItem1
            // 
            this.aBMCuentaToolStripMenuItem1.Name = "aBMCuentaToolStripMenuItem1";
            this.aBMCuentaToolStripMenuItem1.Size = new System.Drawing.Size(229, 24);
            this.aBMCuentaToolStripMenuItem1.Text = "ABM Cuenta";
            this.aBMCuentaToolStripMenuItem1.Click += new System.EventHandler(this.aBMCuentaToolStripMenuItem1_Click);
            // 
            // aBMRolToolStripMenuItem2
            // 
            this.aBMRolToolStripMenuItem2.Name = "aBMRolToolStripMenuItem2";
            this.aBMRolToolStripMenuItem2.Size = new System.Drawing.Size(229, 24);
            this.aBMRolToolStripMenuItem2.Text = "ABM Rol";
            this.aBMRolToolStripMenuItem2.Click += new System.EventHandler(this.aBMRolToolStripMenuItem2_Click);
            // 
            // facturaciónDeCostosToolStripMenuItem1
            // 
            this.facturaciónDeCostosToolStripMenuItem1.Name = "facturaciónDeCostosToolStripMenuItem1";
            this.facturaciónDeCostosToolStripMenuItem1.Size = new System.Drawing.Size(229, 24);
            this.facturaciónDeCostosToolStripMenuItem1.Text = "Facturación de costos";
            this.facturaciónDeCostosToolStripMenuItem1.Click += new System.EventHandler(this.facturaciónDeCostosToolStripMenuItem1_Click);
            // 
            // consultarSaldoToolStripMenuItem
            // 
            this.consultarSaldoToolStripMenuItem.Name = "consultarSaldoToolStripMenuItem";
            this.consultarSaldoToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.consultarSaldoToolStripMenuItem.Text = "Consultar saldo";
            this.consultarSaldoToolStripMenuItem.Click += new System.EventHandler(this.consultarSaldoToolStripMenuItem_Click);
            // 
            // estadísticasToolStripMenuItem
            // 
            this.estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            this.estadísticasToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.estadísticasToolStripMenuItem.Text = "Estadísticas";
            this.estadísticasToolStripMenuItem.Click += new System.EventHandler(this.estadísticasToolStripMenuItem_Click);
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMCuentaToolStripMenuItem,
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem,
            this.realizarDepósitoToolStripMenuItem,
            this.realizarUnaExtracciónToolStripMenuItem,
            this.transferenciaToolStripMenuItem,
            this.facturaciónDeCostosToolStripMenuItem,
            this.consultarSaldoToolStripMenuItem1});
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(69, 23);
            this.menuCliente.Text = "Cliente";
            // 
            // aBMCuentaToolStripMenuItem
            // 
            this.aBMCuentaToolStripMenuItem.Name = "aBMCuentaToolStripMenuItem";
            this.aBMCuentaToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.aBMCuentaToolStripMenuItem.Text = "Administrar cuentas";
            this.aBMCuentaToolStripMenuItem.Click += new System.EventHandler(this.aBMCuentaToolStripMenuItem_Click);
            // 
            // asociarModificarODesaociarUnaTarjetaToolStripMenuItem
            // 
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Name = "asociarModificarODesaociarUnaTarjetaToolStripMenuItem";
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Text = "Administrar tarjetas";
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Click += new System.EventHandler(this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem_Click);
            // 
            // realizarDepósitoToolStripMenuItem
            // 
            this.realizarDepósitoToolStripMenuItem.Name = "realizarDepósitoToolStripMenuItem";
            this.realizarDepósitoToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.realizarDepósitoToolStripMenuItem.Text = "Realizar depósito de dinero";
            this.realizarDepósitoToolStripMenuItem.Click += new System.EventHandler(this.realizarDepósitoToolStripMenuItem_Click);
            // 
            // realizarUnaExtracciónToolStripMenuItem
            // 
            this.realizarUnaExtracciónToolStripMenuItem.Name = "realizarUnaExtracciónToolStripMenuItem";
            this.realizarUnaExtracciónToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.realizarUnaExtracciónToolStripMenuItem.Text = "Realizar una extracción";
            this.realizarUnaExtracciónToolStripMenuItem.Click += new System.EventHandler(this.realizarUnaExtracciónToolStripMenuItem_Click);
            // 
            // transferenciaToolStripMenuItem
            // 
            this.transferenciaToolStripMenuItem.Name = "transferenciaToolStripMenuItem";
            this.transferenciaToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.transferenciaToolStripMenuItem.Text = "Realizar una transferencia";
            this.transferenciaToolStripMenuItem.Click += new System.EventHandler(this.transferenciaToolStripMenuItem_Click);
            // 
            // facturaciónDeCostosToolStripMenuItem
            // 
            this.facturaciónDeCostosToolStripMenuItem.Name = "facturaciónDeCostosToolStripMenuItem";
            this.facturaciónDeCostosToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.facturaciónDeCostosToolStripMenuItem.Text = "Facturación de costos";
            this.facturaciónDeCostosToolStripMenuItem.Click += new System.EventHandler(this.facturaciónDeCostosToolStripMenuItem_Click);
            // 
            // consultarSaldoToolStripMenuItem1
            // 
            this.consultarSaldoToolStripMenuItem1.Name = "consultarSaldoToolStripMenuItem1";
            this.consultarSaldoToolStripMenuItem1.Size = new System.Drawing.Size(379, 24);
            this.consultarSaldoToolStripMenuItem1.Text = "Consultar saldo";
            this.consultarSaldoToolStripMenuItem1.Click += new System.EventHandler(this.consultarSaldoToolStripMenuItem1_Click);
            // 
            // menuCerrarSesion
            // 
            this.menuCerrarSesion.Name = "menuCerrarSesion";
            this.menuCerrarSesion.Size = new System.Drawing.Size(114, 23);
            this.menuCerrarSesion.Text = "Cerrar sesión";
            this.menuCerrarSesion.Click += new System.EventHandler(this.menuCerrarSesion_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(52, 23);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 461);
            this.Controls.Add(this.barraMenu);
            this.MainMenuStrip = this.barraMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago Electrónico";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip barraMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCuentaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aBMCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem asociarModificarODesaociarUnaTarjetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarDepósitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarUnaExtracciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónDeCostosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarSaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSaldoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
    }
}

