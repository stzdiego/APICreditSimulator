

using ApiCreditSimulator.Access.Context;
using ApiCreditSimulator.Access.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "ApiCreditSimulator.Api", Version = "v1" }); });
builder.Services.AddDbContext<IApiCreditSimulatorContext, SQLiteContext>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCreditSimulator.Api v1"));

app.Run();
