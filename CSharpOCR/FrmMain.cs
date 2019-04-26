using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpOCR
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            
           
            InitializeComponent();
            //添加点击事件,判断是否选择了文件
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
                        Run(a,b);
                    }
                };
            }
        }

        /// <summary>
        /// 图片路径或链接
        /// </summary>
        private string imgPath = @"../../index.png";

        /// <summary>
        /// 表格识别获得的Id
        /// </summary>
        private string requestTbId = "";

        /// <summary>
        /// 开始识别的时间
        /// </summary>
        private DateTime beginTime;


        private void FrmMain_Load(object sender, EventArgs e)
        {
            //连接超时时间设置为十秒
            BaiduConfig.client.Timeout = 1000 * 10;
            //填充默认路径
            txtFilePath.Text = imgPath;

        }

        /// <summary>
        /// 执行程序前的检查
        /// </summary>
        private  void RunBefore()
        {
            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                MessageBox.Show("请先选择文件或者填入图片链接");
                return;
            }
            else
            {
                imgPath = txtFilePath.Text.Trim();
                beginTime = DateTime.Now;
                txtResult.Text = "";//清空结果
                gboxResult.Text = "识别中...";
                Thread.Sleep(100);
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
            open.Filter = "*.jpg|*.jpg|*.png|*.png|*.bmp|*.bmp";
            open.Multiselect = false;
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = open.FileName;
                imgFile.Image = Image.FromFile(open.FileName);
            }
        }


        #region 实现拖入文件
        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            FileInfo file = new FileInfo(path);
            if (file.Extension.Equals(".jpg") || file.Extension.Equals(".png") || file.Extension.Equals(".bmp"))
            {
                imgPath = txtFilePath.Text = path.Trim();
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
        #endregion




        #region 点击事件(弃用)
        /// <summary>
        /// 百度通用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommon_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.GeneralBasicDemo(imgPath));
        }

        private void btnBest_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.AccurateBasicDemo(imgPath));
        }

        private void btnSpecial_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.HandwritingDemo(imgPath));
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.WebImageDemo(imgPath));
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.HandwritingDemo(imgPath));
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResultCarNumber(BaiduTool.LicensePlateDemo(imgPath));
        }

        private void btnTableUp_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.TableRecognitionRequestDemo(imgPath));
        }

        private void btnTableDown_Click(object sender, EventArgs e)
        {
            RunBefore();
            txtResult.Text = Common.JsonToResult(BaiduTool.TableRecognitionGetResultDemo(requestTbId));
        }
        #endregion


        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            imgPath = txtFilePath.Text;
        }

        /// <summary>
        /// 识别结果发生变化,识别成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                txtResult.Text = "未识别出结果";
            }
            gboxResult.Text = "识别结束:耗时"+(DateTime.Now-beginTime).TotalSeconds+"秒";
          
        }

        #region 使用TesseractEngine的识别
        private void btnChinese_Click(object sender, EventArgs e)
        {
            RunBefore();
            new Thread(new ThreadStart(delegate ()
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                txtResult.Text = TesseractTool.ConvertStringZN(imgPath);
            })).Start();


        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            RunBefore();
            new Thread(new ThreadStart(delegate ()
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                txtResult.Text = TesseractTool.ConvertStringEN(imgPath);
            })).Start();

        }
        #endregion


        /// <summary>
        /// 反射调用方法
        /// </summary>
        public void Run(object sender, EventArgs e)
        {
           
                imgPath = txtFilePath.Text.Trim();
                beginTime = DateTime.Now;
                txtResult.Text = "正在识别中,请稍等...";//清空结果
                gboxResult.Text = "识别中...";
                Thread.Sleep(100);

                var btn = sender as MyButton;

                if (btn.Name != "btnEnglish" && btn.Name != "btnChinese")
                {
                    //使用反射调用方法
                    Type type = typeof(BaiduTool);
                    MethodInfo method = type.GetMethod(btn.Tag.ToString());
                    if (method != null)
                    {                
                        txtResult.Text = method.Invoke(type, new object[] { imgPath }).ToString();
                    }
                }
        }
    }
}
