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

namespace Login.Password
{
    public partial class 修改密码 : Form
    {
        private string p;


        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        public 修改密码(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p = p;
        }

        private void 修改密码_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.p;
            SqlConnection conn = new SqlConnection(str);
            string sql = string.Format("select 密码 from [User] where 账号='" + this.p + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();//执行查询
                if (sdr.Read())
                {
                    textBox2.Text=sdr["密码"].ToString();
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                error.Text = "请输入原密码";
                textBox2.Focus();
            }
            else if (textBox3.Text.Equals(""))
            {
                error.Text = "请输入新密码";
                textBox3.Focus();
            }
            else if (textBox4.Text.Equals(""))
            {
                error.Text = "请输入确定密码";
                textBox4.Focus();
            }
            else if (!textBox3.Text.Equals(textBox4.Text.Trim()))
            {
  error.Text = "两个密码不一致！！";
                textBox3.Focus();
            }
   
      else
                    {
                        SqlConnection conn1 = new SqlConnection(str);
                        conn1.Open();
                        string sql1 = string.Format("update [User] with (rowlock) set 密码='" + @textBox3.Text.Trim() +  "' where 账号='" + this.p + "'");
                        SqlCommand com2 = new SqlCommand(sql1, conn1);
                        com2.ExecuteNonQuery();
                        conn1.Close();
                        MessageBox.Show("修改密码成功！");
                        this.Close();
                    }
                  
                
            }
            }
               
        }

    