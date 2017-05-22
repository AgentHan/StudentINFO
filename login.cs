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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123");
           
            con.Open();
          
            string sql="select count(*) from usermanager where username='"
                + textBox1.Text + "'and pwd='" + textBox2.Text + "'";
            SqlCommand cmd =new SqlCommand(sql,con);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count > 0)
           
           
            {
                this.Hide();
                welcome  frmwe = new welcome();
                frmwe.Show();

            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("用户名或密码错误");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
