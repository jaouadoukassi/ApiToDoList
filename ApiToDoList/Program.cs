// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using ApiToDoList.DataAccess;
using ApiToDoList.Models;

var builder = WebApplication.CreateBuilder(args);

// 2. Connection with SQL Express
const string CONNECTIONNAMES = "ConnectiDefault";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAMES);

// 3. Add Context For SQL Server
builder.Services.AddDbContext<ClsTodoList>(options => options.UseSqlServer(connectionString));

//// 4. Add Context For MySql Workbench
//builder.Services.AddSingleton(connectionString);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
