using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace CSharpOCR
{
    public class TesseractTool
    {
        /// <summary>
        /// 识别为中文
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string ConvertStringZN(string imgPath)
        {
            string res = "";
           
                TesseractEngine tesseract = new TesseractEngine("./tessdata", "chi_sim", EngineMode.Default);
                if (!string.IsNullOrEmpty(imgPath))
                {
                    var img = new Bitmap(imgPath);
                    res= tesseract.Process(img).GetText();
                }
          
            return res;
        }

        /// <summary>
        /// 识别为英文
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string ConvertStringEN(string imgPath)
        {
            string res = "";
          
                TesseractEngine tesseract = new TesseractEngine("./tessdata", "chi_sim", EngineMode.Default);
                if (!string.IsNullOrEmpty(imgPath))
                {
                    var img = new Bitmap(imgPath);
                    res = tesseract.Process(img).GetText();
                }
          
            return res;
        }
    }
}
