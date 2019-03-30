using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpOCR
{
   public class BDResultModel
    {
        /// <summary>
        /// 记录Id
        /// </summary>
        public string log_id { get; set; }

        /// <summary>
        /// 结果个数
        /// </summary>
        public int words_result_num { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public List<WordsResult> words_result { get; set; }




        public class WordsResult
        {
            public string words { get; set; }
        }
    }

   
}
