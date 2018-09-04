using Login.zhuce;
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

namespace Login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("输入账号") || textBox2.Text.Equals("输入密码"))
            {
                MessageBox.Show("请您输入密账号或密码！");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                string sql = string.Format("select 账号,姓名 from [User] where 账号='" + @textBox1.Text.Trim() + "' and 密码='"+textBox2.Text.Trim()+"'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();//执行查询
                if (sdr.Read())
                {
                    Main man = new Main(sdr["账号"].ToString());             
                    man.Show();
                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show("你输入的账号无效！请注册账号！！");
                }
                conn.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            注册 zhu = new 注册();
            zhu.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            this.textBox2.PasswordChar = '.';
            textBox2.ForeColor = Color.Black;
        }

        
    }
}
