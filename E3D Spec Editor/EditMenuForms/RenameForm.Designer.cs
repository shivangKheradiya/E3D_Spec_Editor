
namespace E3D_Spec_Editor.EditMenuForms
{
    partial class RenameForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.NameLable = new System.Windows.Forms.Label();
            this.oKbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(59, 14);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(206, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Location = new System.Drawing.Point(13, 18);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(35, 13);
            this.NameLable.TabIndex = 1;
            this.NameLable.Text = "Name";
            // 
            // oKbutton
            // 
            this.oKbutton.Location = new System.Drawing.Point(59, 40);
            this.oKbutton.Name = "oKbutton";
            this.oKbutton.Size = new System.Drawing.Size(75, 23);
            this.oKbutton.TabIndex = 2;
            this.oKbutton.Text = "OK";
            this.oKbutton.UseVisualStyleBackColor = true;
            this.oKbutton.Click += new System.EventHandler(this.oKbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(190, 40);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(283, 72);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.oKbutton);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.nameTextBox);
            this.Name = "RenameForm";
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.Button oKbutton;
        private System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.TextBox nameTextBox;
    }
}