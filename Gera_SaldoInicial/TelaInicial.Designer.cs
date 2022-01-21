
namespace Gera_SaldoInicial
{
    partial class TelaInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSelecionarArquivo = new System.Windows.Forms.TextBox();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFormatoConta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataSaldoInicial = new System.Windows.Forms.TextBox();
            this.chkSaldoFinal = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSelecionarArquivo
            // 
            this.txtSelecionarArquivo.Location = new System.Drawing.Point(147, 188);
            this.txtSelecionarArquivo.Name = "txtSelecionarArquivo";
            this.txtSelecionarArquivo.Size = new System.Drawing.Size(247, 23);
            this.txtSelecionarArquivo.TabIndex = 0;
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(400, 188);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionarArquivo.TabIndex = 1;
            this.btnSelecionarArquivo.Text = "Selecionar Arquivo";
            this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 226);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(860, 270);
            this.dataGridView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(307, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gerador de Saldo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(70, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arquivo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 23);
            this.comboBox1.TabIndex = 6;
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.Location = new System.Drawing.Point(375, 518);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(100, 23);
            this.btnGerarArquivo.TabIndex = 7;
            this.btnGerarArquivo.Text = "Gerar Arquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Click += new System.EventHandler(this.btnGerarArquivo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Formato Conta:";
            // 
            // txtFormatoConta
            // 
            this.txtFormatoConta.Location = new System.Drawing.Point(147, 87);
            this.txtFormatoConta.Name = "txtFormatoConta";
            this.txtFormatoConta.Size = new System.Drawing.Size(140, 23);
            this.txtFormatoConta.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Saldo Inicial:";
            // 
            // txtDataSaldoInicial
            // 
            this.txtDataSaldoInicial.Location = new System.Drawing.Point(147, 121);
            this.txtDataSaldoInicial.Name = "txtDataSaldoInicial";
            this.txtDataSaldoInicial.Size = new System.Drawing.Size(140, 23);
            this.txtDataSaldoInicial.TabIndex = 11;
            // 
            // chkSaldoFinal
            // 
            this.chkSaldoFinal.AutoSize = true;
            this.chkSaldoFinal.Location = new System.Drawing.Point(672, 54);
            this.chkSaldoFinal.Name = "chkSaldoFinal";
            this.chkSaldoFinal.Size = new System.Drawing.Size(114, 19);
            this.chkSaldoFinal.TabIndex = 12;
            this.chkSaldoFinal.Text = "Gerar Saldo Final";
            this.chkSaldoFinal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(24, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Informar CNPJ:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(147, 156);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.PlaceholderText = "Informe CNPJ P/ balancetes Wells";
            this.txtCNPJ.Size = new System.Drawing.Size(247, 23);
            this.txtCNPJ.TabIndex = 14;
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 553);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkSaldoFinal);
            this.Controls.Add(this.txtDataSaldoInicial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFormatoConta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGerarArquivo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnSelecionarArquivo);
            this.Controls.Add(this.txtSelecionarArquivo);
            this.Name = "TelaInicial";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelecionarArquivo;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnGerarArquivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFormatoConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataSaldoInicial;
        private System.Windows.Forms.CheckBox chkSaldoFinal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCNPJ;
    }
}

