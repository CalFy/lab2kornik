using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2kornik
{
    public class LinqXmlParserStrategy : IXmlParserStrategy
    {
        public void ParseXml(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            foreach (XElement element in doc.Descendants())
            {
                Console.WriteLine($"Елемент: {element.Name}, Текст: {element.Value}");
            }
        }
    }
}
