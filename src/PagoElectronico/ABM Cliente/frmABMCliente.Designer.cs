namespace PagoElectronico.ABM_Cliente
{
    partial class frmABMCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridCliente = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.txtBApellido = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.Label();
            this.comboId = new System.Windows.Forms.ComboBox();
            this.txtNroId = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.butBuscar = new System.Windows.Forms.Button();
            this.butAgregar = new System.Windows.Forms.Button();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butBuscar);
            this.groupBox1.Controls.Add(this.butLimpiar);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtNroId);
            this.groupBox1.Controls.Add(this.comboId);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtBApellido);
            this.groupBox1.Controls.Add(this.txtBNombre);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // gridCliente
            // 
            this.gridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colApellido,
            this.colEmail,
            this.colSeleccionar});
            this.gridCliente.Location = new System.Drawing.Point(13, 158);
            this.gridCliente.Name = "gridCliente";
            this.gridCliente.Size = new System.Drawing.Size(513, 150);
            this.gridCliente.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.AutoSize = true;
            this.txtNombre.Location = new System.Drawing.Point(10, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(47, 13);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Text = "Nombre:";
            // 
            // txtApellido
            // 
            this.txtApellido.AutoSize = true;
            this.txtApellido.Location = new System.Drawing.Point(10, 55);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(47, 13);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.Text = "Apellido:";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(22, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(35, 13);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "Email:";
            // 
            // txtBNombre
            // 
            this.txtBNombre.Location = new System.Drawing.Point(58, 22);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(142, 20);
            this.txtBNombre.TabIndex = 3;
            // 
            // txtBApellido
            // 
            this.txtBApellido.Location = new System.Drawing.Point(58, 52);
            this.txtBApellido.Name = "txtBApellido";
            this.txtBApellido.Size = new System.Drawing.Size(142, 20);
            this.txtBApellido.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 5;
            // 
            // txtTipo
            // 
            this.txtTipo.AutoSize = true;
            this.txtTipo.Location = new System.Drawing.Point(235, 25);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(97, 13);
            this.txtTipo.TabIndex = 6;
            this.txtTipo.Text = "Tipo Identificación:";
            this.txtTipo.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboId
            // 
            this.comboId.FormattingEnabled = true;
            this.comboId.Location = new System.Drawing.Point(338, 22);
            this.comboId.Name = "comboId";
            this.comboId.Size = new System.Drawing.Size(154, 21);
            this.comboId.TabIndex = 7;
            // 
            // txtNroId
            // 
            this.txtNroId.AutoSize = true;
            this.txtNroId.Location = new System.Drawing.Point(236, 55);
            this.txtNroId.Name = "txtNroId";
            this.txtNroId.Size = new System.Drawing.Size(96, 13);
            this.txtNroId.TabIndex = 8;
            this.txtNroId.Text = "Nro. Identificación:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(339, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 20);
            this.textBox2.TabIndex = 9;
            // 
            // butLimpiar
            // 
            this.butLimpiar.Location = new System.Drawing.Point(338, 81);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(75, 23);
            this.butLimpiar.TabIndex = 10;
            this.butLimpiar.Text = "Limpiar";
            this.butLimpiar.UseVisualStyleBackColor = true;
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(419, 81);
            this.butBuscar.Name = "butBuscar";
            this.butBuscar.Size = new System.Drawing.Size(75, 23);
            this.butBuscar.TabIndex = 11;
            this.butBuscar.Text = "Buscar";
            this.butBuscar.UseVisualStyleBackColor = true;
            // 
            // butAgregar
            // 
            this.butAgregar.Location = new System.Drawing.Point(451, 127);
            this.butAgregar.Name = "butAgregar";
            this.butAgregar.Size = new System.Drawing.Size(75, 23);
            this.butAgregar.TabIndex = 2;
            this.butAgregar.Text = "Agregar";
            this.butAgregar.UseVisualStyleBackColor = true;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            // 
            // colApellido
            // 
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "colApellido";
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "Seleccionar";
            this.colSeleccionar.Name = "colSeleccionar";
            // 
            // frmABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 330);
            this.Controls.Add(this.butAgregar);
            this.Controls.Add(this.gridCliente);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmABMCliente";
            this.Text = "Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBApellido;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Label txtApellido;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label txtTipo;
        private System.Windows.Forms.ComboBox comboId;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label txtNroId;
        private System.Windows.Forms.Button butBuscar;
        private System.Windows.Forms.Button butLimpiar;
        private System.Windows.Forms.Button butAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewButtonColumn colSeleccionar;
    }
}