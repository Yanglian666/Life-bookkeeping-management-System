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

namespace Login.zhuce
{
    public partial class 注册 : Form
    {
        public 注册()
        {
            InitializeComponent();
        }
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.ForeColor = Color.Black;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("输入新账号") || textBox2.Text.Equals("输入姓名") || textBox3.Text.Equals("输入手机号码") || textBox4.Text.Equals("输入新密码") || textBox5.Text.Equals("输入确定密码"))
            {
                MessageBox.Show("请填写信息！");
            }

            else if (!textBox4.Text.Equals(textBox5.Text))
            {
                MessageBox.Show("两个密码不一致！");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                string sql = string.Format("select 账号 from [User] where 账号='" + @textBox1.Text.Trim() + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();//执行查询
                if (sdr.Read())
                {
                    MessageBox.Show("你输入的账号已经存在！请重新输入！");
                    conn.Close();
                }
                else
                {
                    //数据库链接字符串（引号的字符串为之前复印那段字符）
                    SqlConnection conn1 = new SqlConnection(str);

                    string sql1 = string.Format("INSERT INTO [User] VALUES('" + @textBox1.Text.Trim() + "','" + @textBox2.Text.Trim() + "','" + @textBox3.Text.Trim() + "','" + @textBox4.Text.Trim() + "')");
                    SqlCommand com1 = new SqlCommand(sql1, conn1);
                    conn1.Open();
                    com1.ExecuteNonQuery();
                    conn1.Close();
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
            }
        }

    }

}
      
    


