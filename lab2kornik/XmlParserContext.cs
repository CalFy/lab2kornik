using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2kornik
{
    public class XmlParserContext
    {
        private IXmlParserStrategy _strategy;

        public XmlParserContext(IXmlParserStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IXmlParserStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Parse(string filePath)
        {
            _strategy.ParseXml(filePath);
        }
    }

}
