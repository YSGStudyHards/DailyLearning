using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Common
{
    public class AsynchronousMethods
    {
        public async void Test()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Test Task 1 completed.");
            });

            await Task.Run(() =>
            {
                Console.WriteLine("Test Task 2 completed.");
            });

            // 等待所有任务完成
            Task.WaitAll();
        }

        public async Task TestDoSomeAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Async method completed.");
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="url">下载地址</param>
        public void DownloadFile(string url)
        {
            // 创建一个WebClient实例
            WebClient client = new WebClient();

            // 启用异步下载文件操作
            client.DownloadFileAsync(new Uri(url), "file.txt");

            // 注册DownloadFileCompleted事件处理程序【定义异步操作完成后的回调函数】
            client.DownloadFileCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    Console.WriteLine("文件下载出现错误：{0}", e.Error.Message);
                }
                else
                {
                    Console.WriteLine("文件下载完成！");
                }
            };

            Console.WriteLine("按任意键退出程序");
            Console.ReadKey();
        }

        public static async Task ThrowExceptionAsync()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException("Something went wrong");
        }

        public static async void HandleButtonClickAsync()
        {
            try
            {
                await ThrowExceptionAsync().ConfigureAwait(false);
                Console.WriteLine("This line will not be executed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
