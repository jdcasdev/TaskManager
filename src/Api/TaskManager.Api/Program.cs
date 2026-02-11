using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Middlewares;
using TaskManager.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Busqué documentación de qué tenía que poner en el program.
// https://www.c-sharpcorner.com/article/using-mediator-in-web-apis-for-cqrs-pattern/
// Me tiró excepción al correrlo con la anterior config: System.InvalidOperationException: No service for type 'MediatR.IRequestHandler`2[TaskManager. etc...
// https://stackoverflow.com/questions/75848218/no-service-for-type-mediatr-irequesthandler-has-been-registred-net-6 Solución.
builder.Services.AddApplicationServices();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
