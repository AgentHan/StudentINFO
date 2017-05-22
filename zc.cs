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
    public partial class zc : Form
    {
        public zc()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("输入错误！");
                return;


            }
            else
            {
                string sql = "insert into usermanager(username,pwd) values('"
                + textBox1.Text + "','" + textBox2.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    MessageBox.Show("保存成功！");

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            login frm = new login();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            if (textBox7.Text == textBox5.Text)
            {
                MessageBox.Show("新密码不能与旧密码相同！");
                return;


            }
            else if (textBox7.Text != textBox4.Text)
            {
                MessageBox.Show("输入错误！");
                return;


            }
           
            else
            {
                string sql = "update usermanager set username='"
                + textBox6.Text + "',pwd='" + textBox7.Text + "'where username='" + old + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    MessageBox.Show("修改成功！");

            }
        }
        public string old;

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
