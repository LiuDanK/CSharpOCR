using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var re = (ResultModel)DataConvert.JsonToObj(result, typeof(ResultModel));
            if (re != null && re.words_result.Count > 0)
            {
                foreach (var item in re.words_result)
                {
                    str.Append(item.words + "\r\n");
                }
            }
            return str.ToString();
        }
    }
}
