using E3D_Spec_Editor.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor.View
{
    public class CatalogueView
    {
        public TreeNode SizeNode { get; set; }
        public TreeNode DescriptionNode { get; set; }
        public TreeNode MaterialNode { get; set; }
        public ApplicationDbView applicationDbView { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TabControl MainTabControl { get; set; }

        internal void AddNodesInCatalogueTreeView(ref TreeView catalogueTreeView)
        {
            this.SizeNode.Text = "Size";
            this.DescriptionNode.Text = "Description";
            this.MaterialNode.Text = "Material";
            
            catalogueTreeView.Nodes.Add(SizeNode);
            catalogueTreeView.Nodes.Add(DescriptionNode);
            catalogueTreeView.Nodes.Add(MaterialNode);
        }

        internal void addSizeTable()
        {
            TreeNode SizeTable = new TreeNode();
            SizeTable.Tag = this.applicationDbView.SizeElementID + 1;
            SizeTable.Text = "SizeTable" + (this.applicationDbView.SizeElementID + 1).ToString();
            this.applicationDbView.AddID("SizeTable", this.applicationDbView.SizeElementID + 1);
            this.SizeNode.Nodes.Add(SizeTable);
        }

        internal void SetUp()
        {
            this.SizeNode = new TreeNode();
            this.DescriptionNode = new TreeNode();
            this.MaterialNode = new TreeNode();
        }

        internal void AddExistingNodes()
        {
            this.DescriptionNode.Nodes.Clear();
            this.MaterialNode.Nodes.Clear();
            this.SizeNode.Nodes.Clear();

            foreach (KeyValuePair<string, string> element in applicationDbView.getExisitngElements("DescriptionTableAttribute"))
            {
                TreeNode node = new TreeNode();
                node.Tag = Convert.ToInt32(element.Key);
                node.Text = element.Value;
                this.DescriptionNode.Nodes.Add(node);
            }

            foreach (KeyValuePair<string, string> element in applicationDbView.getExisitngElements("MaterialTableAttribute"))
            {
                TreeNode node = new TreeNode();
                node.Tag = Convert.ToInt32(element.Key);
                node.Text = element.Value;
                this.MaterialNode.Nodes.Add(node);
            }

            foreach (KeyValuePair<string, string> element in applicationDbView.getExisitngElements("SizeTableAttribute"))
            {
                TreeNode node = new TreeNode();
                node.Tag = Convert.ToInt32(element.Key);
                node.Text = element.Value;
                this.SizeNode.Nodes.Add(node);
            }
        }

        internal void renameSelectedNode(string Parent, string tag, string newName, string oldName)
        {
            this.applicationDbView.renameSelectedElement(Parent, tag, newName);
            this.applicationDbView.renameSelectedElementReferences(Parent, tag, newName, oldName);
        }

        internal void addTabInMainForm(string Name, string tag, string parent)
        {
            string tableName = applicationDbView.getTableNameFromParent(parent, tag);

            TabPage tabPage = new TabPage();
            tabPage.Text = Name;
            DataGridView dataGridView = new DataGridView();
            tabPage.Controls.Add(dataGridView);
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridView.ScrollBars = ScrollBars.Both;
            string Query = "SELECT * FROM " + tableName + ";";
            SQLiteCommand command = new SQLiteCommand(Query, this.applicationDbView.DbContext.connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            SQLiteCommandBuilder CmdBuilder = new SQLiteCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            dataGridView.DataSource = ds.Tables[tableName];
            ds.Tables[tableName].AcceptChanges();
            this.MainTabControl.Controls.Add(tabPage);
            this.applicationDbView.DbContext.daList.Add(da);
            this.applicationDbView.DbContext.dsList.Add(ds);
        }

        internal void addDescriptionTable()
        {
            TreeNode DescriptionTable = new TreeNode();
            DescriptionTable.Tag = this.applicationDbView.DescriptionElementID + 1;
            DescriptionTable.Text = "DescriptionTable" + (this.applicationDbView.DescriptionElementID + 1).ToString();
            this.applicationDbView.AddID("DescriptionTable", this.applicationDbView.DescriptionElementID + 1);
            this.DescriptionNode.Nodes.Add(DescriptionTable);
        }

        internal void addMaterialTable()
        {
            TreeNode MaterialTable = new TreeNode();
            MaterialTable.Tag = this.applicationDbView.MaterialElementID + 1;
            MaterialTable.Text = "MaterialTable" + (this.applicationDbView.MaterialElementID + 1).ToString();
            this.applicationDbView.AddID("MaterialTable", this.applicationDbView.MaterialElementID + 1);
            this.MaterialNode.Nodes.Add(MaterialTable);
        }
    }
}
