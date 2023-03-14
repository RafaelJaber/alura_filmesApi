using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Adiciona conexão com o banco
string? connectionStringAuth= builder.Configuration.GetConnectionString("AuthConnection");
builder.Services.AddDbContext<UserDbContext>(opts => 
    opts
        .UseMySql(connectionStringAuth, ServerVersion.AutoDetect(connectionStringAuth))
);
// Adiciona o identity
builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<UserDbContext>();


// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
