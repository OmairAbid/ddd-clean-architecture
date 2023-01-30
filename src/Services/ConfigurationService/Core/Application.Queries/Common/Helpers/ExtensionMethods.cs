using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Common.Helpers;
public static class ExtensionMethods
{
    // This is the extension method.
    // The first parameter takes the "this" modifier
    // and specifies the type for which the method is defined.
    public static IEnumerable<T> CheckEmptyOrNull<T>(this IEnumerable<T> source)
    {
        return source ?? Enumerable.Empty<T>();
    }

    /// <summary>
    /// Converto string to Pascal Case
    /// </summary>
    /// <param name="stringToBeConverted"></param>
    /// <returns></returns>
    public static string ToPascal(this string stringToBeConverted)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        return textInfo.ToTitleCase(stringToBeConverted.ToLower()); //War And Peace
    }

    /// <summary>
    /// sets the specific properties of an object in one go
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="hash"></param>
    public static void Set(this object obj, params Func<string, object>[] hash)
    {
        foreach (Func<string, object> member in hash)
        {
            string propertyName = member.Method.GetParameters()[0].Name;
            object propertyValue = member(string.Empty);
            obj.GetType()
                .GetProperty(propertyName)
                    .SetValue(obj, propertyValue, null);
        }
    }

    /// <summary>
    /// converting string to specified Enum e.g status.ToEnum<DocumentStatus>()
    /// </summary>
    /// <typeparam name="T">Enumeration Type</typeparam>
    /// <param name="enumString">value that needs to converted</param>
    /// <returns>Enumeration</returns>
    public static T ToEnum<T>(this string enumString)
    {
        return (T)Enum.Parse(typeof(T), enumString);
    }

    /// <summary>
    /// Check if the string is null or empty
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// Check if string is Not null or empty
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNotNullOrEmpty(this string str)
    {
        return !string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// Check if the value is greater or equal
    /// </summary>
    /// <param name="a"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool EqualOrGreater(this int a, int input)
    {
        if (a >= input)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Convert given date to ISO string [ yyyy-MM-dd HH:mm:ss ]
    /// </summary>
    /// <param name="dt"></param>
    /// <returns>ISO formated string</returns>
    public static string ConvertToISOString(this DateTime dt)
    {
        return dt.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string ConvertToISODateString(this DateTime dt)
    {
        return dt.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// get string value of enum
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToStringValue<T>(this T value) where T : Enum
    {

        string _output = null;
        //try catch block added to handle passed parameter is null

        Type _type = value.GetType();
        FieldInfo _fieldInfo = _type.GetField(value.ToString());
        IEnumerable<CustomAttributeData> _customAttributes = _fieldInfo.CustomAttributes;

        //if Enum value missing StringValue return null
        if (_customAttributes != null && _customAttributes.Any())
        {
            _output = _customAttributes.First().ConstructorArguments[0].Value.ToString();
        }

        return _output;
    }
    /// <summary>
    /// Check if the object is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsNull<T>(this T obj) where T : class
    {
        return obj == null;
    }

    /// <summary>
    /// Check if the object is not null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsNotNull<T>(this T obj) where T : class
    {
        return obj != null;
    }

    

    /// <summary>
    /// Check if the value is not equal.
    /// </summary>
    /// <param name="valueOne"></param>
    /// <param name="valueTwo"></param>
    /// <returns></returns>
    public static bool IsNotEqual(this int valueOne, int valueTwo)
    {
        return valueOne != valueTwo;
    }

    /// <summary>
    /// Returns a deep copy of object of Type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T DeepClone<T>(this T obj)
    {
        using (MemoryStream memory_stream = new MemoryStream())
        {
            // Serialize the object into the memory stream.
            if (obj.GetType().IsSerializable)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory_stream, obj);
                // Rewind the stream and use it to create a new object.
                memory_stream.Position = 0;
                return (T)formatter.Deserialize(memory_stream);
            }
            return obj;
        }
    }

    /// <summary>
    /// Check if current string is valid URL or not
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns>Returns True or False</returns>
    public static bool IsValidURL<T>(this T obj) where T : class
    {
        Uri uriResult;
        bool result = Uri.TryCreate(obj.ToString(), UriKind.Absolute, out uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        return result;
    }

    public static bool IsFalse(this bool input)
    {
        if (!input)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Break a list of items into chunks of a specific size
    /// var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
    /// var chunks = list.Chunk(3);
    /// returns { { 1, 2, 3 }, { 4, 5, 6 }, { 7 } }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="chunkSize"></param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
    {
        while (list.Any())
        {
            yield return list.Take(chunkSize);
            list = list.Skip(chunkSize);
        }
    }
}
