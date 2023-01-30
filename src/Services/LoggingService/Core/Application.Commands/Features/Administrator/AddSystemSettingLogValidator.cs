using IHtmlHelper = Application.Commands.Contracts.Common.IHtmlHelper;

namespace Application.Commands.Features.Administrator;

public class AddSystemSettingLogValidator : AbstractValidator<SystemSettingLogRequest>
{
    #region Private Fields

    private readonly IHtmlHelper _htmlHelper;

    #endregion Private Fields

    #region Public Constructors

    public AddSystemSettingLogValidator(IHtmlHelper htmlHelper)
    {
        _htmlHelper = htmlHelper;

        //RuleForEach(x => x.AdministratorLogs).ChildRules(setting =>
        //{
        //    setting.RuleFor(c => c.AttributeName).NotNull().WithMessage(ErrorMessages.COMMON_ERROR_IS_NULL_OR_EMPTY.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(c => c.AttributeValue).Must(_NotEmpty).WithMessage(ErrorMessages.COMMON_ERROR_IS_NULL_OR_EMPTY.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_NotHaveHTMLCharacters).WithMessage(ErrorMessages.COMMON_ERROR_INVALID_INPUT_VALUE.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateEmail).WithMessage(ErrorMessages.COMMON_ERROR_INVALID_EMAIL.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateURL).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateCheckBox).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateNumeric).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateMaxConcurrentSessionLimit).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
        //    setting.RuleFor(x => x.AttributeValue).Must(_ValidateTime).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
        //});
    }

    #endregion Public Constructors
}