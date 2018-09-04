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

namespace Login.jizhang
{
    public partial class 收入记账 : Form
    {

        public 收入记账(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p = p;
        }
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        private string p;

        private void 收入记账_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            string a = "收 入";
            string b = "公 共";
            string sql = string.Format("select 类型名称,类型分类 from Zhangmu  where 操作人='" + this.p + "' and 类型分类='" + a + "' or 类型分类='" + b + "'");
            string sql1 = string.Format("select 账户名称 from Zhanghu  where 操作人='" + this.p + "'");

            SqlDataAdapter com = new SqlDataAdapter(sql, conn);          //一个SQL语句
            SqlDataAdapter com1 = new SqlDataAdapter(sql1, conn);          //一个SQL语句
            com.Fill(ds, "Zhangmu");
            com1.Fill(ds1, "Zhanghu");
            name.DataSource = ds1.Tables[0].DefaultView;
            name.DisplayMember = "账户名称";

            comboBox2.DataSource = ds.Tables[0].DefaultView;
            comboBox2.DisplayMember = "类型名称";

            comboBox3.DataSource = ds.Tables[0].DefaultView;
            comboBox3.DisplayMember = "类型分类";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请填写发生金额！");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string sql = string.Format("select 余额 from Zhanghu where 账户名称='" + name.Text.Trim() + "' and 操作人='" + this.p + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                //  SqlDataAdapter cmd = new SqlDataAdapter(sql, conn);
                //     cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();  //执行查询
                if (sdr.Read())
                {
                    decimal count = Convert.ToDecimal(sdr["余额"].ToString()) + Convert.ToDecimal(textBox2.Text.Trim());
                    conn.Close();
                    SqlConnection conn1 = new SqlConnection(str);
                    conn1.Open();
                    string role = string.Format("INSERT INTO Jizhang(账目日期,账目说明,账户名称,账目类型名称,资金类型,发生金额,账户余额,备注,记账日期,操作人) VALUES('" + date.Value + "','" + @textBox1.Text.Trim() + "','" + @name.Text.Trim() + "','" + @comboBox2.Text.Trim() + "','" + @comboBox3.Text.Trim() + "','" + @textBox2.Text.Trim() + "','" + @count + "','" + @beizhu.Text.Trim() + "','" + DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");
                    string zhuanruName = string.Format("INSERT INTO Mingxi(账目日期,账户名称,账目说明,发生金额,账户余额,资金类型,[转入/出账户名称],账目类型,记账日期,操作人) VALUES('" + @DateTime.Now.ToLocalTime().ToString() + "','" + @name.Text.Trim() + "','收入'," + @textBox2.Text.Trim() + "," + @count + ",'"+@comboBox3.Text.Trim()+"','无','"+@comboBox2.Text.Trim()+"','" + @DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");
                    string yue = string.Format("update Zhanghu with (rowlock) set 余额='" + @count + "',更新时间='" + DateTime.Now.ToLocalTime().ToString() + "'where 操作人='" + this.p + "' and 账户名称='"+@name.Text.Trim()+"'");
                    
                    SqlCommand com2 = new SqlCommand(role, conn1);
                    SqlCommand com3 = new SqlCommand(zhuanruName, conn1);
                    SqlCommand com4 = new SqlCommand(yue, conn1);
                    com2.ExecuteNonQuery();
                    com3.ExecuteNonQuery();
                    com4.ExecuteNonQuery();

                    conn1.Close();
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("操作失败！");
                }
            }
        }
    }
}
