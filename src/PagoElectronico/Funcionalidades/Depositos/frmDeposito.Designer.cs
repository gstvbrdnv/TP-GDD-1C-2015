namespace PagoElectronico.Depositos
{
    partial class frmDeposito
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
            this.lblCuenta = new System.Windows.Forms.Label();
            this.comboCuenta = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTipoMoneda = new System.Windows.Forms.Label();
            this.comboTipoMoneda = new System.Windows.Forms.ComboBox();
            this.comboTarjeta = new System.Windows.Forms.ComboBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.calendarFecha = new System.Windows.Forms.MonthCalendar();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(10, 12);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(142, 16);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Depositar en la cuenta";
            // 
            // comboCuenta
            // 
            this.comboCuenta.FormattingEnabled = true;
            this.comboCuenta.Location = new System.Drawing.Point(24, 31);
            this.comboCuenta.Name = "comboCuenta";
            this.comboCuenta.Size = new System.Drawing.Size(230, 21);
            this.comboCuenta.TabIndex = 1;
            this.comboCuenta.Tag = "Cuenta";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(9, 55);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(45, 16);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(24, 74);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(230, 20);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.Tag = "Monto";
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(306, 42);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 24);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.TabStop = false;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(306, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 24);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.TabStop = false;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTipoMoneda
            // 
            this.lblTipoMoneda.AutoSize = true;
            this.lblTipoMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMoneda.Location = new System.Drawing.Point(9, 97);
            this.lblTipoMoneda.Name = "lblTipoMoneda";
            this.lblTipoMoneda.Size = new System.Drawing.Size(89, 16);
            this.lblTipoMoneda.TabIndex = 17;
            this.lblTipoMoneda.Text = "Tipo moneda";
            // 
            // comboTipoMoneda
            // 
            this.comboTipoMoneda.FormattingEnabled = true;
            this.comboTipoMoneda.Location = new System.Drawing.Point(24, 116);
            this.comboTipoMoneda.Name = "comboTipoMoneda";
            this.comboTipoMoneda.Size = new System.Drawing.Size(230, 21);
            this.comboTipoMoneda.TabIndex = 3;
            this.comboTipoMoneda.Tag = "Tipo moneda";
            // 
            // comboTarjeta
            // 
            this.comboTarjeta.FormattingEnabled = true;
            this.comboTarjeta.Location = new System.Drawing.Point(24, 159);
            this.comboTarjeta.Name = "comboTarjeta";
            this.comboTarjeta.Size = new System.Drawing.Size(230, 21);
            this.comboTarjeta.TabIndex = 4;
            this.comboTarjeta.Tag = "Tarjeta";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarjeta.Location = new System.Drawing.Point(9, 140);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(114, 16);
            this.lblTarjeta.TabIndex = 20;
            this.lblTarjeta.Text = "Tarjeta de crédito";
            // 
            // btnDepositar
            // 
            this.btnDepositar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepositar.Location = new System.Drawing.Point(283, 337);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(110, 32);
            this.btnDepositar.TabIndex = 5;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(12, 189);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(121, 16);
            this.lblFecha.TabIndex = 21;
            this.lblFecha.Text = "Fecha de depósito";
            // 
            // calendarFecha
            // 
            this.calendarFecha.Enabled = false;
            this.calendarFecha.Location = new System.Drawing.Point(27, 207);
            this.calendarFecha.Name = "calendarFecha";
            this.calendarFecha.TabIndex = 22;
            this.calendarFecha.TabStop = false;
            this.calendarFecha.TodayDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.Red;
            this.lblDisponible.Location = new System.Drawing.Point(117, 142);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(0, 13);
            this.lblDisponible.TabIndex = 23;
            // 
            // frmDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 383);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.calendarFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.comboTarjeta);
            this.Controls.Add(this.comboTipoMoneda);
            this.Controls.Add(this.lblTipoMoneda);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.comboCuenta);
            this.Controls.Add(this.lblCuenta);
            this.Name = "frmDeposito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depósito";
            this.Load += new System.EventHandler(this.frmDeposito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox comboCuenta;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTipoMoneda;
        private System.Windows.Forms.ComboBox comboTipoMoneda;
        private System.Windows.Forms.ComboBox comboTarjeta;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MonthCalendar calendarFecha;
        private System.Windows.Forms.Label lblDisponible;
    }
}