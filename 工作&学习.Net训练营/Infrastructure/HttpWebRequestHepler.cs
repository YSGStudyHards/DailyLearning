using System;
using System.IO;
using System.Net;
using System.Text;

namespace Infrastructure
{
    /// <summary>
    /// Http Web网络请求帮助类
    /// </summary>
    public class HttpWebRequestHepler
    {
        private static HttpWebRequestHepler _httpWebRequestHepler;
        private string _resContent;//响应内容
        private string _errInfo;//错误信息
        private int _responseCode;//响应状态码

        public static HttpWebRequestHepler _
        {
            get => _httpWebRequestHepler ?? (_httpWebRequestHepler = new HttpWebRequestHepler());
            set => _httpWebRequestHepler = value;
        }

        /// <summary>
        /// 数据请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="postData">请求参数</param>
        /// <param name="accessToken">授权token</param>
        /// <param name="contentType">请求标头值类型</param>
        /// <param name="method">请求方式</param>
        /// <returns></returns>
        public string HttpWebResponseData(string requestUrl, string postData, string accessToken = "", string contentType = "application/json", string method = "POST")
        {
            HttpWebResponse wr = null;

            try
            {
                //todo：指定请求包的安全协议，因为不知道你当前项目到底是哪个版本所以为了安全保障都加上
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

                var hp = (HttpWebRequest)WebRequest.Create(requestUrl);

                hp.KeepAlive = false;
                hp.ProtocolVersion = HttpVersion.Version10;

                hp.Timeout = 60 * 1000 * 10;//以毫秒为单位，设置等待超时10分钟
                hp.Method = method;
                hp.ContentType = contentType;
                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    hp.Headers.Add("Authorization", "Bearer " + accessToken);//增加headers请求头信息
                }


                if (postData != "")//带参数请求
                {
                    byte[] data = Encoding.UTF8.GetBytes(postData);
                    hp.ContentLength = data.Length;
                    Stream ws = hp.GetRequestStream();

                    // 发送数据
                    ws.Write(data, 0, data.Length);
                    ws.Close();
                }

                wr = (HttpWebResponse)hp.GetResponse();
                var sr = new StreamReader(wr.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8);

                this._resContent = sr.ReadToEnd();
                sr.Close();
                wr.Close();
            }
            catch (Exception exp)
            {
                this._errInfo += exp.Message;
                if (wr != null)
                {
                    this._responseCode = Convert.ToInt32(wr.StatusCode);
                }

                return this._resContent;
            }

            this._responseCode = Convert.ToInt32(wr.StatusCode);

            return this._resContent;
        }

    }
}
