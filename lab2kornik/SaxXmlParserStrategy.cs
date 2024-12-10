using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2kornik
{
    public class SaxXmlParserStrategy : IXmlParserStrategy
    {
        public void ParseXml(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        Console.WriteLine($"Елемент: {reader.Name}");
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        Console.WriteLine($"Текст: {reader.Value}");
                    }
                }
            }
        }
    }

}
