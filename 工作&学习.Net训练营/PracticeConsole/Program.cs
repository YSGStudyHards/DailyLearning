
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;


public class Program
{
    public static void Main(string[] args)
    {
        string str1 = null;
        string str2 = "";
        string str3 = " ";
        string str4 = "追逐时光者";

        Console.WriteLine(IsStringNullOrWhiteSpace(str1));// 输出：True
        Console.WriteLine(IsStringNullOrWhiteSpace(str2));// 输出：True
        Console.WriteLine(IsStringNullOrWhiteSpace(str3));// 输出：True
        Console.WriteLine(IsStringNullOrWhiteSpace(str4));// 输出：False

        Console.WriteLine(IsStringNullOrEmpty(str1));// 输出：True
        Console.WriteLine(IsStringNullOrEmpty(str2));// 输出：True
        Console.WriteLine(IsStringNullOrEmpty(str3));// 输出：False
        Console.WriteLine(IsStringNullOrEmpty(str4));// 输出：False
    }

    public static bool IsStringNullOrEmpty(string str)
    {
        return string.IsNullOrEmpty(str);
    }


    public static bool IsStringNullOrWhiteSpace(string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
}