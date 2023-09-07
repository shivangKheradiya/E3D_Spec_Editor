using E3D_Spec_Editor.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor
{
    public partial class SpecModifierForm : Form
    {
        public ProjectView projectView { get; set; }
        public PropertyView propertyView { get; set; }
        public CatalogueView catalogueView { get; set; }
        public ApplicationDbView applicationDbView { get; set; }
        public SpecModifierView specModifierView { get; set; }
        public DataTable propertyDataTable { get; set; }

        public SpecModifierForm()
        {
            InitializeComponent();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            this.StandardComboBox.Text = "";
            this.StypeTextBox.Text = "";
            this.RemarksTextBox.Text = "";
            this.HeadingComboBox.Text = "";
            this.MaterialComboBox.Text = "";
            this.DescriptionComboBox.Text = "";
            this.ComponentComboBox.Text = "";
            this.SectionComboBox.Text = "";

            this.HeadingComboBox.Items.Clear();
            this.MaterialComboBox.Items.Clear();
            this.DescriptionComboBox.Items.Clear();
            this.ComponentComboBox.Items.Clear();
            this.SectionComboBox.Items.Clear();

            this.specModifierView.ElementIdLabel.Text = "New";

            IEnumerator myEnumerator;
            myEnumerator = this.SizeCheckedListBox.CheckedIndices.GetEnumerator();
            int y;
            while (myEnumerator.MoveNext() != false)
            {
                y = (int)myEnumerator.Current;
                this.SizeCheckedListBox.SetItemChecked(y, false); 
            }

        //    }
        //    for (int i = 0; i < this.SizeCheckedListBox.CheckedItems.Count; i++)
        //    {
        //        //this.SizeCheckedListBox.CheckedItems[i];
        //    }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string standard = this.StandardComboBox.Text;
            string stype = this.StypeTextBox.Text;
            string heading = this.HeadingComboBox.Text;
            string section = this.SectionComboBox.Text;
            string descirption = this.DescriptionComboBox.Text;
            string material = this.MaterialComboBox.Text;
            string component = this.ComponentComboBox.Text;
            string remarks = this.RemarksTextBox.Text;

            bool isValid = standard != null && stype != null && heading != null && component != null && section != null;

            bool isNew = this.specModifierView.ElementIdLabel.Text.Contains("New");

            string Sizes = "";
            for (int i = 0; i < this.SizeCheckedListBox.CheckedItems.Count; i++)
            {
                Sizes += this.SizeCheckedListBox.CheckedItems[i].ToString() + ",";
            }

            if (Sizes != "")
            {
                Sizes = Sizes.Substring(0, Sizes.Length - 1);
            }
            
            if (isValid && isNew)
            {
                this.specModifierView.AddSpecElement(standard, stype, heading, section, descirption, material, component, remarks, Sizes);
            }
            else if(isValid && !isNew)
            {
                this.specModifierView.EditSpecElement(standard, stype, heading, section, descirption, material, component, remarks, Sizes);
            }
            else
            {
                MessageBox.Show("Please select required data.");
            }
        }

        private void SpecModifierForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.specModifierView.ElementIdLabel.Text = "New";
        }

        private void HeadingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.specModifierView.UpdateComboBoxes("Heading");
        }

        private void StandardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.specModifierView.UpdateComboBoxes("Standard");
        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.specModifierView.UpdateComboBoxes("Section");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.specModifierView.DeleteSpecElement();
        }
    }
}
