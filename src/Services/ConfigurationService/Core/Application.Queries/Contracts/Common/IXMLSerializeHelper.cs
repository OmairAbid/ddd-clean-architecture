using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Contracts.Common;
public interface IXMLSerializeHelper
{
    #region Public Methods

    /// <summary>
    /// Deserialize xml string to Object
    /// </summary>
    /// <param name="xmlString"></param>
    /// <param name="ObjectType"></param>
    /// <returns></returns>
    object DeserializeXmlStringToObject(string xmlString, Type ObjectType);

    /// <summary>
    /// Serialize Object to Xml String
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    string SerializeObjectToXmlString(object obj);

    /// <summary>
    /// Convert object to XML 
    /// </summary>
    /// <param name="oObject"></param>
    /// <returns></returns>
    string ToXML(object oObject);

    /// <summary>
    /// Validate XML
    /// </summary>
    /// <param name="document"></param>
    /// <returns></returns>
    bool ValidateXML(byte[] document);

    #endregion Public Methods
}
