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
    public partial class sourse : Form
    {
        public sourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "添加")
            {
                //加数据到数据库
                string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
                SqlConnection sqlcon = new SqlConnection(Sql);
                //Connection对象与数据源建立连接
                sqlcon.Open();



                string sql = "insert into SC(学号,课程名称,成绩) values ('" + textBox1.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
                //Command对象对数据源执行查询、添加、删除和修改等各种操作
                if (function(textBox1.Text))
                {
                    MessageBox.Show("学号已经存在！");
                }
                else
                {
                    sqlcmd.ExecuteNonQuery();
                    //ExecuteNonQuery()方法：执行SQl语句，但没有返回结果，一般用于执行Insert into、update、delete语句
                }
                sqlcon.Close();
                textBox1.Focus();

            }

           
        }
        public bool function(string ID)//判断学号是否重复
        {
            //添加数据到数据库
            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            //Connection对象与数据源建立连接
            sqlcon.Open();

            string sql = "select * from SC where 学号='" + ID + "'";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
            int count = 0;
            if (sqlcmd.ExecuteScalar() == null)
                count = 0;
            else
                count = int.Parse(sqlcmd.ExecuteScalar().ToString());
            //ExecuteScalar()方法：返回一行一列

            if (count > 0)
                return true;
            else
                return false;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                SendKeys.Send("{tab}");
            }
        }

       
      
        public string old;
       
        public void reset()
        {
            textBox1.Text = "";
            textBox3.Text = "";
           
            comboBox1.Text = "";
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
      

       
       
        
        }
    }

