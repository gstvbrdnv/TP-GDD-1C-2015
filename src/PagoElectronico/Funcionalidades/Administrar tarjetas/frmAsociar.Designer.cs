namespace PagoElectronico.Tarjetas
{
    partial class frmAsociar
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
            this.comboEmisor = new System.Windows.Forms.ComboBox();
            this.txtCodigoSeguridad = new System.Windows.Forms.TextBox();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.fechaEmision = new System.Windows.Forms.DateTimePicker();
            this.fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblNumTarj = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmisor = new System.Windows.Forms.Label();
            this.lblFechEmi = new System.Windows.Forms.Label();
            this.lblFechVto = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboEmisor
            // 
            this.comboEmisor.FormattingEnabled = true;
            this.comboEmisor.Location = new System.Drawing.Point(186, 74);
            this.comboEmisor.Name = "comboEmisor";
            this.comboEmisor.Size = new System.Drawing.Size(216, 21);
            this.comboEmisor.TabIndex = 2;
            this.comboEmisor.Tag = "Emisor";
            // 
            // txtCodigoSeguridad
            // 
            this.txtCodigoSeguridad.Location = new System.Drawing.Point(186, 153);
            this.txtCodigoSeguridad.MaxLength = 3;
            this.txtCodigoSeguridad.Name = "txtCodigoSeguridad";
            this.txtCodigoSeguridad.Size = new System.Drawing.Size(216, 20);
            this.txtCodigoSeguridad.TabIndex = 5;
            this.txtCodigoSeguridad.Tag = "Código de seguridad";
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.Location = new System.Drawing.Point(186, 48);
            this.txtNumTarjeta.MaxLength = 16;
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.Size = new System.Drawing.Size(216, 20);
            this.txtNumTarjeta.TabIndex = 1;
            this.txtNumTarjeta.Tag = "Número tarjeta";
            // 
            // fechaEmision
            // 
            this.fechaEmision.Location = new System.Drawing.Point(186, 101);
            this.fechaEmision.Name = "fechaEmision";
            this.fechaEmision.Size = new System.Drawing.Size(216, 20);
            this.fechaEmision.TabIndex = 3;
            this.fechaEmision.Tag = "Fecha emisión";
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Location = new System.Drawing.Point(186, 127);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(216, 20);
            this.fechaVencimiento.TabIndex = 4;
            this.fechaVencimiento.Tag = "Fecha vencimiento";
            // 
            // lblNumTarj
            // 
            this.lblNumTarj.AutoSize = true;
            this.lblNumTarj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTarj.Location = new System.Drawing.Point(12, 49);
            this.lblNumTarj.Name = "lblNumTarj";
            this.lblNumTarj.Size = new System.Drawing.Size(115, 16);
            this.lblNumTarj.TabIndex = 7;
            this.lblNumTarj.Text = "Número de tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Por favor, complete los siguientes datos para asociar una tarjeta";
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmisor.Location = new System.Drawing.Point(12, 74);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(50, 16);
            this.lblEmisor.TabIndex = 9;
            this.lblEmisor.Text = "Emisor";
            // 
            // lblFechEmi
            // 
            this.lblFechEmi.AutoSize = true;
            this.lblFechEmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechEmi.Location = new System.Drawing.Point(12, 101);
            this.lblFechEmi.Name = "lblFechEmi";
            this.lblFechEmi.Size = new System.Drawing.Size(115, 16);
            this.lblFechEmi.TabIndex = 10;
            this.lblFechEmi.Text = "Fecha de emisión";
            // 
            // lblFechVto
            // 
            this.lblFechVto.AutoSize = true;
            this.lblFechVto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechVto.Location = new System.Drawing.Point(12, 127);
            this.lblFechVto.Name = "lblFechVto";
            this.lblFechVto.Size = new System.Drawing.Size(140, 16);
            this.lblFechVto.TabIndex = 11;
            this.lblFechVto.Text = "Fecha de vencimiento";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod.Location = new System.Drawing.Point(12, 153);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(135, 16);
            this.lblCod.TabIndex = 12;
            this.lblCod.Text = "Código de seguridad";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(15, 221);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 32);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Asociar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(316, 229);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 24);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.TabStop = false;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(12, 183);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(117, 16);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.Text = "Número de cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(186, 181);
            this.txtCliente.MaxLength = 8;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(72, 20);
            this.txtCliente.TabIndex = 19;
            this.txtCliente.Tag = "Cliente";
            // 
            // frmAsociar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 265);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.lblFechVto);
            this.Controls.Add(this.lblFechEmi);
            this.Controls.Add(this.lblEmisor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumTarj);
            this.Controls.Add(this.fechaVencimiento);
            this.Controls.Add(this.fechaEmision);
            this.Controls.Add(this.txtNumTarjeta);
            this.Controls.Add(this.txtCodigoSeguridad);
            this.Controls.Add(this.comboEmisor);
            this.Name = "frmAsociar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asociar una tarjeta nueva";
            this.Load += new System.EventHandler(this.frmAsociar_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEmisor;
        private System.Windows.Forms.TextBox txtCodigoSeguridad;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.DateTimePicker fechaEmision;
        private System.Windows.Forms.DateTimePicker fechaVencimiento;
        private System.Windows.Forms.Label lblNumTarj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.Label lblFechEmi;
        private System.Windows.Forms.Label lblFechVto;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
    }
}