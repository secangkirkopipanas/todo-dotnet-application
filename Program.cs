using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Configuration; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");
//"Server=mssql;Database=todo;User Id=sa; Password=Zxcvbnm<>1;TrustServerCertificate=True;MultiSubnetFailover=True;Encrypt=false";
//configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TodoContext>(options =>
              options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure()));
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


// DefaultFilesOptions options = new DefaultFilesOptions();
// options.DefaultFileNames.Clear();
// options.DefaultFileNames.Add("index.html");
//app.UseDefaultFiles(options);
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
