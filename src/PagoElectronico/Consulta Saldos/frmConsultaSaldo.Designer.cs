namespace PagoElectronico.Consulta_Saldos
{
    partial class frmConsultaSaldo
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
            this.lblCuentaPropia = new System.Windows.Forms.Label();
            this.comboCuenta = new System.Windows.Forms.ComboBox();
            this.btnConsultarPropia = new System.Windows.Forms.Button();
            this.lblCuentaTercero = new System.Windows.Forms.Label();
            this.txtCuentaTercero = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.gridDeposito = new System.Windows.Forms.DataGridView();
            this.fec_deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRetiro = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDatos = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridTransferencias = new System.Windows.Forms.DataGridView();
            this.fechaTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_transfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cta_origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cta_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransferencia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRetiro)).BeginInit();
            this.groupDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCuentaPropia
            // 
            this.lblCuentaPropia.AutoSize = true;
            this.lblCuentaPropia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaPropia.Location = new System.Drawing.Point(21, 17);
            this.lblCuentaPropia.Name = "lblCuentaPropia";
            this.lblCuentaPropia.Size = new System.Drawing.Size(197, 16);
            this.lblCuentaPropia.TabIndex = 0;
            this.lblCuentaPropia.Text = "Consultar saldo de mis cuentas:";
            // 
            // comboCuenta
            // 
            this.comboCuenta.FormattingEnabled = true;
            this.comboCuenta.Location = new System.Drawing.Point(24, 36);
            this.comboCuenta.Name = "comboCuenta";
            this.comboCuenta.Size = new System.Drawing.Size(194, 21);
            this.comboCuenta.TabIndex = 1;
            this.comboCuenta.Tag = "Cuenta";
            // 
            // btnConsultarPropia
            // 
            this.btnConsultarPropia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarPropia.Location = new System.Drawing.Point(117, 71);
            this.btnConsultarPropia.Name = "btnConsultarPropia";
            this.btnConsultarPropia.Size = new System.Drawing.Size(101, 28);
            this.btnConsultarPropia.TabIndex = 2;
            this.btnConsultarPropia.Text = "Consultar";
            this.btnConsultarPropia.UseVisualStyleBackColor = true;
            this.btnConsultarPropia.Click += new System.EventHandler(this.btnConsultarPropia_Click);
            // 
            // lblCuentaTercero
            // 
            this.lblCuentaTercero.AutoSize = true;
            this.lblCuentaTercero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaTercero.Location = new System.Drawing.Point(624, 17);
            this.lblCuentaTercero.Name = "lblCuentaTercero";
            this.lblCuentaTercero.Size = new System.Drawing.Size(211, 16);
            this.lblCuentaTercero.TabIndex = 3;
            this.lblCuentaTercero.Text = "Consultar saldo cuenta de tercero:";
            this.lblCuentaTercero.Visible = false;
            // 
            // txtCuentaTercero
            // 
            this.txtCuentaTercero.Enabled = false;
            this.txtCuentaTercero.Location = new System.Drawing.Point(624, 37);
            this.txtCuentaTercero.MaxLength = 16;
            this.txtCuentaTercero.Name = "txtCuentaTercero";
            this.txtCuentaTercero.Size = new System.Drawing.Size(210, 20);
            this.txtCuentaTercero.TabIndex = 4;
            this.txtCuentaTercero.Tag = "Cuenta de tercero";
            this.txtCuentaTercero.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(733, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(852, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 24);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.TabStop = false;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(852, 50);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 24);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.TabStop = false;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // gridDeposito
            // 
            this.gridDeposito.AllowUserToAddRows = false;
            this.gridDeposito.AllowUserToDeleteRows = false;
            this.gridDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDeposito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fec_deposito,
            this.id_deposito,
            this.importe});
            this.gridDeposito.Location = new System.Drawing.Point(12, 140);
            this.gridDeposito.Name = "gridDeposito";
            this.gridDeposito.ReadOnly = true;
            this.gridDeposito.Size = new System.Drawing.Size(371, 146);
            this.gridDeposito.TabIndex = 18;
            // 
            // fec_deposito
            // 
            this.fec_deposito.Frozen = true;
            this.fec_deposito.HeaderText = "Fecha depósito";
            this.fec_deposito.MaxInputLength = 20;
            this.fec_deposito.Name = "fec_deposito";
            this.fec_deposito.ReadOnly = true;
            this.fec_deposito.Width = 150;
            // 
            // id_deposito
            // 
            this.id_deposito.Frozen = true;
            this.id_deposito.HeaderText = "ID Depósito";
            this.id_deposito.MaxInputLength = 20;
            this.id_deposito.Name = "id_deposito";
            this.id_deposito.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.Frozen = true;
            this.importe.HeaderText = "Importe";
            this.importe.MaxInputLength = 20;
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 70;
            // 
            // gridRetiro
            // 
            this.gridRetiro.AllowUserToAddRows = false;
            this.gridRetiro.AllowUserToDeleteRows = false;
            this.gridRetiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRetiro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1,
            this.num_cheque,
            this.banco,
            this.dataGridViewTextBoxColumn2});
            this.gridRetiro.Location = new System.Drawing.Point(388, 140);
            this.gridRetiro.Name = "gridRetiro";
            this.gridRetiro.ReadOnly = true;
            this.gridRetiro.Size = new System.Drawing.Size(550, 146);
            this.gridRetiro.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha retiro";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 165;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID Retiro";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // num_cheque
            // 
            this.num_cheque.Frozen = true;
            this.num_cheque.HeaderText = "Cheque";
            this.num_cheque.Name = "num_cheque";
            this.num_cheque.ReadOnly = true;
            this.num_cheque.Width = 80;
            // 
            // banco
            // 
            this.banco.Frozen = true;
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // groupDatos
            // 
            this.groupDatos.Controls.Add(this.lblEstado);
            this.groupDatos.Controls.Add(this.lblTitular);
            this.groupDatos.Controls.Add(this.lblSaldo);
            this.groupDatos.Controls.Add(this.lblNumCuenta);
            this.groupDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDatos.Location = new System.Drawing.Point(235, 17);
            this.groupDatos.Name = "groupDatos";
            this.groupDatos.Size = new System.Drawing.Size(383, 91);
            this.groupDatos.TabIndex = 21;
            this.groupDatos.TabStop = false;
            this.groupDatos.Text = "Datos de la cuenta";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(191, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(48, 15);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitular.Location = new System.Drawing.Point(13, 40);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(48, 16);
            this.lblTitular.TabIndex = 2;
            this.lblTitular.Text = "Titular:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(13, 62);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(93, 18);
            this.lblSaldo.TabIndex = 1;
            this.lblSaldo.Text = "Saldo: U$S";
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCuenta.Location = new System.Drawing.Point(13, 19);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(53, 16);
            this.lblNumCuenta.TabIndex = 0;
            this.lblNumCuenta.Text = "Cuenta:";
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(13, 119);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(196, 18);
            this.lblDeposito.TabIndex = 22;
            this.lblDeposito.Text = "ÚLTIMOS 5 DEPÓSITOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "ÚLTIMOS 5 RETIROS";
            // 
            // gridTransferencias
            // 
            this.gridTransferencias.AllowUserToAddRows = false;
            this.gridTransferencias.AllowUserToDeleteRows = false;
            this.gridTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaTransfer,
            this.id_transfer,
            this.cta_origen,
            this.cta_destino,
            this.dataGridViewTextBoxColumn6,
            this.costo});
            this.gridTransferencias.Location = new System.Drawing.Point(33, 316);
            this.gridTransferencias.Name = "gridTransferencias";
            this.gridTransferencias.ReadOnly = true;
            this.gridTransferencias.Size = new System.Drawing.Size(883, 264);
            this.gridTransferencias.TabIndex = 24;
            // 
            // fechaTransfer
            // 
            this.fechaTransfer.Frozen = true;
            this.fechaTransfer.HeaderText = "Fecha transferencia";
            this.fechaTransfer.MaxInputLength = 20;
            this.fechaTransfer.Name = "fechaTransfer";
            this.fechaTransfer.ReadOnly = true;
            this.fechaTransfer.Width = 180;
            // 
            // id_transfer
            // 
            this.id_transfer.Frozen = true;
            this.id_transfer.HeaderText = "ID Transferencia";
            this.id_transfer.MaxInputLength = 20;
            this.id_transfer.Name = "id_transfer";
            this.id_transfer.ReadOnly = true;
            this.id_transfer.Width = 150;
            // 
            // cta_origen
            // 
            this.cta_origen.Frozen = true;
            this.cta_origen.HeaderText = "Cuenta origen";
            this.cta_origen.Name = "cta_origen";
            this.cta_origen.ReadOnly = true;
            this.cta_origen.Width = 150;
            // 
            // cta_destino
            // 
            this.cta_destino.Frozen = true;
            this.cta_destino.HeaderText = "Cuenta destino";
            this.cta_destino.Name = "cta_destino";
            this.cta_destino.ReadOnly = true;
            this.cta_destino.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.Frozen = true;
            this.costo.HeaderText = "Costo fijo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferencia.Location = new System.Drawing.Point(30, 296);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(254, 18);
            this.lblTransferencia.TabIndex = 25;
            this.lblTransferencia.Text = "ÚLTIMAS 10 TRANSFERENCIAS";
            // 
            // frmConsultaSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 604);
            this.Controls.Add(this.lblTransferencia);
            this.Controls.Add(this.gridTransferencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeposito);
            this.Controls.Add(this.groupDatos);
            this.Controls.Add(this.gridRetiro);
            this.Controls.Add(this.gridDeposito);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCuentaTercero);
            this.Controls.Add(this.lblCuentaTercero);
            this.Controls.Add(this.btnConsultarPropia);
            this.Controls.Add(this.comboCuenta);
            this.Controls.Add(this.lblCuentaPropia);
            this.Name = "frmConsultaSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de saldo";
            this.Load += new System.EventHandler(this.frmConsultaSaldo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRetiro)).EndInit();
            this.groupDatos.ResumeLayout(false);
            this.groupDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCuentaPropia;
        private System.Windows.Forms.ComboBox comboCuenta;
        private System.Windows.Forms.Button btnConsultarPropia;
        private System.Windows.Forms.Label lblCuentaTercero;
        private System.Windows.Forms.TextBox txtCuentaTercero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView gridDeposito;
        private System.Windows.Forms.DataGridView gridRetiro;
        private System.Windows.Forms.GroupBox groupDatos;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fec_deposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_deposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridView gridTransferencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cta_origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cta_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.Label lblTransferencia;
    }
}