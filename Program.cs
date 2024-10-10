using Microsoft.EntityFrameworkCore;
using Survivor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var cs = builder.Configuration.GetConnectionString("Default");// we defined vonfigartiobn for the connection string
builder.Services.AddDbContext<SurvivorContext>(options=>options.UseSqlServer(cs));// we use to the options for the sqlserver

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
