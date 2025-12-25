using Administration.API.DependancyInjections;
using Administration.Data.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdministrationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("AdministrationConnection"), new MySqlServerVersion(new Version(8, 0, 43)))
);

builder.Services.AddServices().AddRepositories();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
