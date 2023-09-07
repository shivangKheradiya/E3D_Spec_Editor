using E3D_Spec_Editor.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3D_Spec_Editor.View
{
    public class ApplicationDbView
    {
        public DataTable propertyDataTable { get; set; }
        public SQLiteDbContext DbContext { get; set; }
        public int SpecificationElementID { get; set; }
        public int SizeElementID { get; set; }
        public int MaterialElementID { get; set; }
        public int DescriptionElementID { get; set; }

        internal bool IsValidDb()
        {
            bool isValid = false;
            DataSet ds = this.DbContext.getDataSet("SELECT name FROM sqlite_master WHERE type='table' and name='E3D_Spec_Editor' ORDER BY 1;", "sqlite_master");
            this.DbContext.SetToDefaultParam();

            if ( ds.Tables["sqlite_master"].Rows.Count == 1 )
            {
                isValid = true;
            }
            return isValid;
        }

        internal void CreateValidDbs()
        {
            List<string> Queries = new List<string>();
            Queries.Add("CREATE TABLE E3D_Spec_Editor ( " +
                "Attribute TEXT NOT NULL," +
                "Value TEXT," +
                "PRIMARY KEY(Attribute)" +
                "); ");

            Queries.Add("CREATE TABLE SizeTableAttribute ( " +
                "ReferenceNo   TEXT NOT NULL, " +
                "Name TEXT UNIQUE, " +
                "PRIMARY KEY(ReferenceNo) " +
                "); ");

            Queries.Add("CREATE TABLE DescriptionTableAttribute ( " +
                "ReferenceNo   TEXT NOT NULL, " +
                "Name TEXT UNIQUE, " +
                "PRIMARY KEY(ReferenceNo) " +
                "); ");

            Queries.Add("CREATE TABLE MaterialTableAttribute ( " +
                "ReferenceNo   TEXT NOT NULL, " +
                "Name TEXT UNIQUE, " +
                "PRIMARY KEY(ReferenceNo) " +
                "); ");

            Queries.Add("CREATE TABLE SpecificationsTableAttribute ( " +
                "ReferenceNo   TEXT NOT NULL, " +
                "Name TEXT UNIQUE, " +
                "SizeTable TEXT, " +
                "MaterialTable TEXT, " +
                "DescriptionTable TEXT, " +
                "PRIMARY KEY(ReferenceNo) " +
                "); ");

            Queries.Add("INSERT INTO E3D_Spec_Editor ( Attribute , Value) VALUES ('SpecificationElementID' , '0');");
            Queries.Add("INSERT INTO E3D_Spec_Editor ( Attribute , Value) VALUES ('SizeElementID' , '0');");
            Queries.Add("INSERT INTO E3D_Spec_Editor ( Attribute , Value) VALUES ('MaterialElementID' , '0');");
            Queries.Add("INSERT INTO E3D_Spec_Editor ( Attribute , Value) VALUES ('DescriptionElementID' , '0');");

            this.DbContext.BeginTransection();
            for (int i = 0; i < Queries.Count; i++)
            {
                this.DbContext.ExecuteQuery(Queries[i]);
            }

            this.DbContext.CommitTransection();
            this.DbContext.BeginTransection();
        }

        internal void renameSelectedElement(string parent, string ID, string newName)
        {
            string tableName = "";
            string Query = "";
            switch (parent)
            {
                case "Size":
                    tableName = "SizeTableAttribute";
                    Query = "UPDATE " + tableName +" SET Name ='" + newName + "' WHERE ReferenceNo ='"+ ID +"' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Material":
                    tableName = "MaterialTableAttribute";
                    Query = "UPDATE " + tableName + " SET Name ='" + newName + "' WHERE ReferenceNo ='" + ID + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Description":
                    tableName = "DescriptionTableAttribute";
                    Query = "UPDATE " + tableName + " SET Name ='" + newName + "' WHERE ReferenceNo ='" + ID + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Specification":
                    tableName = "SpecificationsTableAttribute";
                    Query = "UPDATE " + tableName + " SET Name ='" + newName + "' WHERE ReferenceNo ='" + ID + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                default:
                    break;
            }
        }

        internal void AddSpecElement(string standard, string stype, string heading, string section, string descirption, string material, string component, string remarks, string sizes, ref DataSet ds)
        {
            object[] rowArray = new object[10];

            if ( ds.Tables[0].Rows.Count == 0)
            {
                rowArray[0] = "0";
            }
            else
            {
                rowArray[0] = Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0]) + 1;
            }

            rowArray[1] = standard;
            rowArray[2] = stype;
            rowArray[3] = heading;
            rowArray[4] = section;
            rowArray[5] = sizes;
            rowArray[6] = descirption;
            rowArray[7] = material;
            rowArray[8] = component;
            rowArray[9] = remarks;

            DataRow dr = ds.Tables[0].NewRow();
            dr.ItemArray = rowArray;

            ds.Tables[0].Rows.Add(dr);
        }

        internal void renameSelectedElementReferences(string parent, string tag, string newName, string oldName)
        {
            string Query = "";
            switch (parent)
            {
                case "Size":
                    Query = "UPDATE SpecificationsTableAttribute SET SizeTable ='" + newName + "' WHERE SizeTable='" + oldName + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Material":
                    Query = "UPDATE SpecificationsTableAttribute SET MaterialTable ='" + newName + "' WHERE MaterialTable ='" + oldName + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Description":
                    Query = "UPDATE SpecificationsTableAttribute SET DescriptionTable ='" + newName + "' WHERE DescriptionTable ='" + oldName + "' ;";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                default:
                    break;
            }
        }

        internal void UpdateSpecTableInfo(Dictionary<string, string> table)
        {
            string tableName = "";
            string Query = "";
            tableName = "SpecificationsTableAttribute";
            Query = "UPDATE " + tableName + 
                    " SET SizeTable ='" + table["SizeTable"] + "' ," +
                    "MaterialTable ='" + table["MaterialTable"]+ "' ," +
                    "DescriptionTable ='" + table["DescriptionTable"] + "' WHERE ReferenceNo ='" + table["ReferenceNo"] + "' ;";
            this.DbContext.ExecuteQuery(Query);
        }

        internal Dictionary<string, string> GetSpecTableInfo(string tag)
        {
            string TableName = "SpecificationsTableAttribute";
            DataSet ds = this.DbContext.getDataSet("SELECT * FROM SpecificationsTableAttribute where ReferenceNo='" + tag + "';", "SpecificationsTableAttribute");
            this.DbContext.SetToDefaultParam();
            List<string> ColumnNames = new List<string>();
            Dictionary<string, string> tables = new Dictionary<string, string>();

            foreach (DataColumn dc in ds.Tables[TableName].Columns)
            {
                ColumnNames.Add(dc.ColumnName);
            }

            for (int i = 0; i < ColumnNames.Count; i++)
            {
                tables.Add(ColumnNames[i], ds.Tables[TableName].Rows[0][ColumnNames[i]].ToString());
            }
            return tables;
        }

        internal string getTableNameFromParent(string parent, string ID)
        { 
            string tableName = "";
            switch (parent)
            {
                case "Size":
                    tableName = "SizeTable" + ID;
                    break;
                case "Material":
                    tableName = "MaterialTable" + ID;
                    break;
                case "Description":
                    tableName = "DescriptionTable" + ID;
                    break;
                case "Specification":
                    tableName = "Specification" + ID;
                    break;
                default:
                    break;
            }
            return tableName;
        }

        internal void UpdatePropertyView(string Parent, object Key)
        {
            switch (Parent)
            {
                case "Size":
                    this.updatePropertyDataTable("SizeTableAttribute", Key.ToString());
                    break;
                case "Description":
                    this.updatePropertyDataTable("DescriptionTableAttribute", Key.ToString());
                    break;
                case "Material":
                    this.updatePropertyDataTable("MaterialTableAttribute", Key.ToString());
                    break;
                case "Specification":
                    this.updatePropertyDataTable("SpecificationsTableAttribute", Key.ToString());
                    break;
                default:
                    break;
            }
        }

        private void updatePropertyDataTable(string TableName, string ReferenceNo)
        {
            string Query;
            this.propertyDataTable.Rows.Clear();
            List<string> ColumnNames = new List<string>();
            Query = "SELECT * FROM "+ TableName + " where ReferenceNo='" + ReferenceNo + "';";
            DataSet ds = this.DbContext.getDataSet(Query, TableName);
            this.DbContext.SetToDefaultParam();
            foreach (DataColumn dc in ds.Tables[TableName].Columns)
            {
                ColumnNames.Add(dc.ColumnName);
            }

            foreach (DataRow dr in ds.Tables[TableName].Rows)
            {
                for (int i = 0; i < ColumnNames.Count; i++)
                {
                    DataRow dataRow = this.propertyDataTable.NewRow();
                    dataRow["Attribute"] = ColumnNames[i];
                    dataRow["Value"] = dr[ColumnNames[i]].ToString();
                    this.propertyDataTable.Rows.Add(dataRow);
                }
            }
        }

        internal Dictionary<string, string> getExisitngElements(string TableName)
        {
            Dictionary<string, string> Elements = new Dictionary<string, string>();
            DataSet ds = this.DbContext.getDataSet("SELECT * FROM "+ TableName +";", TableName);
            this.DbContext.SetToDefaultParam();
            foreach (DataRow dr in ds.Tables[TableName].Rows)
            {
                Elements.Add(dr["ReferenceNo"].ToString(), dr["Name"].ToString());
            }
            return Elements;
        }

        internal void AddID(string AttributeString, int Id)
        {
            string Query;
            switch (AttributeString)
            {
                case "SizeTable":
                    Query = "UPDATE E3D_Spec_Editor SET Value ='" + Id.ToString() + "' WHERE Attribute ='SizeElementID' ;";
                    this.DbContext.ExecuteQuery(Query);
                    this.SizeElementID = Id;
                    this.CreateTable(AttributeString);
                    break;
                case "DescriptionTable":
                    Query = "UPDATE E3D_Spec_Editor SET Value ='" + Id.ToString() + "' WHERE Attribute ='DescriptionElementID' ;";
                    this.DbContext.ExecuteQuery(Query);
                    this.DescriptionElementID = Id;
                    this.CreateTable(AttributeString);
                    break;
                case "MaterialTable":
                    Query = "UPDATE E3D_Spec_Editor SET Value ='" + Id.ToString() + "' WHERE Attribute ='MaterialElementID' ;";
                    this.DbContext.ExecuteQuery(Query);
                    this.MaterialElementID = Id;
                    this.CreateTable(AttributeString);
                    break;
                case "Specification":
                    Query = "UPDATE E3D_Spec_Editor SET Value ='" + Id.ToString() + "' WHERE Attribute ='SpecificationElementID' ;";
                    this.DbContext.ExecuteQuery(Query);
                    this.SpecificationElementID = Id;
                    this.CreateTable(AttributeString);
                    break;
                default:
                    break;
            }
        }

        internal void SetID()
        {
            DataSet ds = this.DbContext.getDataSet("SELECT * FROM E3D_Spec_Editor;", "E3D_Spec_Editor");
            this.DbContext.SetToDefaultParam();

            foreach (DataRow dr in ds.Tables["E3D_Spec_Editor"].Rows)
            {
                switch (dr["Attribute"].ToString())
                {
                    case "SpecificationElementID":
                        this.SpecificationElementID = Convert.ToInt32(dr["Value"].ToString());
                        break;
                    case "SizeElementID":
                        this.SizeElementID = Convert.ToInt32(dr["Value"].ToString());
                        break;
                    case "MaterialElementID":
                        this.MaterialElementID = Convert.ToInt32(dr["Value"].ToString());
                        break;
                    case "DescriptionElementID":
                        this.DescriptionElementID = Convert.ToInt32(dr["Value"].ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        internal void CreateTable(string tableName)
        {
            string Query;
            switch (tableName)
            {   
                case "SizeTable":
                    Query = "CREATE TABLE SizeTable" + this.SizeElementID.ToString() + " ( " +
                        "Sizes   INTEGER NOT NULL, " +
                        "PRIMARY KEY(Sizes) ); ";
                    this.DbContext.ExecuteQuery(Query);
                    Query = "INSERT INTO SizeTableAttribute ( ReferenceNo, Name ) VALUES ( '" + this.SizeElementID.ToString() + "', 'SizeTable" + this.SizeElementID.ToString() + "' );";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "MaterialTable":
                    Query = "CREATE TABLE MaterialTable" + this.MaterialElementID.ToString() + " ( " +
                        "Material   TEXT NOT NULL, " +
                        "Heading   TEXT, " +
                        "PRIMARY KEY(Material) ); ";
                    this.DbContext.ExecuteQuery(Query);
                    Query = "INSERT INTO MaterialTableAttribute ( ReferenceNo, Name ) VALUES ( '" + this.MaterialElementID.ToString() + "', 'MaterialTable" + this.MaterialElementID.ToString() + "' );";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "DescriptionTable":
                    Query = "CREATE TABLE DescriptionTable" + this.DescriptionElementID.ToString() + " ( " +
                        "Description   TEXT NOT NULL, " +
                        "Heading   TEXT, " +
                        "PRIMARY KEY(Description) ); ";
                    this.DbContext.ExecuteQuery(Query);
                    Query = "INSERT INTO DescriptionTableAttribute ( ReferenceNo, Name ) VALUES ( '" + this.DescriptionElementID.ToString() + "', 'DescriptionTable" + this.DescriptionElementID.ToString() + "' );";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                case "Specification":
                    Query = "CREATE TABLE Specification" + this.SpecificationElementID.ToString() + " ( " +
                        "SrNo  INTEGER NOT NULL," +
                        "Standard   TEXT NOT NULL, " +
                        "Stype   TEXT NOT NULL, " +
                        "Heading   TEXT NOT NULL, " +
                        "Section   TEXT NOT NULL, " +
                        "SizeRange   TEXT, " +
                        "Description   TEXT, " +
                        "Material   TEXT, " +
                        "CatalogueComponent   TEXT, " +
                        "Remarks   TEXT, " +
                        "PRIMARY KEY(SrNo AUTOINCREMENT) ); ";
                    this.DbContext.ExecuteQuery(Query);
                    Query = "INSERT INTO SpecificationsTableAttribute ( ReferenceNo, Name, SizeTable, MaterialTable, DescriptionTable) VALUES ( '" + this.SpecificationElementID.ToString() + "', 'Specification" + this.SpecificationElementID.ToString() + "' , '' , '' , '' );";
                    this.DbContext.ExecuteQuery(Query);
                    break;
                default:
                    break;
            }
        }
    }
}
