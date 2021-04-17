using System;
using System.Collections.Generic;
using System.Net.Http;
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

        ///<summary>
        /// HttpClient Post异步网络请求
        /// </summary>
        /// <param name="requestUrl">url</param>
        /// <param name="bmpBytes">图片二进制字节流</param>
        /// <returns></returns>
        public async Task<string> HttpClientPost(string requestUrl, Byte[] bmpBytes)
        {
            string responseBody = string.Empty;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    #region headers
                    httpClient.DefaultRequestHeaders.Add("Method", "Post");
                    //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization","");//授权token
                    #endregion

                    var fileContent = new ByteArrayContent(bmpBytes);

                    //请求内容类型
                    fileContent.Headers.Add("Content-Type", "multipart/form-data");

                    HttpResponseMessage response = await httpClient.PostAsync(requestUrl, fileContent);

                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }




        ///// <summary>
        ///// 根据返回的tmpUploadUrl、uploadMethod和uploadHeaders上传文件(分片文件上传)
        ///// </summary>
        ///// <param name="bmpBytes">图片二进制字节流</param>
        ///// <param name="uploadHeaderObjects">上传文件时需要携带的的HTTP Header列表</param>
        ///// <param name="uploadUrlResponseObject">文件地址申请响应参数</param>
        ///// <returns></returns>
        //public string HttpClientUploadSlicingMediaFiles(Byte[] bmpBytes, dynamic uploadHeaderObjects, Filepart uploadUrlResponseObject)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        #region 自定义请求头

        //        client.DefaultRequestHeaders.Add("x-amz-content-sha256", Convert.ToString(uploadHeaderObjects["x-amz-content-sha256"]));
        //        client.DefaultRequestHeaders.Add("x-amz-date", Convert.ToString(uploadHeaderObjects["x-amz-date"]));
        //        client.DefaultRequestHeaders.Add("Host", Convert.ToString(uploadHeaderObjects["Host"]));
        //        #endregion

        //        var fileContent = new ByteArrayContent(bmpBytes);

        //        //请求内容类型
        //        fileContent.Headers.Add("Content-Type", Convert.ToString(uploadHeaderObjects["Content-Type"]));

        //        var result = new HttpResponseMessage();

        //        if (uploadUrlResponseObject.method == "PUT")
        //        {
        //            result = client.PutAsync(uploadUrlResponseObject.materialUrl, fileContent).Result;//put请求
        //        }
        //        else
        //        {
        //            result = client.PostAsync(uploadUrlResponseObject.materialUrl, fileContent).Result;//post请求
        //        }

        //        var reponseMessage = "";

        //        if (result.Content.ReadAsStringAsync().Result == "")//request success
        //        {
        //            //HttpResponseHeaders headerResult= result.Headers; //成功上传每个分片后注意保存返回的Headers，在分片合并时需要用到。
        //            //var googleGeneration=result.Headers.GetValues("x-google-generation");
        //            reponseMessage = result.Headers.ETag.ToString(); //result.Headers.GetValues("etag");必填实际上传分片文件时，教育中心服务端返回的名称为Etag的HTTP Header的值。
        //        }
        //        else
        //        {
        //            reponseMessage = result.Content.ReadAsStringAsync().Result;
        //        }

        //        return reponseMessage;

        //    }
        //}
    }
}
