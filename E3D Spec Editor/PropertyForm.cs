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

namespace E3D_Spec_Editor
{
    public partial class PropertyForm : Form
    {
        public ProjectView projectView { get; set; }
        public PropertyView propertyView { get; set; }
        public CatalogueView catalogueView { get; set; }
        public SpecModifierView specModifierView { get; set; }
        public ApplicationDbView applicationDbView { get; set; }

        public PropertyForm()
        {
            InitializeComponent();
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.PropertyDataGridView.DataSource = propertyView.propertyBindingSource;
        }
    }
}
