using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole
{
    public class MyAsyncClass : Component
    {
        /// <summary>
        /// 声明一个委托类型，用于定义异步操作的方法签名
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public delegate int MyAsyncDelegate(int arg);

        /// <summary>
        /// 声明一个事件，用于通知异步操作的完成
        /// </summary>
        public event MyAsyncDelegate OperationNameCompleted;

        /// <summary>
        /// 异步执行方法，接受一个参数 arg
        /// </summary>
        /// <param name="arg"></param>
        public void DoWorkAsync(int arg)
        {
            // 将异步操作放入线程池中执行
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), arg);
        }

        /// <summary>
        /// 真正的异步操作
        /// </summary>
        /// <param name="obj"></param>
        private void DoWork(object obj)
        {
            int arg = (int)obj;
            int res = arg + 1;

            // 触发事件，传递异步操作的结果
            OperationNameCompleted?.Invoke(res);
        }
    }

}
