

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApiCreditSimulator.Api", Version = "v1" });
});

var app = builder.Build();

app.MapControllers();
app.UseSwagger();

app.Run();
