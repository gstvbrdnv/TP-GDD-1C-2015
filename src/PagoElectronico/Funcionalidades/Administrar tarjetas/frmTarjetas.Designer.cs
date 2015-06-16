namespace PagoElectronico.Tarjetas
{
    partial class frmTarjetas
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
            this.lblOpcion = new System.Windows.Forms.Label();
            this.btnAsociarTarjeta = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDesasociar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcion.Location = new System.Drawing.Point(12, 9);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(189, 20);
            this.lblOpcion.TabIndex = 0;
            this.lblOpcion.Text = "Por favor, elija una opción";
            // 
            // btnAsociarTarjeta
            // 
            this.btnAsociarTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsociarTarjeta.Location = new System.Drawing.Point(12, 37);
            this.btnAsociarTarjeta.Name = "btnAsociarTarjeta";
            this.btnAsociarTarjeta.Size = new System.Drawing.Size(224, 40);
            this.btnAsociarTarjeta.TabIndex = 12;
            this.btnAsociarTarjeta.TabStop = false;
            this.btnAsociarTarjeta.Text = "Asociar una tarjeta nueva";
            this.btnAsociarTarjeta.UseVisualStyleBackColor = true;
            this.btnAsociarTarjeta.Click += new System.EventHandler(this.btnAsociarTarjeta_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(12, 83);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(224, 40);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.TabStop = false;
            this.btnModificar.Text = "Modificar una tarjeta ya asociada";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDesasociar
            // 
            this.btnDesasociar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesasociar.Location = new System.Drawing.Point(12, 129);
            this.btnDesasociar.Name = "btnDesasociar";
            this.btnDesasociar.Size = new System.Drawing.Size(224, 40);
            this.btnDesasociar.TabIndex = 14;
            this.btnDesasociar.TabStop = false;
            this.btnDesasociar.Text = "Desasociar una tarjeta";
            this.btnDesasociar.UseVisualStyleBackColor = true;
            this.btnDesasociar.Click += new System.EventHandler(this.btnDesasociar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(150, 188);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 24);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.TabStop = false;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 224);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnDesasociar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAsociarTarjeta);
            this.Controls.Add(this.lblOpcion);
            this.Name = "frmTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar tarjetas";
            this.Load += new System.EventHandler(this.frmTarjetas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpcion;
        private System.Windows.Forms.Button btnAsociarTarjeta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesasociar;
        private System.Windows.Forms.Button btnVolver;
    }
}