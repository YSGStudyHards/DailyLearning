using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public static class StaticClass
    {

        public static void GetUserInfo()
        { 
        
        }

        public static string GetUserName()
        {
            //String userName = new String("追逐时光者");// 创建了几个String Object?
            string userName = new string("追逐时光者"); //与string String=“C# program”有什么 区别

            return userName;
        }
    }
}
