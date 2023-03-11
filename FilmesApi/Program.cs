using FilmesApi.Data;
using FilmesApi.Repository;
using FilmesApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Adicionando conexão com o banco
string? connectionStringMovie = builder.Configuration.GetConnectionString("MovieConnection");
builder.Services.AddDbContext<MovieContext>(opts => 
    opts.UseMySql(connectionStringMovie, ServerVersion.AutoDetect(connectionStringMovie))
);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMovieTheaterRepository, MovieTheaterRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

WebApplication app = builder.Build();

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
