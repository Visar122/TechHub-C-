using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using TechHub.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//*Cors
//<Cors>
//allow calls from AngularUI

//builder.Services.AddCors(options=>options.AddPolicy(name:"TechHub",
//    policy =>
//    {
//        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
//    }));

//</ Cors >

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Dbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//<Cors>
//allow calls from AngularUI

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

//</ Cors >
app.UseAuthorization();

app.MapControllers();

app.Run();
