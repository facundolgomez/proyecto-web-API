using Infrastructure.Data;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Application.Models.Requests;
using Application.Models;
using Domain.Entities;
using Application.Profiles;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Batteries_V2.Init();

#region Database


/*builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(
    builder.Configuration["ConnectionString:DBConnectionString"], b => b.MigrationsAssembly("web")));
#endregion*/

string connectionString = builder.Configuration["ConnectionStrings:DBConnectionString"]!;

// Configure the SQLite connection
var connection = new SqliteConnection(connectionString);
connection.Open();

// Set journal mode to DELETE using PRAGMA statement
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationContext>(dbContextOptions => dbContextOptions.UseSqlite(connection));
#endregion

#region Repositories

//configuracion del repositorio generico
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

#endregion

#region Services
builder.Services.AddScoped(typeof(IService<,,,>), typeof(GenericService<,,,>));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDuenoService, DuenoService>();
builder.Services.AddScoped<IGuarderiaService, GuarderiaService>();
#endregion

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); //configuracion del automapper


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
