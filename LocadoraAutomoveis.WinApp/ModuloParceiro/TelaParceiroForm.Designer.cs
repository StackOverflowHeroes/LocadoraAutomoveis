﻿namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
     partial class TelaParceiroForm
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
               txtNome = new TextBox();
               label2 = new Label();
               btnCancelar = new Button();
               btnGravar = new Button();
               SuspendLayout();
               // 
               // txtNome
               // 
               txtNome.Location = new Point(69, 129);
               txtNome.Name = "txtNome";
               txtNome.Size = new Size(350, 23);
               txtNome.TabIndex = 4;
               // 
               // label2
               // 
               label2.AutoSize = true;
               label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
               label2.Location = new Point(69, 111);
               label2.Name = "label2";
               label2.Size = new Size(41, 15);
               label2.TabIndex = 3;
               label2.Text = "Nome";
               // 
               // btnCancelar
               // 
               btnCancelar.DialogResult = DialogResult.Cancel;
               btnCancelar.FlatStyle = FlatStyle.Popup;
               btnCancelar.Location = new Point(397, 255);
               btnCancelar.Name = "btnCancelar";
               btnCancelar.Size = new Size(75, 45);
               btnCancelar.TabIndex = 6;
               btnCancelar.Text = "Cancelar";
               btnCancelar.UseVisualStyleBackColor = true;
               // 
               // btnGravar
               // 
               btnGravar.DialogResult = DialogResult.OK;
               btnGravar.FlatStyle = FlatStyle.Popup;
               btnGravar.Location = new Point(316, 255);
               btnGravar.Name = "btnGravar";
               btnGravar.Size = new Size(75, 45);
               btnGravar.TabIndex = 5;
               btnGravar.Text = "Gravar";
               btnGravar.UseVisualStyleBackColor = true;
               btnGravar.Click += btnGravar_Click;
               // 
               // TelaParceiroForm
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               ClientSize = new Size(484, 311);
               Controls.Add(btnCancelar);
               Controls.Add(btnGravar);
               Controls.Add(txtNome);
               Controls.Add(label2);
               Name = "TelaParceiroForm";
               Text = "Cadastro de Parceiros";
               ResumeLayout(false);
               PerformLayout();
          }

          #endregion

          private TextBox txtNome;
          private Label label2;
          private Button btnCancelar;
          private Button btnGravar;
     }
}