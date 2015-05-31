namespace PagoElectronico.ABM_Rol
{
    partial class RolesForm
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
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.cBox_Funcionalidad = new System.Windows.Forms.ComboBox();
            this.lbl_Funcionalidad = new System.Windows.Forms.Label();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.cBox_Estado = new System.Windows.Forms.ComboBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Agregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Roles)).BeginInit();
            this.Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGrid_Roles
            // 
            this.dGrid_Roles.AllowUserToOrderColumns = true;
            this.dGrid_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid_Roles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNombre,
            this.ColEstado,
            this.ColumSeleccionar});
            this.dGrid_Roles.Location = new System.Drawing.Point(35, 146);
            this.dGrid_Roles.Name = "dGrid_Roles";
            this.dGrid_Roles.Size = new System.Drawing.Size(481, 150);
            this.dGrid_Roles.TabIndex = 0;
            this.dGrid_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.Filtros.Location = new System.Drawing.Point(35, 14);
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
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Location = new System.Drawing.Point(19, 54);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(43, 13);
            this.lbl_Estado.TabIndex = 7;
            this.lbl_Estado.Text = "Estado:";
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
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(382, 54);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 3;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
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
            // ColNombre
            // 
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.Name = "ColNombre";
            // 
            // ColEstado
            // 
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Name = "ColEstado";
            // 
            // ColumSeleccionar
            // 
            this.ColumSeleccionar.HeaderText = "Seleccionar";
            this.ColumSeleccionar.Name = "ColumSeleccionar";
            this.ColumSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(441, 110);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar.TabIndex = 2;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            // 
            // RolesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 330);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.Filtros);
            this.Controls.Add(this.dGrid_Roles);
            this.Name = "RolesForm";
            this.Text = "Administrar Roles";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
        private System.Windows.Forms.DataGridViewButtonColumn ColumSeleccionar;
        private System.Windows.Forms.Button btn_Agregar;
    }
}