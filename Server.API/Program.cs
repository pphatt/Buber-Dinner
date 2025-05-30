using Microsoft.AspNetCore.Mvc.Infrastructure;
using Server.API.Errors;
using Server.API.Middleware;
using Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddInfrastructure(builder.Configuration);
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddSingleton<ProblemDetailsFactory, ServerProblemDetailsFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
