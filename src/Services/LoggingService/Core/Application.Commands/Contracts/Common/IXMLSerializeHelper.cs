namespace Application.Commands.Contracts.Common
{
    public interface IXMLSerializeHelper
    {
        /// <summary>
        /// Serialize Object to Xml String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string SerializeObjectToXmlString(object obj);
    }
}