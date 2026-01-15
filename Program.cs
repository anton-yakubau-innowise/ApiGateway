using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var WebAppCorsPolicy = "WebAppCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: WebAppCorsPolicy,
        policy =>
        {
            policy.AllowAnyOrigin() 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors(WebAppCorsPolicy);

await app.UseOcelot();

app.Run();
