using ManagementSystem.Data;
using ManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<AppDbContext>(
        options => options.UseMySql(builder.Configuration.GetConnectionString("MySQLDatabase"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySQLDatabase"))
        )
    );

builder.Services.AddScoped<IUsersRepositorie, UserRepositorie>();

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
