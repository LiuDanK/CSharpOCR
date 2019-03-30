using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace CSharpOCR
{
    /// <summary>
    /// 自定义类型转换类
    /// </summary>
    public class DataConvert
    {

        /// <summary>
        /// 字符串转换为整形
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ConvertInt(string obj)
        {
            int result;
            if (int.TryParse(obj, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 字符串转化decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ConvertDecimal(string obj)
        {
            decimal result;
            if (decimal.TryParse(obj, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 将dynamic数据转换为字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DynamicToString(dynamic data)
        {
            if (data == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(data);
            }
        }
        /// <summary>
        /// 将dynamic数据转换为整数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int DynamicToInt(dynamic data)
        {
            if (data == null)
            {
                return 0;
            }
            else
            {
                string temp = Convert.ToString(data);
                return ConvertInt(temp);
            }
        }
        /// <summary>
        /// 将dynamic数据转换为Decimal浮点数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal DynamicToDecimal(dynamic data)
        {
            if (data == null)
            {
                return 0;
            }
            else
            {
                string temp = Convert.ToString(data);
                return ConvertDecimal(temp);
            }
        }

        #region  Json的转化
        /// <summary>
        /// 可序列化的对象，可直接转换为json格式
        /// </summary>
        /// <param name="obj">可序列化的对象</param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        /// <summary>
        /// DataTable表转为json格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string TableToJson(DataTable dt)
        {
            StringBuilder strResult = new StringBuilder();
            strResult.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //strResult.Append("[{aa:1,bb:2,cc:3},{aa:5,bb:6,cc:7}]");
                strResult.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strResult.Append(dt.Columns[j] + ":\"" + dt.Rows[i][j] + "\"");
                    if (j != dt.Columns.Count - 1)
                    {
                        strResult.Append(",");
                    }
                }
                strResult.Append("}");
                if (i != dt.Rows.Count - 1)
                {
                    strResult.Append(",");
                }
            }
            strResult.Append("]");
            return strResult.ToString();
        }
        /// <summary>
        /// DataTable转化为json格式
        /// </summary>
        /// <param name="jsonName">DataTable表名称</param>
        /// <param name="dt">DataTable表</param>
        /// <returns></returns>
        public static string TableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTable2Json(DataTable dt, int totalCount)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"total\":{0}, ", totalCount);
            jsonBuilder.Append("\"rows\":[ ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            try
            {
                //转换json格式
                strJson = strJson.Replace(" ", "");
                strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
                //取出表名   
                var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
                string strName = rg.Match(strJson).Value;
                DataTable tb = null;
                //去除表名   
                strJson = strJson.Substring(strJson.IndexOf("[") + 1);
                strJson = strJson.Substring(0, strJson.IndexOf("]"));

                //获取数据   
                rg = new Regex(@"(?<={)[^}]+(?=})");
                MatchCollection mc = rg.Matches(strJson);
                for (int i = 0; i < mc.Count; i++)
                {
                    string strRow = mc[i].Value;
                    string[] strRows = strRow.Split('*');

                    //创建表   
                    if (tb == null)
                    {
                        tb = new DataTable();
                        tb.TableName = strName;
                        foreach (string str in strRows)
                        {
                            var dc = new DataColumn();
                            string[] strCell = str.Split('#');

                            if (strCell[0].Substring(0, 1) == "\"")
                            {
                                int a = strCell[0].Length;
                                dc.ColumnName = strCell[0].Substring(1, a - 2);
                            }
                            else
                            {
                                dc.ColumnName = strCell[0];
                            }
                            tb.Columns.Add(dc);
                        }
                        tb.AcceptChanges();
                    }
                    //增加内容   
                    DataRow dr = tb.NewRow();
                    for (int r = 0; r < strRows.Length; r++)
                    {
                        dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                    }
                    tb.Rows.Add(dr);
                    tb.AcceptChanges();
                }
                return tb;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 将json转换为DataTable 加最外边的{} 加表名称
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTableNew(string strJson)
        {
            try
            {
                strJson = "{\"dtJson\":" + strJson.Replace("\r", "").Replace("\n", "") + "}";

                //转换json格式
                strJson = strJson.Replace(" ", "").Replace("null","");
                strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
                //取出表名   
                var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
                string strName = rg.Match(strJson).Value;
                DataTable tb = null;
                //去除表名   
                strJson = strJson.Substring(strJson.IndexOf("[") + 1);
                strJson = strJson.Substring(0, strJson.IndexOf("]"));

                //获取数据   
                rg = new Regex(@"(?<={)[^}]+(?=})");
                MatchCollection mc = rg.Matches(strJson);
                for (int i = 0; i < mc.Count; i++)
                {
                    string strRow = mc[i].Value;
                    string[] strRows = strRow.Split('*');

                    //创建表   
                    if (tb == null)
                    {
                        tb = new DataTable();
                        tb.TableName = strName;
                        foreach (string str in strRows)
                        {
                            var dc = new DataColumn();
                            string[] strCell = str.Split('#');

                            if (strCell[0].Substring(0, 1) == "\"")
                            {
                                int a = strCell[0].Length;
                                dc.ColumnName = strCell[0].Substring(1, a - 2);
                            }
                            else
                            {
                                dc.ColumnName = strCell[0];
                            }
                            tb.Columns.Add(dc);
                        }
                        tb.AcceptChanges();
                    }
                    //增加内容   
                    DataRow dr = tb.NewRow();
                    for (int r = 0; r < strRows.Length; r++)
                    {
                        dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                    }
                    tb.Rows.Add(dr);
                    tb.AcceptChanges();
                }
                return tb;
            }
            catch 
            {
                return null;
            }

        }

        #endregion

        /// <summary>
        /// json字符串转换为任意类型，如List<T>
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <param name="t">要转换的数据类型</param>
        /// <returns></returns>
        public static Object JsonToObj(String json, Type t)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, t);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将table表的某一列转换为一个字符串，用逗号间隔
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Column"></param>
        /// <returns></returns>
        public static string ColumnToString(DataTable dt, string Column)
        {
            string result = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        result = result + dt.Rows[i][Column].ToString();
                    }
                    else
                    {
                        result = result + dt.Rows[i][Column].ToString() + ",";
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 将父类中的值赋值给其子类
        /// </summary>
        /// <typeparam name="TChild">子类类型</typeparam>
        /// <typeparam name="TParent">父类类型</typeparam>
        /// <param name="parent">父类变量</param>
        /// <returns>返回值中，父类拥有的值，子类都有</returns>
        public static TChild AutoCopy<TChild, TParent>(TParent parent) where TChild : TParent, new()
        {
            TChild child = new TChild();
            var parentType = typeof(TParent);
            var proties = parentType.GetProperties();
            foreach (var pro in proties)
            {
                if (pro.CanRead && pro.CanWrite)
                {
                    pro.SetValue(child, pro.GetValue(parent, null), null);
                }
            }
            return child;
        }

        /// <summary>  
        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>  
        /// <param name="isStoreDB">是否存入数据库DateTime字段，date时间范围没事，取出展示不用设置TRUE</param>  
        /// <returns>返回datatable结果</returns>  
        public static DataTable ListToTable<T>(List<T> list, bool isStoreDB = true)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            try
            {
                foreach (var item in proInfos)
                {
                    dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型  
                }
                foreach (var item in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var proInfo in proInfos)
                    {
                        object obj = proInfo.GetValue(item, null);
                        if (obj == null)
                        {
                            continue;
                        }
                        //if (obj != null)  
                        // {  
                        if (isStoreDB && proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                        {
                            continue;
                        }
                        // dr[proInfo.Name] = proInfo.GetValue(item);  
                        dr[proInfo.Name] = obj;
                        // }  
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch 
            {

            }
            return dt;
        }
        /// <summary>  
        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>  
        /// <returns>返回datatable结果</returns>  
        public static DataTable ListToTableItemString<T>(List<T> list)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            try
            {
                foreach (var item in proInfos)
                {
                    dt.Columns.Add(item.Name); //添加列明及对应类型   //item.PropertyType
                }
                foreach (var item in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var proInfo in proInfos)
                    {
                        object obj = proInfo.GetValue(item, null);
                        if (obj == null)
                        {
                            continue;
                        }
                        //if (obj != null)  
                        // {  
                        if (proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                        {
                            continue;
                        }
                        // dr[proInfo.Name] = proInfo.GetValue(item);  
                        dr[proInfo.Name] = obj;
                        // }  
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch
            {

            }
            return dt;
        }

    }
}
