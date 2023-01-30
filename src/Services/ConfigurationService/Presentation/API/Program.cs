using API;

var builder = WebApplication.CreateBuilder(args);

//Configuring Srevices
{
    builder.Host.ConfigureApp();
    builder.Host.AddLogging(builder.Configuration);
    builder.Services.AddAPM(builder.Configuration);
    builder.Services.AddCustomHttpLogging();
    builder.Services.AddAppSettings(builder.Configuration);
    builder.Services.AddCustomController();
    builder.Services.AddHealthCheck(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddVersioning();
    builder.Services.AddSwagger();
    builder.Services.AddApplicationDependencies(builder.Configuration);
    builder.Services.AddMassTransit(builder.Configuration);

}

var app = builder.Build();

//Request Pipeline
{
    app.UseRequestLogging();

    if (!app.Environment.IsProduction())
    {
        app.UseSwaggerUIMiddleware(builder.Configuration);
    }
    else
    {
        app.UseHttpsRedirection();
    }

    app.UseExceptionMiddleware();
    app.UseClaimsAuthorizationMiddleware();
    
    app.UseRouting();
    app.UseEndpointsMiddleware();
}

await app.RunAsync();