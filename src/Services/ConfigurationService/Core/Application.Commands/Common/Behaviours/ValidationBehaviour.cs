using Microsoft.Extensions.Logging;

namespace Application.Commands.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	#region Private Fields

	private readonly ILogger<TRequest> _logger;
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	#endregion Private Fields

	#region Public Constructors

	public ValidationBehaviour(ILogger<TRequest> logger, IEnumerable<IValidator<TRequest>> validators)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_validators = validators ?? throw new ArgumentNullException(nameof(validators));
	}

	#endregion Public Constructors

	#region Public Methods

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
        var typeName = typeof(TRequest).Name;

        if (!_validators.Any()) return await next();

		if (_validators.Any())
		{
			var context = new ValidationContext<TRequest>(request);

			var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

			var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            
			_logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", typeName, request, failures);

            if (failures.Count != 0)
				throw new Exceptions.ValidationException(failures);
		}

		return await next();
	}

	#endregion Public Methods
}