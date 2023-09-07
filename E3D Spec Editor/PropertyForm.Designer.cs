
namespace E3D_Spec_Editor
{
    partial class PropertyForm
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
            this.PropertyDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PropertyDataGridView
            // 
            this.PropertyDataGridView.AllowUserToAddRows = false;
            this.PropertyDataGridView.AllowUserToDeleteRows = false;
            this.PropertyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PropertyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PropertyDataGridView.Name = "PropertyDataGridView";
            this.PropertyDataGridView.ReadOnly = true;
            this.PropertyDataGridView.Size = new System.Drawing.Size(347, 578);
            this.PropertyDataGridView.TabIndex = 0;
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 578);
            this.Controls.Add(this.PropertyDataGridView);
            this.Name = "PropertyForm";
            this.Text = "Property Form";
            this.Load += new System.EventHandler(this.PropertyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PropertyDataGridView;
    }
}