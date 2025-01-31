var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddCarter();

app.MapGet("/", () => "Hello World!");

app.MapCarter();

app.Run();
