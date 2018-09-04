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

namespace Login.zhangmu
{
    public partial class 账目类型_添加_ : Form
    {

        public 账目类型_添加_(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p = p;
        }
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        private string p;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请填写账目名称！");
                textBox1.Focus();
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请填写助记码！");
                textBox2.Focus();
            }
            else
            {
                //数据库链接字符串（引号的字符串为之前复印那段字符）
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string sql = string.Format("select 助记码 from Zhangmu where 助记码='" + textBox2.Text.Trim() + "' and 操作人='" + this.p + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                //  SqlDataAdapter cmd = new SqlDataAdapter(sql, conn);
                //     cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();  //执行查询
                if (sdr.Read())
                {
                    MessageBox.Show("非常抱歉！您输入的助记码已经存在！请重新输入！");
                    textBox2.Focus();
                }
                else
                {
                    conn.Close();
                    SqlConnection conn1 = new SqlConnection(str);
                    conn1.Open();
                    string role = string.Format("INSERT INTO Zhangmu(类型名称,助记码,类型分类,备注,追加时间,操作人) VALUES('" + @textBox1.Text.Trim() + "','" + @textBox2.Text.Trim() + "','" + @comboBox1.Text.Trim() + "','" + @textBox3.Text.Trim() + "','" + DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");
                    SqlCommand com2 = new SqlCommand(role, conn1);
                    com2.ExecuteNonQuery();
                    conn1.Close();
                    MessageBox.Show("添加成功！");
                    this.Close();
                }

            }
        }
    }
}
