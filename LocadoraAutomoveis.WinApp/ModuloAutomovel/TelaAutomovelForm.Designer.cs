namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    partial class TelaAutomovelForm
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
            PictureBoxCarro = new PictureBox();
            label1 = new Label();
            ComboBoxGrupoAutomovel = new ComboBox();
            label2 = new Label();
            TextBoxModelo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            TextBoxMarca = new TextBox();
            label5 = new Label();
            TextBoxCor = new TextBox();
            label6 = new Label();
            ComboBoxTipoCombustivel = new ComboBox();
            NumericInputCapacidadeLitros = new NumericUpDown();
            label7 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            BotaoBuscarImagem = new Button();
            OpenFileDialog = new OpenFileDialog();
            label8 = new Label();
            TextBoxPlaca = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputCapacidadeLitros).BeginInit();
            SuspendLayout();
            // 
            // PictureBoxCarro
            // 
            PictureBoxCarro.Location = new Point(176, 36);
            PictureBoxCarro.Name = "PictureBoxCarro";
            PictureBoxCarro.Size = new Size(136, 128);
            PictureBoxCarro.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxCarro.TabIndex = 0;
            PictureBoxCarro.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 13);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "Foto";
            // 
            // ComboBoxGrupoAutomovel
            // 
            ComboBoxGrupoAutomovel.DisplayMember = "Nome";
            ComboBoxGrupoAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxGrupoAutomovel.FormattingEnabled = true;
            ComboBoxGrupoAutomovel.Location = new Point(48, 255);
            ComboBoxGrupoAutomovel.Name = "ComboBoxGrupoAutomovel";
            ComboBoxGrupoAutomovel.Size = new Size(384, 28);
            ComboBoxGrupoAutomovel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 232);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 3;
            label2.Text = "Grupo automóveis";
            // 
            // TextBoxModelo
            // 
            TextBoxModelo.Location = new Point(48, 309);
            TextBoxModelo.Name = "TextBoxModelo";
            TextBoxModelo.Size = new Size(384, 27);
            TextBoxModelo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 286);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 5;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 345);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 7;
            label4.Text = "Marca";
            // 
            // TextBoxMarca
            // 
            TextBoxMarca.Location = new Point(48, 368);
            TextBoxMarca.Name = "TextBoxMarca";
            TextBoxMarca.Size = new Size(384, 27);
            TextBoxMarca.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 402);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 9;
            label5.Text = "Cor";
            // 
            // TextBoxCor
            // 
            TextBoxCor.Location = new Point(48, 425);
            TextBoxCor.Name = "TextBoxCor";
            TextBoxCor.Size = new Size(384, 27);
            TextBoxCor.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 520);
            label6.Name = "label6";
            label6.Size = new Size(144, 20);
            label6.TabIndex = 11;
            label6.Text = "Tipo de combustivel";
            // 
            // ComboBoxTipoCombustivel
            // 
            ComboBoxTipoCombustivel.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxTipoCombustivel.FormattingEnabled = true;
            ComboBoxTipoCombustivel.Location = new Point(48, 543);
            ComboBoxTipoCombustivel.Name = "ComboBoxTipoCombustivel";
            ComboBoxTipoCombustivel.Size = new Size(384, 28);
            ComboBoxTipoCombustivel.TabIndex = 10;
            // 
            // NumericInputCapacidadeLitros
            // 
            NumericInputCapacidadeLitros.Location = new Point(48, 607);
            NumericInputCapacidadeLitros.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NumericInputCapacidadeLitros.Name = "NumericInputCapacidadeLitros";
            NumericInputCapacidadeLitros.Size = new Size(384, 27);
            NumericInputCapacidadeLitros.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 584);
            label7.Name = "label7";
            label7.Size = new Size(150, 20);
            label7.TabIndex = 13;
            label7.Text = "Capacidade em litros";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(344, 664);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 60);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Location = new Point(251, 664);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 60);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // BotaoBuscarImagem
            // 
            BotaoBuscarImagem.Location = new Point(176, 173);
            BotaoBuscarImagem.Name = "BotaoBuscarImagem";
            BotaoBuscarImagem.Size = new Size(136, 29);
            BotaoBuscarImagem.TabIndex = 16;
            BotaoBuscarImagem.Text = "Buscar imagem";
            BotaoBuscarImagem.UseVisualStyleBackColor = true;
            BotaoBuscarImagem.Click += BotaoBuscarImagem_Click;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog";
            OpenFileDialog.Filter = "Imagens|*.jpg;*.png;*.jpeg\"";
            OpenFileDialog.Title = "\"Selecione uma imagem\"";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 464);
            label8.Name = "label8";
            label8.Size = new Size(44, 20);
            label8.TabIndex = 18;
            label8.Text = "Placa";
            // 
            // TextBoxPlaca
            // 
            TextBoxPlaca.Location = new Point(48, 487);
            TextBoxPlaca.Name = "TextBoxPlaca";
            TextBoxPlaca.Size = new Size(384, 27);
            TextBoxPlaca.TabIndex = 17;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 754);
            Controls.Add(label8);
            Controls.Add(TextBoxPlaca);
            Controls.Add(BotaoBuscarImagem);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label7);
            Controls.Add(NumericInputCapacidadeLitros);
            Controls.Add(label6);
            Controls.Add(ComboBoxTipoCombustivel);
            Controls.Add(label5);
            Controls.Add(TextBoxCor);
            Controls.Add(label4);
            Controls.Add(TextBoxMarca);
            Controls.Add(label3);
            Controls.Add(TextBoxModelo);
            Controls.Add(label2);
            Controls.Add(ComboBoxGrupoAutomovel);
            Controls.Add(label1);
            Controls.Add(PictureBoxCarro);
            Name = "TelaAutomovelForm";
            Text = "TelaAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)PictureBoxCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputCapacidadeLitros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PictureBoxCarro;
        private Label label1;
        private ComboBox ComboBoxGrupoAutomovel;
        private Label label2;
        private TextBox TextBoxModelo;
        private Label label3;
        private Label label4;
        private TextBox TextBoxMarca;
        private Label label5;
        private TextBox TextBoxCor;
        private Label label6;
        private ComboBox ComboBoxTipoCombustivel;
        private NumericUpDown NumericInputCapacidadeLitros;
        private Label label7;
        private Button btnCancelar;
        private Button btnGravar;
        private Button BotaoBuscarImagem;
        private OpenFileDialog OpenFileDialog;
        private Label label8;
        private TextBox TextBoxPlaca;
    }
}