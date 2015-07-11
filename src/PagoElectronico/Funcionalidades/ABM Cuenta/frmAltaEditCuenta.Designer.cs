namespace PagoElectronico.Funcionalidades.ABM_Cuenta
{
    partial class frmAltaEditCuenta
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
            this.lbPais = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.comboMoneda = new System.Windows.Forms.ComboBox();
            this.dtFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.comboTipoCuenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPais = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.comboUsuario = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPais
            // 
            this.lbPais.AutoSize = true;
            this.lbPais.Location = new System.Drawing.Point(74, 37);
            this.lbPais.Name = "lbPais";
            this.lbPais.Size = new System.Drawing.Size(29, 13);
            this.lbPais.TabIndex = 60;
            this.lbPais.Text = "País";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(145, 12);
            this.txtNumCuenta.MaxLength = 50;
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(164, 20);
            this.txtNumCuenta.TabIndex = 59;
            this.txtNumCuenta.Tag = "Nombre";
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Location = new System.Drawing.Point(9, 15);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(131, 13);
            this.lblNumCuenta.TabIndex = 58;
            this.lblNumCuenta.Text = "Número de cuenta a crear";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(24, 91);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(79, 13);
            this.lblTipoCuenta.TabIndex = 124;
            this.lblTipoCuenta.Text = "Tipo de cuenta";
            // 
            // comboMoneda
            // 
            this.comboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMoneda.FormattingEnabled = true;
            this.comboMoneda.Location = new System.Drawing.Point(109, 61);
            this.comboMoneda.Name = "comboMoneda";
            this.comboMoneda.Size = new System.Drawing.Size(200, 21);
            this.comboMoneda.TabIndex = 123;
            // 
            // dtFechaApertura
            // 
            this.dtFechaApertura.Enabled = false;
            this.dtFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaApertura.Location = new System.Drawing.Point(109, 115);
            this.dtFechaApertura.Name = "dtFechaApertura";
            this.dtFechaApertura.Size = new System.Drawing.Size(200, 20);
            this.dtFechaApertura.TabIndex = 122;
            this.dtFechaApertura.Tag = "Fecha de apertura";
            this.dtFechaApertura.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(57, 64);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 121;
            this.lblMoneda.Text = "Moneda";
            // 
            // comboTipoCuenta
            // 
            this.comboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoCuenta.FormattingEnabled = true;
            this.comboTipoCuenta.Location = new System.Drawing.Point(109, 88);
            this.comboTipoCuenta.Name = "comboTipoCuenta";
            this.comboTipoCuenta.Size = new System.Drawing.Size(200, 21);
            this.comboTipoCuenta.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Fecha de apertura";
            // 
            // comboPais
            // 
            this.comboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPais.FormattingEnabled = true;
            this.comboPais.Location = new System.Drawing.Point(109, 34);
            this.comboPais.Name = "comboPais";
            this.comboPais.Size = new System.Drawing.Size(200, 21);
            this.comboPais.TabIndex = 127;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(11, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 31);
            this.btnAceptar.TabIndex = 128;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.Color.Black;
            this.btnVolver.Location = new System.Drawing.Point(249, 185);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(60, 22);
            this.btnVolver.TabIndex = 130;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(24, 141);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(127, 13);
            this.lblUsuario.TabIndex = 131;
            this.lblUsuario.Text = "Asignar cuenta a usuario:";
            this.lblUsuario.Visible = false;
            // 
            // comboUsuario
            // 
            this.comboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUsuario.FormattingEnabled = true;
            this.comboUsuario.Location = new System.Drawing.Point(152, 138);
            this.comboUsuario.Name = "comboUsuario";
            this.comboUsuario.Size = new System.Drawing.Size(157, 21);
            this.comboUsuario.TabIndex = 132;
            this.comboUsuario.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(176, 185);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(60, 22);
            this.btnLimpiar.TabIndex = 133;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmAltaEditCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 220);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.comboUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboPais);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTipoCuenta);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.comboMoneda);
            this.Controls.Add(this.dtFechaApertura);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lbPais);
            this.Controls.Add(this.txtNumCuenta);
            this.Controls.Add(this.lblNumCuenta);
            this.Name = "frmAltaEditCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta";
            this.Load += new System.EventHandler(this.frmAltaEditCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPais;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.ComboBox comboMoneda;
        private System.Windows.Forms.DateTimePicker dtFechaApertura;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ComboBox comboTipoCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPais;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox comboUsuario;
        private System.Windows.Forms.Button btnLimpiar;
    }
}