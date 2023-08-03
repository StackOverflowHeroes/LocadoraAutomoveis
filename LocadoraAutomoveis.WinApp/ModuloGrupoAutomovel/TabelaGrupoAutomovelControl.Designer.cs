namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomovel
{
    partial class TabelaGrupoAutomovelControl
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
            gridGrupoAutomovel = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridGrupoAutomovel).BeginInit();
            SuspendLayout();
            // 
            // gridGrupoAutomovel
            // 
            gridGrupoAutomovel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGrupoAutomovel.Dock = DockStyle.Fill;
            gridGrupoAutomovel.Location = new Point(0, 0);
            gridGrupoAutomovel.Name = "gridGrupoAutomovel";
            gridGrupoAutomovel.RowHeadersWidth = 51;
            gridGrupoAutomovel.RowTemplate.Height = 29;
            gridGrupoAutomovel.Size = new Size(459, 388);
            gridGrupoAutomovel.TabIndex = 0;
            // 
            // TabelaGrupoAutomovelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridGrupoAutomovel);
            Name = "TabelaGrupoAutomovelControl";
            Size = new Size(459, 388);
            ((System.ComponentModel.ISupportInitialize)gridGrupoAutomovel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridGrupoAutomovel;
    }
}
