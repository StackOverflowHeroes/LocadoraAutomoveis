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
            label9 = new Label();
            NumericInputQuilometragem = new NumericUpDown();
            label10 = new Label();
            NumericInputAno = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputCapacidadeLitros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputQuilometragem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputAno).BeginInit();
            SuspendLayout();
            // 
            // PictureBoxCarro
            // 
            PictureBoxCarro.BorderStyle = BorderStyle.FixedSingle;
            PictureBoxCarro.Location = new Point(154, 27);
            PictureBoxCarro.Margin = new Padding(3, 2, 3, 2);
            PictureBoxCarro.Name = "PictureBoxCarro";
            PictureBoxCarro.Size = new Size(119, 96);
            PictureBoxCarro.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxCarro.TabIndex = 0;
            PictureBoxCarro.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(154, 10);
            label1.Name = "label1";
            label1.Size = new Size(32, 16);
            label1.TabIndex = 1;
            label1.Text = "Foto";
            // 
            // ComboBoxGrupoAutomovel
            // 
            ComboBoxGrupoAutomovel.DisplayMember = "Nome";
            ComboBoxGrupoAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxGrupoAutomovel.FormattingEnabled = true;
            ComboBoxGrupoAutomovel.Location = new Point(42, 191);
            ComboBoxGrupoAutomovel.Margin = new Padding(3, 2, 3, 2);
            ComboBoxGrupoAutomovel.Name = "ComboBoxGrupoAutomovel";
            ComboBoxGrupoAutomovel.Size = new Size(336, 23);
            ComboBoxGrupoAutomovel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(42, 174);
            label2.Name = "label2";
            label2.Size = new Size(106, 16);
            label2.TabIndex = 3;
            label2.Text = "Grupo automóveis";
            // 
            // TextBoxModelo
            // 
            TextBoxModelo.Location = new Point(42, 232);
            TextBoxModelo.Margin = new Padding(3, 2, 3, 2);
            TextBoxModelo.Name = "TextBoxModelo";
            TextBoxModelo.Size = new Size(211, 23);
            TextBoxModelo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(42, 214);
            label3.Name = "label3";
            label3.Size = new Size(47, 16);
            label3.TabIndex = 5;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(258, 214);
            label4.Name = "label4";
            label4.Size = new Size(44, 16);
            label4.TabIndex = 7;
            label4.Text = "Marca";
            // 
            // TextBoxMarca
            // 
            TextBoxMarca.Location = new Point(258, 232);
            TextBoxMarca.Margin = new Padding(3, 2, 3, 2);
            TextBoxMarca.Name = "TextBoxMarca";
            TextBoxMarca.Size = new Size(120, 23);
            TextBoxMarca.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(42, 302);
            label5.Name = "label5";
            label5.Size = new Size(26, 16);
            label5.TabIndex = 9;
            label5.Text = "Cor";
            // 
            // TextBoxCor
            // 
            TextBoxCor.Location = new Point(42, 319);
            TextBoxCor.Margin = new Padding(3, 2, 3, 2);
            TextBoxCor.Name = "TextBoxCor";
            TextBoxCor.Size = new Size(211, 23);
            TextBoxCor.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(44, 345);
            label6.Name = "label6";
            label6.Size = new Size(119, 16);
            label6.TabIndex = 11;
            label6.Text = "Tipo de combustivel";
            // 
            // ComboBoxTipoCombustivel
            // 
            ComboBoxTipoCombustivel.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxTipoCombustivel.FormattingEnabled = true;
            ComboBoxTipoCombustivel.Location = new Point(44, 362);
            ComboBoxTipoCombustivel.Margin = new Padding(3, 2, 3, 2);
            ComboBoxTipoCombustivel.Name = "ComboBoxTipoCombustivel";
            ComboBoxTipoCombustivel.Size = new Size(336, 23);
            ComboBoxTipoCombustivel.TabIndex = 10;
            // 
            // NumericInputCapacidadeLitros
            // 
            NumericInputCapacidadeLitros.Location = new Point(44, 410);
            NumericInputCapacidadeLitros.Margin = new Padding(3, 2, 3, 2);
            NumericInputCapacidadeLitros.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NumericInputCapacidadeLitros.Name = "NumericInputCapacidadeLitros";
            NumericInputCapacidadeLitros.Size = new Size(336, 23);
            NumericInputCapacidadeLitros.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(44, 393);
            label7.Name = "label7";
            label7.Size = new Size(127, 16);
            label7.TabIndex = 13;
            label7.Text = "Capacidade em litros";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(303, 443);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGravar.Location = new Point(221, 443);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // BotaoBuscarImagem
            // 
            BotaoBuscarImagem.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoBuscarImagem.Location = new Point(154, 130);
            BotaoBuscarImagem.Margin = new Padding(3, 2, 3, 2);
            BotaoBuscarImagem.Name = "BotaoBuscarImagem";
            BotaoBuscarImagem.Size = new Size(119, 22);
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
            label8.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(258, 302);
            label8.Name = "label8";
            label8.Size = new Size(36, 16);
            label8.TabIndex = 18;
            label8.Text = "Placa";
            // 
            // TextBoxPlaca
            // 
            TextBoxPlaca.Location = new Point(258, 319);
            TextBoxPlaca.Margin = new Padding(3, 2, 3, 2);
            TextBoxPlaca.Name = "TextBoxPlaca";
            TextBoxPlaca.Size = new Size(120, 23);
            TextBoxPlaca.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(42, 262);
            label9.Name = "label9";
            label9.Size = new Size(93, 16);
            label9.TabIndex = 20;
            label9.Text = "Quilometragem";
            // 
            // NumericInputQuilometragem
            // 
            NumericInputQuilometragem.Location = new Point(42, 279);
            NumericInputQuilometragem.Margin = new Padding(3, 2, 3, 2);
            NumericInputQuilometragem.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumericInputQuilometragem.Name = "NumericInputQuilometragem";
            NumericInputQuilometragem.Size = new Size(211, 23);
            NumericInputQuilometragem.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(258, 262);
            label10.Name = "label10";
            label10.Size = new Size(28, 16);
            label10.TabIndex = 22;
            label10.Text = "Ano";
            // 
            // NumericInputAno
            // 
            NumericInputAno.Location = new Point(258, 279);
            NumericInputAno.Margin = new Padding(3, 2, 3, 2);
            NumericInputAno.Maximum = new decimal(new int[] { 2024, 0, 0, 0 });
            NumericInputAno.Name = "NumericInputAno";
            NumericInputAno.Size = new Size(122, 23);
            NumericInputAno.TabIndex = 21;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 500);
            Controls.Add(label10);
            Controls.Add(NumericInputAno);
            Controls.Add(label9);
            Controls.Add(NumericInputQuilometragem);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "TelaAutomovelForm";
            Text = "TelaAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)PictureBoxCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputCapacidadeLitros).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputQuilometragem).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputAno).EndInit();
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
        private Label label9;
        private NumericUpDown NumericInputQuilometragem;
        private Label label10;
        private NumericUpDown NumericInputAno;
    }
}