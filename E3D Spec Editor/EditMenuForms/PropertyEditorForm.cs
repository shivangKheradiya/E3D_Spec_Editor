using E3D_Spec_Editor.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor.EditMenuForms
{
    public partial class PropertyEditorForm : Form
    {
        public ApplicationDbView applicationDbView { get; set; }

        public PropertyEditorForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PropertyEditorForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> entity = this.applicationDbView.getExisitngElements("DescriptionTableAttribute");
            foreach(KeyValuePair<string,string> kv in entity)
            {
                this.DescriptionComboBox.Items.Add(kv.Value);
            }
            
            entity = this.applicationDbView.getExisitngElements("MaterialTableAttribute");
            foreach (KeyValuePair<string, string> kv in entity)
            {
                this.MaterialComboBox.Items.Add(kv.Value);
            }
            
            entity = this.applicationDbView.getExisitngElements("SizeTableAttribute");
            foreach (KeyValuePair<string, string> kv in entity)
            {
                this.SizeComboBox.Items.Add(kv.Value);
            }
        }
    }
}
