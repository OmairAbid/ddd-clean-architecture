
using System.Reflection;

namespace Application.Queries.Common.Enumerations;
public class StringValue : System.Attribute
{
    private readonly string _value;

    public StringValue(string value)
    {
        _value = value;
    }

    public string Value
    {
        get { return _value; }
    }

}

public class StringEnumerationHelper: IEnumerationHelper
{
    #region Public Methods

    public string GetStringValue(Enum value)
    {

        string _output = null;
        //try catch block added to handle passed parameter is null
        try
        {
            Type _type = value.GetType();
            FieldInfo _fieldInfo = _type.GetField(value.ToString());
            IEnumerable<CustomAttributeData> _customAttributes = _fieldInfo.CustomAttributes;

            //if Enum value missing StringValue return null
            if (_customAttributes != null && _customAttributes.Any())
            {
                _output = _customAttributes.First().ConstructorArguments[0].Value.ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return _output;
    }

    #endregion Public Methods
}
