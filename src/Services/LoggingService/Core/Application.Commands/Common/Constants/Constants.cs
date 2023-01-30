namespace Application.Commands.Common.Constants;

public static class Constants
{
    #region Public Fields

    public const string AUDIT_LOG_EMPTY_VALUE = "(null)";
    public const string LOG_EXCHANGE = "Log_Exchange";
    public const string OPERATOR_LOG_ROUTING_KEY = "operator.*";
    public const string OPERATOR_QUEUE = "operator_queue";
    public const string QUEUE_TYPE = "lazy";
    public const string RABBIT_MQ_HOST = "RabbitMQ:Host";
    public const string RABBIT_MQ_PASSWORD = "RabbitMQ:Password";
    public const string RABBIT_MQ_USER_NAME = "RabbitMQ:UserName";
    public const string RABBIT_MQ_VIRTUAL_HOST = "RabbitMQ:VirtualHost";

    #endregion Public Fields

    #region Public Properties

    public static List<string> BlackListCharacters
    {
        get
        {
            return new List<string>() { "@", "=", "0x09", "0x0D" };
        }
    }

    #endregion Public Properties
}