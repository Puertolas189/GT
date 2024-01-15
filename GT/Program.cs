using GT.Contracts;
using GT.Models;
using GT.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GlobalTaskEFContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    GlobalTaskEFContext context = scope.ServiceProvider.GetRequiredService<GlobalTaskEFContext>();
    context.Database.EnsureCreated();
}

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
