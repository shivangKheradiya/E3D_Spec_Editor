
namespace E3D_Spec_Editor
{
    partial class CatalogueForm
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
            this.CatalogueTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // CatalogueTreeView
            // 
            this.CatalogueTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CatalogueTreeView.Location = new System.Drawing.Point(0, 0);
            this.CatalogueTreeView.Name = "CatalogueTreeView";
            this.CatalogueTreeView.Size = new System.Drawing.Size(262, 524);
            this.CatalogueTreeView.TabIndex = 0;
            // 
            // CatalogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 524);
            this.Controls.Add(this.CatalogueTreeView);
            this.Name = "CatalogueForm";
            this.Text = "Catalogue Form";
            this.Load += new System.EventHandler(this.CatalogueForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CatalogueTreeView;
    }
}