// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
#pragma warning disable SA1200 // UsingDirectivesMustBePlacedWithinNamespace
using ApiCreditSimulator.Access.Context;
using ApiCreditSimulator.Access.Database;
using Microsoft.EntityFrameworkCore;
#pragma warning restore SA1200 // UsingDirectivesMustBePlacedWithinNamespace

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new () { Title = "ApiCreditSimulator.Api", Version = "v1" }); });
builder.Services.AddDbContext<IApiCreditSimulatorContext, SQLiteContext>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SQLiteContext>();
    context.Database.Migrate();
}

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCreditSimulator.Api v1"));

app.Run();