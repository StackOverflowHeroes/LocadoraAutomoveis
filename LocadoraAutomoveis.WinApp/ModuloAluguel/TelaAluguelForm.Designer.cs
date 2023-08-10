namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cboxFuncionario = new ComboBox();
            cboxCliente = new ComboBox();
            cboxGrupoAutomoveis = new ComboBox();
            cmbPlanoCobranca = new ComboBox();
            dateLocacao = new DateTimePicker();
            cboxCondutor = new ComboBox();
            cboxAutomovel = new ComboBox();
            txtKmAutomovel = new NumericUpDown();
            dateDevolucao = new DateTimePicker();
            txtCupom = new TextBox();
            btnCupom = new Button();
            tbControlTaxasAdicionadas = new TabControl();
            tbTaxas = new TabPage();
            listTaxas = new CheckedListBox();
            label12 = new Label();
            label11 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            lbValor = new Label();
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).BeginInit();
            tbControlTaxasAdicionadas.SuspendLayout();
            tbTaxas.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 16);
            label1.TabIndex = 0;
            label1.Text = "Funcionário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(46, 16);
            label2.TabIndex = 1;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 97);
            label3.Name = "label3";
            label3.Size = new Size(127, 16);
            label3.TabIndex = 2;
            label3.Text = "Grupo de Automóveis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(111, 16);
            label4.TabIndex = 3;
            label4.Text = "Plano de Cobrança";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(11, 185);
            label5.Name = "label5";
            label5.Size = new Size(86, 16);
            label5.TabIndex = 4;
            label5.Text = "Data Locação";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 229);
            label6.Name = "label6";
            label6.Size = new Size(41, 16);
            label6.TabIndex = 5;
            label6.Text = "Cupom";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(200, 9);
            label7.Name = "label7";
            label7.Size = new Size(57, 16);
            label7.TabIndex = 6;
            label7.Text = "Condutor";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(200, 53);
            label8.Name = "label8";
            label8.Size = new Size(65, 16);
            label8.TabIndex = 7;
            label8.Text = "Automóvel";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(200, 97);
            label9.Name = "label9";
            label9.Size = new Size(106, 16);
            label9.TabIndex = 8;
            label9.Text = "KM do Automóvel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(197, 141);
            label10.Name = "label10";
            label10.Size = new Size(115, 16);
            label10.TabIndex = 9;
            label10.Text = "Devolução Prevista";
            // 
            // cboxFuncionario
            // 
            cboxFuncionario.DisplayMember = "Nome";
            cboxFuncionario.FormattingEnabled = true;
            cboxFuncionario.Location = new Point(12, 27);
            cboxFuncionario.Name = "cboxFuncionario";
            cboxFuncionario.Size = new Size(154, 23);
            cboxFuncionario.TabIndex = 10;
            // 
            // cboxCliente
            // 
            cboxCliente.DisplayMember = "Nome";
            cboxCliente.FormattingEnabled = true;
            cboxCliente.Location = new Point(12, 71);
            cboxCliente.Name = "cboxCliente";
            cboxCliente.Size = new Size(154, 23);
            cboxCliente.TabIndex = 11;
            // 
            // cboxGrupoAutomoveis
            // 
            cboxGrupoAutomoveis.DisplayMember = "Nome";
            cboxGrupoAutomoveis.FormattingEnabled = true;
            cboxGrupoAutomoveis.Location = new Point(12, 115);
            cboxGrupoAutomoveis.Name = "cboxGrupoAutomoveis";
            cboxGrupoAutomoveis.Size = new Size(154, 23);
            cboxGrupoAutomoveis.TabIndex = 12;
            // 
            // cmbPlanoCobranca
            // 
            cmbPlanoCobranca.DisplayMember = "Nome";
            cmbPlanoCobranca.FormattingEnabled = true;
            cmbPlanoCobranca.Location = new Point(12, 159);
            cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            cmbPlanoCobranca.Size = new Size(154, 23);
            cmbPlanoCobranca.TabIndex = 13;
            cmbPlanoCobranca.SelectedIndexChanged += cmbPlanoCobranca_SelectedIndexChanged;
            // 
            // dateLocacao
            // 
            dateLocacao.Format = DateTimePickerFormat.Short;
            dateLocacao.Location = new Point(12, 203);
            dateLocacao.Name = "dateLocacao";
            dateLocacao.Size = new Size(154, 23);
            dateLocacao.TabIndex = 16;
            // 
            // cboxCondutor
            // 
            cboxCondutor.DisplayMember = "Nome";
            cboxCondutor.FormattingEnabled = true;
            cboxCondutor.Location = new Point(200, 27);
            cboxCondutor.Name = "cboxCondutor";
            cboxCondutor.Size = new Size(121, 23);
            cboxCondutor.TabIndex = 17;
            // 
            // cboxAutomovel
            // 
            cboxAutomovel.DisplayMember = "Placa";
            cboxAutomovel.FormattingEnabled = true;
            cboxAutomovel.Location = new Point(200, 71);
            cboxAutomovel.Name = "cboxAutomovel";
            cboxAutomovel.Size = new Size(121, 23);
            cboxAutomovel.TabIndex = 18;
            cboxAutomovel.SelectedIndexChanged += cboxAutomovel_SelectedIndexChanged;
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Enabled = false;
            txtKmAutomovel.Location = new Point(200, 116);
            txtKmAutomovel.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.Size = new Size(121, 23);
            txtKmAutomovel.TabIndex = 19;
            // 
            // dateDevolucao
            // 
            dateDevolucao.Format = DateTimePickerFormat.Short;
            dateDevolucao.Location = new Point(200, 159);
            dateDevolucao.Name = "dateDevolucao";
            dateDevolucao.Size = new Size(121, 23);
            dateDevolucao.TabIndex = 20;
            dateDevolucao.ValueChanged += dateDevolucao_ValueChanged;
            // 
            // txtCupom
            // 
            txtCupom.Location = new Point(11, 247);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(155, 23);
            txtCupom.TabIndex = 21;
            // 
            // btnCupom
            // 
            btnCupom.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCupom.Location = new Point(200, 247);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(124, 28);
            btnCupom.TabIndex = 22;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            btnCupom.Click += btnCupom_Click;
            // 
            // tbControlTaxasAdicionadas
            // 
            tbControlTaxasAdicionadas.Controls.Add(tbTaxas);
            tbControlTaxasAdicionadas.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tbControlTaxasAdicionadas.Location = new Point(11, 277);
            tbControlTaxasAdicionadas.Name = "tbControlTaxasAdicionadas";
            tbControlTaxasAdicionadas.SelectedIndex = 0;
            tbControlTaxasAdicionadas.Size = new Size(398, 191);
            tbControlTaxasAdicionadas.TabIndex = 84;
            // 
            // tbTaxas
            // 
            tbTaxas.Controls.Add(listTaxas);
            tbTaxas.Location = new Point(4, 25);
            tbTaxas.Name = "tbTaxas";
            tbTaxas.Padding = new Padding(3);
            tbTaxas.Size = new Size(390, 162);
            tbTaxas.TabIndex = 0;
            tbTaxas.Text = "Taxas Selecionadas";
            tbTaxas.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            listTaxas.CheckOnClick = true;
            listTaxas.Dock = DockStyle.Fill;
            listTaxas.FormattingEnabled = true;
            listTaxas.Location = new Point(3, 3);
            listTaxas.Name = "listTaxas";
            listTaxas.Size = new Size(384, 156);
            listTaxas.TabIndex = 0;
            listTaxas.MouseUp += listTaxas_MouseUp;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(12, 471);
            label12.Name = "label12";
            label12.Size = new Size(128, 16);
            label12.TabIndex = 87;
            label12.Text = "Valor Total Previsto:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(143, 471);
            label11.Name = "label11";
            label11.Size = new Size(23, 16);
            label11.TabIndex = 92;
            label11.Text = "R$";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGravar.Location = new Point(229, 474);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 94;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(320, 474);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 95;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbValor
            // 
            lbValor.AutoSize = true;
            lbValor.Location = new Point(172, 472);
            lbValor.Name = "lbValor";
            lbValor.Size = new Size(13, 15);
            lbValor.TabIndex = 96;
            lbValor.Text = "0";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 541);
            Controls.Add(lbValor);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(tbControlTaxasAdicionadas);
            Controls.Add(btnCupom);
            Controls.Add(txtCupom);
            Controls.Add(dateDevolucao);
            Controls.Add(txtKmAutomovel);
            Controls.Add(cboxAutomovel);
            Controls.Add(cboxCondutor);
            Controls.Add(dateLocacao);
            Controls.Add(cmbPlanoCobranca);
            Controls.Add(cboxGrupoAutomoveis);
            Controls.Add(cboxCliente);
            Controls.Add(cboxFuncionario);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguel";
            Load += TelaAluguelForm_Load;
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).EndInit();
            tbControlTaxasAdicionadas.ResumeLayout(false);
            tbTaxas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cboxFuncionario;
        private ComboBox cboxCliente;
        private ComboBox cboxGrupoAutomoveis;
        private ComboBox cmbPlanoCobranca;
        private DateTimePicker dateLocacao;
        private ComboBox cboxCondutor;
        private ComboBox cboxAutomovel;
        private NumericUpDown txtKmAutomovel;
        private DateTimePicker dateDevolucao;
        private TextBox txtCupom;
        private Button btnCupom;
        private TabControl tbControlTaxasAdicionadas;
        private TabPage tbTaxas;
        private CheckedListBox listTaxas;
        private Label label12;
        private Label label11;
        private Button btnGravar;
        private Button btnCancelar;
        private Label lbValor;
    }
}