using Login.baobiao;
using Login.Password;
using Login.zhanghu;
using Login.zhangmu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Login
{
    public partial class Main : Form
    {
        private string p;


        public Main(string p)
        {

            InitializeComponent();// TODO: Complete member initialization
            this.p = p;
        }

        private void 账户信息_Click(object sender, EventArgs e)
        {

            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 账户信息)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            账户信息 mohe = new 账户信息(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void 记账信息_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 记账信息管理)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            记账信息管理 mohe = new 记账信息管理(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1,DockState.Document);
        }

        private void 账目信息_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 账目类型)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            账目类型 mohe = new 账目类型(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void 期末考试管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 账户信息)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            账户信息 mohe = new 账户信息(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void 校园新闻管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 记账信息管理)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            记账信息管理 mohe = new 记账信息管理(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, DockState.Document);
        }

        private void 账目_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is 账目类型)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            账目类型 mohe = new 账目类型(this.p);
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请到账户信息管理里进行操作！");
          
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请到账户信息管理里进行操作！");

        }

        private void 校园新闻管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            name.Text = this.p;
            Timer time = new Timer();
            time.Enabled = true;
            time.Interval = 1000;
            time.Tick += timerCD_Tick;
        }
        //动态时间
        private void timerCD_Tick(object sender, EventArgs e)
        {
            this.date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            修改密码 edit = new 修改密码(this.p);
            edit.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 guan = new 关于();
            guan.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is Form1)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            Form1 mohe = new Form1();
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void 学生权限管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is Form1)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            Form1 mohe = new Form1();
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is Form2)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            Form2 mohe = new Form2();
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);  
        }

        private void 教师权限管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent frm in this.dockPanel1.Contents)
            {
                if (frm is Form2)
                {
                    frm.Activate();     //激活子窗体
                    return;
                }
            }

            Form2 mohe = new Form2();
            //   a.MdiParent = this;
            mohe.Show(this.dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document);  
        }

    }

  
    }
    

