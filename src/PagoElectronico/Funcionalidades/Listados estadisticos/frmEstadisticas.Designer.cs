namespace PagoElectronico.Listados
{
    partial class frmEstadisticas
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
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblReporte = new System.Windows.Forms.Label();
            this.comboReporte = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.datagridTOP5 = new System.Windows.Forms.DataGridView();
            this.columna1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTOP5)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Location = new System.Drawing.Point(12, 36);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(162, 21);
            this.comboTrimestre.TabIndex = 0;
            this.comboTrimestre.Tag = "Trimestre";
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrimestre.Location = new System.Drawing.Point(12, 20);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(100, 16);
            this.lblTrimestre.TabIndex = 1;
            this.lblTrimestre.Tag = "Trimestre";
            this.lblTrimestre.Text = "Elegir trimestre:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(198, 37);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(83, 20);
            this.txtYear.TabIndex = 2;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(195, 20);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(86, 16);
            this.lblAnio.TabIndex = 3;
            this.lblAnio.Text = "Ingresar año:";
            // 
            // lblReporte
            // 
            this.lblReporte.AutoSize = true;
            this.lblReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporte.Location = new System.Drawing.Point(309, 20);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(199, 16);
            this.lblReporte.TabIndex = 4;
            this.lblReporte.Text = "Seleccionar reporte a visualizar:";
            // 
            // comboReporte
            // 
            this.comboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReporte.FormattingEnabled = true;
            this.comboReporte.Location = new System.Drawing.Point(312, 36);
            this.comboReporte.Name = "comboReporte";
            this.comboReporte.Size = new System.Drawing.Size(196, 21);
            this.comboReporte.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(533, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 24);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(409, 76);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(99, 23);
            this.btnMostrar.TabIndex = 7;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // datagridTOP5
            // 
            this.datagridTOP5.AllowUserToAddRows = false;
            this.datagridTOP5.AllowUserToDeleteRows = false;
            this.datagridTOP5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridTOP5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columna1,
            this.columna2,
            this.columna3,
            this.columna4,
            this.columna5});
            this.datagridTOP5.Location = new System.Drawing.Point(12, 105);
            this.datagridTOP5.Name = "datagridTOP5";
            this.datagridTOP5.ReadOnly = true;
            this.datagridTOP5.Size = new System.Drawing.Size(591, 207);
            this.datagridTOP5.TabIndex = 8;
            // 
            // columna1
            // 
            this.columna1.Frozen = true;
            this.columna1.HeaderText = "Columna1";
            this.columna1.Name = "columna1";
            this.columna1.ReadOnly = true;
            // 
            // columna2
            // 
            this.columna2.Frozen = true;
            this.columna2.HeaderText = "Columna1";
            this.columna2.Name = "columna2";
            this.columna2.ReadOnly = true;
            // 
            // columna3
            // 
            this.columna3.Frozen = true;
            this.columna3.HeaderText = "Columna3";
            this.columna3.Name = "columna3";
            this.columna3.ReadOnly = true;
            // 
            // columna4
            // 
            this.columna4.Frozen = true;
            this.columna4.HeaderText = "Columna4";
            this.columna4.Name = "columna4";
            this.columna4.ReadOnly = true;
            // 
            // columna5
            // 
            this.columna5.Frozen = true;
            this.columna5.HeaderText = "Columna5";
            this.columna5.Name = "columna5";
            this.columna5.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(533, 42);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 24);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "TOP5";
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.datagridTOP5);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.comboReporte);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.comboTrimestre);
            this.Name = "frmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadísticas";
            this.Load += new System.EventHandler(this.frmEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridTOP5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTrimestre;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox comboReporte;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DataGridView datagridTOP5;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna3;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna4;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna5;
        private System.Windows.Forms.Label label1;
    }
}