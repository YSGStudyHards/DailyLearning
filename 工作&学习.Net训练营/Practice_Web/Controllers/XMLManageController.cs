using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace PracticeSiteWeb.Controllers
{
    /// <summary>
    /// xml管理类
    /// </summary>
    public class XMLManageController : Controller
    {
        public IActionResult Index()
        {
            DeleteXmlNode();
            return View();
        }

        #region DeleteXml

        private static void DeleteXmlNode()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D://xmlSampleCreateFile.xml");//加载Xml文件
            XmlNode xns = xmlDoc.SelectSingleNode("books/book");//查找要删除的根节点

            #region 1、清空author节点下的数据
            XmlNodeList xmlNodeList = xns.ChildNodes;//取出book节点下所有的子节点
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;//将节点转换一下类型
                if (xmlElement.Name == "author")//判断该子节点是否是要查找的节点
                {
                    //清空author节点下的数据
                    xmlElement.RemoveAll();//删除该节点的全部内容
                }
            }
            #endregion

            #region 删除author节点

            var delNode = xmlDoc.SelectSingleNode("books/book/" + "author");
            xns.RemoveChild(delNode);

            #endregion

            xmlDoc.Save("D://DeleteXmlNode.xml");//保存操作后的Xml文件内容
        }

        #endregion

        #region update xmlFile

        private static void UpdateXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D://xmlSampleCreateFile.xml");//加载Xml文件
            XmlNode xns = xmlDoc.SelectSingleNode("books/book");//查找要修改的节点
            XmlNodeList xmlNodeList = xns.ChildNodes;//取出book节点下所有的子节点

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;//将节点转换一下类型
                if (xmlElement.Name=="author")//判断该子节点是否是要查找的节点
                {
                    xmlElement.InnerText = "大姚同学";//设置新值
                    break;
                }
            }
            xmlDoc.Save("D://UpdateXml.xml");//保存修改的Xml文件内容
        }

        #endregion

        #region appendNode

        private static void AppendNode()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D://xmlSampleCreateFile.xml");//加载Xml文件
            XmlNode root = xmlDoc.SelectSingleNode("books/book");//选择要添加子节点的book节点
            //创建一个新的Xml节点元素
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, "publishdate", null);
            node.InnerText = "2022-03-26";
            root.AppendChild(node);//将创建的item子节点添加到items节点的尾部
            xmlDoc.Save("D://AppendNodeFile.xml");//保存修改的Xml文件内容
        }

        #endregion

        #region 创建Xml文件
        /// <summary>
        /// 创建Xml文件
        /// </summary>
        public void CreateXmlFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建Xml根节点  
            XmlNode root = xmlDoc.CreateElement("books");
            xmlDoc.AppendChild(root);

            XmlNode root1 = xmlDoc.CreateElement("book");
            root.AppendChild(root1);

            //创建子节点
            CreateNode(xmlDoc, root1, "author", "追逐时光者");
            CreateNode(xmlDoc, root1, "title", "XML学习教程");
            CreateNode(xmlDoc, root1, "publisher", "时光出版社");
            //将文件保存到指定位置
            xmlDoc.Save("D://xmlSampleCreateFile.xml");
        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmlDoc">xml文档</param>    
        /// <param name="parentNode">Xml父节点</param>    
        /// <param name="name">节点名</param>    
        /// <param name="value">节点值</param>    
        ///   
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            //创建对应Xml节点元素
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
        #endregion
    }
}
