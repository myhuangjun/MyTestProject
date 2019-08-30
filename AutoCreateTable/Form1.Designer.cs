namespace AutoCreateTable
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textConn = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPrimary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCols = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前连接:";
            // 
            // textConn
            // 
            this.textConn.Location = new System.Drawing.Point(89, 13);
            this.textConn.Name = "textConn";
            this.textConn.Size = new System.Drawing.Size(413, 21);
            this.textConn.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(516, 13);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(373, 349);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "创建表";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "表名:";
            // 
            // textTableName
            // 
            this.textTableName.Location = new System.Drawing.Point(89, 49);
            this.textTableName.Name = "textTableName";
            this.textTableName.Size = new System.Drawing.Size(166, 21);
            this.textTableName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "主键:";
            // 
            // textPrimary
            // 
            this.textPrimary.Location = new System.Drawing.Point(326, 49);
            this.textPrimary.Name = "textPrimary";
            this.textPrimary.Size = new System.Drawing.Size(176, 21);
            this.textPrimary.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "列名及类型:";
            // 
            // textCols
            // 
            this.textCols.Location = new System.Drawing.Point(89, 83);
            this.textCols.Multiline = true;
            this.textCols.Name = "textCols";
            this.textCols.Size = new System.Drawing.Size(413, 163);
            this.textCols.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 384);
            this.Controls.Add(this.textCols);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPrimary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTableName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.textConn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "自动生成表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textConn;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPrimary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCols;
    }
}

