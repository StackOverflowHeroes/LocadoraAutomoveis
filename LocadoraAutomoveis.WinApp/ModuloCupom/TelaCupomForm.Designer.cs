namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    partial class TelaCupomForm
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
            Nome = new Label();
            TextBoxNome = new TextBox();
            ComboBoxParceiro = new ComboBox();
            DataValidade = new DateTimePicker();
            label1 = new Label();
            NumericInputValor = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)NumericInputValor).BeginInit();
            SuspendLayout();
            // 
            // Nome
            // 
            Nome.AutoSize = true;
            Nome.Location = new Point(50, 28);
            Nome.Name = "Nome";
            Nome.Size = new Size(50, 20);
            Nome.TabIndex = 0;
            Nome.Text = "Nome";
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(50, 51);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(358, 27);
            TextBoxNome.TabIndex = 1;
            // 
            // ComboBoxParceiro
            // 
            ComboBoxParceiro.DisplayMember = "Nome";
            ComboBoxParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxParceiro.FormattingEnabled = true;
            ComboBoxParceiro.Location = new Point(50, 239);
            ComboBoxParceiro.Name = "ComboBoxParceiro";
            ComboBoxParceiro.Size = new Size(358, 28);
            ComboBoxParceiro.TabIndex = 2;
            // 
            // DataValidade
            // 
            DataValidade.Format = DateTimePickerFormat.Short;
            DataValidade.Location = new Point(50, 176);
            DataValidade.Name = "DataValidade";
            DataValidade.Size = new Size(358, 27);
            DataValidade.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 90);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 4;
            label1.Text = "Valor";
            // 
            // NumericInputValor
            // 
            NumericInputValor.DecimalPlaces = 2;
            NumericInputValor.Location = new Point(50, 113);
            NumericInputValor.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericInputValor.Name = "NumericInputValor";
            NumericInputValor.Size = new Size(358, 27);
            NumericInputValor.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 153);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 6;
            label2.Text = "Data de validade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 216);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Parceiro";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(320, 304);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 60);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Location = new Point(227, 304);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 60);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 394);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NumericInputValor);
            Controls.Add(label1);
            Controls.Add(DataValidade);
            Controls.Add(ComboBoxParceiro);
            Controls.Add(TextBoxNome);
            Controls.Add(Nome);
            Name = "TelaCupomForm";
            Text = "TelaCupomForm";
            ((System.ComponentModel.ISupportInitialize)NumericInputValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nome;
        private TextBox TextBoxNome;
        private ComboBox ComboBoxParceiro;
        private DateTimePicker DataValidade;
        private Label label1;
        private NumericUpDown NumericInputValor;
        private Label label2;
        private Label label3;
        private Button btnCancelar;
        private Button btnGravar;
    }
}