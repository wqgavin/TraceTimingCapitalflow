namespace TraceTimingCapitalflow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtend = new System.Windows.Forms.TextBox();
            this.txtstart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // txtinfo
            // 
            this.txtinfo.Location = new System.Drawing.Point(5, 111);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtinfo.Size = new System.Drawing.Size(377, 125);
            this.txtinfo.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtend);
            this.panel1.Controls.Add(this.txtstart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radio2);
            this.panel1.Controls.Add(this.radio1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(131, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 93);
            this.panel1.TabIndex = 4;
            // 
            // txtend
            // 
            this.txtend.Location = new System.Drawing.Point(169, 58);
            this.txtend.Name = "txtend";
            this.txtend.Size = new System.Drawing.Size(60, 21);
            this.txtend.TabIndex = 10;
            this.txtend.Text = "15:01:00";
            // 
            // txtstart
            // 
            this.txtstart.Location = new System.Drawing.Point(86, 58);
            this.txtstart.Name = "txtstart";
            this.txtstart.Size = new System.Drawing.Size(60, 21);
            this.txtstart.TabIndex = 9;
            this.txtstart.Text = "09:30:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "天数";
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Location = new System.Drawing.Point(3, 59);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(65, 16);
            this.radio2.TabIndex = 7;
            this.radio2.TabStop = true;
            this.radio2.Text = "每3分钟";
            this.radio2.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Location = new System.Drawing.Point(3, 16);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(47, 16);
            this.radio1.TabIndex = 6;
            this.radio1.TabStop = true;
            this.radio1.Text = "尾盘";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "30";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "历史采集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "--";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "实时采集";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 239);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtinfo);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form1";
            this.Text = "收集时段资金流";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtinfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtend;
        private System.Windows.Forms.TextBox txtstart;
        private System.Windows.Forms.Label label2;
    }
}

