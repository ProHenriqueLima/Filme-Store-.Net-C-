using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TesteWiPro.Api.Configuration;
using TesteWiPro.Business.Models.Validations;
using TesteWiPro.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnection =
    builder.Configuration.GetConnectionString("TesteWiProDbContext");

builder.Services.AddDbContextPool<TesteWiProDbContext>(options =>
    options.UseMySql(mySqlConnection
        , ServerVersion.AutoDetect(mySqlConnection)));
builder.Services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<FilmeValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
builder.Services.ResolveDependencies();
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
