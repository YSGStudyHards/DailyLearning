using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace PracticeSiteWeb.Controllers
{
    public class XmlManager : Controller
    {
        public IActionResult Index()
        {
            //有效Xml格式数据验证 输出true
            bool result1 = IsValidXml("<person><name>大姚</name><age>26</age><gender>男</gender></person>");

            //无效Xml格式数据验证 输出false
            bool result2 = IsValidXml("你要姚同学");

            return View();
        }

        /// <summary>
        /// Xml字符串格式验证
        /// </summary>
        /// <param name="xmlString">Xml字符串</param>
        /// <returns></returns>
        public static bool IsValidXml(string xmlString)
        {
            try
            {
                // 创建XmlDocument对象
                XmlDocument xmlDoc = new XmlDocument();
                // 加载xml字符串
                xmlDoc.LoadXml(xmlString);
                // 如果没有异常，则说明xml字符串是有效的
                return true;
            }
            catch (XmlException ex)
            {
                // 如果有异常，则说明xml字符串是无效的
                //Data at the root level is invalid. Line 1, position 1.
                return false;
            }
        }
    }
}
