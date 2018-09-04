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

namespace Login.zhanghu
{
    public partial class 账户信息_编辑_ : Form
    {
        private string p;
        private string zhuji;
        private string id;

        public 账户信息_编辑_(string p, string name, string zhuji, string id)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.p = p;
            this.Name = name;
            this.zhuji = zhuji;
            this.id = id;
        }
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        private void 账户信息_编辑__Load(object sender, EventArgs e)
        {
            //数据库链接字符串（引号的字符串为之前复印那段字符）
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string sql = string.Format("select 备注 from Zhanghu where 助记码='" + this.zhuji+ "' and ID='" + this.id + "'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            //  SqlDataAdapter cmd = new SqlDataAdapter(sql, conn);
            //     cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();  //执行查询
            if (sdr.Read())
            {
                textBox1.Text = Name;
                textBox2.Text = zhuji;
                textBox3.Text = sdr["备注"].ToString(); ;
            }
            conn.Close();
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                 SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                string sql1 = string.Format("update Zhanghu with (rowlock) set 账户名称='" + @textBox1.Text.Trim() + "',助记码='" + @textBox2.Text.Trim() + "',备注='" + @textBox3.Text.Trim() + "',更新时间='" + DateTime.Now.ToLocalTime().ToString() + "',操作人='" + @p + "' where ID='"+this.id+"'");
                SqlCommand com2 = new SqlCommand(sql1, conn);
                  com2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("修改成功！");
                    this.Close();
            
        }
    }
}
