using Web.Admin.GW.Middlewares;

List<KeyValuePair<string, string>> headerstoAdd = new()
				{
					new KeyValuePair<string, string>("p3p", "CP=&quot;Internet Explorer Requires This In Order to Set Third Party Cookies&quot;"),
					new KeyValuePair<string, string>("X-XSS-Protection", "1; mode=block"),
					new KeyValuePair<string, string>("X-Content-Type-Options", "nosniff"),
					new KeyValuePair<string, string>("Strict-Transport-Security", "max-age=31536000;includeSubDomains; preload"),
				};

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureApp();
builder.Host.AddLogging(builder.Configuration);
builder.Services.AddCustomHttpLogging();
builder.Services.AddAPM(builder.Configuration,builder.Environment);
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddGateway();
builder.Services.AddCorsPolicy();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(builder.Configuration);

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseRequestLogging();
app.UseExceptionMiddleware();
app.UseRouting();
app.UseCors(PolicyNames.AllowAll);
app.UseAuthentication();
app.UseReponseHeadersMiddleware(headerstoAdd);
app.UseRemoveHeadersMiddleware("Server", "X-Powered-By");

//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapGet("/",
//		async context => { await context.Response.WriteAsync("Admin Gateway is running"); });
//});

app.UseEndpointsMiddleware();

await app.UseGateway();

app.Run();