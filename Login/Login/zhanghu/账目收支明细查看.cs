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
    public partial class 账目收支明细查看 : Form
    {

        int i, start;//i为总行数，start为起始位置
        int size = 10;//定义一个每页显示的行数
        string str = "server=localhost;database=JiZhang;User ID=sa;Password=123456";
        private string p;
        public 账目收支明细查看(string name, string p)
        {
            // TODO: Complete member initialization
            InitializeComponent(); 
            this.Name = name;
            this.p = p;
        }
      
        private void 账目收支明细查看_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet6.Mingxi”中。您可以根据需要移动或删除它。
            this.mingxiTableAdapter2.Fill(this.jiZhangDataSet6.Mingxi);
            // TODO: 这行代码将数据加载到表“jiZhangDataSet5.Mingxi”中。您可以根据需要移动或删除它。
            this.mingxiTableAdapter1.Fill(this.jiZhangDataSet5.Mingxi);
           
           
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Mingxi where 操作人='" + this.p + "' and 账户名称='"+Name+"'order by ID desc");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Mingxi");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "Mingxi";                    //绑定ds的表名为shetuanxinxi
             i = ds.Tables["Mingxi"].Rows.Count;//总的行数或者记录数
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
            string sql = string.Format("select * from Mingxi where 操作人='" + this.p + "' and 账户名称='" + Name + "'order by ID desc");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, p, j, "Mingxi");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds
            dataGridView1.DataMember = "Mingxi";                    //绑定ds的表名为shetuanxinxi


            ds = null;//清空数据集
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);                            //实例化链接
            conn.Open();                        //打了链接
            string sql = string.Format("select * from Mingxi where 操作人='" + this.p + "' and 账户名称='" + Name + "'and 记账日期 between'" + date1.Text + "' and '" + date2.Text + "'order by ID desc");
            SqlCommand com = new SqlCommand(sql, conn);          //一个SQL语句
            SqlDataAdapter sda = new SqlDataAdapter(com);        //数据适配器
            DataSet ds = new DataSet();                         //DataSet表示数据在内存中的内容
            sda.Fill(ds, "Mingxi");                        //适配器匹配数据
            dataGridView1.DataSource = ds;                         //dataGridView1的数据源设为ds

            dataGridView1.DataMember = "Mingxi";                    //绑定ds的表名为shetuanxinxi
            i = ds.Tables["Mingxi"].Rows.Count;//总的行数或者记录数
            for (int a = 0; a < i; a++)
            {
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Rows[a].Height = 35;    //datagridView的行高度为35
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



    }
}
