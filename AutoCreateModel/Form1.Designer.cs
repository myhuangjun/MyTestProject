namespace AutoCreateModel
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
            this.textBox_conn = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.comboBox_tables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_nameSpace = new System.Windows.Forms.TextBox();
            this.button_create = new System.Windows.Forms.Button();
            this.checkBox_savefile = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库链接:";
            // 
            // textBox_conn
            // 
            this.textBox_conn.Location = new System.Drawing.Point(105, 18);
            this.textBox_conn.Name = "textBox_conn";
            this.textBox_conn.Size = new System.Drawing.Size(415, 21);
            this.textBox_conn.TabIndex = 1;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(548, 15);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 2;
            this.button_test.Text = "测试连接";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // comboBox_tables
            // 
            this.comboBox_tables.FormattingEnabled = true;
            this.comboBox_tables.Location = new System.Drawing.Point(105, 60);
            this.comboBox_tables.Name = "comboBox_tables";
            this.comboBox_tables.Size = new System.Drawing.Size(109, 20);
            this.comboBox_tables.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "表名:";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(105, 110);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(415, 182);
            this.textBox_result.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "生成结果:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "命名空间:";
            // 
            // textBox_nameSpace
            // 
            this.textBox_nameSpace.Location = new System.Drawing.Point(292, 59);
            this.textBox_nameSpace.Name = "textBox_nameSpace";
            this.textBox_nameSpace.Size = new System.Drawing.Size(104, 21);
            this.textBox_nameSpace.TabIndex = 8;
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(548, 60);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 9;
            this.button_create.Text = "生成";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // checkBox_savefile
            // 
            this.checkBox_savefile.AutoSize = true;
            this.checkBox_savefile.Checked = true;
            this.checkBox_savefile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_savefile.Location = new System.Drawing.Point(504, 62);
            this.checkBox_savefile.Name = "checkBox_savefile";
            this.checkBox_savefile.Size = new System.Drawing.Size(15, 14);
            this.checkBox_savefile.TabIndex = 10;
            this.checkBox_savefile.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "保存至文件:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 313);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_savefile);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBox_nameSpace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_tables);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.textBox_conn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_conn;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.ComboBox comboBox_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_nameSpace;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.CheckBox checkBox_savefile;
        private System.Windows.Forms.Label label5;
    }
}

