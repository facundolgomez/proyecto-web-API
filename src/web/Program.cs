using Infrastructure.Data;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Models.Requests;
using Application.Models;
using Domain.Entities;
using Application.Profiles;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Infrastructure.Services;
using Domain.Enums;
using Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

#region ConfigureJsonOptions
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Authentication
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Introduzca el token JWT como: Bearer {token}"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiBearerAuth"
                }
            },
            new List<string>()
        }
    });
});
//configurar las opciones para la clase AutenticacionServiceOptions
builder.Services.Configure<AuthenticationService.AutenticacionServiceOptions>(
    builder.Configuration.GetSection("Authentication"));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });



// configuración de autorización basada en roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Dueno", policy => policy.RequireRole(UserRole.Dueno.ToString()));
    options.AddPolicy("Cliente", policy => policy.RequireRole(UserRole.Cliente.ToString(), UserRole.Dueno.ToString()));
});

#endregion

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
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();


#endregion

#region Services
builder.Services.AddScoped(typeof(IService<,,,>), typeof(GenericService<,,,>));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDuenoService, DuenoService>();
builder.Services.AddScoped<IGuarderiaService, GuarderiaService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<INotificacionService, NotificacionService>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
