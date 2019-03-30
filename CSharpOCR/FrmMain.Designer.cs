namespace CSharpOCR
{
    partial class FrmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imgFile = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabCommon = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnEnglish = new CSharpOCR.MyButton();
            this.btnChinese = new CSharpOCR.MyButton();
            this.btnTableDown = new CSharpOCR.MyButton();
            this.btnTableUp = new CSharpOCR.MyButton();
            this.btnCar = new CSharpOCR.MyButton();
            this.btnWrite = new CSharpOCR.MyButton();
            this.btnNum = new CSharpOCR.MyButton();
            this.btnSpecial = new CSharpOCR.MyButton();
            this.btnBest = new CSharpOCR.MyButton();
            this.btnCommon = new CSharpOCR.MyButton();
            this.btnIntroduce = new CSharpOCR.MyButton();
            this.myButton23 = new CSharpOCR.MyButton();
            this.myButton24 = new CSharpOCR.MyButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imgFile);
            this.groupBox1.Location = new System.Drawing.Point(17, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(535, 399);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片预览(可直接拖入)";
            // 
            // imgFile
            // 
            this.imgFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgFile.Image = global::CSharpOCR.Properties.Resources.index;
            this.imgFile.Location = new System.Drawing.Point(4, 23);
            this.imgFile.Margin = new System.Windows.Forms.Padding(4);
            this.imgFile.Name = "imgFile";
            this.imgFile.Size = new System.Drawing.Size(527, 372);
            this.imgFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFile.TabIndex = 0;
            this.imgFile.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Location = new System.Drawing.Point(17, 451);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(535, 399);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "识别结果";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(4, 23);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(527, 372);
            this.txtResult.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabCommon);
            this.groupBox3.Location = new System.Drawing.Point(584, 451);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(535, 399);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // tabCommon
            // 
            this.tabCommon.Controls.Add(this.tabPage1);
            this.tabCommon.Controls.Add(this.tabPage2);
            this.tabCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCommon.Location = new System.Drawing.Point(4, 23);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(4);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.SelectedIndex = 0;
            this.tabCommon.Size = new System.Drawing.Size(527, 372);
            this.tabCommon.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEnglish);
            this.tabPage1.Controls.Add(this.btnChinese);
            this.tabPage1.Controls.Add(this.btnTableDown);
            this.tabPage1.Controls.Add(this.btnTableUp);
            this.tabPage1.Controls.Add(this.btnCar);
            this.tabPage1.Controls.Add(this.btnWrite);
            this.tabPage1.Controls.Add(this.btnNum);
            this.tabPage1.Controls.Add(this.btnSpecial);
            this.tabPage1.Controls.Add(this.btnBest);
            this.tabPage1.Controls.Add(this.btnCommon);
            this.tabPage1.Controls.Add(this.btnIntroduce);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(519, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件版";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myButton23);
            this.tabPage2.Controls.Add(this.myButton24);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(519, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "链接版";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnSelectFile);
            this.groupBox4.Controls.Add(this.txtFilePath);
            this.groupBox4.Location = new System.Drawing.Point(584, 29);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(535, 399);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "请输入路径或者网络链接:";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(391, 61);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(100, 31);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(49, 63);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(271, 26);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnEnglish
            // 
            this.btnEnglish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnEnglish.ForeColor = System.Drawing.Color.White;
            this.btnEnglish.Location = new System.Drawing.Point(193, 271);
            this.btnEnglish.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(139, 59);
            this.btnEnglish.TabIndex = 16;
            this.btnEnglish.Text = "本地识别英文";
            this.btnEnglish.UseVisualStyleBackColor = false;
            // 
            // btnChinese
            // 
            this.btnChinese.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnChinese.ForeColor = System.Drawing.Color.White;
            this.btnChinese.Location = new System.Drawing.Point(21, 271);
            this.btnChinese.Margin = new System.Windows.Forms.Padding(4);
            this.btnChinese.Name = "btnChinese";
            this.btnChinese.Size = new System.Drawing.Size(139, 59);
            this.btnChinese.TabIndex = 15;
            this.btnChinese.Text = "本地识别中文";
            this.btnChinese.UseVisualStyleBackColor = false;
            // 
            // btnTableDown
            // 
            this.btnTableDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTableDown.ForeColor = System.Drawing.Color.White;
            this.btnTableDown.Location = new System.Drawing.Point(359, 181);
            this.btnTableDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnTableDown.Name = "btnTableDown";
            this.btnTableDown.Size = new System.Drawing.Size(139, 59);
            this.btnTableDown.TabIndex = 14;
            this.btnTableDown.Text = "表格识别";
            this.btnTableDown.UseVisualStyleBackColor = false;
            // 
            // btnTableUp
            // 
            this.btnTableUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTableUp.ForeColor = System.Drawing.Color.White;
            this.btnTableUp.Location = new System.Drawing.Point(193, 181);
            this.btnTableUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnTableUp.Name = "btnTableUp";
            this.btnTableUp.Size = new System.Drawing.Size(139, 59);
            this.btnTableUp.TabIndex = 13;
            this.btnTableUp.Text = "表格上传";
            this.btnTableUp.UseVisualStyleBackColor = false;
            // 
            // btnCar
            // 
            this.btnCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnCar.ForeColor = System.Drawing.Color.White;
            this.btnCar.Location = new System.Drawing.Point(21, 181);
            this.btnCar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(139, 59);
            this.btnCar.TabIndex = 12;
            this.btnCar.Text = "车牌识别";
            this.btnCar.UseVisualStyleBackColor = false;
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnWrite.ForeColor = System.Drawing.Color.White;
            this.btnWrite.Location = new System.Drawing.Point(359, 95);
            this.btnWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(139, 59);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "手写识别";
            this.btnWrite.UseVisualStyleBackColor = false;
            // 
            // btnNum
            // 
            this.btnNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnNum.ForeColor = System.Drawing.Color.White;
            this.btnNum.Location = new System.Drawing.Point(193, 95);
            this.btnNum.Margin = new System.Windows.Forms.Padding(4);
            this.btnNum.Name = "btnNum";
            this.btnNum.Size = new System.Drawing.Size(139, 59);
            this.btnNum.TabIndex = 10;
            this.btnNum.Text = "数字识别";
            this.btnNum.UseVisualStyleBackColor = false;
            // 
            // btnSpecial
            // 
            this.btnSpecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnSpecial.ForeColor = System.Drawing.Color.White;
            this.btnSpecial.Location = new System.Drawing.Point(21, 95);
            this.btnSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(139, 59);
            this.btnSpecial.TabIndex = 9;
            this.btnSpecial.Text = "特殊字体";
            this.btnSpecial.UseVisualStyleBackColor = false;
            // 
            // btnBest
            // 
            this.btnBest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnBest.ForeColor = System.Drawing.Color.White;
            this.btnBest.Location = new System.Drawing.Point(359, 8);
            this.btnBest.Margin = new System.Windows.Forms.Padding(4);
            this.btnBest.Name = "btnBest";
            this.btnBest.Size = new System.Drawing.Size(139, 59);
            this.btnBest.TabIndex = 8;
            this.btnBest.Text = "百度高精度";
            this.btnBest.UseVisualStyleBackColor = false;
            this.btnBest.Click += new System.EventHandler(this.btnBest_Click);
            // 
            // btnCommon
            // 
            this.btnCommon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnCommon.ForeColor = System.Drawing.Color.White;
            this.btnCommon.Location = new System.Drawing.Point(193, 8);
            this.btnCommon.Margin = new System.Windows.Forms.Padding(4);
            this.btnCommon.Name = "btnCommon";
            this.btnCommon.Size = new System.Drawing.Size(139, 59);
            this.btnCommon.TabIndex = 7;
            this.btnCommon.Text = "百度通用(推荐)";
            this.btnCommon.UseVisualStyleBackColor = false;
            this.btnCommon.Click += new System.EventHandler(this.btnCommon_Click);
            // 
            // btnIntroduce
            // 
            this.btnIntroduce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.btnIntroduce.ForeColor = System.Drawing.Color.White;
            this.btnIntroduce.Location = new System.Drawing.Point(21, 8);
            this.btnIntroduce.Margin = new System.Windows.Forms.Padding(4);
            this.btnIntroduce.Name = "btnIntroduce";
            this.btnIntroduce.Size = new System.Drawing.Size(139, 59);
            this.btnIntroduce.TabIndex = 6;
            this.btnIntroduce.Text = "使用说明";
            this.btnIntroduce.UseVisualStyleBackColor = false;
            // 
            // myButton23
            // 
            this.myButton23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.myButton23.ForeColor = System.Drawing.Color.White;
            this.myButton23.Location = new System.Drawing.Point(192, 9);
            this.myButton23.Margin = new System.Windows.Forms.Padding(4);
            this.myButton23.Name = "myButton23";
            this.myButton23.Size = new System.Drawing.Size(139, 59);
            this.myButton23.TabIndex = 19;
            this.myButton23.Text = "特殊字体";
            this.myButton23.UseVisualStyleBackColor = false;
            // 
            // myButton24
            // 
            this.myButton24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
            this.myButton24.ForeColor = System.Drawing.Color.White;
            this.myButton24.Location = new System.Drawing.Point(20, 9);
            this.myButton24.Margin = new System.Windows.Forms.Padding(4);
            this.myButton24.Name = "myButton24";
            this.myButton24.Size = new System.Drawing.Size(139, 59);
            this.myButton24.TabIndex = 18;
            this.myButton24.Text = "百度通用";
            this.myButton24.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1135, 865);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCR文字识别";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.PictureBox imgFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabCommon;
        private System.Windows.Forms.TabPage tabPage1;
        private MyButton btnTableDown;
        private MyButton btnTableUp;
        private MyButton btnCar;
        private MyButton btnWrite;
        private MyButton btnNum;
        private MyButton btnSpecial;
        private MyButton btnBest;
        private MyButton btnCommon;
        private MyButton btnIntroduce;
        private System.Windows.Forms.TabPage tabPage2;
        private MyButton myButton23;
        private MyButton myButton24;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private MyButton btnEnglish;
        private MyButton btnChinese;
        private System.Windows.Forms.Label label1;
    }
}

