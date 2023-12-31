﻿using Songbook.API.Extensions;
using Songbook.Infrastructure.MediatR.v1.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsExtension();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddVersioning();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetFormItemsQuery>());

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorMiddleware();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("Default");

app.Run();

