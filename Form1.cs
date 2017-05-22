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
    public partial class Form1 : Form
    {
        public Form1()
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

                string sex = "";
                if (radioButton1.Checked)
                    sex = radioButton1.Text;
                else
                    sex = radioButton2.Text;
                string sql = "insert into student(学号,姓名,性别,出生日期,民族,政治面貌,班级) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + sex + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
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
                function1();
            }

            if (button1.Text == "保存")
            {
                //在dataGridView1显示
                string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
                SqlConnection sqlcon = new SqlConnection(Sql);
                sqlcon.Open();

                if (radioButton1.Checked)
                    sex = radioButton1.Text;
                else
                    sex = radioButton2.Text;
                string sqlStr = "";
                sqlStr = "update student set 学号='" + textBox1.Text + "',姓名='" + textBox2.Text + "',性别='" + sex + "',出生日期='" + textBox3.Text + "',民族='" + comboBox1.Text + "',政治面貌='" + comboBox2.Text + "' ,班级='" + comboBox3.Text + "' where 学号='" + old + "'";
                //SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlcon);
                if (function(textBox1.Text))
                {
                    sqlStr = "update student set 姓名='" + textBox2.Text + "',性别='" + sex + "',出生日期='" + textBox3.Text + "',民族='" + comboBox1.Text + "',政治面貌='" + comboBox2.Text + "',班级='" + comboBox3.Text + "'where 学号='" + old + "'";
                    SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    //reset();
                    function1();
                }
                else
                {
                    SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    //reset();
                    function1();
                    //ExecuteNonQuery()方法：执行SQl语句，但没有返回结果，一般用于执行Insert into、update、delete语句
                }
                button1.Text = "添加";
            }
        }
        public bool function(string ID)//判断学号是否重复
        {
            //添加数据到数据库
            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            //Connection对象与数据源建立连接
            sqlcon.Open();

            string sql = "select * from student where 学号='" + ID + "'";
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
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("汉族");
            comboBox1.Items.Add("少数民族");

            comboBox2.Items.Add("群众");
            comboBox2.Items.Add("共青团员");
            comboBox2.Items.Add("党员");
            function1();
           
        }
        public void function1() //在dataGridView1显示
        {
           

            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            sqlcon.Open();

            string sqlStr = "select * from student";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //DataAdapter对象是DataSet对象和数据源之间联系的桥梁，
            //主要是从数据源中检测数据、填充DataSet对象中的表或者把用户对DataSet对象的更改写到数据源
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
        private void textBox3_functionValidated(object sender, EventArgs e)
        {
            if (!date(textBox3.Text))
            {
                MessageBox.Show("输入的日期不合法！");

                textBox3.Focus();
            }
               
        }
        public string old;
       
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            radioButton1.Checked = true;
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string Sql = "Data Source=.\\sqlexpress;database=D_sample;uid=sa;pwd=123";
            SqlConnection sqlcon = new SqlConnection(Sql);
            sqlcon.Open();
            old = textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sql = "delete from student where 学号='" + old + "'";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
            sqlcmd.ExecuteNonQuery();
            function1();
        }
        string sex = "";
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "更新";
            if (button1.Text == "更新")
            {
                old = textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string sex = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (sex == "男")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                
                button1.Text = "保存";
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
