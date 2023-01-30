using System.Runtime.Serialization;

namespace Application.Commands.Common.Exceptions;

public class BadRequestException : ApplicationException
{
    #region Public Constructors

    public BadRequestException(string message) : base(message)
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