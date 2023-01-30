using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Application.Queries.Common.Helpers;
public class XMLSerializeHelper: IXMLSerializeHelper
{
    #region Public Methods

    public object DeserializeXmlStringToObject(string xmlString, Type ObjectType)
    {
        XmlSerializer _xmls = new XmlSerializer(ObjectType);

        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
        {
            return _xmls.Deserialize(ms);
        }
    }

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

    public string ToXML(object oObject)
    {
        XmlDocument _xmlDoc = new XmlDocument();
        XmlSerializer _serializer = new XmlSerializer(oObject.GetType());
        string _result = string.Empty;

        using (MemoryStream xmlStream = new MemoryStream())
        {
            _serializer.Serialize(xmlStream, oObject);
            xmlStream.Position = 0;
            _xmlDoc.Load(xmlStream);
            _result = _xmlDoc.InnerXml;
        }

        return _result;
    }

    public bool ValidateXML(byte[] document)
    {
        bool _isValid;
        try
        {
            new XmlDocument().Load(new MemoryStream(document));
            _isValid = true;
        }
        catch (Exception)
        {
            _isValid = false;
        }
        return _isValid;
    }

    #endregion Public Methods
}
