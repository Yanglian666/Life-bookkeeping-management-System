namespace Login.baobiao
{
    partial class Form1
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
            this.jiZhangDataSet12 = new Login.JiZhangDataSet12();
            this.shouruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shouruTableAdapter = new Login.JiZhangDataSet12TableAdapters.ShouruTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shouruBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "newshou";
            reportDataSource1.Value = this.shouruBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Login.baobiao.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(954, 600);
            this.reportViewer1.TabIndex = 0;
            // 
            // jiZhangDataSet12
            // 
            this.jiZhangDataSet12.DataSetName = "JiZhangDataSet12";
            this.jiZhangDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shouruBindingSource
            // 
            this.shouruBindingSource.DataMember = "Shouru";
            this.shouruBindingSource.DataSource = this.jiZhangDataSet12;
            // 
            // shouruTableAdapter
            // 
            this.shouruTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 600);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shouruBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private JiZhangDataSet12 jiZhangDataSet12;
        private System.Windows.Forms.BindingSource shouruBindingSource;
        private JiZhangDataSet12TableAdapters.ShouruTableAdapter shouruTableAdapter;
    }
}