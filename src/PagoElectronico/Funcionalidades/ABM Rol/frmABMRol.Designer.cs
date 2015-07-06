namespace PagoElectronico.ABM_Rol
{
    partial class frmABMRol
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
            this.dGrid_Roles = new System.Windows.Forms.DataGridView();
            this.id_rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.cBox_Funcionalidad = new System.Windows.Forms.ComboBox();
            this.lbl_Funcionalidad = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.cBox_Estado = new System.Windows.Forms.ComboBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Roles)).BeginInit();
            this.Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGrid_Roles
            // 
            this.dGrid_Roles.AllowUserToOrderColumns = true;
            this.dGrid_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid_Roles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_rol,
            this.ColNombre,
            this.ColEstado,
            this.ColumSeleccionar});
            this.dGrid_Roles.Location = new System.Drawing.Point(12, 135);
            this.dGrid_Roles.MultiSelect = false;
            this.dGrid_Roles.Name = "dGrid_Roles";
            this.dGrid_Roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGrid_Roles.Size = new System.Drawing.Size(481, 217);
            this.dGrid_Roles.TabIndex = 0;
            this.dGrid_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id_rol
            // 
            this.id_rol.Frozen = true;
            this.id_rol.HeaderText = "Código rol";
            this.id_rol.Name = "id_rol";
            this.id_rol.ReadOnly = true;
            this.id_rol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id_rol.Width = 90;
            // 
            // ColNombre
            // 
            this.ColNombre.Frozen = true;
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            this.ColNombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColNombre.Width = 150;
            // 
            // ColEstado
            // 
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;
            this.ColEstado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEstado.Width = 70;
            // 
            // ColumSeleccionar
            // 
            this.ColumSeleccionar.HeaderText = "Seleccionar";
            this.ColumSeleccionar.Name = "ColumSeleccionar";
            this.ColumSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Filtros
            // 
            this.Filtros.AccessibleDescription = "";
            this.Filtros.Controls.Add(this.cBox_Funcionalidad);
            this.Filtros.Controls.Add(this.lbl_Funcionalidad);
            this.Filtros.Controls.Add(this.btn_Limpiar);
            this.Filtros.Controls.Add(this.lbl_Estado);
            this.Filtros.Controls.Add(this.btn_Buscar);
            this.Filtros.Controls.Add(this.cBox_Estado);
            this.Filtros.Controls.Add(this.lbl_Nombre);
            this.Filtros.Controls.Add(this.txt_Nombre);
            this.Filtros.Location = new System.Drawing.Point(12, 41);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(481, 88);
            this.Filtros.TabIndex = 1;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros de Búsqueda";
            this.Filtros.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cBox_Funcionalidad
            // 
            this.cBox_Funcionalidad.FormattingEnabled = true;
            this.cBox_Funcionalidad.Location = new System.Drawing.Point(301, 21);
            this.cBox_Funcionalidad.Name = "cBox_Funcionalidad";
            this.cBox_Funcionalidad.Size = new System.Drawing.Size(156, 21);
            this.cBox_Funcionalidad.TabIndex = 9;
            // 
            // lbl_Funcionalidad
            // 
            this.lbl_Funcionalidad.AutoSize = true;
            this.lbl_Funcionalidad.Location = new System.Drawing.Point(217, 24);
            this.lbl_Funcionalidad.Name = "lbl_Funcionalidad";
            this.lbl_Funcionalidad.Size = new System.Drawing.Size(76, 13);
            this.lbl_Funcionalidad.TabIndex = 8;
            this.lbl_Funcionalidad.Text = "Funcionalidad:";
            this.lbl_Funcionalidad.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(301, 54);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar.TabIndex = 2;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Location = new System.Drawing.Point(19, 54);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(43, 13);
            this.lbl_Estado.TabIndex = 7;
            this.lbl_Estado.Text = "Estado:";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(382, 54);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 3;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // cBox_Estado
            // 
            this.cBox_Estado.FormattingEnabled = true;
            this.cBox_Estado.Location = new System.Drawing.Point(64, 54);
            this.cBox_Estado.Name = "cBox_Estado";
            this.cBox_Estado.Size = new System.Drawing.Size(144, 21);
            this.cBox_Estado.TabIndex = 6;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Location = new System.Drawing.Point(16, 24);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(47, 13);
            this.lbl_Nombre.TabIndex = 5;
            this.lbl_Nombre.Text = "Nombre:";
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(64, 21);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(144, 20);
            this.txt_Nombre.TabIndex = 4;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Agregar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(174, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.Color.Black;
            this.btnVolver.Location = new System.Drawing.Point(439, 11);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(60, 22);
            this.btnVolver.TabIndex = 119;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 369);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.Filtros);
            this.Controls.Add(this.dGrid_Roles);
            this.Name = "frmABMRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar roles";
            this.Load += new System.EventHandler(this.RolesForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Roles)).EndInit();
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGrid_Roles;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label lbl_Funcionalidad;
        private System.Windows.Forms.Label lbl_Estado;
        private System.Windows.Forms.ComboBox cBox_Estado;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.ComboBox cBox_Funcionalidad;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
        private System.Windows.Forms.DataGridViewButtonColumn ColumSeleccionar;
    }
}