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
            Nome.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Nome.Location = new Point(44, 21);
            Nome.Name = "Nome";
            Nome.Size = new Size(39, 16);
            Nome.TabIndex = 0;
            Nome.Text = "Nome";
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(44, 38);
            TextBoxNome.Margin = new Padding(3, 2, 3, 2);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(314, 23);
            TextBoxNome.TabIndex = 1;
            // 
            // ComboBoxParceiro
            // 
            ComboBoxParceiro.DisplayMember = "Nome";
            ComboBoxParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxParceiro.FormattingEnabled = true;
            ComboBoxParceiro.Location = new Point(44, 179);
            ComboBoxParceiro.Margin = new Padding(3, 2, 3, 2);
            ComboBoxParceiro.Name = "ComboBoxParceiro";
            ComboBoxParceiro.Size = new Size(314, 23);
            ComboBoxParceiro.TabIndex = 2;
            // 
            // DataValidade
            // 
            DataValidade.Format = DateTimePickerFormat.Short;
            DataValidade.Location = new Point(44, 132);
            DataValidade.Margin = new Padding(3, 2, 3, 2);
            DataValidade.Name = "DataValidade";
            DataValidade.Size = new Size(314, 23);
            DataValidade.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(44, 68);
            label1.Name = "label1";
            label1.Size = new Size(37, 16);
            label1.TabIndex = 4;
            label1.Text = "Valor";
            // 
            // NumericInputValor
            // 
            NumericInputValor.DecimalPlaces = 2;
            NumericInputValor.Location = new Point(44, 85);
            NumericInputValor.Margin = new Padding(3, 2, 3, 2);
            NumericInputValor.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericInputValor.Name = "NumericInputValor";
            NumericInputValor.Size = new Size(313, 23);
            NumericInputValor.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(44, 115);
            label2.Name = "label2";
            label2.Size = new Size(107, 16);
            label2.TabIndex = 6;
            label2.Text = "Data de validade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(44, 162);
            label3.Name = "label3";
            label3.Size = new Size(54, 16);
            label3.TabIndex = 7;
            label3.Text = "Parceiro";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(280, 228);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGravar.Location = new Point(199, 228);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 296);
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
            Margin = new Padding(3, 2, 3, 2);
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