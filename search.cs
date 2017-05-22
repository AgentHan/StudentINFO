using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 韩富康
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void btnCx_Click(object sender, EventArgs e)
        {
            string s = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123"; 
            SqlConnection con = new SqlConnection(s);
     con.Open();
     string sql = "select * from student where 学号='" + textBox1.Text +"'";

      SqlCommand cmd = new SqlCommand(sql ,con );           
       SqlDataAdapter dap = new SqlDataAdapter(cmd );
        DataSet ds = new DataSet();
       dap.Fill(ds);
       dataGridView1.DataSource = ds.Tables[0];



        }

        
        private void search_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




       
    }
}
