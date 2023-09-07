using E3D_Spec_Editor.SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor.View
{
    public class ProjectView
    {
        public ApplicationDbView applicationDbView { get; set; }
        public TreeNode specificationNode { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TabControl MainTabControl { get; set; }
        public SpecModifierView specModifierView { get; set; }

        internal void AddNodesInProjectTreeView(ref TreeView projectTreeView)
        {
            this.specificationNode.Text = "Specification";
            projectTreeView.Nodes.Add(this.specificationNode);
        }

        internal void SetUp()
        {
            this.specificationNode = new TreeNode();
        }

        internal void AddExistingNodes()
        {
            this.specificationNode.Nodes.Clear();

            foreach (KeyValuePair<string, string> element in applicationDbView.getExisitngElements("SpecificationsTableAttribute"))
            {
                TreeNode node = new TreeNode();
                node.Tag = Convert.ToInt32(element.Key);
                node.Text = element.Value;
                this.specificationNode.Nodes.Add(node);
            }
        }

        internal void addSpecification()
        {
            TreeNode Specification = new TreeNode();
            Specification.Tag = this.applicationDbView.SpecificationElementID + 1;
            Specification.Text = "Specification" + (this.applicationDbView.SpecificationElementID + 1).ToString();
            this.applicationDbView.AddID("Specification", this.applicationDbView.SpecificationElementID + 1);
            this.specificationNode.Nodes.Add(Specification);
        }

        internal void addTabInMainForm(string Name, string tag, string parent)
        {
            string tableName = applicationDbView.getTableNameFromParent(parent, tag);

            TabPage tabPage = new TabPage();
            tabPage.Text = Name;
            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowDrop = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage.Controls.Add(dataGridView);
            string Query = "SELECT * FROM " + tableName + ";";
            SQLiteCommand command = new SQLiteCommand(Query, this.applicationDbView.DbContext.connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            SQLiteCommandBuilder CmdBuilder = new SQLiteCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            dataGridView.DataSource = ds.Tables[tableName];
            ds.Tables[tableName].AcceptChanges();
            dataGridView.AutoResizeColumns();
            dataGridView.ScrollBars = ScrollBars.Both;

            this.MainTabControl.Controls.Add(tabPage);
            tabPage.Width = 25;

            this.applicationDbView.DbContext.daList.Add(da);
            this.applicationDbView.DbContext.dsList.Add(ds);

            this.specModifierView.SqliteDa = da;
            this.specModifierView.SqliteDs = ds;
            this.specModifierView.UpdateSpecModifierFormElements();

            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
        }

        internal Dictionary<string, string> getSpecTableInfo(string tag)
        {
            Dictionary<string, string> table = this.applicationDbView.GetSpecTableInfo(tag);
            return table;
        }

        internal void UpdateSpecTableInfo(Dictionary<string, string> table)
        {
            this.applicationDbView.UpdateSpecTableInfo(table);
        }

        internal void renameSelectedNode(string Parent, string tag, string newName, string oldName)
        {
            this.applicationDbView.renameSelectedElement(Parent, tag, newName);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow dgvRow = dgv.SelectedRows[0];

                this.specModifierView.StandardComboBox.Text = dgvRow.Cells[1].Value.ToString();
                this.specModifierView.StypeTextBox.Text = dgvRow.Cells[2].Value.ToString();
                this.specModifierView.UpdateComboBoxes("Standard");
                this.specModifierView.HeadingComboBox.Text = dgvRow.Cells[3].Value.ToString();
                this.specModifierView.UpdateComboBoxes("Heading");
                this.specModifierView.SectionComboBox.Text = dgvRow.Cells[4].Value.ToString();
                this.specModifierView.UpdateComboBoxes("Section");
                this.specModifierView.DescriptionComboBox.Text = dgvRow.Cells[6].Value.ToString();
                this.specModifierView.MaterialComboBox.Text = dgvRow.Cells[7].Value.ToString();
                this.specModifierView.ComponentComboBox.Text = dgvRow.Cells[8].Value.ToString();
                this.specModifierView.RemarksTextBox.Text = dgvRow.Cells[9].Value.ToString();

                IEnumerator myEnumerator;
                myEnumerator = this.specModifierView.checkedListBox.CheckedIndices.GetEnumerator();
                int index;

                while (myEnumerator.MoveNext() != false)
                {
                    index = (int)myEnumerator.Current;
                    this.specModifierView.checkedListBox.SetItemChecked(index, false);
                }

                string[] sizes = dgvRow.Cells[5].Value.ToString().Split(',');

                for (int i =0; i < sizes.Length; i++)
                {
                    index = this.specModifierView.checkedListBox.Items.IndexOf(sizes[i]);
                    this.specModifierView.checkedListBox.SetItemChecked(index, true);
                }

                this.specModifierView.SelectedDataGridRow = dgvRow;
                this.specModifierView.ElementIdLabel.Text = dgvRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
