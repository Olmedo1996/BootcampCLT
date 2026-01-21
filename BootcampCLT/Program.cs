using BootcampCLT.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ProductosDb")));

//MediaR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetProductoByIdHandler).Assembly));

builder.Host.UseSerilog((ctx, services, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration)
      .ReadFrom.Services(services)
      .Enrich.FromLogContext()
);

// Necesario para Swagger clásico
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
