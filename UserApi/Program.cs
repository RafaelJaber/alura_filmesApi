using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Repository;
using UserApi.Repository.IRepository;
using UserApi.Services;
using UserApi.Services.IServices;

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
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
});


// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

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
