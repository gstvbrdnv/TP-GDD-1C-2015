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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónDeCostosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarDepósitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarUnaExtracciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.administrarClientesToolStripMenuItem});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(416, 27);
            this.barraMenu.TabIndex = 0;
            this.barraMenu.Text = "mainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMUsuariosToolStripMenuItem,
            this.aBMRolToolStripMenuItem,
            this.aBMRolToolStripMenuItem1,
            this.aBMRolToolStripMenuItem2,
            this.facturaciónDeCostosToolStripMenuItem1,
            this.consultarSaldoToolStripMenuItem,
            this.estadísticasToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 23);
            this.toolStripMenuItem1.Text = "Administrador";
            // 
            // aBMUsuariosToolStripMenuItem
            // 
            this.aBMUsuariosToolStripMenuItem.Name = "aBMUsuariosToolStripMenuItem";
            this.aBMUsuariosToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.aBMUsuariosToolStripMenuItem.Text = "ABM Usuario";
            // 
            // aBMRolToolStripMenuItem
            // 
            this.aBMRolToolStripMenuItem.Name = "aBMRolToolStripMenuItem";
            this.aBMRolToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.aBMRolToolStripMenuItem.Text = "ABM Cliente";
            this.aBMRolToolStripMenuItem.Click += new System.EventHandler(this.aBMRolToolStripMenuItem_Click);
            // 
            // aBMRolToolStripMenuItem1
            // 
            this.aBMRolToolStripMenuItem1.Name = "aBMRolToolStripMenuItem1";
            this.aBMRolToolStripMenuItem1.Size = new System.Drawing.Size(229, 24);
            this.aBMRolToolStripMenuItem1.Text = "ABM Cuenta";
            this.aBMRolToolStripMenuItem1.Click += new System.EventHandler(this.aBMRolToolStripMenuItem1_Click);
            // 
            // aBMRolToolStripMenuItem2
            // 
            this.aBMRolToolStripMenuItem2.Name = "aBMRolToolStripMenuItem2";
            this.aBMRolToolStripMenuItem2.Size = new System.Drawing.Size(229, 24);
            this.aBMRolToolStripMenuItem2.Text = "ABM Rol";
            // 
            // facturaciónDeCostosToolStripMenuItem1
            // 
            this.facturaciónDeCostosToolStripMenuItem1.Name = "facturaciónDeCostosToolStripMenuItem1";
            this.facturaciónDeCostosToolStripMenuItem1.Size = new System.Drawing.Size(229, 24);
            this.facturaciónDeCostosToolStripMenuItem1.Text = "Facturación de costos";
            // 
            // consultarSaldoToolStripMenuItem
            // 
            this.consultarSaldoToolStripMenuItem.Name = "consultarSaldoToolStripMenuItem";
            this.consultarSaldoToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.consultarSaldoToolStripMenuItem.Text = "Consultar saldo";
            // 
            // estadísticasToolStripMenuItem
            // 
            this.estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            this.estadísticasToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.estadísticasToolStripMenuItem.Text = "Estadísticas";
            // 
            // administrarClientesToolStripMenuItem
            // 
            this.administrarClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMCuentaToolStripMenuItem,
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem,
            this.realizarDepósitoToolStripMenuItem,
            this.realizarUnaExtracciónToolStripMenuItem,
            this.transferenciaToolStripMenuItem,
            this.facturaciónDeCostosToolStripMenuItem,
            this.consultarSaldoToolStripMenuItem1});
            this.administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            this.administrarClientesToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.administrarClientesToolStripMenuItem.Text = "Cliente";
            // 
            // aBMCuentaToolStripMenuItem
            // 
            this.aBMCuentaToolStripMenuItem.Name = "aBMCuentaToolStripMenuItem";
            this.aBMCuentaToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.aBMCuentaToolStripMenuItem.Text = "Agregar, modificar o borrar una cuenta";
            // 
            // asociarModificarODesaociarUnaTarjetaToolStripMenuItem
            // 
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Name = "asociarModificarODesaociarUnaTarjetaToolStripMenuItem";
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.asociarModificarODesaociarUnaTarjetaToolStripMenuItem.Text = "Asociar, modificar o desasociar una tarjeta";
            // 
            // realizarDepósitoToolStripMenuItem
            // 
            this.realizarDepósitoToolStripMenuItem.Name = "realizarDepósitoToolStripMenuItem";
            this.realizarDepósitoToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.realizarDepósitoToolStripMenuItem.Text = "Realizar depósito de dinero";
            // 
            // realizarUnaExtracciónToolStripMenuItem
            // 
            this.realizarUnaExtracciónToolStripMenuItem.Name = "realizarUnaExtracciónToolStripMenuItem";
            this.realizarUnaExtracciónToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.realizarUnaExtracciónToolStripMenuItem.Text = "Realizar una extracción";
            // 
            // transferenciaToolStripMenuItem
            // 
            this.transferenciaToolStripMenuItem.Name = "transferenciaToolStripMenuItem";
            this.transferenciaToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.transferenciaToolStripMenuItem.Text = "Realizar una transferencia";
            // 
            // facturaciónDeCostosToolStripMenuItem
            // 
            this.facturaciónDeCostosToolStripMenuItem.Name = "facturaciónDeCostosToolStripMenuItem";
            this.facturaciónDeCostosToolStripMenuItem.Size = new System.Drawing.Size(379, 24);
            this.facturaciónDeCostosToolStripMenuItem.Text = "Facturación de costos";
            // 
            // consultarSaldoToolStripMenuItem1
            // 
            this.consultarSaldoToolStripMenuItem1.Name = "consultarSaldoToolStripMenuItem1";
            this.consultarSaldoToolStripMenuItem1.Size = new System.Drawing.Size(379, 24);
            this.consultarSaldoToolStripMenuItem1.Text = "Consultar saldo";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 461);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem1;
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
    }
}

