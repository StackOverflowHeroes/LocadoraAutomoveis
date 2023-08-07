using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaServico
{
     partial class TelaTaxaServicoForm
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
               campoPreco = new NumericUpDown();
               planoCalculo = new GroupBox();
               precoDiario = new RadioButton();
               precoFixo = new RadioButton();
               ((System.ComponentModel.ISupportInitialize)campoPreco).BeginInit();
               planoCalculo.SuspendLayout();
               SuspendLayout();
               // 
               // btnCancelar
               // 
               btnCancelar.DialogResult = DialogResult.Cancel;
               btnCancelar.FlatStyle = FlatStyle.Popup;
               btnCancelar.Location = new Point(397, 304);
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
               btnGravar.Location = new Point(316, 304);
               btnGravar.Name = "btnGravar";
               btnGravar.Size = new Size(75, 45);
               btnGravar.TabIndex = 9;
               btnGravar.Text = "Gravar";
               btnGravar.UseVisualStyleBackColor = true;
               btnGravar.Click += btnGravar_Click;
               // 
               // txtNome
               // 
               txtNome.Location = new Point(65, 82);
               txtNome.Name = "txtNome";
               txtNome.Size = new Size(350, 23);
               txtNome.TabIndex = 8;
               // 
               // label2
               // 
               label2.AutoSize = true;
               label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label2.Location = new Point(65, 64);
               label2.Name = "label2";
               label2.Size = new Size(41, 15);
               label2.TabIndex = 7;
               label2.Text = "Nome";
               // 
               // label1
               // 
               label1.AutoSize = true;
               label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label1.Location = new Point(65, 116);
               label1.Name = "label1";
               label1.Size = new Size(120, 15);
               label1.TabIndex = 11;
               label1.Text = "Preço Serviço / Taxa";
               // 
               // campoPreco
               // 
               campoPreco.DecimalPlaces = 2;
               campoPreco.Location = new Point(65, 134);
               campoPreco.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
               campoPreco.Name = "campoPreco";
               campoPreco.Size = new Size(120, 23);
               campoPreco.TabIndex = 12;
               // 
               // planoCalculo
               // 
               planoCalculo.Controls.Add(precoDiario);
               planoCalculo.Controls.Add(precoFixo);
               planoCalculo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               planoCalculo.Location = new Point(65, 163);
               planoCalculo.Name = "planoCalculo";
               planoCalculo.Size = new Size(350, 100);
               planoCalculo.TabIndex = 13;
               planoCalculo.TabStop = false;
               planoCalculo.Text = "Plano de Cálculo";
               // 
               // precoDiario
               // 
               precoDiario.AutoSize = true;
               precoDiario.Checked = true;
               precoDiario.Location = new Point(64, 45);
               precoDiario.Name = "precoDiario";
               precoDiario.Size = new Size(111, 19);
               precoDiario.TabIndex = 1;
               precoDiario.TabStop = true;
               precoDiario.Text = "Cobrança Diária";
               precoDiario.UseVisualStyleBackColor = true;
               // 
               // precoFixo
               // 
               precoFixo.AutoSize = true;
               precoFixo.Location = new Point(202, 45);
               precoFixo.Name = "precoFixo";
               precoFixo.Size = new Size(83, 19);
               precoFixo.TabIndex = 0;
               precoFixo.Text = "Preço Fixo";
               precoFixo.UseVisualStyleBackColor = true;
               // 
               // TelaTaxaServicoForm
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               ClientSize = new Size(484, 361);
               Controls.Add(planoCalculo);
               Controls.Add(campoPreco);
               Controls.Add(label1);
               Controls.Add(btnCancelar);
               Controls.Add(btnGravar);
               Controls.Add(txtNome);
               Controls.Add(label2);
               Name = "TelaTaxaServicoForm";
               Text = "Cadastro de Taxa ou Serviço";
               ((System.ComponentModel.ISupportInitialize)campoPreco).EndInit();
               planoCalculo.ResumeLayout(false);
               planoCalculo.PerformLayout();
               ResumeLayout(false);
               PerformLayout();
          }

          #endregion

          private Button btnCancelar;
          private Button btnGravar;
          private TextBox txtNome;
          private Label label2;
          private Label label1;
          private NumericUpDown campoPreco;
          private GroupBox planoCalculo;
          private RadioButton precoDiario;
          private RadioButton precoFixo;
     }
}