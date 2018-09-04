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

namespace Login.baobiao
{
    public partial class Form2 : DockContent
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jiZhangDataSet13.Zhichu”中。您可以根据需要移动或删除它。
            this.zhichuTableAdapter.Fill(this.jiZhangDataSet13.Zhichu);

            this.reportViewer1.RefreshReport();
        }
    }
}
