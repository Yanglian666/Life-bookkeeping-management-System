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
    public partial class 账户对账 : Form
    {
        private string id;
        private string zhuji;
        private string p;
        private string yue;


        public 账户对账(string id, string name, string zhuji, string yue, string p)
        {
            InitializeComponent();
            
            // TODO: Complete member initialization
            this.id = id;
            this.Name = name;
            this.zhuji = zhuji;
            this.yue = yue;
            this.p = p;
        }
                string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        private void 账户对账_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet1.Zhangmu”中。您可以根据需要移动或删除它。
            this.zhangmuTableAdapter.Fill(this.jiZhangDataSet1.Zhangmu);
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

                zhanghu.Text = Name;
                textBox1.Text = this.yue;
                textBox3.Text = zhuji;
                beizhu.Text = sdr["备注"].ToString();
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            decimal yuan = Convert.ToDecimal(textBox1.Text.Trim());
            decimal xin = Convert.ToDecimal(textBox2.Text.Trim());
            decimal count = yuan + xin;
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql1 = string.Format("update Zhanghu with (rowlock) set 余额='" + @count  + "',操作人='" + @p + "' where ID='" + this.id + "'");
            string duizhang = string.Format("INSERT INTO Mingxi(账目日期,账户名称,账目说明,发生金额,账户余额,资金类型,[转入/出账户名称],账目类型,记账日期,操作人) VALUES('" + @DateTime.Now.ToLocalTime().ToString() + "','" + @zhanghu.Text.Trim() + "','对账收入'," + @textBox2.Text.Trim() + "," + @count + ",'对账收入','无','其他','" + @DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");

            SqlCommand com2 = new SqlCommand(sql1, conn);
            SqlCommand com3 = new SqlCommand(duizhang, conn);
            com2.ExecuteNonQuery();

            com3.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("充入金额成功！");
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
