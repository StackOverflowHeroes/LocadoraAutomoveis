﻿namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    partial class TabelaAutomovelForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridAutomovel = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridAutomovel).BeginInit();
            SuspendLayout();
            // 
            // gridAutomovel
            // 
            gridAutomovel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAutomovel.Dock = DockStyle.Fill;
            gridAutomovel.Location = new Point(0, 0);
            gridAutomovel.Name = "gridAutomovel";
            gridAutomovel.RowHeadersWidth = 51;
            gridAutomovel.RowTemplate.Height = 29;
            gridAutomovel.Size = new Size(482, 438);
            gridAutomovel.TabIndex = 0;
            // 
            // TabelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridAutomovel);
            Name = "TabelaAutomovelForm";
            Size = new Size(482, 438);
            ((System.ComponentModel.ISupportInitialize)gridAutomovel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridAutomovel;
    }
}
