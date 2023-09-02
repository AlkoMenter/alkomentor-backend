using Alkomentor.Api;
using Alkomentor.Application;
using Alkomentor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(ModelStateFilter));
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
