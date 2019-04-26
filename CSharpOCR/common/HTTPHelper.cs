using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace CSharpOCR
{
    public class HTTPHelper
   {
        public HTTPHelper()
        {
                
        }

        /// <summary>
        /// json格式参数post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">参数,json格式</param>
        /// <returns></returns>
        public static string PostJson(string url, string postData)
        {
            string result = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.Timeout = 1000 * 10;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Post上传文件,含其他参数(Json)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="fileName"></param>
        public static void PostUpload(string url,string postData,string fileName)
        {
            //边界

            string boundary = DateTime.Now.Ticks.ToString("x");

            HttpWebRequest uploadRequest = (HttpWebRequest)WebRequest.Create(url);//url为上传的地址

            uploadRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            uploadRequest.Method = "POST";

            uploadRequest.Accept = "*/*";

            uploadRequest.KeepAlive = true;

            uploadRequest.Headers.Add("Accept-Language", "zh-cn");

            uploadRequest.Headers.Add("Accept-Encoding", "gzip, deflate");

            uploadRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //uploadRequest.Headers["Cookie"] = cookies;//上传文件时需要的cookies



            WebResponse reponse;

            //创建一个内存流

            Stream memStream = new MemoryStream();



            //确定上传的文件路径

            if (!String.IsNullOrEmpty(fileName))

            {

                boundary = "--" + boundary;



                //添加上传文件参数格式边界

                string paramFormat = boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}\r\n";

                NameValueCollection param = new NameValueCollection();

                param.Add("fname", Guid.NewGuid().ToString() + Path.GetExtension(fileName));



                //写上参数

                foreach (string key in param.Keys)

                {

                    string formitem = string.Format(paramFormat, key, param[key]);

                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);

                    memStream.Write(formitembytes, 0, formitembytes.Length);

                }



                //添加上传文件数据格式边界

                string dataFormat = boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\nContent-Type:application/octet-stream\r\n\r\n";

                string header = string.Format(dataFormat, "Filedata", Path.GetFileName(fileName));

                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                memStream.Write(headerbytes, 0, headerbytes.Length);



                //获取文件内容

                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                byte[] buffer = new byte[1024];

                int bytesRead = 0;



                //将文件内容写进内存流

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)

                {

                    memStream.Write(buffer, 0, bytesRead);

                }

                fileStream.Close();



                //添加文件结束边界

                byte[] boundarybytes = System.Text.Encoding.UTF8.GetBytes("\r\n\n" + boundary + "\r\nContent-Disposition: form-data; name=\"Upload\"\r\n\nSubmit Query\r\n" + boundary + "--");

                memStream.Write(boundarybytes, 0, boundarybytes.Length);



                //设置请求长度

                uploadRequest.ContentLength = memStream.Length;

                //获取请求写入流

                Stream requestStream = uploadRequest.GetRequestStream();





                //将内存流数据读取位置归零

                memStream.Position = 0;

                byte[] tempBuffer = new byte[memStream.Length];

                memStream.Read(tempBuffer, 0, tempBuffer.Length);

                memStream.Close();



                //将内存流中的buffer写入到请求写入流

                requestStream.Write(tempBuffer, 0, tempBuffer.Length);

                requestStream.Close();

            }



            //获取到上传请求的响应

            reponse = uploadRequest.GetResponse();
        }


        //public  void PostUpload2(string url, Dictionary<string, object> postData, string fileName)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        using (var multipartFormDataContent = new MultipartFormDataContent())
        //        {
        //            var values = new[]
        //            {
        //    new KeyValuePair<string, string>("tp", "2")
        //};
        //            foreach (var keyValuePair in values)
        //            {
        //                multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
        //                    String.Format("\"{0}\"", keyValuePair.Key));
        //            }

        //            multipartFormDataContent.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(@"D:\git.jpeg")),
        //                "\"pic\"",
        //                "\"git.jpeg\"");

        //            var requestUri = "http://192.168.0.47/api/Img/PostFiles";
        //            var html = client.PostAsync(requestUri, multipartFormDataContent).Result.Content.ReadAsStringAsync().Result;
                  
        //        }
        //    }
        //}
    }
}
