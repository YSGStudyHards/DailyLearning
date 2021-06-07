using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Http网络请求帮助类
    /// </summary>
    public class HttpClientHelper
    {
        private static HttpClientHelper _httpClientHelper;

        public static HttpClientHelper _
        {
            get => _httpClientHelper ?? (_httpClientHelper = new HttpClientHelper());
            set => _httpClientHelper = value;
        }

        /// <summary>
        /// 向目标地址提交图片文件参数数据
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="bmpBytes">图片字节流</param>
        /// <param name="imgType">上传图片类型</param>
        /// <param name="fileName">图片名称</param>
        /// <returns></returns>
        public string HttpClientPost(string requestUrl, byte[] bmpBytes, string imgType, string fileName)
        {
            using (var httpClient = new HttpClient())
            {
                List<ByteArrayContent> byteArrayContents = new List<ByteArrayContent>();

                var imgTypeContent = new ByteArrayContent(Encoding.UTF8.GetBytes(imgType));
                imgTypeContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "imgType"
                };
                byteArrayContents.Add(imgTypeContent);

                var fileContent = new ByteArrayContent(bmpBytes);//填充图片文件二进制字节
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = fileName
                };
                byteArrayContents.Add(fileContent);

                var content = new MultipartFormDataContent();
                //将ByteArrayContent集合加入到MultipartFormDataContent中
                foreach (var byteArrayContent in byteArrayContents)
                {
                    content.Add(byteArrayContent);
                }

                try
                {
                    var result = httpClient.PostAsync(requestUrl, content).Result;//post请求
                    return result.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
