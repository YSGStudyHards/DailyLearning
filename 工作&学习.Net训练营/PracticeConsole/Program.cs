
using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;


public class Program
{
    public static void Main(string[] args)
    {
        GenerateQRCodeServices.GenerateQRCode();
    }

}