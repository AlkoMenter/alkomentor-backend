using System.Text.Json.Serialization;
using Alkomentor.Api.Utils;
using Alkomentor.Application;
using Alkomentor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Services
    .AddControllers(opts =>
        {
            opts.Filters.Add(typeof(ModelStateFilter));
        })
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
});

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
