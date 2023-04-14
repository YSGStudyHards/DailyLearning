
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

/// <summary>
/// 自定义一个Attribute类型
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CustomAttribute : Attribute
{
    public string TargetMethod { get; set; }

    public CustomAttribute(string targetMethod)
    {
        TargetMethod = targetMethod;
    }
}

/// <summary>
/// 前进服务
/// </summary>
[Custom("AdvanceWay")]
public class AdvanceService
{
    public void AdvanceWay()
    {
        Console.WriteLine("On the move!");
    }
}

/// <summary>
/// 后退服务
/// </summary>
[Custom("RetreatWay")]
public class RetreatService
{
    public void RetreatWay()
    {
        Console.WriteLine("Be retreating!");
    }
}


public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        //注册需要注入的服务
        services.AddTransient<AdvanceService>();
        services.AddTransient<RetreatService>();

        var provider = services.BuildServiceProvider();

        #region 反射获取所有带有CustomAttribute特性的类并调用对应方法

        //反射获取所有带有CustomAttribute特性的类
        var classes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.GetCustomAttributes<CustomAttribute>().Any());

        foreach (var clazz in classes)
        {
            //获取标记CustomAttribute的实例
            var attr = clazz.GetCustomAttributes<CustomAttribute>().First();

            //根据CustomAttribute元数据信息调用对应的方法
            var methodInfo = clazz.GetMethod(attr.TargetMethod);
            if (methodInfo != null)
            {
                //instance 对象是通过依赖注入容器获取的。这是一种常用的实现方式，可以使用依赖注入解耦程序中各个组件之间的依赖关系，方便测试和维护。
                var instance = provider.GetService(clazz);
                methodInfo.Invoke(instance, null);
            }
        }

        #endregion

        #region 反射获取所有带有CustomAttribute特性的类并调用指定方法

        var executionMethod = "RetreatWay";

        foreach (var clazz in classes)
        {
            //获取标记CustomAttribute的实例
            var attr = clazz.GetCustomAttributes<CustomAttribute>().First();

            if (attr.TargetMethod == executionMethod)
            {
                //根据CustomAttribute元数据信息调用对应的方法
                var methodInfo = clazz.GetMethod(attr.TargetMethod);
                if (methodInfo != null)
                {
                    //instance 对象是通过依赖注入容器获取的。这是一种常用的实现方式，可以使用依赖注入解耦程序中各个组件之间的依赖关系，方便测试和维护。
                    var instance = provider.GetService(clazz);
                    methodInfo.Invoke(instance, null);
                }
            }
        }

        #endregion

        Console.ReadLine();
    }
}