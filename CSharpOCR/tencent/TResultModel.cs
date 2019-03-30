using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpOCR
{
    class TResultModel
    {
        public class Itemcoord
        {
            /// <summary>
            /// X
            /// </summary>
            public int x { get; set; }
            /// <summary>
            /// Y
            /// </summary>
            public int y { get; set; }
            /// <summary>
            /// Width
            /// </summary>
            public int width { get; set; }
            /// <summary>
            /// Height
            /// </summary>
            public int height { get; set; }
        }

        public class Words
        {
            /// <summary>
            /// 夏
            /// </summary>
            public string character { get; set; }
            /// <summary>
            /// Confidence
            /// </summary>
            public double confidence { get; set; }
        }

        public class Item_list
        {
            /// <summary>
            /// 
            /// </summary>
            public string item { get; set; }
            /// <summary>
            /// 夏天的飞鸟，飞到我窗前唱歌，又飞去了。
            /// </summary>
            public string itemstring { get; set; }
            /// <summary>
            /// Itemcoord
            /// </summary>
            public List<Itemcoord> itemcoord { get; set; }
            /// <summary>
            /// Words
            /// </summary>
            public List<Words> words { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// Item_list
            /// </summary>
            public List<Item_list> item_list { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// Ret
            /// </summary>
            public int ret { get; set; }
            /// <summary>
            /// ok
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// Data
            /// </summary>
            public Data data { get; set; }
        }

    }
}
