using Application.Commands.Common.Enumerations;

using System.Globalization;

using IHtmlHelper = Application.Commands.Contracts.Common.IHtmlHelper;

namespace Application.Commands.Features.Update;

public class SystemSettingValidator : AbstractValidator<UpdateSystemSettingRequest>
{
	#region Private Fields

	private readonly IHtmlHelper _htmlHelper;
	private readonly IEmailHelper _emailHelper;

	#endregion Private Fields

	#region Public Constructors

	public SystemSettingValidator(IHtmlHelper htmlHelper, IEmailHelper emailHelper)
	{
		_htmlHelper = htmlHelper;
		_emailHelper = emailHelper;

		RuleForEach(x => x.SystemSettings).ChildRules(setting =>
		{
			setting.RuleFor(c => c.AttributeName).NotNull().WithMessage(ErrorMessages.COMMON_ERROR_IS_NULL_OR_EMPTY.ToString());
			setting.RuleFor(c => c.AttributeName).NotEmpty().WithMessage(ErrorMessages.COMMON_ERROR_IS_NULL_OR_EMPTY.ToString());
			setting.RuleFor(c => c.AttributeValue).Must(_NotEmpty).WithMessage(ErrorMessages.COMMON_ERROR_IS_NULL_OR_EMPTY.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_NotHaveHTMLCharacters).WithMessage(ErrorMessages.COMMON_ERROR_INVALID_INPUT_VALUE.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateEmail).WithMessage(ErrorMessages.COMMON_ERROR_INVALID_EMAIL.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateURL).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateCheckBox).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateNumeric).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateMaxConcurrentSessionLimit).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
			setting.RuleFor(x => x.AttributeValue).Must(_ValidateTime).WithMessage(ErrorMessages.COMMON_ERROR_GENERIC.ToString()).WithState(x => x.AttributeName);
		});
	}

	#endregion Public Constructors

	#region Private Methods

	private bool IsEmpty(string attributeName)
	{
		List<string> systemSettings = new()
			{
                #region Default Connectors

                SystemSettingAttribute.FILE_SCANNING_CONNECTOR_DEFAULT.ToString(),
				SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_DROPBOX_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_GOOGLE_DRIVE_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_ONEDRIVE_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_PUSH_NOTIFICATION_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_GEO_IP_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_MARKETING_CONNECTOR.ToString(),
				SystemSettingAttribute.DEFAULT_GOOGLE_CONNECTOR_CAPTCHA.ToString(),
				SystemSettingAttribute.DEFAULT_OTP_CONNECTOR.ToString(),
				SystemSettingAttribute.DATA_SECURITY_DEFAULT_CONNECTOR.ToString(),

	            #endregion Default Connectors

                #region Analytics Tracking Code

		        SystemSettingAttribute.ANALYTICS_GOOGLE.ToString(),
				SystemSettingAttribute.ANALYTICS_BING.ToString(),
				SystemSettingAttribute.ANALYTICS_PIXEL.ToString(),
				SystemSettingAttribute.ANALYTICS_BING_MOBILE_WEB.ToString(),
				SystemSettingAttribute.ANALYTICS_GOOGLE_MOBILE_WEB.ToString(),
				SystemSettingAttribute.APP_INSIGHT_INSTRUMENTATION_KEY.ToString(),

	            #endregion Analytics Tracking Code

                #region Document Settings

		        SystemSettingAttribute.DOCUMENT_LOCK_SIGNING_SERVER_PROFILE.ToString(),
				SystemSettingAttribute.DOCUMENT_LOCK_ESEAL_CAPACITY.ToString(),

	            #endregion Document Settings

                #region Evidance Repot

                SystemSettingAttribute.PROCESS_EVIDENCE_SIGNING_SERVER_PROFILE.ToString(),

                #endregion Evidance Repot

                #region Excluded Domains

		        SystemSettingAttribute.REPORT_DOMAIN_NAME.ToString(),

	            #endregion Excluded Domains

                #region Billing

		        WorldPayConstanst.BILLING_DESCRIPTION.ToString(),
				SystemSettingAttribute.COMPANY_BILLING_ADDRESS.ToString(),
				SystemSettingAttribute.COMPANY_BILLING_SALES_EMAIL.ToString(),
				SystemSettingAttribute.COMPANY_BILLING_SUPPORT_EMAIL.ToString(),
				SystemSettingAttribute.DEFAULT_PAYMENT_GATEWAY_CONNECTOR.ToString(),
				SystemSettingAttribute.BILLING_ENABLED.ToString(),
				SystemSettingAttribute.VAT_ENABLED.ToString(),
				SystemSettingAttribute.DEFAULT_CURRENCY.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_EUR_TO_USD.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_EUR_TO_GBP.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_GBP_TO_USD.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_GBP_TO_EUR.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_USD_TO_EUR.ToString(),
				SystemSettingAttribute.CONVERSION_RATE_USD_TO_GBP.ToString(),
				SystemSettingAttribute.BILLING_MARGIN_DAYS.ToString(),

	            #endregion Billing

                #region Sevice Plans

		        SystemSettingAttribute.DOWNGRADE_ENTERPRISE_PLANS_TO.ToString(),
				SystemSettingAttribute.DOWNGRADE_INDIVIDUAL_PLANS_TO.ToString(),

	            #endregion Sevice Plans

                SystemSettingAttribute.WEB_HELP_PAGE_URL.ToString(),
				SystemSettingAttribute.ADMIN_HELP_PAGE_URL.ToString(),

				SystemSettingAttribute.MOBILE_APPS_URL.ToString()
			};

		return systemSettings.Contains(attributeName);
	}

	private bool _IsSkipCheckForHTMLCharacters(string attributeName)
	{
		List<string> systemSettings = new List<string>
			{
                #region Analytics Tracking Code

		        SystemSettingAttribute.ANALYTICS_GOOGLE.ToString(),
				SystemSettingAttribute.ANALYTICS_BING.ToString(),
				SystemSettingAttribute.ANALYTICS_PIXEL.ToString(),
				SystemSettingAttribute.ANALYTICS_BING_MOBILE_WEB.ToString(),
				SystemSettingAttribute.ANALYTICS_GOOGLE_MOBILE_WEB.ToString(),
				SystemSettingAttribute.APP_INSIGHT_INSTRUMENTATION_KEY.ToString()

	            #endregion Analytics Tracking Code
            };

		return systemSettings.Contains(attributeName);
	}

	private bool _IsApplyEmailValidation(string attributeName)
	{
		List<string> systemSettings = new()
		{
			SystemSettingAttribute.CONTACT_US_EMAIL_TO.ToString(),
			SystemSettingAttribute.ERRORS_NOTIFICATION_EMAIL_TO.ToString(),
			SystemSettingAttribute.LICENSE_EXPIRY_ALERT_SEND_TO.ToString(),
			SystemSettingAttribute.ARCHIVE_NOTIFICATION_EMAIL_TO.ToString()
		};
		return systemSettings.Contains(attributeName);
	}

	private bool _IsApplyNumericValidation(string attributeName)
	{
		List<string> systemSettings = new List<string>
			{
				SystemSettingAttribute.SESSION_TIMEOUT.ToString(),
				SystemSettingAttribute.LINK_EXPIRY_ACTIVATION_INVITATION.ToString(),
				SystemSettingAttribute.LINK_EXPIRY_FORGOT_PASSWORD.ToString(),
				SystemSettingAttribute.WEB_SERVICE_ACCESS_TOKEN_EXPIRY_TIME.ToString(),
				SystemSettingAttribute.WEB_SERVICE_REFRESH_TOKEN_EXPIRY_TIME.ToString(),
				SystemSettingAttribute.ERROR_NOTIFICATION_TIMEOUT.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_MINIMUM_LENGTH.ToString(),
				SystemSettingAttribute.ACCOUNT_LOCKED_COUNT.ToString(),
				SystemSettingAttribute.ACCOUNT_LOCKED_DURATION.ToString(),
				SystemSettingAttribute.LICENSE_EXPIRY_ALERT_DAYS.ToString(),
				SystemSettingAttribute.BULK_ACTION_MAX_COUNT.ToString(),
				SystemSettingAttribute.BULK_DOWNLOAD_MAX_SIZE.ToString(),
				SystemSettingAttribute.EMAIL_ATTACHMENT_SIZE.ToString(),
				SystemSettingAttribute.CORE_FAILED_REQUEST_RETRY_COUNT.ToString(),
				SystemSettingAttribute.CORE_NOTIFICATIONS_DELETION_DURATION.ToString(),
				SystemSettingAttribute.CORE_EMAIL_RETRY_COUNT.ToString(),
				SystemSettingAttribute.CORE_DELETE_ACTIVITY_LOGS_DURATION.ToString(),
				SystemSettingAttribute.USER_SESSION_LIMIT.ToString()
			};
		return systemSettings.Contains(attributeName);
	}

	private bool _IsApplyURLValidation(string attributeName)
	{
		List<string> systemSettings = new List<string>
			{
				SystemSettingAttribute.ADMIN_BASE_URL.ToString(),
				SystemSettingAttribute.BASE_URL.ToString(),
				SystemSettingAttribute.CORE_BASE_URL.ToString(),
				SystemSettingAttribute.CORE_SERVICE_URL.ToString(),
				SystemSettingAttribute.LOGIN_PAGE_URL.ToString(),
				SystemSettingAttribute.MOBILE_WEB_URL.ToString(),
				SystemSettingAttribute.ADMIN_HELP_PAGE_URL.ToString(),
				SystemSettingAttribute.WEB_HELP_PAGE_URL.ToString(),
			};
		return systemSettings.Contains(attributeName);
	}

	private bool _IsApplyCheckBoxValidation(string attributeName)
	{
		List<string> systemSettings = new List<string>
			{
				SystemSettingAttribute.ALLOW_PASSWORD_AUTHENTICATION.ToString(),
				SystemSettingAttribute.ALLOW_API_AGREE_TERMS_OF_SERVICE.ToString(),
				SystemSettingAttribute.ALLOW_ADD_NATIONAL_ID_NUMBER.ToString(),
				SystemSettingAttribute.EMAILS_USE_RECIPIENT_LANGUAGE.ToString(),
				SystemSettingAttribute.ALLOW_LANGUAGE_DROPDOWN.ToString(),
				SystemSettingAttribute.ALLOW_COUNTRY_CHANGE.ToString(),
				SystemSettingAttribute.ALLOW_TIMEZONE_CHANGE.ToString(),
				SystemSettingAttribute.ALLOW_EMAIL_CERTIFICATE_REVOKED_OR_EXPIRED.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_ENFORCE_AT_LEAST_NUMBER.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_ENFORCE_AT_LEAST_ONE_SPECIAL_CHRACTER.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_ENFORCE_UPPER_LOWER_CHARACTER.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_ENFORCE_CHANGE_PASSWORD.ToString(),
				SystemSettingAttribute.ACCOUNT_LOCKED_ENABLED.ToString(),
				SystemSettingAttribute.PASSWORD_POLICY_EXPIRY_ENABLED.ToString(),
				SystemSettingAttribute.CORE_EMAIL_RETRY_THREAD.ToString(),
				SystemSettingAttribute.CORE_DELETE_DOCUMENTS_THREAD.ToString(),
				SystemSettingAttribute.CORE_SUMMARY_EMAIL_THREAD.ToString(),
				SystemSettingAttribute.CORE_DOCUMENT_PROCESSING_THREAD.ToString(),
				SystemSettingAttribute.CORE_DAILY_THREAD.ToString(),
				SystemSettingAttribute.CORE_REMINDER_THREAD.ToString(),
				SystemSettingAttribute.CORE_SYNC_AD_CONTACTS_THREAD.ToString(),
				SystemSettingAttribute.CORE_RESET_USER_STATISTICS.ToString(),
				SystemSettingAttribute.CORE_DOWNGRADE_SERVICEPLAN.ToString()
			};
		return systemSettings.Contains(attributeName);
	}

	private bool _NotEmpty(SystemSetting systemSetting, string attributeValue)
	{
		//TO DO: enhacement required if attribute name is missing then return false
		if (IsEmpty(systemSetting.AttributeName))
		{
			return true;
		}
		else
		{
			return systemSetting.AttributeValue.IsNotNullOrEmpty();
		}
	}

	private bool _NotHaveHTMLCharacters(SystemSetting systemSetting, string attributeValue)
	{
		if (_IsSkipCheckForHTMLCharacters(systemSetting.AttributeName))
		{
			return true;
		}
		else
		{
			return !_htmlHelper.HasHTMLTags(systemSetting.AttributeValue);
		}
	}

	private bool _ValidateEmail(SystemSetting systemSetting, string attributeValue)
	{
		if (_IsApplyEmailValidation(systemSetting.AttributeName))
		{
			return _emailHelper.IsValidEmail(systemSetting.AttributeValue);
		}
		return true;
	}

	private bool _ValidateURL(SystemSetting systemSetting, string attributeValue)
	{
		if (_IsApplyURLValidation(systemSetting.AttributeName) && !IsIgnoreHelpPageURLValidation(systemSetting))
		{
			Uri uriResult;
			return Uri.TryCreate(systemSetting.AttributeValue, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}
		return true;
	}

	private bool IsIgnoreHelpPageURLValidation(SystemSetting systemSetting)
	{
		return (systemSetting.AttributeName == SystemSettingAttribute.ADMIN_HELP_PAGE_URL.ToString() || systemSetting.AttributeName == SystemSettingAttribute.WEB_HELP_PAGE_URL.ToString()) && systemSetting.AttributeValue.IsNullOrEmpty();
	}

	private bool _ValidateCheckBox(SystemSetting systemSetting, string attributeValue)
	{
		if (_IsApplyCheckBoxValidation(systemSetting.AttributeName))
		{
			return Enum.IsDefined(typeof(Flag), systemSetting.AttributeValue.ToUpper());
		}
		return true;
	}

	private bool _ValidateNumeric(SystemSetting systemSetting, string attributeValue)
	{
		if (systemSetting.AttributeValue.IsNotNullOrEmpty() && _IsApplyNumericValidation(systemSetting.AttributeName))
		{
			if (systemSetting.AttributeValue.Length > 5)
			{
				return false;
			}

			return int.TryParse(systemSetting.AttributeValue, out _);
		}
		return true;
	}

	private bool _ValidateTime(SystemSetting systemSetting, string attributeValue)
	{
		bool isSucess = false;
		try
		{
			if (systemSetting.AttributeName != SystemSettingAttribute.CORE_REMINDER_EMAIL_TIME.ToString())
			{
				isSucess = true;
			}
			else
			{
				_ = DateTime.ParseExact(systemSetting.AttributeValue, "H:mm", null, DateTimeStyles.None);
				isSucess = true;
			}
		}
		catch (Exception ex)
		{
			isSucess = false;
		}
		return isSucess;
	}

	private bool _ValidateMaxConcurrentSessionLimit(SystemSetting systemSetting, string attributeValue)
	{
		bool isSucess = false;
		try
		{
			if (systemSetting.AttributeName != SystemSettingAttribute.USER_SESSION_LIMIT.ToString())
			{
				isSucess = true;
			}
			else
			{
				if (int.Parse(systemSetting.AttributeValue) <= 5)
				{
					isSucess = true;
				}
			}
		}
		catch (Exception ex)
		{
			isSucess = false;
		}
		return isSucess;
	}

	#endregion Private Methods
}