using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpOCR;

namespace CSharpOCR
{
   public class Common
    {
        /// <summary>
        /// 提取json中的数据
        /// </summary>
        public static string JsonToResult(string result)
        {
            StringBuilder str = new StringBuilder();
            var re = (BaiDuResult)DataConvert.JsonToObj(result, typeof(BaiDuResult));
            if (re != null && re.words_result!=null && re.words_result.Count > 0)
            {
                foreach (var item in re.words_result)
                {
                    str.Append(item.words + "\r\n");
                }
            }
            return str.ToString();
        }


        /// <summary>
        /// 提取json中的车牌号
        /// </summary>
        public static string JsonToResultCarNumber(string result)
        {
            //StringBuilder str = new StringBuilder();
            //var re = (CarModel)DataConvert.JsonToObj(result, typeof(CarModel));
            //if (re != null && re.data!= null && re.data.words_result!=null)
            //{
            //    str.Append( re.data.words_result.number);
            //}
            //return str.ToString();

            result = result.Replace("\"", "'");
            result = Regex.Match(result, "(?<='number': ').*?(?=',)").Value;
            return result;//=(result+"").Length>0?result:"未识别出结果"
        }
    }
}
