namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
     partial class TelaClienteForm
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
               txtNome = new TextBox();
               label2 = new Label();
               txtEmail = new TextBox();
               label4 = new Label();
               label5 = new Label();
               txtTelefone = new MaskedTextBox();
               rdbFisica = new RadioButton();
               rdbJuridica = new RadioButton();
               txtTipoCliente = new Label();
               txtCpf = new MaskedTextBox();
               txtCnpj = new MaskedTextBox();
               label6 = new Label();
               label7 = new Label();
               label1 = new Label();
               label3 = new Label();
               txtEstado = new TextBox();
               txtCidade = new TextBox();
               txtRua = new TextBox();
               label8 = new Label();
               txtNumero = new TextBox();
               label9 = new Label();
               txtBairro = new TextBox();
               label10 = new Label();
               SuspendLayout();
               // 
               // btnCancelar
               // 
               btnCancelar.DialogResult = DialogResult.Cancel;
               btnCancelar.FlatStyle = FlatStyle.Popup;
               btnCancelar.Location = new Point(336, 429);
               btnCancelar.Name = "btnCancelar";
               btnCancelar.Size = new Size(75, 45);
               btnCancelar.TabIndex = 21;
               btnCancelar.Text = "Cancelar";
               btnCancelar.UseVisualStyleBackColor = true;
               // 
               // btnGravar
               // 
               btnGravar.DialogResult = DialogResult.OK;
               btnGravar.FlatStyle = FlatStyle.Popup;
               btnGravar.Location = new Point(255, 429);
               btnGravar.Name = "btnGravar";
               btnGravar.Size = new Size(75, 45);
               btnGravar.TabIndex = 20;
               btnGravar.Text = "Gravar";
               btnGravar.UseVisualStyleBackColor = true;
               btnGravar.Click += btnGravar_Click;
               // 
               // txtNome
               // 
               txtNome.Location = new Point(61, 79);
               txtNome.Name = "txtNome";
               txtNome.Size = new Size(350, 23);
               txtNome.TabIndex = 19;
               // 
               // label2
               // 
               label2.AutoSize = true;
               label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label2.Location = new Point(61, 61);
               label2.Name = "label2";
               label2.Size = new Size(41, 15);
               label2.TabIndex = 18;
               label2.Text = "Nome";
               // 
               // txtEmail
               // 
               txtEmail.Location = new Point(61, 123);
               txtEmail.Name = "txtEmail";
               txtEmail.Size = new Size(350, 23);
               txtEmail.TabIndex = 27;
               // 
               // label4
               // 
               label4.AutoSize = true;
               label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label4.Location = new Point(61, 105);
               label4.Name = "label4";
               label4.Size = new Size(36, 15);
               label4.TabIndex = 26;
               label4.Text = "Email";
               // 
               // label5
               // 
               label5.AutoSize = true;
               label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label5.Location = new Point(61, 149);
               label5.Name = "label5";
               label5.Size = new Size(56, 15);
               label5.TabIndex = 28;
               label5.Text = "Telefone";
               // 
               // txtTelefone
               // 
               txtTelefone.Location = new Point(61, 167);
               txtTelefone.Mask = "(99) 00000-0000";
               txtTelefone.Name = "txtTelefone";
               txtTelefone.Size = new Size(97, 23);
               txtTelefone.TabIndex = 63;
               // 
               // rdbFisica
               // 
               rdbFisica.AutoSize = true;
               rdbFisica.Checked = true;
               rdbFisica.Location = new Point(61, 211);
               rdbFisica.Name = "rdbFisica";
               rdbFisica.Size = new Size(93, 19);
               rdbFisica.TabIndex = 64;
               rdbFisica.TabStop = true;
               rdbFisica.Text = "Pessoa Física";
               rdbFisica.UseVisualStyleBackColor = true;
               rdbFisica.CheckedChanged += rdbFisica_CheckedChanged;
               // 
               // rdbJuridica
               // 
               rdbJuridica.AutoSize = true;
               rdbJuridica.Location = new Point(161, 211);
               rdbJuridica.Name = "rdbJuridica";
               rdbJuridica.Size = new Size(104, 19);
               rdbJuridica.TabIndex = 65;
               rdbJuridica.Text = "Pessoa Jurídica";
               rdbJuridica.UseVisualStyleBackColor = true;
               rdbJuridica.CheckedChanged += rdbJuridica_CheckedChanged;
               // 
               // txtTipoCliente
               // 
               txtTipoCliente.AutoSize = true;
               txtTipoCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               txtTipoCliente.Location = new Point(61, 193);
               txtTipoCliente.Name = "txtTipoCliente";
               txtTipoCliente.Size = new Size(73, 15);
               txtTipoCliente.TabIndex = 66;
               txtTipoCliente.Text = "Tipo Cliente";
               // 
               // txtCpf
               // 
               txtCpf.Location = new Point(61, 251);
               txtCpf.Mask = "999,999,999-99";
               txtCpf.Name = "txtCpf";
               txtCpf.Size = new Size(97, 23);
               txtCpf.TabIndex = 67;
               // 
               // txtCnpj
               // 
               txtCnpj.Enabled = false;
               txtCnpj.Location = new Point(165, 251);
               txtCnpj.Mask = "99,999,999/9999-99";
               txtCnpj.Name = "txtCnpj";
               txtCnpj.Size = new Size(100, 23);
               txtCnpj.TabIndex = 68;
               // 
               // label6
               // 
               label6.AutoSize = true;
               label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label6.Location = new Point(61, 233);
               label6.Name = "label6";
               label6.Size = new Size(27, 15);
               label6.TabIndex = 69;
               label6.Text = "CPF";
               // 
               // label7
               // 
               label7.AutoSize = true;
               label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label7.Location = new Point(165, 233);
               label7.Name = "label7";
               label7.Size = new Size(34, 15);
               label7.TabIndex = 70;
               label7.Text = "CNPJ";
               // 
               // label1
               // 
               label1.AutoSize = true;
               label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label1.Location = new Point(61, 277);
               label1.Name = "label1";
               label1.Size = new Size(43, 15);
               label1.TabIndex = 71;
               label1.Text = "Estado";
               // 
               // label3
               // 
               label3.AutoSize = true;
               label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label3.Location = new Point(255, 277);
               label3.Name = "label3";
               label3.Size = new Size(44, 15);
               label3.TabIndex = 72;
               label3.Text = "Cidade";
               // 
               // txtEstado
               // 
               txtEstado.Location = new Point(61, 295);
               txtEstado.Name = "txtEstado";
               txtEstado.Size = new Size(146, 23);
               txtEstado.TabIndex = 73;
               // 
               // txtCidade
               // 
               txtCidade.Location = new Point(255, 295);
               txtCidade.Name = "txtCidade";
               txtCidade.Size = new Size(156, 23);
               txtCidade.TabIndex = 74;
               // 
               // txtRua
               // 
               txtRua.Location = new Point(61, 383);
               txtRua.Name = "txtRua";
               txtRua.Size = new Size(350, 23);
               txtRua.TabIndex = 76;
               // 
               // label8
               // 
               label8.AutoSize = true;
               label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label8.Location = new Point(61, 365);
               label8.Name = "label8";
               label8.Size = new Size(28, 15);
               label8.TabIndex = 75;
               label8.Text = "Rua";
               // 
               // txtNumero
               // 
               txtNumero.Location = new Point(61, 428);
               txtNumero.Name = "txtNumero";
               txtNumero.Size = new Size(146, 23);
               txtNumero.TabIndex = 78;
               // 
               // label9
               // 
               label9.AutoSize = true;
               label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label9.Location = new Point(61, 410);
               label9.Name = "label9";
               label9.Size = new Size(53, 15);
               label9.TabIndex = 77;
               label9.Text = "Número";
               // 
               // txtBairro
               // 
               txtBairro.Location = new Point(61, 339);
               txtBairro.Name = "txtBairro";
               txtBairro.Size = new Size(350, 23);
               txtBairro.TabIndex = 80;
               // 
               // label10
               // 
               label10.AutoSize = true;
               label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label10.Location = new Point(61, 321);
               label10.Name = "label10";
               label10.Size = new Size(41, 15);
               label10.TabIndex = 79;
               label10.Text = "Bairro";
               // 
               // TelaClienteForm
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               ClientSize = new Size(442, 486);
               Controls.Add(txtBairro);
               Controls.Add(label10);
               Controls.Add(txtNumero);
               Controls.Add(label9);
               Controls.Add(txtRua);
               Controls.Add(label8);
               Controls.Add(txtCidade);
               Controls.Add(txtEstado);
               Controls.Add(label3);
               Controls.Add(label1);
               Controls.Add(label7);
               Controls.Add(label6);
               Controls.Add(txtCnpj);
               Controls.Add(txtCpf);
               Controls.Add(txtTipoCliente);
               Controls.Add(rdbJuridica);
               Controls.Add(rdbFisica);
               Controls.Add(txtTelefone);
               Controls.Add(label5);
               Controls.Add(txtEmail);
               Controls.Add(label4);
               Controls.Add(btnCancelar);
               Controls.Add(btnGravar);
               Controls.Add(txtNome);
               Controls.Add(label2);
               Name = "TelaClienteForm";
               Text = "Cadastro de Cliente";
               ResumeLayout(false);
               PerformLayout();
          }

          #endregion
          private Button btnCancelar;
          private Button btnGravar;
          private TextBox txtNome;
          private Label label2;
          private TextBox txtEmail;
          private Label label4;
          private Label label5;
          private MaskedTextBox txtTelefone;
          private RadioButton rdbFisica;
          private RadioButton rdbJuridica;
          private Label txtTipoCliente;
          private MaskedTextBox txtCpf;
          private MaskedTextBox txtCnpj;
          private Label label6;
          private Label label7;
          private Label label1;
          private Label label3;
          private TextBox txtEstado;
          private TextBox txtCidade;
          private TextBox txtRua;
          private Label label8;
          private TextBox txtNumero;
          private Label label9;
          private TextBox txtBairro;
          private Label label10;
     }
}