using System.Runtime.Serialization;

namespace Application.Commands.Common.Exceptions;

public class BuisnessException : Exception
{
    #region Public Properties

    public string ErrorCode { get; set; }

    #endregion Public Properties

    #region Public Constructors

    public BuisnessException()
    { }

    public BuisnessException(string Message) : base(Message)
    { }

    public BuisnessException(string Message, Exception ex) : base(Message, ex)
    { }

    #endregion Public Constructors

    #region Protected Constructors

    protected BuisnessException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {
        throw new NotImplementedException();
    }

    #endregion Protected Constructors
}