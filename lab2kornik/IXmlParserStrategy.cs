using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2kornik
{
    public interface IXmlParserStrategy
    {
        void ParseXml(string filePath);
    }
}
