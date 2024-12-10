using System.Text;
using System.Xml;

namespace lab2kornik.Services
{
    public class XmlToHtmlService
    {
        public string ConvertXmlToHtml(string xmlFilePath)
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.Append("<html><body><h1>XML to HTML</h1><table border='1'><tr><th>Element Name</th><th>Element Value</th></tr>");

            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                while (reader.Read())
                {
                    // Перевіряємо, чи це вузол-елемент
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        string elementName = reader.Name;
                        string elementText = string.Empty;

                        // Якщо у вузла є текстовий вміст
                        if (!reader.IsEmptyElement)
                        {
                            reader.Read(); // Читаємо наступний вузол
                            if (reader.NodeType == XmlNodeType.Text) // Перевіряємо, чи це текст
                            {
                                elementText = reader.Value;
                            }
                        }

                        htmlContent.Append($"<tr><td>{elementName}</td><td>{elementText}</td></tr>");
                    }
                }
            }

            htmlContent.Append("</table></body></html>");
            return htmlContent.ToString();
        }
    }
}
