using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Common.Exceptions;
[Serializable]
public class BadRequestException : ApplicationException
{
    #region Public Constructors

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
    {
    }

    public BadRequestException(string message, IDictionary<string,string> validationErrors, Exception innerException)
            : base(message, innerException)
    {
    }

    public BadRequestException(string message, IDictionary<string, string> validationErrors)
            : base(message)
    {
    }

    public BadRequestException(string name, object key)
            : base($" \"{name}\" ({key}) has required.")
    {
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected BadRequestException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {
        throw new NotImplementedException();
    }

    #endregion Protected Constructors
}
