namespace Login.zhanghu
{
    partial class 账户转账
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.zhanghuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jiZhangDataSet3 = new Login.JiZhangDataSet3();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.zhanghuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jiZhangDataSet2 = new Login.JiZhangDataSet2();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zhanghuTableAdapter = new Login.JiZhangDataSet2TableAdapters.ZhanghuTableAdapter();
            this.textBox3 = new System.Windows.Forms.RichTextBox();
            this.zhanghuTableAdapter1 = new Login.JiZhangDataSet3TableAdapters.ZhanghuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.zhanghuBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhanghuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(268, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 25;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 24;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(150, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 21);
            this.textBox2.TabIndex = 22;
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(148, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(193, 20);
            this.comboBox2.TabIndex = 21;
            // 
            // zhanghuBindingSource1
            // 
            this.zhanghuBindingSource1.DataMember = "Zhanghu";
            this.zhanghuBindingSource1.DataSource = this.jiZhangDataSet3;
            // 
            // jiZhangDataSet3
            // 
            this.jiZhangDataSet3.DataSetName = "JiZhangDataSet3";
            this.jiZhangDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(148, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 20);
            this.comboBox1.TabIndex = 20;
            // 
            // zhanghuBindingSource
            // 
            this.zhanghuBindingSource.DataMember = "Zhanghu";
            this.zhanghuBindingSource.DataSource = this.jiZhangDataSet2;
            // 
            // jiZhangDataSet2
            // 
            this.jiZhangDataSet2.DataSetName = "JiZhangDataSet2";
            this.jiZhangDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(65, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "转入说明：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(67, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "转入金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(65, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "转入账户：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(65, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "转出账户：";
            // 
            // zhanghuTableAdapter
            // 
            this.zhanghuTableAdapter.ClearBeforeFill = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(150, 149);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 58);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "";
            // 
            // zhanghuTableAdapter1
            // 
            this.zhanghuTableAdapter1.ClearBeforeFill = true;
            // 
            // 账户转账
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 281);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "账户转账";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "账户转账";
            this.Load += new System.EventHandler(this.账户转账_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zhanghuBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhanghuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiZhangDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JiZhangDataSet2 jiZhangDataSet2;
        private System.Windows.Forms.BindingSource zhanghuBindingSource;
        private JiZhangDataSet2TableAdapters.ZhanghuTableAdapter zhanghuTableAdapter;
        private System.Windows.Forms.RichTextBox textBox3;
        private JiZhangDataSet3 jiZhangDataSet3;
        private System.Windows.Forms.BindingSource zhanghuBindingSource1;
        private JiZhangDataSet3TableAdapters.ZhanghuTableAdapter zhanghuTableAdapter1;
    }
}