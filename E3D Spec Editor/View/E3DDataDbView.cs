using E3D_Spec_Editor.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3D_Spec_Editor.View
{
    public class E3DDataDbView
    {
        public SQLiteDbContext E3DDataDbContext { get; set; }

        public E3DDataDbView()
        {
            this.E3DDataDbContext = new SQLiteDbContext();
            this.E3DDataDbContext.DbFilePath = AppContext.BaseDirectory + @"E3DData.db";
            this.E3DDataDbContext.Setup();
        }
    }
}
