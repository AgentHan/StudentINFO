using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 韩富康
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

       

       
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
       

            frm1.Show();
        }

       

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void 学号查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search frm = new search();
            
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 性别查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search2 frm2=new search2();
            frm2.Show();
        }

        private void 课程查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssc frm3 = new ssc();
            frm3.Show();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sourse frm4 = new sourse();
            frm4.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            xk frm5 = new xk();
            frm5.Show();
        }

        private void welcome_Load(object sender, EventArgs e)
        {

        }

        private void I(object sender, KeyPressEventArgs e)
        {

        }
    }
}
