using Login.zhanghu;
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
    public partial class 账户信息 : DockContent
    {
        string p;
        public 账户信息(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p = p;
        }
        //添加信息
        private void 增加_Click(object sender, EventArgs e)
        {
            账户信息_添加_ add = new 账户信息_添加_(this.p);
            add.Owner = this;
            add.ShowDialog();
            BindData();
        }

   

        private void 编辑_Click(object sender, EventArgs e)
        {
            //获取点击datagridview1的行的 行号
            int r = this.dataGridView1.CurrentRow.Index;
            string id = this.dataGridView1.Rows[r].Cells[0].Value.ToString();
            string name = this.dataGridView1.Rows[r].Cells[1].Value.ToString();
            string zhuji = this.dataGridView1.Rows[r].Cells[2].Value.ToString();
            //获取此行的 员工编号 的值
            账户信息_编辑_ edit = new 账户信息_编辑_(this.p,name,zhuji,id);
            edit.Owner = this;
            edit.ShowDialog();
            BindData();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //获取点击datagridview1的行的 行号
            int r = this.dataGridView1.CurrentRow.Index;
            string id = this.dataGridView1.Rows[r].Cells[0].Value.ToString();
            string name = this.dataGridView1.Rows[r].Cells[1].Value.ToString();
            string zhuji = this.dataGridView1.Rows[r].Cells[2].Value.ToString();
            string yue = this.dataGridView1.Rows[r].Cells[3].Value.ToString();

            账户对账 duizhang = new 账户对账(id,name,zhuji, yue,this.p);
            duizhang.ShowDialog();
            BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //获取点击datagridview1的行的 行号
            int r = this.dataGridView1.CurrentRow.Index;
            string id = this.dataGridView1.Rows[r].Cells[0].Value.ToString();
            string name = this.dataGridView1.Rows[r].Cells[1].Value.ToString();
            string zhuji = this.dataGridView1.Rows[r].Cells[2].Value.ToString();
            string yue = this.dataGridView1.Rows[r].Cells[3].Value.ToString();

            账户转账 zhuanzhang = new 账户转账(id, name, zhuji,yue, this.p);
            zhuanzhang.ShowDialog();
            BindData();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
//明细信息
        private void 导出_Click(object sender, EventArgs e)
        {
            //获取点击datagridview1的行的 行号
            int r = this.dataGridView1.CurrentRow.Index;
            string id = this.dataGridView1.Rows[r].Cells[0].Value.ToString();
            string name = this.dataGridView1.Rows[r].Cells[1].Value.ToString();
            账目收支明细查看 mingxi = new 账目收支明细查看(name,this.p);
            mingxi.Owner = this;
            mingxi.ShowDialog();
        }
        int i, start;//i为总行数，start为起始位置
        int size = 20;//定义一个每页显示的行数
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        //所有信息显示
        private void 账户信息_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet.Zhanghu”中。您可以根据需要移动或删除它。
            this.zhanghuTableAdapter.Fill(this.jiZhangDataSet.Zhanghu);
            // TODO: 这行代码将数据加载到表“testDataSet16.TonerOutput”中。您可以根据需要移动或删除它。

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhanghu where 操作人='"+this.p+"'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Zhanghu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "Zhanghu";                    //绑定ds的表名为shetuanxinxi
             i = ds.Tables["Zhanghu"].Rows.Count;//总的行数或者记录数
             for (int a = 0; a < i; a++)
             {
                 this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                 this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
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

        //显示分页
        private void show(int p, int j)
        {
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhanghu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, p, j, "zhanghu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView1.DataMember = "zhanghu";                    //绑定ds的表名为shetuanxinxi


            ds = null;//清空数据集
        }

        //首页按钮事件
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;//清空数据
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

                dataGridView1.DataSource = null;
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
                    dataGridView1.DataSource = null;

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
                    dataGridView1.DataSource = null;

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
            dataGridView1.DataSource = null;

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


        private void BindData()
        {

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhanghu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "zhanghu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "zhanghu";                    //绑定ds的表名为shetuanxinxi
            int i = ds.Tables["zhanghu"].Rows.Count;//总的行数或者记录数
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
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
            }
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数
                int iCount = dataGridView1.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("Delete Data Fail!", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("是否删除选中的数据和选中的所有明细信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {

                    for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)  //循环遍历所有行
                    {

                        //获取点击datagridview1的行的 行号
                        int r = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value);
                        string name = Convert.ToString(dataGridView1.SelectedRows[i].Cells[1].Value);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);  //使用获得的ID删除数据库的数据

                        SqlConnection conn = new SqlConnection(str);                            //实例化链接
                        conn.Open();                        //打了链接
                        string sql = "delete from Zhanghu where ID='" + r + "'";
                        string sql1 = "delete from Mingxi where 账户名称='" + name + "'";
                        SqlCommand sda = new SqlCommand(sql, conn);
                        SqlCommand sda1 = new SqlCommand(sql1, conn);
                        sda.ExecuteNonQuery();
                        sda1.ExecuteNonQuery();
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
            string sql = string.Format("select * from Zhanghu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "zhanghu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "zhanghu";                    //绑定ds的表名为shetuanxinxi
            int i = ds.Tables["zhanghu"].Rows.Count;//总的行数或者记录数
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
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
            }
        }

        private void soucha_Click(object sender, EventArgs e)
        {
            start = 0;//第一行
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhanghu where 账户名称 like'%" + 搜查.Text.Trim() + "%' or 助记码 like'%" + 搜查.Text.Trim() +"%'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句

            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Zhanghu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView1.DataMember = "Zhanghu";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Zhanghu"].Rows.Count;//总的行数或者记录数                    

            bbb.Text = Convert.ToString(start + 1);     //第几页
            bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            //show1(0, size);
            conn.Close();
            conn.Dispose();

            for (int a = 0; a < i; a++)
            {
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            搜查.Text = "";
            BindData();
        }
    }
}
