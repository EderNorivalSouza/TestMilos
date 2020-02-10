using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EderGridView.DataSource = GetDataList();
        }

        private DataTable GetDataList()
        {
            DataTable Datagrid = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * From clientes", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Datagrid.Load(reader);
                }
            }
            return Datagrid;
        }
    }
}
