using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CSharpOCR
{
    public class JsonHelper
    {
        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ObjectToJSON(object obj)
        {
            string res = string.Empty;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //byte[] b = Encoding.UTF8.GetBytes(jss.Serialize(obj));
                //return Encoding.UTF8.GetString(b);


                //在这里进行了第二次转义
                res = jss.Serialize(obj);


                //if (res.Contains("\""))
                //{
                //    res = res.Replace("\"", "'");
                //}
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
            }
        }

        /// <summary> 
        /// 数据表转键值对集合
        /// 把DataTable转成 List集合, 存每一行 
        /// 集合中放的是键值对字典,存每一列 
        /// </summary> 
        /// <param name="dt">数据表</param> 
        /// <returns>哈希表数组</returns> 
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list
                 = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }

        /// <summary> 
        /// 数据集转键值对数组字典 
        /// </summary> 
        /// <param name="dataSet">数据集</param> 
        /// <returns>键值对数组字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> DataSetToDic(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> result = new Dictionary<string, List<Dictionary<string, object>>>();

            foreach (DataTable dt in ds.Tables)
                result.Add(dt.TableName, DataTableToList(dt));

            return result;
        }

        /// <summary> 
        /// 数据表转JSON 
        /// </summary> 
        /// <param name="dataTable">数据表</param> 
        /// <returns>JSON字符串</returns> 
        public static string DataTableToJSON(DataTable dt)
        {
            return ObjectToJSON(DataTableToList(dt));
        }

        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JSONToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }

        /// <summary> 
        /// 将JSON文本转换为数据表数据 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据表字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> TablesDataFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }

        /// <summary> 
        /// 将JSON文本转换成数据行 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据行的字典</returns>
        public static Dictionary<string, object> DataRowFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, object>>(jsonText);
        }

        /// <summary>
        /// 数据行转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static dynamic DataRowToObject<T>(DataRow row, T obj)
        {
            if (row != null)
            {
                //利用反射获得属性的所有公共属性
                Type modelType = obj.GetType();
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    //查找实体是否存在列表相同的公共属性
                    PropertyInfo proInfo = modelType.GetProperty(row.Table.Columns[i].ColumnName);
                    if (proInfo != null && row[i] != DBNull.Value)
                    {                                            
                        proInfo.SetValue(obj, row[i], null);//用索引值设置属性值
                    }
                }
            }
            return obj;
        }

      
    }
}
