using Microsoft.EntityFrameworkCore;
using CRUDCliente.Application.Interfaces;
using CRUDCliente.Application.Mapping;
using CRUDCliente.Application.Services;
using CRUDCliente.Domain.Interfaces;
using CRUDCliente.Infra.Context;
using CRUDCliente.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(
      options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
      m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
