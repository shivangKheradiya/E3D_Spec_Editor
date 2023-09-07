using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3D_Spec_Editor.SQLite
{
    public class SQLiteDbContext
    {
        public string DbFilePath { get; set; }
        public string DbConnectionString { get; set; }
        public SQLiteConnection connection { get; set; }
        public SQLiteCommand command { get; set; }
        public SQLiteTransaction transaction { get; set; }
        public string QueryString { get; set; }
        public SQLiteDataAdapter da { get; set; }
        public List<SQLiteDataAdapter> daList { get; set; }
        public List<DataSet> dsList { get; set; }
        public DataSet ds { get; set; }

        public SQLiteDbContext()
        {
            SetToDefaultParam();
            this.daList = new List<SQLiteDataAdapter>();
            this.dsList = new List<DataSet>();
        }

        public void Setup()
        {
            this.DbConnectionString = @"Data source=" + this.DbFilePath + "; foreign keys = true;";
            this.connection = new SQLiteConnection(this.DbConnectionString);
            this.connection.Open();
            this.daList.Clear();
        }

        public void BeginTransection()
        {
            transaction = this.connection.BeginTransaction();
        }

        public void CommitTransection()
        {
            transaction.Commit();
        }

        public void Exit()
        {
            this.connection.Close();
        }

        public void SetToDefaultParam()
        {
            QueryString = String.Empty;
            command = null;
            ds = null;
            da = null;
        }

        public DataSet getDataSet(string Query, string TableName)
        {
            this.QueryString = Query;
            this.command = new SQLiteCommand(this.QueryString, this.connection);
            this.da = new SQLiteDataAdapter(this.command);
            this.ds = new DataSet();
            this.da.Fill(ds, TableName);
            return ds;
        }

        public void ExecuteQuery(string Query)
        {
            this.QueryString = Query;
            this.command = new SQLiteCommand(this.QueryString, this.connection);
            this.command.ExecuteNonQuery();
        }

        internal void RollBackTransection()
        {
            this.transaction.Rollback();
        }
    }
}
