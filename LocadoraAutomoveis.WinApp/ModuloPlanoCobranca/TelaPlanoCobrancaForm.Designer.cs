namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    partial class TelaPlanoCobrancaForm
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            NumericInputKmDisponiveis = new NumericUpDown();
            label4 = new Label();
            NumericInputPrecoKM = new NumericUpDown();
            label3 = new Label();
            NumericInputPrecoDiaria = new NumericUpDown();
            label2 = new Label();
            ComboBoxTipoPlano = new ComboBox();
            ComboBoxGrupoAutomoveis = new ComboBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericInputKmDisponiveis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoKM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoDiaria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(37, 42);
            label1.Name = "label1";
            label1.Size = new Size(125, 16);
            label1.TabIndex = 0;
            label1.Text = "Grupo de automóveis";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NumericInputKmDisponiveis);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NumericInputPrecoKM);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(NumericInputPrecoDiaria);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ComboBoxTipoPlano);
            groupBox1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(37, 92);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(360, 230);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuração de planos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(44, 170);
            label5.Name = "label5";
            label5.Size = new Size(89, 16);
            label5.TabIndex = 10;
            label5.Text = "KM disponíveis";
            // 
            // NumericInputKmDisponiveis
            // 
            NumericInputKmDisponiveis.Enabled = false;
            NumericInputKmDisponiveis.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NumericInputKmDisponiveis.Location = new Point(44, 187);
            NumericInputKmDisponiveis.Margin = new Padding(3, 2, 3, 2);
            NumericInputKmDisponiveis.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputKmDisponiveis.Name = "NumericInputKmDisponiveis";
            NumericInputKmDisponiveis.Size = new Size(273, 24);
            NumericInputKmDisponiveis.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(44, 121);
            label4.Name = "label4";
            label4.Size = new Size(84, 16);
            label4.TabIndex = 8;
            label4.Text = "Preço por KM";
            // 
            // NumericInputPrecoKM
            // 
            NumericInputPrecoKM.DecimalPlaces = 2;
            NumericInputPrecoKM.Enabled = false;
            NumericInputPrecoKM.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NumericInputPrecoKM.Location = new Point(44, 138);
            NumericInputPrecoKM.Margin = new Padding(3, 2, 3, 2);
            NumericInputPrecoKM.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputPrecoKM.Name = "NumericInputPrecoKM";
            NumericInputPrecoKM.Size = new Size(273, 24);
            NumericInputPrecoKM.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(44, 73);
            label3.Name = "label3";
            label3.Size = new Size(76, 16);
            label3.TabIndex = 6;
            label3.Text = "Preço diária";
            // 
            // NumericInputPrecoDiaria
            // 
            NumericInputPrecoDiaria.DecimalPlaces = 2;
            NumericInputPrecoDiaria.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NumericInputPrecoDiaria.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            NumericInputPrecoDiaria.Location = new Point(44, 90);
            NumericInputPrecoDiaria.Margin = new Padding(3, 2, 3, 2);
            NumericInputPrecoDiaria.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputPrecoDiaria.Name = "NumericInputPrecoDiaria";
            NumericInputPrecoDiaria.Size = new Size(273, 24);
            NumericInputPrecoDiaria.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(44, 26);
            label2.Name = "label2";
            label2.Size = new Size(82, 16);
            label2.TabIndex = 4;
            label2.Text = "Tipo de plano";
            // 
            // ComboBoxTipoPlano
            // 
            ComboBoxTipoPlano.DisplayMember = "Nome";
            ComboBoxTipoPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxTipoPlano.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ComboBoxTipoPlano.FormattingEnabled = true;
            ComboBoxTipoPlano.Location = new Point(44, 44);
            ComboBoxTipoPlano.Margin = new Padding(3, 2, 3, 2);
            ComboBoxTipoPlano.Name = "ComboBoxTipoPlano";
            ComboBoxTipoPlano.Size = new Size(274, 24);
            ComboBoxTipoPlano.TabIndex = 3;
            ComboBoxTipoPlano.SelectedIndexChanged += ComboBoxTipoPlano_SelectedIndexChanged;
            // 
            // ComboBoxGrupoAutomoveis
            // 
            ComboBoxGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxGrupoAutomoveis.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ComboBoxGrupoAutomoveis.FormattingEnabled = true;
            ComboBoxGrupoAutomoveis.Location = new Point(37, 59);
            ComboBoxGrupoAutomoveis.Margin = new Padding(3, 2, 3, 2);
            ComboBoxGrupoAutomoveis.Name = "ComboBoxGrupoAutomoveis";
            ComboBoxGrupoAutomoveis.Size = new Size(361, 24);
            ComboBoxGrupoAutomoveis.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(320, 342);
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
            btnGravar.Location = new Point(239, 342);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaPlanoCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 397);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(ComboBoxGrupoAutomoveis);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TelaPlanoCobrancaForm";
            Text = "Cadastro de Plano de Cobrança";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericInputKmDisponiveis).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoKM).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoDiaria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private ComboBox ComboBoxGrupoAutomoveis;
        private Button btnCancelar;
        private Button btnGravar;
        private Label label2;
        private ComboBox ComboBoxTipoPlano;
        private Label label3;
        private NumericUpDown NumericInputPrecoDiaria;
        private Label label5;
        private NumericUpDown NumericInputKmDisponiveis;
        private Label label4;
        private NumericUpDown NumericInputPrecoKM;
    }
}