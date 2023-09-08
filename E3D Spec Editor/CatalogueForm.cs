using E3D_Spec_Editor.EditMenuForms;
using E3D_Spec_Editor.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor
{
    public partial class CatalogueForm : Form
    {
        public ProjectView projectView { get; set; }
        public PropertyView propertyView { get; set; }
        public CatalogueView catalogueView { get; set; }
        public SpecModifierView specModifierView { get; set; }
        public ApplicationDbView applicationDbView { get; set; }
        public TreeNode selectedNode { get; set; }
        
        public CatalogueForm()
        {
            InitializeComponent();
        }

        private void CatalogueForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            catalogueView.AddNodesInCatalogueTreeView(ref CatalogueTreeView);
            this.CatalogueTreeView.MouseDoubleClick += CatalogueTreeView_MouseDoubleClick;
            this.CatalogueTreeView.NodeMouseClick += CatalogueTreeView_NodeMouseClick;
        }

        private void CatalogueTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
                MenuItem DeleteMenuItem = new MenuItem("&Delete");

                RenameMenuItem.Click += RenameMenuItem_Click;
                DeleteMenuItem.Click += DeleteMenuItem_Click;

                contextMenu.MenuItems.Add(RenameMenuItem);
                contextMenu.MenuItems.Add(DeleteMenuItem);

                contextMenu.Show(this, e.Location);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure, you want to delete ?", "Delete Specification", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.applicationDbView.DeleteTable(this.selectedNode.Parent.Text, selectedNode.Tag.ToString());
                this.selectedNode.Remove();
            }
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectedItemRename();
        }

        private void CatalogueTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = ((TreeView)sender).SelectedNode;
            if (selectedNode.Tag != null)
            {
                this.applicationDbView.UpdatePropertyView(selectedNode.Parent.Text, selectedNode.Tag);
                this.catalogueView.addTabInMainForm(selectedNode.Text, selectedNode.Tag.ToString(), selectedNode.Parent.Text);
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
                    this.catalogueView.renameSelectedNode(this.selectedNode.Parent.Text, this.selectedNode.Tag.ToString(), renameForm.nameTextBox.Text, this.selectedNode.Text);
                    this.selectedNode.Text = renameForm.nameTextBox.Text;
                }

            }
        }
    }
}
