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
    public class PropertyView
    {
        public ApplicationDbView applicationDbView { get; set; }
        public BindingSource propertyBindingSource { get; set; }
        public DataTable propertyDataTable { get; set; }
        public TabControl MainTabControl { get; internal set; }

        internal void SetUp()
        {
            this.propertyBindingSource = new BindingSource();
            this.propertyBindingSource.DataSource = this.propertyDataTable;
        }

    }
}
