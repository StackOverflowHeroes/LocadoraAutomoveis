﻿namespace LocadoraAutomoveis.WinApp.ModuloCondutor
{
    partial class TelaCondutorForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtTelefone = new MaskedTextBox();
            label5 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ComboBoxCliente = new ComboBox();
            cBoxCliente = new CheckBox();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            dateDataValidade = new DateTimePicker();
            txtCPF = new MaskedTextBox();
            txtCNH = new MaskedTextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(305, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGravar.Location = new Point(224, 322);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 22;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(30, 232);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(127, 23);
            txtTelefone.TabIndex = 69;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(30, 214);
            label5.Name = "label5";
            label5.Size = new Size(57, 16);
            label5.TabIndex = 68;
            label5.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(30, 170);
            label4.Name = "label4";
            label4.Size = new Size(37, 16);
            label4.TabIndex = 66;
            label4.Text = "Email";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(30, 144);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(350, 23);
            txtNome.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(30, 124);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 64;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(30, 43);
            label3.Name = "label3";
            label3.Size = new Size(46, 16);
            label3.TabIndex = 71;
            label3.Text = "Cliente";
            // 
            // ComboBoxCliente
            // 
            ComboBoxCliente.DisplayMember = "Nome";
            ComboBoxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCliente.FormattingEnabled = true;
            ComboBoxCliente.Location = new Point(30, 60);
            ComboBoxCliente.Margin = new Padding(3, 2, 3, 2);
            ComboBoxCliente.Name = "ComboBoxCliente";
            ComboBoxCliente.Size = new Size(350, 23);
            ComboBoxCliente.TabIndex = 70;
            // 
            // cBoxCliente
            // 
            cBoxCliente.AutoSize = true;
            cBoxCliente.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cBoxCliente.Location = new Point(30, 88);
            cBoxCliente.Name = "cBoxCliente";
            cBoxCliente.Size = new Size(138, 20);
            cBoxCliente.TabIndex = 72;
            cBoxCliente.Text = "Cliente é condutor?";
            cBoxCliente.UseVisualStyleBackColor = true;
            cBoxCliente.CheckedChanged += cBoxCliente_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(177, 264);
            label1.Name = "label1";
            label1.Size = new Size(33, 16);
            label1.TabIndex = 73;
            label1.Text = "CNH";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(177, 214);
            label6.Name = "label6";
            label6.Size = new Size(27, 16);
            label6.TabIndex = 75;
            label6.Text = "CPF";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(30, 264);
            label7.Name = "label7";
            label7.Size = new Size(87, 16);
            label7.TabIndex = 78;
            label7.Text = "Validade CNH";
            // 
            // dateDataValidade
            // 
            dateDataValidade.Format = DateTimePickerFormat.Short;
            dateDataValidade.Location = new Point(30, 281);
            dateDataValidade.Margin = new Padding(3, 2, 3, 2);
            dateDataValidade.Name = "dateDataValidade";
            dateDataValidade.Size = new Size(127, 23);
            dateDataValidade.TabIndex = 77;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(177, 232);
            txtCPF.Mask = "000.000.000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(127, 23);
            txtCPF.TabIndex = 79;
            // 
            // txtCNH
            // 
            txtCNH.Location = new Point(177, 281);
            txtCNH.Mask = "LL000000000";
            txtCNH.Name = "txtCNH";
            txtCNH.Size = new Size(127, 23);
            txtCNH.TabIndex = 80;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 188);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 23);
            txtEmail.TabIndex = 81;
            // 
            // TelaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 408);
            Controls.Add(txtEmail);
            Controls.Add(txtCNH);
            Controls.Add(txtCPF);
            Controls.Add(label7);
            Controls.Add(dateDataValidade);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(cBoxCliente);
            Controls.Add(label3);
            Controls.Add(ComboBoxCliente);
            Controls.Add(txtTelefone);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaCondutorForm";
            Text = "TelaCondutorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private MaskedTextBox txtTelefone;
        private Label label5;
        private Label label4;
        private TextBox txtNome;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxCliente;
        private CheckBox cBoxCliente;
        private Label label1;
        private Label label6;
        private Label label7;
        private DateTimePicker dateDataValidade;
        private MaskedTextBox txtCPF;
        private MaskedTextBox txtCNH;
        private TextBox txtEmail;
    }
}