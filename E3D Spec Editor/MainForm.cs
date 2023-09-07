using E3D_Spec_Editor.EditMenuForms;
using E3D_Spec_Editor.SQLite;
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
    public partial class MainForm : Form
    {
        public SQLiteDbContext ApplicationDbContext { get; set; }
        private CatalogueForm catalogueForm { get; set; }
        private PropertyForm propertyForm { get; set; }
        private ProjectForm projectForm { get; set; }
        private ProjectView projectView { get; set; }
        private PropertyView propertyView { get; set; }
        private CatalogueView catalogueView { get; set; }
        private ApplicationDbView applicationDbView { get; set; }
        private E3DDataDbView e3DDataDbView { get; set; }
        private SpecModifierView specModifierView { get; set; }
        public SpecModifierForm specModifierForm { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TabControl MainTabControl { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Save and Exit ?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < this.ApplicationDbContext.daList.Count; i++)
                {
                    this.ApplicationDbContext.daList[i].Update(this.ApplicationDbContext.dsList[i].Tables[0]);
                }

                this.ApplicationDbContext.CommitTransection();
                this.ApplicationDbContext.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.ApplicationDbContext.RollBackTransection();
                this.ApplicationDbContext.Exit();
            }

            this.e3DDataDbView.E3DDataDbContext.Exit();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.projectForm                            = new ProjectForm();
            this.catalogueForm                          = new CatalogueForm();
            this.propertyForm                           = new PropertyForm();
            this.propertyView                           = new PropertyView();
            this.projectView                            = new ProjectView();
            this.catalogueView                          = new CatalogueView();
            this.applicationDbView                      = new ApplicationDbView();
            this.specModifierForm                       = new SpecModifierForm();
            this.specModifierView                       = new SpecModifierView();
            this.ApplicationDbContext                   = new SQLiteDbContext();
            this.propertyDataTable                      = new DataTable();
            this.e3DDataDbView                          = new E3DDataDbView();

            this.MainTabControl                         = this.MainFormTabControler;

            this.applicationDbView.DbContext            = this.ApplicationDbContext;
            this.applicationDbView.propertyDataTable    = this.propertyDataTable;

            this.projectForm.catalogueView              = this.catalogueView;
            this.projectForm.projectView                = this.projectView;
            this.projectForm.propertyView               = this.propertyView;
            this.projectForm.applicationDbView          = this.applicationDbView;
            this.projectForm.specModifierView           = this.specModifierView;
            this.projectForm.specModifierForm           = this.specModifierForm;

            this.catalogueForm.catalogueView            = this.catalogueView;
            this.catalogueForm.projectView              = this.projectView;
            this.catalogueForm.propertyView             = this.propertyView;
            this.catalogueForm.applicationDbView        = this.applicationDbView;
            this.catalogueForm.specModifierView         = this.specModifierView;

            this.propertyForm.catalogueView             = this.catalogueView;
            this.propertyForm.projectView               = this.projectView;
            this.propertyForm.propertyView              = this.propertyView;
            this.propertyForm.applicationDbView         = this.applicationDbView;
            this.propertyForm.specModifierView          = this.specModifierView;

            this.specModifierForm.catalogueView         = this.catalogueView;
            this.specModifierForm.projectView           = this.projectView;
            this.specModifierForm.propertyView          = this.propertyView;
            this.specModifierForm.applicationDbView     = this.applicationDbView;
            this.specModifierForm.specModifierView      = this.specModifierView;

            this.catalogueView.applicationDbView        = this.applicationDbView;
            this.projectView.applicationDbView          = this.applicationDbView;
            this.projectView.specModifierView           = this.specModifierView;
            this.propertyView.applicationDbView         = this.applicationDbView;
            this.specModifierView.applicationDbView     = this.applicationDbView;

            this.catalogueView.propertyDataTable        = this.propertyDataTable;
            this.projectView.propertyDataTable          = this.propertyDataTable;
            this.propertyView.propertyDataTable         = this.propertyDataTable;
            this.specModifierView.propertyDataTable     = this.propertyDataTable;

            this.catalogueView.MainTabControl           = this.MainTabControl;
            this.projectView.MainTabControl             = this.MainTabControl;
            this.propertyView.MainTabControl            = this.MainTabControl;
            this.specModifierView.MainTabControl        = this.MainTabControl;
            this.specModifierView.e3DDataDbView         = this.e3DDataDbView;

            this.specModifierView.checkedListBox        = this.specModifierForm.SizeCheckedListBox;
            this.specModifierView.HeadingComboBox       = this.specModifierForm.HeadingComboBox;
            this.specModifierView.DescriptionComboBox   = this.specModifierForm.DescriptionComboBox;
            this.specModifierView.StandardComboBox      = this.specModifierForm.StandardComboBox;
            this.specModifierView.MaterialComboBox      = this.specModifierForm.MaterialComboBox;
            this.specModifierView.ComponentComboBox     = this.specModifierForm.ComponentComboBox;
            this.specModifierView.RemarksTextBox        = this.specModifierForm.RemarksTextBox;
            this.specModifierView.StypeTextBox          = this.specModifierForm.StypeTextBox;
            this.specModifierView.SectionComboBox       = this.specModifierForm.SectionComboBox;
            this.specModifierView.ElementIdLabel        = this.specModifierForm.ElementIdLabel;

            this.catalogueView.SetUp();
            this.specModifierView.SetUp();
            this.propertyView.SetUp();
            this.projectView.SetUp();

            this.propertyDataTable.Columns.Add("Attribute");
            this.propertyDataTable.Columns.Add("Value");

            this.MainFormTabControler.DrawMode          = TabDrawMode.OwnerDrawFixed;
            this.MainTabControl.SizeMode                = TabSizeMode.Fixed;
            this.MainFormTabControler.ItemSize          = new Size(150, 25);
            this.MainTabControl.MouseDown              += MainTabControl_MouseDown;
            this.MainTabControl.DrawItem               += MainTabControl_DrawItem;
            this.MainTabControl.Selecting              += MainTabControl_Selecting;
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = this.MainTabControl.SelectedIndex;
            if (index != -1)
            {
                DataTable dt = this.applicationDbView.DbContext.dsList[index].Tables[0];

                bool isSpecTable = dt.TableName.Contains("Specification");
                bool isDescriptionTable = dt.TableName.Contains("DescriptionTable");
                bool MaterialTable = dt.TableName.Contains("MaterialTable");
                bool SizeTableTable = dt.TableName.Contains("SizeTable");

                if (isSpecTable)
                {
                    this.specModifierView.SqliteDa = this.ApplicationDbContext.daList[this.MainTabControl.SelectedIndex];
                    this.specModifierView.SqliteDs = this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex];
                    this.specModifierView.UpdateSpecModifierFormElements();
                    this.applicationDbView.UpdatePropertyView("Specification", this.specModifierView.SqliteDs.Tables[0].TableName.Replace("Specification", ""));
                }
                else if (isDescriptionTable)
                {
                    this.applicationDbView.UpdatePropertyView("Description", this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex].Tables[0].TableName.Replace("DescriptionTable", ""));
                }
                else if (MaterialTable)
                {
                    this.applicationDbView.UpdatePropertyView("Material", this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex].Tables[0].TableName.Replace("MaterialTable", ""));
                }
                else if (SizeTableTable)
                {
                    this.applicationDbView.UpdatePropertyView("Size", this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex].Tables[0].TableName.Replace("SizeTable", ""));
                }
            }
        }

        private void MainTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage thisTab = this.MainTabControl.TabPages[e.Index];
            string tabTitle = thisTab.Text;
            //Image icon = imageList1.Images[thisTab.ImageIndex];
            //Draw Close button
            Point closeLoc = new Point(15, 5);
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.Right - closeLoc.X, e.Bounds.Top + closeLoc.Y, 10, 12);
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds.Right - closeLoc.X, e.Bounds.Top + closeLoc.Y, 10, 12);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - (closeLoc.X), e.Bounds.Top + closeLoc.Y - 2);
            // Draw String of Caption
            e.Graphics.DrawString(tabTitle, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 4);
            // Add Icon to Front
            //e.Graphics.DrawImage(icon, e.Bounds.Left + 6, e.Bounds.Top + 3);
            e.DrawFocusRectangle();
        }

        private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            Point closeLoc = new Point(15, 5);
            Rectangle r = this.MainTabControl.GetTabRect(this.MainTabControl.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - closeLoc.X, r.Top + closeLoc.Y, 10, 12);
            if (closeButton.Contains(e.Location))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save the changes in the table?", "Save", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.ApplicationDbContext.daList[this.MainTabControl.SelectedIndex].Update(this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex].Tables[0]);
                }

                this.ApplicationDbContext.dsList[this.MainTabControl.SelectedIndex].Dispose();
                this.ApplicationDbContext.daList[this.MainTabControl.SelectedIndex].Dispose();

                this.ApplicationDbContext.dsList.RemoveAt(this.MainTabControl.SelectedIndex);
                this.ApplicationDbContext.daList.RemoveAt(this.MainTabControl.SelectedIndex);

                this.MainTabControl.TabPages.Remove(this.MainTabControl.SelectedTab);

                return; // Don't keep running logic in method
            }
            //for (int i = 0; i < this.MainTabControl.TabCount; i++)
            //{
            //    r = this.MainTabControl.GetTabRect(i);
            //    if (r.Contains(e.Location) && e.Button == MouseButtons.Middle)
            //    {
            //        this.MainTabControl.TabPages.RemoveAt(i);
            //        this.ApplicationDbContext.dsList.RemoveAt(i);
            //        this.ApplicationDbContext.daList.RemoveAt(i);
            //    }
            //}
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Db files (*.db)|*.db";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.ApplicationDbContext.DbFilePath = saveFileDialog.FileName;
                    this.ApplicationDbContext.Setup();
                    this.applicationDbView.DbContext = this.ApplicationDbContext;
                    this.Text = "E3D Spec Editor ( " + this.ApplicationDbContext.DbFilePath + " )";
                    this.applicationDbView.CreateValidDbs();
                    this.applicationDbView.SetID();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Db files (*.db)|*.db";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (this.ApplicationDbContext.DbFilePath != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save the work ?", "Save", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.ApplicationDbContext.CommitTransection();
                        this.ApplicationDbContext.Exit();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.ApplicationDbContext.RollBackTransection();
                        this.ApplicationDbContext.Exit();
                    }
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.ApplicationDbContext.DbFilePath = openFileDialog.FileName;
                    this.ApplicationDbContext.Setup();
                    this.applicationDbView.DbContext = this.ApplicationDbContext;
                    if (this.applicationDbView.IsValidDb())
                    {
                        this.Text = "E3D Spec Editor ( " + this.ApplicationDbContext.DbFilePath + " )";
                        this.applicationDbView.SetID();
                        this.catalogueView.AddExistingNodes();
                        this.projectView.AddExistingNodes();
                        this.applicationDbView.DbContext.BeginTransection();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Correct Project File.");
                        this.ApplicationDbContext.Exit();
                    }
                }
            }
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            if (menuitem.Checked == false)
            {
                menuitem.Checked = true;
                this.propertyForm.Show();
            }
            else
            {
                menuitem.Checked = false;
                this.propertyForm.Hide();
            }
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            if (menuitem.Checked == false)
            {
                menuitem.Checked = true;
                this.catalogueForm.Show();
            }
            else
            {
                menuitem.Checked = false;
                this.catalogueForm.Hide();
            }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            if (menuitem.Checked == false)
            {
                menuitem.Checked = true;
                this.projectForm.Show();
            }
            else
            {
                menuitem.Checked = false;
                this.projectForm.Hide();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < this.ApplicationDbContext.daList.Count; i++)
                {
                    this.ApplicationDbContext.daList[i].Update(this.ApplicationDbContext.dsList[i].Tables[0]);
                }

                this.ApplicationDbContext.CommitTransection();
                this.ApplicationDbContext.BeginTransection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ApplicationDbContext.RollBackTransection();
        }

        private void sizeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.catalogueView.addSizeTable();
        }

        private void descriptionTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.catalogueView.addDescriptionTable();
        }

        private void materialTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.catalogueView.addMaterialTable();
        }

        private void specificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.projectView.addSpecification();
        }

        private void specModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            if (menuitem.Checked == false)
            {
                menuitem.Checked = true;
                this.specModifierForm.Show();
            }
            else
            {
                menuitem.Checked = false;
                this.specModifierForm.Hide();
            }
        }
    }
}
