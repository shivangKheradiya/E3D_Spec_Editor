
namespace E3D_Spec_Editor
{
    partial class SpecModifierForm
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
            this.StypeTextBox = new System.Windows.Forms.TextBox();
            this.StypeLable = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.StandardLabel = new System.Windows.Forms.Label();
            this.StandardComboBox = new System.Windows.Forms.ComboBox();
            this.HeadingComboBox = new System.Windows.Forms.ComboBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SizeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.RemarksLabel = new System.Windows.Forms.Label();
            this.RemarksTextBox = new System.Windows.Forms.TextBox();
            this.ComponentLabel = new System.Windows.Forms.Label();
            this.MaterialLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.MaterialComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionComboBox = new System.Windows.Forms.ComboBox();
            this.SectionLabel = new System.Windows.Forms.Label();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.ComponentComboBox = new System.Windows.Forms.ComboBox();
            this.ElementIdLabel = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StypeTextBox
            // 
            this.StypeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StypeTextBox.Location = new System.Drawing.Point(80, 33);
            this.StypeTextBox.Name = "StypeTextBox";
            this.StypeTextBox.Size = new System.Drawing.Size(185, 20);
            this.StypeTextBox.TabIndex = 2;
            // 
            // StypeLable
            // 
            this.StypeLable.AutoSize = true;
            this.StypeLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StypeLable.Location = new System.Drawing.Point(3, 33);
            this.StypeLable.Margin = new System.Windows.Forms.Padding(3);
            this.StypeLable.Name = "StypeLable";
            this.StypeLable.Size = new System.Drawing.Size(61, 24);
            this.StypeLable.TabIndex = 1;
            this.StypeLable.Text = "Stype";
            this.StypeLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplyButton
            // 
            this.ApplyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplyButton.Location = new System.Drawing.Point(159, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(150, 24);
            this.ApplyButton.TabIndex = 5;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // StandardLabel
            // 
            this.StandardLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandardLabel.Location = new System.Drawing.Point(3, 3);
            this.StandardLabel.Margin = new System.Windows.Forms.Padding(3);
            this.StandardLabel.Name = "StandardLabel";
            this.StandardLabel.Size = new System.Drawing.Size(61, 24);
            this.StandardLabel.TabIndex = 7;
            this.StandardLabel.Text = "Standard";
            this.StandardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StandardComboBox
            // 
            this.StandardComboBox.FormattingEnabled = true;
            this.StandardComboBox.Location = new System.Drawing.Point(80, 3);
            this.StandardComboBox.Name = "StandardComboBox";
            this.StandardComboBox.Size = new System.Drawing.Size(185, 21);
            this.StandardComboBox.TabIndex = 0;
            this.StandardComboBox.SelectedIndexChanged += new System.EventHandler(this.StandardComboBox_SelectedIndexChanged);
            // 
            // HeadingComboBox
            // 
            this.HeadingComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingComboBox.FormattingEnabled = true;
            this.HeadingComboBox.Location = new System.Drawing.Point(80, 63);
            this.HeadingComboBox.Name = "HeadingComboBox";
            this.HeadingComboBox.Size = new System.Drawing.Size(185, 21);
            this.HeadingComboBox.TabIndex = 10;
            this.HeadingComboBox.SelectedIndexChanged += new System.EventHandler(this.HeadingComboBox_SelectedIndexChanged);
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingLabel.Location = new System.Drawing.Point(3, 63);
            this.HeadingLabel.Margin = new System.Windows.Forms.Padding(3);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(61, 24);
            this.HeadingLabel.TabIndex = 9;
            this.HeadingLabel.Text = "Heading";
            this.HeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.StandardLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SizeCheckedListBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.StandardComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SizeLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.StypeTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeadingLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.HeadingComboBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.StypeLable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RemarksLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.RemarksTextBox, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.ComponentLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.MaterialLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.MaterialComboBox, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionComboBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.SectionLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SectionComboBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ComponentComboBox, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.ElementIdLabel, 4, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 269);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // SizeCheckedListBox
            // 
            this.SizeCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeCheckedListBox.FormattingEnabled = true;
            this.SizeCheckedListBox.Location = new System.Drawing.Point(281, 33);
            this.SizeCheckedListBox.Name = "SizeCheckedListBox";
            this.tableLayoutPanel1.SetRowSpan(this.SizeCheckedListBox, 6);
            this.SizeCheckedListBox.Size = new System.Drawing.Size(184, 174);
            this.SizeCheckedListBox.TabIndex = 13;
            // 
            // SizeLabel
            // 
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeLabel.Location = new System.Drawing.Point(281, 3);
            this.SizeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(184, 24);
            this.SizeLabel.TabIndex = 11;
            this.SizeLabel.Text = "Size";
            this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RemarksLabel
            // 
            this.RemarksLabel.Location = new System.Drawing.Point(3, 213);
            this.RemarksLabel.Margin = new System.Windows.Forms.Padding(3);
            this.RemarksLabel.Name = "RemarksLabel";
            this.RemarksLabel.Size = new System.Drawing.Size(61, 13);
            this.RemarksLabel.TabIndex = 17;
            this.RemarksLabel.Text = "Remarks";
            this.RemarksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemarksTextBox
            // 
            this.RemarksTextBox.Location = new System.Drawing.Point(80, 213);
            this.RemarksTextBox.Name = "RemarksTextBox";
            this.RemarksTextBox.Size = new System.Drawing.Size(185, 20);
            this.RemarksTextBox.TabIndex = 21;
            // 
            // ComponentLabel
            // 
            this.ComponentLabel.AutoSize = true;
            this.ComponentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComponentLabel.Location = new System.Drawing.Point(3, 183);
            this.ComponentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ComponentLabel.Name = "ComponentLabel";
            this.ComponentLabel.Size = new System.Drawing.Size(61, 24);
            this.ComponentLabel.TabIndex = 16;
            this.ComponentLabel.Text = "Component";
            this.ComponentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialLabel.Location = new System.Drawing.Point(3, 153);
            this.MaterialLabel.Margin = new System.Windows.Forms.Padding(3);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(61, 24);
            this.MaterialLabel.TabIndex = 15;
            this.MaterialLabel.Text = "Material";
            this.MaterialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 123);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(61, 24);
            this.DescriptionLabel.TabIndex = 14;
            this.DescriptionLabel.Text = "Description";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaterialComboBox
            // 
            this.MaterialComboBox.FormattingEnabled = true;
            this.MaterialComboBox.Location = new System.Drawing.Point(80, 153);
            this.MaterialComboBox.Name = "MaterialComboBox";
            this.MaterialComboBox.Size = new System.Drawing.Size(185, 21);
            this.MaterialComboBox.TabIndex = 12;
            // 
            // DescriptionComboBox
            // 
            this.DescriptionComboBox.FormattingEnabled = true;
            this.DescriptionComboBox.Location = new System.Drawing.Point(80, 123);
            this.DescriptionComboBox.Name = "DescriptionComboBox";
            this.DescriptionComboBox.Size = new System.Drawing.Size(185, 21);
            this.DescriptionComboBox.TabIndex = 11;
            // 
            // SectionLabel
            // 
            this.SectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionLabel.Location = new System.Drawing.Point(3, 93);
            this.SectionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SectionLabel.Name = "SectionLabel";
            this.SectionLabel.Size = new System.Drawing.Size(61, 24);
            this.SectionLabel.TabIndex = 22;
            this.SectionLabel.Text = "Section";
            this.SectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Location = new System.Drawing.Point(80, 93);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(185, 21);
            this.SectionComboBox.TabIndex = 23;
            this.SectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SectionComboBox_SelectedIndexChanged);
            // 
            // ComponentComboBox
            // 
            this.ComponentComboBox.FormattingEnabled = true;
            this.ComponentComboBox.Location = new System.Drawing.Point(80, 183);
            this.ComponentComboBox.Name = "ComponentComboBox";
            this.ComponentComboBox.Size = new System.Drawing.Size(185, 21);
            this.ComponentComboBox.TabIndex = 20;
            // 
            // ElementIdLabel
            // 
            this.ElementIdLabel.AutoSize = true;
            this.ElementIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElementIdLabel.Location = new System.Drawing.Point(281, 210);
            this.ElementIdLabel.Name = "ElementIdLabel";
            this.ElementIdLabel.Size = new System.Drawing.Size(184, 59);
            this.ElementIdLabel.TabIndex = 24;
            this.ElementIdLabel.Text = "ElementID";
            this.ElementIdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NewButton
            // 
            this.NewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewButton.Location = new System.Drawing.Point(3, 3);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(150, 24);
            this.NewButton.TabIndex = 3;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.NewButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ApplyButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 239);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(468, 30);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteButton.Location = new System.Drawing.Point(315, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(150, 24);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SpecModifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 269);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SpecModifierForm";
            this.Text = "Specification Modifier Form";
            this.Load += new System.EventHandler(this.SpecModifierForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label StypeLable;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label StandardLabel;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label MaterialLabel;
        private System.Windows.Forms.Label ComponentLabel;
        private System.Windows.Forms.Label RemarksLabel;
        public System.Windows.Forms.CheckedListBox SizeCheckedListBox;
        public System.Windows.Forms.TextBox StypeTextBox;
        public System.Windows.Forms.ComboBox HeadingComboBox;
        public System.Windows.Forms.ComboBox DescriptionComboBox;
        public System.Windows.Forms.ComboBox MaterialComboBox;
        public System.Windows.Forms.ComboBox ComponentComboBox;
        public System.Windows.Forms.TextBox RemarksTextBox;
        public System.Windows.Forms.ComboBox StandardComboBox;
        private System.Windows.Forms.Label SectionLabel;
        public System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.Label ElementIdLabel;
    }
}