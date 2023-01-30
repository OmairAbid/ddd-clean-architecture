using Application.Commands.Contracts.Common;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Application.Commands.Common.Helpers
{
    public class XMLSerializeHelper : IXMLSerializeHelper
    {
        public string SerializeObjectToXmlString(object obj)
        {
            XmlSerializer _xmls = new XmlSerializer(obj.GetType());
            string _xml = string.Empty;
            MemoryStream _memoryStream = null;
            XmlWriterSettings _settings;
            XmlWriter _writer;
            try
            {
                _memoryStream = new MemoryStream();
                _settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                    ConformanceLevel = ConformanceLevel.Document
                };

                _writer = XmlWriter.Create(_memoryStream, _settings);
                _xmls.Serialize(_writer, obj);

                _xml = Encoding.UTF8.GetString(_memoryStream.ToArray());
            }
            finally
            {
                if (_memoryStream != null)
                {
                    _memoryStream.Dispose();
                }
            }
            return _xml;
        }
    }
}