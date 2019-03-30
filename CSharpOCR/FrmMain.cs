using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpOCR
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 图片路径或链接
        /// </summary>
        private string imgPath = @"../../index.png";

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtFilePath.Text = imgPath;

            //文件路径检查
            foreach (var item in tabPage1.Controls)
            {
                ((MyButton)item).Click += (a, b) => 
                {
                    if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
                    {
                        MessageBox.Show("请先选择文件或者填入图片链接");
                        return;
                    }
                    else
                    {
                        imgPath = txtFilePath.Text.Trim();
                    }
                };
            }
        }

       

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = ".*jpg|.*jpg|*.png|*.png|*.bmp|*.bmp";
            open.Multiselect = false;
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = open.FileName;
            }
        }



        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            FileInfo file = new FileInfo(path);
            if (file.Extension.Equals(".jpg") || file.Extension.Equals(".png") || file.Extension.Equals(".bmp"))
            {
                imgPath= txtFilePath.Text = path.Trim();
                imgFile.Image = Image.FromFile(path);
            }
            else
            {
                MessageBox.Show("该文件类型不受支持,仅支持 .jpg|.png|.bmp格式文件");
            }
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 百度通用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommon_Click(object sender, EventArgs e)
        {
            //var result = BaiduTool.GeneralBasicDemo(imgPath);
            txtResult.Text = Common.JsonToResult(BaiduTool.GeneralBasicDemo(imgPath));
        }

        private void btnBest_Click(object sender, EventArgs e)
        {
            txtResult.Text = Common.JsonToResult(BaiduTool.AccurateBasicDemo(imgPath));
        }
    }
}
