using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Application.Commands.Common.Exceptions;

[Serializable]
public class ValidationException : ApplicationException
{
    public List<KeyValuePair<string, string>> ValidationFailures { get; set; }

    public ValidationException(List<ValidationFailure> failures)
    {
        ValidationFailures = new();

        foreach (var item in failures)
        {
            ValidationFailures.Add(new KeyValuePair<string, string>(item.PropertyName, item.ErrorMessage));
        }
    }

    #region Public Methods

    protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}