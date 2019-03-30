using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpOCR
{
   public class BaiduTool
    {

        #region 通用文字识别 每天50000次
        /// <summary>
        /// 通用文字识别本地图片
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string GeneralBasicDemo(string imgPath)
        {
            string res = "";
           
                var image = File.ReadAllBytes(imgPath);
                // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获

                var options = new Dictionary<string, object>
                {
                    {"language_type", "CHN_ENG"},
                    {"detect_direction", "true"},
                    {"detect_language", "true"},
                    {"probability", "true"}
                 };
                // 带参数调用通用文字识别, 图片参数为本地图片
                var result = BaiduConfig.client.GeneralBasic(image, options);
                res = result.ToString();
           
            return res;
        }

        /// <summary>
        /// 通用文字识别网络图片
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string GeneralBasicUrlDemo(string imgPath)
        {
            string res = "";
            
                var url = imgPath;
                // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
                var options = new Dictionary<string, object>
                {
                    {"language_type", "CHN_ENG"},
                    {"detect_direction", "true"},
                    {"detect_language", "true"},
                    {"probability", "true"}
                 };
                // 带参数调用通用文字识别, 图片参数为远程url图片
                var result = BaiduConfig.client.GeneralBasicUrl(url, options);
                res = result.ToString();
           
            return res;

        }
        #endregion


        /// <summary>
        /// 高精度识别本地图片,每天200次
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string AccurateBasicDemo(string imgPath)
        {
            string res = "";
           
                var image = File.ReadAllBytes(imgPath);
                // 调用通用文字识别（高精度版），可能会抛出网络等异常，请使用try/catch捕获

                // 如果有可选参数
                var options = new Dictionary<string, object>{
                {"detect_direction", "true"}
                 };
                // 带参数调用通用文字识别（高精度版）
               var result = BaiduConfig.client.AccurateBasic(image, options);
                res = result.ToString();
           
             return res;
        }

        #region 识别特殊字体,背景复杂的网络图片,每天500次
        /// <summary>
        /// 识别网络图片-文件
        /// </summary>
        /// <returns></returns>
        public string WebImageDemo(string imgPath)
        {
            var image = File.ReadAllBytes("图片文件路径");
            // 调用网络图片文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获        

            var options = new Dictionary<string, object>{
        {"detect_direction", "true"},
        {"detect_language", "true"}};
            // 带参数调用网络图片文字识别, 图片参数为本地图片
            return BaiduConfig.client.WebImage(image, options).ToString();

        }

        /// <summary>
        /// 识别网络图片-链接
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public string WebImageUrlDemo(string imgPath)
        {
            var url = imgPath;
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"detect_direction", "true"},
        {"detect_language", "true"}};
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.WebImageUrl(url, options).ToString();
        }
        #endregion

  
        /// <summary>
        /// 识别图片中的数字
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string NumbersDemo(string imgPath)
        {
            var url =File.ReadAllBytes( imgPath);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"recognize_granularity", "big"},
        {"detect_direction", "true"}
    };
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.Numbers(url, options).ToString();
        }


        /// <summary>
        /// 手写文字识别
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string HandwritingDemo(string imgPath)
        {
            var url = File.ReadAllBytes(imgPath);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"recognize_granularity", "big"}
    };
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.Handwriting(url, options).ToString();
        }


        #region 表格文字识别

        /// <summary>
        /// 表格文字识别请求,每天50次
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string TableRecognitionRequestDemo(string imgPath)
        {
            var url = File.ReadAllBytes(imgPath);
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.TableRecognitionRequest(url).ToString();
        }
        /// <summary>
        /// 获取表格识别的结果,不限次
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public static string TableRecognitionGetResultDemo(string requestId)
        {
            return BaiduConfig.client.TableRecognitionGetResult(requestId).ToString();
        }


        #endregion

        /// <summary>
        /// 车牌识别
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public static string LicensePlateDemo(string imgPath)
        {
            var url = File.ReadAllBytes(imgPath);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"multi_detect", "true"}
    };
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.LicensePlate(url, options).ToString();
        }

        public string Demo(string imgPath)
        {
            var url = File.ReadAllBytes(imgPath);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"detect_direction", "true"},
        {"detect_language", "true"}};
            // 带参数调用网络图片文字识别, 图片参数为远程url图片
            return BaiduConfig.client.WebImageUrl("", options).ToString();
        }
    }
}
