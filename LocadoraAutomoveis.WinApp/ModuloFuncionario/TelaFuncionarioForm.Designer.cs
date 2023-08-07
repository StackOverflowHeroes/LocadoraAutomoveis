namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
     partial class TelaFuncionarioForm
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
               label1 = new Label();
               dateAdmissao = new DateTimePicker();
               label3 = new Label();
               campoSalario = new NumericUpDown();
               ((System.ComponentModel.ISupportInitialize)campoSalario).BeginInit();
               SuspendLayout();
               // 
               // btnCancelar
               // 
               btnCancelar.DialogResult = DialogResult.Cancel;
               btnCancelar.FlatStyle = FlatStyle.Popup;
               btnCancelar.Location = new Point(309, 239);
               btnCancelar.Name = "btnCancelar";
               btnCancelar.Size = new Size(75, 45);
               btnCancelar.TabIndex = 10;
               btnCancelar.Text = "Cancelar";
               btnCancelar.UseVisualStyleBackColor = true;
               // 
               // btnGravar
               // 
               btnGravar.DialogResult = DialogResult.OK;
               btnGravar.FlatStyle = FlatStyle.Popup;
               btnGravar.Location = new Point(228, 239);
               btnGravar.Name = "btnGravar";
               btnGravar.Size = new Size(75, 45);
               btnGravar.TabIndex = 9;
               btnGravar.Text = "Gravar";
               btnGravar.UseVisualStyleBackColor = true;
               btnGravar.Click += btnGravar_Click;
               // 
               // txtNome
               // 
               txtNome.Location = new Point(34, 72);
               txtNome.Name = "txtNome";
               txtNome.Size = new Size(350, 23);
               txtNome.TabIndex = 8;
               // 
               // label2
               // 
               label2.AutoSize = true;
               label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label2.Location = new Point(34, 54);
               label2.Name = "label2";
               label2.Size = new Size(41, 15);
               label2.TabIndex = 7;
               label2.Text = "Nome";
               // 
               // label1
               // 
               label1.AutoSize = true;
               label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label1.Location = new Point(34, 98);
               label1.Name = "label1";
               label1.Size = new Size(59, 15);
               label1.TabIndex = 12;
               label1.Text = "Admissão";
               // 
               // dateAdmissao
               // 
               dateAdmissao.Format = DateTimePickerFormat.Short;
               dateAdmissao.Location = new Point(34, 116);
               dateAdmissao.Name = "dateAdmissao";
               dateAdmissao.Size = new Size(100, 23);
               dateAdmissao.TabIndex = 16;
               dateAdmissao.Value = new DateTime(2023, 8, 7, 3, 26, 58, 0);
               // 
               // label3
               // 
               label3.AutoSize = true;
               label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label3.Location = new Point(34, 142);
               label3.Name = "label3";
               label3.Size = new Size(44, 15);
               label3.TabIndex = 17;
               label3.Text = "Salário";
               // 
               // campoSalario
               // 
               campoSalario.DecimalPlaces = 2;
               campoSalario.Location = new Point(34, 160);
               campoSalario.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
               campoSalario.Name = "campoSalario";
               campoSalario.Size = new Size(120, 23);
               campoSalario.TabIndex = 18;
               // 
               // TelaFuncionarioForm
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               ClientSize = new Size(397, 293);
               Controls.Add(campoSalario);
               Controls.Add(label3);
               Controls.Add(dateAdmissao);
               Controls.Add(label1);
               Controls.Add(btnCancelar);
               Controls.Add(btnGravar);
               Controls.Add(txtNome);
               Controls.Add(label2);
               Name = "TelaFuncionarioForm";
               Text = "Cadastro de Funcionário";
               ((System.ComponentModel.ISupportInitialize)campoSalario).EndInit();
               ResumeLayout(false);
               PerformLayout();
          }

          #endregion

          private Button btnCancelar;
          private Button btnGravar;
          private TextBox txtNome;
          private Label label2;
          private Label label1;
          private DateTimePicker dateAdmissao;
          private Label label3;
          private NumericUpDown campoSalario;
     }
}