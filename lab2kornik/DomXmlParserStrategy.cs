using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2kornik
{
    public class DomXmlParserStrategy : IXmlParserStrategy
    {
        public void ParseXml(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodes = doc.GetElementsByTagName("*");

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"Елемент: {node.Name}, Текст: {node.InnerText}");
            }
        }
    }

}
