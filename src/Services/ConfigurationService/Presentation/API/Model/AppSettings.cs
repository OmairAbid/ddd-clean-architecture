namespace API.Model;

public class AppSettings
{
    public bool Settings { get; set; }
}

public class DbSettings
{
    public bool DbSource { get; set; }
}

public class ApiSettings
{
    public string Host { get; set; }
    public string SwaggerUrl { get; set; }
}
