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

namespace Login.zhangmu
{
    public partial class 账目类型 : DockContent
    {
        private string p;



        public 账目类型(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent(); 
            this.p = p;
        }

        private void 增加_Click(object sender, EventArgs e)
        {
            账目类型_添加_ add = new 账目类型_添加_(this.p);
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
            string fenlei = this.dataGridView1.Rows[r].Cells[3].Value.ToString(); 
            账目类型_编辑_ edit = new 账目类型_编辑_(id,name,zhuji,fenlei,this.p);
            edit.ShowDialog();
            BindData();
        }
        int i, start;//i为总行数，start为起始位置
        int size = 18;//定义一个每页显示的行数
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        private void 账目类型_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet7.Zhangmu”中。您可以根据需要移动或删除它。
            this.zhangmuTableAdapter.Fill(this.jiZhangDataSet7.Zhangmu);
            // TODO: 这行代码将数据加载到表“jiZhangDataSet.Zhanghu”中。您可以根据需要移动或删除它。
           
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhangmu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Zhangmu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "Zhangmu";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Zhangmu"].Rows.Count;//总的行数或者记录数
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
            string sql = string.Format("select * from Zhangmu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, p, j, "Zhangmu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView1.DataMember = "Zhangmu";                    //绑定ds的表名为shetuanxinxi


            ds = null;//清空数据集
        }

        private void BindData()
        {

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhangmu where 操作人='" + this.p + "'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Zhangmu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "Zhangmu";                    //绑定ds的表名为shetuanxinxi
            int i = ds.Tables["Zhangmu"].Rows.Count;//总的行数或者记录数
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
                if (DialogResult.Yes == MessageBox.Show("是否删除选中的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {

                    for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)  //循环遍历所有行
                    {

                        //获取点击datagridview1的行的 行号
                        int r = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value);
                        string name = Convert.ToString(dataGridView1.SelectedRows[i].Cells[1].Value);

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);  //使用获得的ID删除数据库的数据

                        SqlConnection conn = new SqlConnection(str);                            //实例化链接
                        conn.Open();                        //打了链接
                        string sql = "delete from Zhangmu where ID='" + r + "'";
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
            BindData();
        }

        private void soucha_Click(object sender, EventArgs e)
        {
            start = 0;//第一行
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Zhangmu where 类型名称 like'%" + 搜查.Text.Trim() + "%' or 助记码 like'%" + 搜查.Text.Trim() + "%' or 类型分类 like'%" + 搜查.Text.Trim() + "%'");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句

            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Zhangmu");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView1.DataMember = "Zhangmu";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Zhangmu"].Rows.Count;//总的行数或者记录数                    
            for (int a = 0; a < i; a++)
            {
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
            }
            bbb.Text = Convert.ToString(start + 1);     //第几页
            bb.Text = Convert.ToString((i / size) + 1);    //共有几页
            toolStripLabel2.Text = i.ToString();  //获取总行数的记录
            //show1(0, size);
            conn.Close();
            conn.Dispose();

           
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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            搜查.Text = "";
            BindData();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
