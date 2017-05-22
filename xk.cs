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
    public partial class xk : Form
    {
        public xk()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (button1.Text == "确定")
            {
                //加数据到数据库
                string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
                SqlConnection sqlcon = new SqlConnection(Sql);
                //Connection对象与数据源建立连接
                string kc = "";
                if (radioButton1.Checked)
                    kc = radioButton1.Text;
                if (radioButton2.Checked)
                    kc = radioButton2.Text;
                if (radioButton3.Checked)
                    kc = radioButton3.Text;
                if (radioButton4.Checked)
                    kc = radioButton4.Text;
                sqlcon.Open();
                string sql = "insert into selectKC(学号,课程名称) values ('" + txtXh.Text + "','" + kc + "')";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
                //Command对象对数据源执行查询、添加、删除和修改等各种操作
                if (function(txtXh.Text))
                {
                    MessageBox.Show("学号已经存在！");
                }
                else
                {
                    sqlcmd.ExecuteNonQuery();
                    //ExecuteNonQuery()方法：执行SQl语句，但没有返回结果，一般用于执行Insert into、update、delete语句
                }
                sqlcon.Close();
                txtXh.Focus();
                function1();

            }
        }
        public bool function(string ID)//判断学号是否重复
        {
            //添加数据到数据库
            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            //Connection对象与数据源建立连接
            sqlcon.Open();

            string sql = "select * from selectKC where 学号='" + ID + "'";
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
        public void function1() //在dataGridView1显示
        {


            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            sqlcon.Open();

            string sqlStr = "select * from selectKC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //DataAdapter对象是DataSet对象和数据源之间联系的桥梁，
            //主要是从数据源中检测数据、填充DataSet对象中的表或者把用户对DataSet对象的更改写到数据源
        }
      
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{tab}");
            }
        }
        public bool date(string n)
        {
            try
            {
                DateTime.Parse(n);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string old;
       
    

        
        string kc = "";
      

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

      

    }
}
