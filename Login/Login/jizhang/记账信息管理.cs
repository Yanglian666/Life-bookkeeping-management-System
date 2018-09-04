using Login.jizhang;
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
using WeifenLuo.WinFormsUI.Docking;

namespace Login.zhanghu
{
    public partial class 记账信息管理 : DockContent
    {
        private string p;


        public 记账信息管理(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p = p;
        }
        int i, start;//i为总行数，start为起始位置
        int size = 15;//定义一个每页显示的行数
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        //所有信息显示
        private void 记账信息管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet8.Jizhang”中。您可以根据需要移动或删除它。
            this.jizhangTableAdapter.Fill(this.jiZhangDataSet8.Jizhang);
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Jizhang"].Rows.Count;//总的行数或者记录数

            show(0, size);//每页显示10条记录
            for (int a = 0; a < i; a++)
            {
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView2.Rows[a].Height = 35;    //datagridView的行高度为35
            }
            start = 0;//第一行
            bbb.Text = Convert.ToString(start + 1);     //第几页
            if ((i % size) == 0)
            {
                bb.Text = Convert.ToString(i / size);
            }
            else
            {
                bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            }
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            qq.Text = Convert.ToString(size);    //每页几条记录



            //   datatime.Text = DateTime.Now.ToLocalTime().ToString();
            com.Clone();
            com.Dispose();


            SqlConnection conn1 = new SqlConnection(str);                            //实例化链接
            conn1.Open();                        //打了链接
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();


            string sq2 = string.Format("select 类型名称 from Zhangmu  where 操作人='" + this.p + "'");
            SqlDataAdapter com1 = new SqlDataAdapter(sq2, conn1);          //一个SQL语句
            com1.Fill(ds1, "Zhangmu");

            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            comboBox2.DisplayMember = "类型名称";

            string sq3 = string.Format("select 账户名称 from Zhanghu  where 操作人='" + this.p + "'");
            SqlDataAdapter com2 = new SqlDataAdapter(sq3, conn1);          //一个SQL语句
            com2.Fill(ds2, "Zhangmu");

            comboBox3.DataSource = ds2.Tables[0].DefaultView;
            comboBox3.DisplayMember = "账户名称";
        }
        //显示分页
        private void show(int p, int j)
        {
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, p, j, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi


            ds = null;//清空数据集
        }
        private void 增加_Click(object sender, EventArgs e)
        {
            收入记账 shouru = new 收入记账(this.p);
            shouru.ShowDialog();
            BindData();
        }

        private void BindData()
        {

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi
            int i = ds.Tables["Jizhang"].Rows.Count;//总的行数或者记录数
            for (int a = 0; a < i; a++)
            {
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView2.Rows[a].Height = 35;    //datagridView的行高度为35
            }
            show(0, size);//每页显示10条记录
            start = 0;//第一行
            bbb.Text = Convert.ToString(start + 1);     //第几页
            if ((i % size) == 0)
            {
                bb.Text = Convert.ToString(i / size);
            }
            else
            {
                bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            }
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            qq.Text = Convert.ToString(size);    //每页几条记录



            //   datatime.Text = DateTime.Now.ToLocalTime().ToString();
            com.Clone();
            com.Dispose();


        }


        //首页按钮事件
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;//清空数据
            start = 0;
            bbb.Text = Convert.ToString(start + 1);     //第几页
            show(0, size);//调用show函数
        }
        //上一页按钮事件
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            start = start - 1;
            if (start > -1)
            {

                dataGridView2.DataSource = null;
                bbb.Text = Convert.ToString(start + 1);     //第几页
                show(start * size, size);


            }
            else
            {
                MessageBox.Show("已经是第一页！");


            }
        }

        //下一页
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (i < size)
            {


                bb.Text = Convert.ToString(1);
                bbb.Text = Convert.ToString(1);
            }
            start = start + 1;
            if (i % size == 0)
            {
                if (start < (i / size))
                {
                    dataGridView2.DataSource = null;

                    bbb.Text = Convert.ToString(start + 1);

                    show(start * size, size);

                }
                else
                {
                    MessageBox.Show("已经是最后一页！");
                }
            }
            else
            {
                if (start < (i / size + 1))
                {
                    dataGridView2.DataSource = null;

                    bbb.Text = Convert.ToString(start + 1);
                    show(start * size, size);

                }
                else
                {
                    MessageBox.Show("已经是最后一页！");
                }
            }

        }
        //尾页
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;

            if (i < size)  //i是总行记录，size是每一页30行
            {

                show(0, size);
            }
            else
            {
                show(i - size, i % size);
            }
            if (i % size == 0)
            {
                bbb.Text = Convert.ToString(i / size);     //第几页
            }
            else
            {
                bbb.Text = Convert.ToString(i / size + 1);     //第几页
            }
        }

        private void 编辑_Click(object sender, EventArgs e)
        {
            支出记账 zhichu = new 支出记账(this.p);
            zhichu.ShowDialog();
            BindData();
        }
        //删除记录
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数
                int iCount = dataGridView2.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("Delete Data Fail!", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("确定撒销选中的收支记录吗？此操作不可恢复哦！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {

                    for (int i = dataGridView2.SelectedRows.Count - 1; i >= 0; i--)  //循环遍历所有行
                    {

                        //获取点击datagridview1的行的 行号
                        int r = Convert.ToInt32(dataGridView2.SelectedRows[i].Cells[0].Value);
                        string name = Convert.ToString(dataGridView2.SelectedRows[i].Cells[1].Value);
                        dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[i].Index);  //使用获得的ID删除数据库的数据

                        SqlConnection conn = new SqlConnection(str);                            //实例化链接
                        conn.Open();                        //打了链接
                        string sql = "delete from Jizhang where ID='" + r + "'";
                        SqlCommand sda = new SqlCommand(sql, conn);
                        sda.ExecuteNonQuery();
                        conn.Close();


                    }

                    BindData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi
            int i = ds.Tables["Jizhang"].Rows.Count;//总的行数或者记录数
            show(0, size);//每页显示10条记录
            start = 0;//第一行
            bbb.Text = Convert.ToString(start + 1);     //第几页
            if ((i % size) == 0)
            {
                bb.Text = Convert.ToString(i / size);
            }
            else
            {
                bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            }
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            qq.Text = Convert.ToString(size);    //每页几条记录



            //   datatime.Text = DateTime.Now.ToLocalTime().ToString();
            com.Clone();
            com.Dispose();

            for (int a = 0; a < i; a++)
            {
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView2.Rows[a].Height = 35;    //datagridView的行高度为35
            }
        }

        //撒销记录
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数
                int iCount = dataGridView2.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("Delete Data Fail!", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("确定要对选中记录冲账吗？此操作不可恢复哦！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {

                    for (int i = dataGridView2.SelectedRows.Count - 1; i >= 0; i--)  //循环遍历所有行
                    {
                        int r = Convert.ToInt32(dataGridView2.SelectedRows[i].Cells[0].Value);
                        dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[i].Index);  //使用获得的ID删除数据库的数据

                        //数据库链接字符串（引号的字符串为之前复印那段字符）
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string sql = string.Format("select 账户名称,发生金额,账户余额 from Jizhang where 操作人='" + this.p + "' and ID='" + r + "'");
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader sdr = cmd.ExecuteReader();  //执行查询
                        if (sdr.Read())
                        {
                            decimal count = Convert.ToDecimal(sdr["账户余额"].ToString()) - Convert.ToDecimal(sdr["发生金额"].ToString());
                            string name = Convert.ToString(sdr["账户名称"].ToString());
                            conn.Close();

                            SqlConnection conn1 = new SqlConnection(str);                            //实例化链接
                            conn1.Open();                        //打了链接
                            string sql1 = "delete from Jizhang where ID='" + r + "'";
                            string sql2 = string.Format("update Zhanghu with (rowlock) set 余额='" + @count + "' where 操作人='" + this.p + "' and 账户名称='" + @name + "'");
                            SqlCommand sda = new SqlCommand(sql1, conn1);
                            SqlCommand sda2 = new SqlCommand(sql2, conn1);

                            sda.ExecuteNonQuery();
                            sda2.ExecuteNonQuery();
                            conn1.Close();

                            BindData();
                        }
                        else
                        {
                            MessageBox.Show("操作失败！");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            start = 0;//第一行
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 账目日期 between'" + date1.Text.Trim() + "' and '" + date2.Text.Trim() + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句

            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Jizhang"].Rows.Count;//总的行数或者记录数                    
            for (int a = 0; a < i; a++)
            {
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView2.Rows[a].Height = 35;    //datagridView的行高度为35
            }
            bbb.Text = Convert.ToString(start + 1);     //第几页
            bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            //show1(0, size);
            conn.Close();
            conn.Dispose();
            toolStripButton6.Text = toolStripButton8.Text = toolStripButton9.Text = toolStripButton10.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            start = 0;//第一行
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Jizhang where 账户名称='" + comboBox3.Text.Trim() + "' or 资金类型 ='" + comboBox1.Text.Trim() + "' or 账目类型名称 ='" + comboBox2.Text.Trim() + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句

            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Jizhang");                        //适配器匹配数据
            dataGridView2.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView2.DataMember = "Jizhang";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Jizhang"].Rows.Count;//总的行数或者记录数                    
            for (int a = 0; a < i; a++)
            {
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView2.Rows[a].Height = 35;    //datagridView的行高度为35
            }
            bbb.Text = Convert.ToString(start + 1);     //第几页
            bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            //show1(0, size);
            conn.Close();
            conn.Dispose();
            toolStripButton6.Text = toolStripButton8.Text = toolStripButton9.Text = toolStripButton10.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }



}
