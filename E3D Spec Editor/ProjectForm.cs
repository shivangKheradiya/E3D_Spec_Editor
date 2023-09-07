using E3D_Spec_Editor.EditMenuForms;
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
    public partial class ProjectForm : Form
    {
        public ProjectView projectView { get; set; }
        public PropertyView propertyView { get; set; }
        public CatalogueView catalogueView { get; set; }
        public SpecModifierView specModifierView { get; set; }
        public SpecModifierForm specModifierForm { get; set; }
        public ApplicationDbView applicationDbView { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TreeNode selectedNode { get; set; }

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            projectView.AddNodesInProjectTreeView(ref ProjectTreeView);
            this.ProjectTreeView.MouseDoubleClick += ProjectTreeView_MouseDoubleClick;
            this.ProjectTreeView.NodeMouseClick += ProjectTreeView_NodeMouseClick;
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode.Tag != null)
            {
                this.selectedNode = selectedNode;
                this.applicationDbView.UpdatePropertyView(selectedNode.Parent.Text, selectedNode.Tag);
            }
            else
            {
                this.selectedNode = null;
            }

            if (e.Button == MouseButtons.Right && this.selectedNode != null)
            {
                ContextMenu contextMenu = new ContextMenu();

                MenuItem RenameMenuItem = new MenuItem("&Rename");
                MenuItem PropertyEditMenuItem = new MenuItem("&Edit Property");
                MenuItem RemoveMenuItem = new MenuItem("&Remove");
                
                RenameMenuItem.Click += RenameMenuItem_Click;
                PropertyEditMenuItem.Click += PropertyEditMenuItem_Click;
                RemoveMenuItem.Click += RemoveMenuItem_Click;

                contextMenu.MenuItems.Add(RenameMenuItem);
                contextMenu.MenuItems.Add(PropertyEditMenuItem);
                contextMenu.MenuItems.Add(RemoveMenuItem);

                contextMenu.Show(this, e.Location);
            }
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void PropertyEditMenuItem_Click(object sender, EventArgs e)
        {
            PropertyEditorForm propertyEditorForm = new PropertyEditorForm();
            propertyEditorForm.applicationDbView = this.applicationDbView;
            Dictionary<string, string> table = this.projectView.getSpecTableInfo(this.selectedNode.Tag.ToString());
            propertyEditorForm.SizeComboBox.Text = table["SizeTable"];
            propertyEditorForm.MaterialComboBox.Text = table["MaterialTable"];
            propertyEditorForm.DescriptionComboBox.Text = table["DescriptionTable"];
            bool isValidUpdate = propertyEditorForm.ShowDialog() == DialogResult.OK && propertyEditorForm.SizeComboBox.Text != "" && propertyEditorForm.MaterialComboBox.Text != "" && propertyEditorForm.DescriptionComboBox.Text != "";
            if (isValidUpdate) {
                table["SizeTable"]          = propertyEditorForm.SizeComboBox.Text;
                table["MaterialTable"]      =  propertyEditorForm.MaterialComboBox.Text;
                table["DescriptionTable"]   = propertyEditorForm.DescriptionComboBox.Text;
                this.projectView.UpdateSpecTableInfo(table);
            }
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectedItemRename();
        }

        private void ProjectTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = ((TreeView)sender).SelectedNode;
            if (selectedNode.Tag != null)
            {
                this.applicationDbView.UpdatePropertyView(selectedNode.Parent.Text, selectedNode.Tag);
                this.projectView.addTabInMainForm(selectedNode.Text, selectedNode.Tag.ToString(), selectedNode.Parent.Text);
            }
        }

        internal void SelectedItemRename()
        {
            if (this.selectedNode != null)
            {
                RenameForm renameForm = new RenameForm();
                renameForm.nameTextBox.Text = this.selectedNode.Text;
                if (renameForm.ShowDialog() == DialogResult.OK && this.selectedNode.Text != renameForm.nameTextBox.Text)
                {
                    this.projectView.renameSelectedNode(this.selectedNode.Parent.Text, this.selectedNode.Tag.ToString(), renameForm.nameTextBox.Text, this.selectedNode.Text);
                    this.selectedNode.Text = renameForm.nameTextBox.Text;
                }
            }
        }
    }
}
