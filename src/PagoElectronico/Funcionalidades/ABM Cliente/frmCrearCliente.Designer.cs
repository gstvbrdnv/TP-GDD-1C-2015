namespace PagoElectronico.Funcionalidades.ABM_Cliente
{
    partial class frmCrearCliente
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
            this.comboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNumCalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPais = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboNacionalidad = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboTipoDocumento
            // 
            this.comboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDocumento.FormattingEnabled = true;
            this.comboTipoDocumento.Location = new System.Drawing.Point(205, 62);
            this.comboTipoDocumento.Name = "comboTipoDocumento";
            this.comboTipoDocumento.Size = new System.Drawing.Size(107, 21);
            this.comboTipoDocumento.TabIndex = 70;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(113, 219);
            this.txtTelefono.MaxLength = 50;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 68;
            this.txtTelefono.Tag = "Teléfono";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Telefono";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaNacimiento.Location = new System.Drawing.Point(112, 272);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtFechaNacimiento.TabIndex = 66;
            this.dtFechaNacimiento.Tag = "Fecha de nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Fecha nacimiento";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(113, 141);
            this.txtDomicilio.MaxLength = 50;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(200, 20);
            this.txtDomicilio.TabIndex = 64;
            this.txtDomicilio.Tag = "Domicilio";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(58, 144);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(49, 13);
            this.lblDireccion.TabIndex = 63;
            this.lblDireccion.Text = "Domicilio";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(112, 89);
            this.txtMail.MaxLength = 100;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(200, 20);
            this.txtMail.TabIndex = 62;
            this.txtMail.Tag = "Mail";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(79, 92);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 61;
            this.lblMail.Text = "Mail";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(112, 63);
            this.txtDocumento.MaxLength = 8;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(87, 20);
            this.txtDocumento.TabIndex = 60;
            this.txtDocumento.Tag = "Documento";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(44, 66);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 59;
            this.lblDocumento.Text = "Documento";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(112, 40);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 57;
            this.txtApellido.Tag = "Apellido";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(61, 43);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 56;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(112, 17);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 55;
            this.txtNombre.Tag = "Nombre";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(61, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 54;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNumCalle
            // 
            this.txtNumCalle.Location = new System.Drawing.Point(113, 167);
            this.txtNumCalle.Name = "txtNumCalle";
            this.txtNumCalle.Size = new System.Drawing.Size(42, 20);
            this.txtNumCalle.TabIndex = 74;
            this.txtNumCalle.Tag = "Numero calle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Número";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(193, 167);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(42, 20);
            this.txtPiso.TabIndex = 76;
            this.txtPiso.Tag = "Piso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Piso";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(282, 167);
            this.txtDepto.MaxLength = 1;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(31, 20);
            this.txtDepto.TabIndex = 77;
            this.txtDepto.Tag = "Departamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(241, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Depto";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(113, 193);
            this.txtLocalidad.MaxLength = 50;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(200, 20);
            this.txtLocalidad.TabIndex = 80;
            this.txtLocalidad.Tag = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "Localidad";
            // 
            // comboPais
            // 
            this.comboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPais.FormattingEnabled = true;
            this.comboPais.Location = new System.Drawing.Point(112, 115);
            this.comboPais.Name = "comboPais";
            this.comboPais.Size = new System.Drawing.Size(200, 21);
            this.comboPais.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Pais";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Nacionalidad";
            // 
            // comboNacionalidad
            // 
            this.comboNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNacionalidad.FormattingEnabled = true;
            this.comboNacionalidad.Location = new System.Drawing.Point(112, 245);
            this.comboNacionalidad.Name = "comboNacionalidad";
            this.comboNacionalidad.Size = new System.Drawing.Size(200, 21);
            this.comboNacionalidad.TabIndex = 84;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(271, 312);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(60, 22);
            this.btnLimpiar.TabIndex = 116;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.Color.Black;
            this.btnVolver.Location = new System.Drawing.Point(271, 338);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(60, 22);
            this.btnVolver.TabIndex = 117;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(12, 329);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 31);
            this.btnAceptar.TabIndex = 118;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Location = new System.Drawing.Point(113, 298);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(128, 21);
            this.comboEstado.TabIndex = 119;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(62, 301);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 120;
            this.lblEstado.Text = "Estado";
            // 
            // frmCrearCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 371);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.comboNacionalidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboPais);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumCalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTipoDocumento);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtFechaNacimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmCrearCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCrearCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTipoDocumento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNumCalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboPais;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboNacionalidad;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}