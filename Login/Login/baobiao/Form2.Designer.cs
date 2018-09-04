namespace Login.baobiao
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.jiZhangDataSet13 = new Login.JiZhangDataSet13();
            this.jiZhangDataSet13BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zhichuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zhichuTableAdapter = new Login.JiZhangDataSet13TableAdapters.ZhichuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet13BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhichuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "chu";
            reportDataSource1.Value = this.zhichuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Login.baobiao.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(930, 528);
            this.reportViewer1.TabIndex = 0;
            // 
            // jiZhangDataSet13
            // 
            this.jiZhangDataSet13.DataSetName = "JiZhangDataSet13";
            this.jiZhangDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jiZhangDataSet13BindingSource
            // 
            this.jiZhangDataSet13BindingSource.DataSource = this.jiZhangDataSet13;
            this.jiZhangDataSet13BindingSource.Position = 0;
            // 
            // zhichuBindingSource
            // 
            this.zhichuBindingSource.DataMember = "Zhichu";
            this.zhichuBindingSource.DataSource = this.jiZhangDataSet13BindingSource;
            // 
            // zhichuTableAdapter
            // 
            this.zhichuTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 528);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet13BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhichuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private JiZhangDataSet13 jiZhangDataSet13;
        private System.Windows.Forms.BindingSource jiZhangDataSet13BindingSource;
        private System.Windows.Forms.BindingSource zhichuBindingSource;
        private JiZhangDataSet13TableAdapters.ZhichuTableAdapter zhichuTableAdapter;
    }
}