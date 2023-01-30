

using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Application.Queries.Common.Exceptions;

[Serializable]
public class ValidationException : Exception
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
