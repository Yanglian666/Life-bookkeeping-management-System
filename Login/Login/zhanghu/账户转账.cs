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
    public partial class 账户转账 : Form
    {
        private string id;
        private string zhuji;
        private string p;
        private string yue;


                string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";

        public 账户转账(string id, string name, string zhuji, string yue, string p)
        {
            InitializeComponent();
            
            // TODO: Complete member initialization
            this.id = id;
            this.Name = name;
            this.zhuji = zhuji;
            this.yue = yue;
            this.p = p;
        }

        private void 账户转账_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Name;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();


            string sql = string.Format("select 账户名称 from Zhanghu  where 操作人='" + this.p + "'");
            string sql1 = string.Format("select 账户名称 from Zhanghu  where 操作人='" + this.p + "'");

            SqlDataAdapter com = new SqlDataAdapter(sql, conn);          //一个SQL语句
            SqlDataAdapter com1 = new SqlDataAdapter(sql1, conn);          //一个SQL语句
            com.Fill(ds, "Zhanghu");
            com1.Fill(ds1, "Zhanghu");
         

            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMember = "账户名称";

            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            comboBox2.DisplayMember = "账户名称";
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(comboBox2.Text))
            {
                MessageBox.Show("非常抱歉！因转入账户名称和转出账户名称是同一个，不能操作！");
            }
            else{
//数据库链接字符串（引号的字符串为之前复印那段字符）
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string sql = string.Format("select 余额 from Zhanghu where 账户名称='" + comboBox1.Text.Trim() + "'and 操作人='" + this.p + "'");  //转入账户

            SqlCommand cmd = new SqlCommand(sql, conn);
            //  SqlDataAdapter cmd = new SqlDataAdapter(sql, conn);
            //     cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();  //执行查询
            if (sdr.Read())
            {
                decimal yuan = Convert.ToDecimal(sdr["余额"].ToString());  //转入账户的余额

                 conn.Close();
                
                //数据库链接字符串（引号的字符串为之前复印那段字符）
                 SqlConnection conn1 = new SqlConnection(str);
                 
                  string sql1 = string.Format("select 余额 from Zhanghu where 账户名称='" +comboBox2.Text.Trim()+ "'and 操作人='"+this.p+"'");  //转出账户
                 SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                 conn1.Open(); 
                SqlDataReader sdr1 = cmd1.ExecuteReader();  //执行查询
                  if (sdr1.Read())
                  {
                      decimal zhuan = Convert.ToDecimal(sdr1["余额"].ToString());  //转出账户的余额
                      decimal xin = Convert.ToDecimal(textBox2.Text.Trim());   //转入是转出账户的新金额
                      if (yuan < xin)  //如果转出账户余额小于要转入金额
                      {
                          MessageBox.Show("非常抱歉！转出账户的余额不足！目前的余额是：" + yuan + "元");
                      }
                      else
                      {
                          decimal yue = yuan - xin;  //转出账户余额-要转入金额
                          decimal count = zhuan + xin;//转入账户余额+要转入金额

                          conn1.Close();
                          SqlConnection conn2 = new SqlConnection(str);
                          conn2.Open();
                          string zhuanru = string.Format("update Zhanghu with (rowlock) set 余额='" + @count + "'where 操作人='" + @p + "' and 账户名称='" + comboBox2.Text.Trim() + "'");
                          string zhuanchu = string.Format("update Zhanghu with (rowlock) set 余额='" + @yue + "'where 操作人='" + @p + "' and 账户名称='" + comboBox1.Text.Trim() + "'");
                         string zhuanruName = string.Format("INSERT INTO Mingxi(账目日期,账户名称,账目说明,发生金额,账户余额,资金类型,[转入/出账户名称],账目类型,记账日期,操作人) VALUES('" + @DateTime.Now.ToLocalTime().ToString() + "','" + @comboBox2.Text.Trim() + "','转账'," + @xin + "," + @count + ",'转账收入','" + @comboBox1.Text.Trim() + "','公共','" + @DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");
                         string zhuanchuName = string.Format("INSERT INTO Mingxi(账目日期,账户名称,账目说明,发生金额,账户余额,资金类型,[转入/出账户名称],账目类型,记账日期,操作人) VALUES('" + @DateTime.Now.ToLocalTime().ToString() + "','" + @comboBox1.Text.Trim() + "','转账'," + -xin + "," + @yue + ",'转账支出','" + @comboBox2.Text.Trim() + "','公共','" + @DateTime.Now.ToLocalTime().ToString() + "','" + this.p + "')");
                         SqlCommand com2 = new SqlCommand(zhuanru, conn2);
                          SqlCommand com3 = new SqlCommand(zhuanchu, conn2);
                          SqlCommand com4 = new SqlCommand(zhuanruName, conn2);
                          SqlCommand com5 = new SqlCommand(zhuanchuName, conn2);


                          com2.ExecuteNonQuery();
                          com3.ExecuteNonQuery();
                          com4.ExecuteNonQuery();
                          com5.ExecuteNonQuery();

                          conn2.Close();
                          MessageBox.Show("转账成功了！");
                          this.Close();
                      }
                  }
                      else{
                          MessageBox.Show("转账操作失败！");
                      }
                  }
            else{
                          MessageBox.Show("转账操作失败！");
                      }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.zhanghuTableAdapter.FillBy(this.jiZhangDataSet2.Zhanghu);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

