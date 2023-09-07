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
    public class SpecModifierView
    {
        internal ComboBox DescriptionComboBox { get; set; }
        internal ComboBox StandardComboBox { get; set; }
        public ApplicationDbView applicationDbView { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TabControl MainTabControl { get; set; }
        public SQLiteDataAdapter SqliteDa { get; set; }
        public DataSet SqliteDs { get; set; }
        public E3DDataDbView e3DDataDbView { get;  set; }
        public CheckedListBox checkedListBox { get; set; }
        public ComboBox HeadingComboBox { get;  set; }
        public ComboBox MaterialComboBox { get;  set; }
        public ComboBox ComponentComboBox { get;  set; }
        public ComboBox SectionComboBox { get;  set; }
        public TextBox RemarksTextBox { get;  set; }
        public TextBox StypeTextBox { get;  set; }
        public Dictionary<string, string> SpecTableInfo { get; set; }
        public DataTable SizeTable { get; set; }
        public DataTable MaterialTable { get; set; }
        public DataTable DescriptionTable { get; set; }
        public DataTable E3DCataloguesTable { get; set; }
        public DataGridViewRow SelectedDataGridRow { get; set; }
        public Label ElementIdLabel { get; set; }

        public SpecModifierView()
        {
            //this.ElementIdLabel.Text = "New";
        }

        internal void SetUp()
        {
            this.E3DCataloguesTable = this.e3DDataDbView.E3DDataDbContext.getDataSet("SELECT * FROM E3DCatalogues;", "E3DCatalogues").Tables[0];
            this.e3DDataDbView.E3DDataDbContext.SetToDefaultParam();

            var stds = (from r in this.E3DCataloguesTable.AsEnumerable()
                     select r["Standard"]).Distinct().ToList();

            foreach(var std in stds)
            {
                this.StandardComboBox.Items.Add(std.ToString());
            }
        }

        internal void UpdateSpecModifierFormElements()
        {
            try
            {
                string tag = this.SqliteDs.Tables[0].TableName.Replace("Specification", "");
                this.SpecTableInfo = this.applicationDbView.GetSpecTableInfo(tag);
                string SizeTableName = this.SpecTableInfo["SizeTable"];
                string MaterialTableName = this.SpecTableInfo["MaterialTable"];
                string DescriptionTableName = this.SpecTableInfo["DescriptionTable"];
                KeyValuePair<string, string> SizeTableID = this.applicationDbView.getExisitngElements("SizeTableAttribute").FirstOrDefault(x => x.Value == SizeTableName);
                KeyValuePair<string, string> MaterialTableNameID = this.applicationDbView.getExisitngElements("MaterialTableAttribute").FirstOrDefault(x => x.Value == MaterialTableName);
                KeyValuePair<string, string> DescriptionTableNameID = this.applicationDbView.getExisitngElements("DescriptionTableAttribute").FirstOrDefault(x => x.Value == DescriptionTableName);

                string tempTableName = "SizeTable" + SizeTableID.Key;
                this.SizeTable = this.applicationDbView.DbContext.getDataSet("SELECT * FROM " + tempTableName + ";", tempTableName).Tables[0];
                this.applicationDbView.DbContext.SetToDefaultParam();

                tempTableName = "MaterialTable" + MaterialTableNameID.Key;
                this.MaterialTable = this.applicationDbView.DbContext.getDataSet("SELECT * FROM " + tempTableName + ";", tempTableName).Tables[0];
                this.applicationDbView.DbContext.SetToDefaultParam();

                tempTableName = "DescriptionTable" + DescriptionTableNameID.Key;
                this.DescriptionTable = this.applicationDbView.DbContext.getDataSet("SELECT * FROM " + tempTableName + ";", tempTableName).Tables[0];
                this.applicationDbView.DbContext.SetToDefaultParam();

                this.checkedListBox.Items.Clear();
                foreach (DataRow dr in this.SizeTable.Rows)
                {
                    this.checkedListBox.Items.Add(dr["Sizes"].ToString(), false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        internal void EditSpecElement(string standard, string stype, string heading, string section, string descirption, string material, string component, string remarks, string sizes)
        {
            this.SelectedDataGridRow.Cells[1].Value = standard;
            this.SelectedDataGridRow.Cells[2].Value = stype;
            this.SelectedDataGridRow.Cells[3].Value = heading;
            this.SelectedDataGridRow.Cells[4].Value = section;
            this.SelectedDataGridRow.Cells[5].Value = sizes;
            this.SelectedDataGridRow.Cells[6].Value = descirption;
            this.SelectedDataGridRow.Cells[7].Value = material;
            this.SelectedDataGridRow.Cells[8].Value = component;
            this.SelectedDataGridRow.Cells[9].Value = remarks;
        }

        internal void DeleteSpecElement()
        {
            DataGridView dgv = this.SelectedDataGridRow.DataGridView;
            dgv.Rows.Remove(this.SelectedDataGridRow);
        }

        internal void AddSpecElement(string standard, string stype, string heading, string section, string descirption, string material, string component, string remarks, string sizes)
        {
            DataSet ds = this.SqliteDs;
            this.applicationDbView.AddSpecElement(standard, stype, heading, section, descirption, material, component, remarks, sizes, ref ds);
            this.SqliteDs = ds;
            this.SqliteDa.Update(this.SqliteDs.Tables[0]);
        }

        internal void UpdateComboBoxes(string title)
        {
            string std = "";
            string headingString = "";
            string SectionString = "";

            switch (title)
            {
                case "Heading":
                    this.MaterialComboBox.Items.Clear();
                    this.DescriptionComboBox.Items.Clear();
                    this.ComponentComboBox.Items.Clear();
                    this.SectionComboBox.Items.Clear();
                    std = this.StandardComboBox.Text;
                    headingString = this.HeadingComboBox.Text;

                    var sections = (from r in this.E3DCataloguesTable.AsEnumerable()
                                    where r["Standard"].ToString() == std &&
                                    r["Heading"].ToString() == headingString 
                                    select r["Section"]).Distinct().ToList();

                    foreach (var section in sections)
                    {
                        this.SectionComboBox.Items.Add(section.ToString());
                    }
                    break;
                case "Standard":
                    this.MaterialComboBox.Items.Clear();
                    this.DescriptionComboBox.Items.Clear();
                    this.ComponentComboBox.Items.Clear();
                    this.HeadingComboBox.Items.Clear();
                    this.SectionComboBox.Items.Clear();
                    std = this.StandardComboBox.Text;

                    var headings = (from r in this.E3DCataloguesTable.AsEnumerable()
                                    where r["Standard"].ToString() == std
                                    select r["Heading"]).Distinct().ToList();

                    foreach (var heading in headings)
                    {
                        this.HeadingComboBox.Items.Add(heading.ToString());
                    }
                    break;
                case "Section":
                    this.MaterialComboBox.Items.Clear();
                    this.DescriptionComboBox.Items.Clear();
                    this.ComponentComboBox.Items.Clear();
                    SectionString = this.SectionComboBox.Text;
                    std = this.StandardComboBox.Text;
                    headingString = this.HeadingComboBox.Text;

                    var descriptions = (from r in this.E3DCataloguesTable.AsEnumerable()
                                    where r["Standard"].ToString() == std &&
                                    r["Section"].ToString() == SectionString &&
                                    r["Heading"].ToString() == headingString
                                    select r["DescriptionOfCatalogue"]).Distinct().ToList();

                    foreach (var description in descriptions)
                    {
                        this.ComponentComboBox.Items.Add(description.ToString());
                    }

                    var rtexts = (from r in this.DescriptionTable.AsEnumerable()
                                        where r["Heading"].ToString() == headingString
                                        select r["Description"]).Distinct().ToList();

                    foreach (var rtext in rtexts)
                    {
                        this.DescriptionComboBox.Items.Add(rtext.ToString());
                    }

                    var mtxxs = (from r in this.MaterialTable.AsEnumerable()
                                  where r["Heading"].ToString() == headingString
                                  select r["Material"]).Distinct().ToList();

                    foreach (var mtxx in mtxxs)
                    {
                        this.MaterialComboBox.Items.Add(mtxx.ToString());
                    }
                    break;
            }
        }
    }
}
