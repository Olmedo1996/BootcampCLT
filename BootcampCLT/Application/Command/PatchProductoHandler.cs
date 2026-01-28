using BootcampCLT.Api.Response;
using BootcampCLT.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace BootcampCLT.Application.Command
{
    public class PatchProductoHandler
    : IRequestHandler<PatchProductoCommand, ProductoResponse?>
    {
        private readonly PostgresDbContext _context;

        public PatchProductoHandler(PostgresDbContext postgresDbContex)
        {
            _context = postgresDbContex;
        }

        public async Task<ProductoResponse?> Handle(
            PatchProductoCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Productos
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                return null;

            if (request.Request.Codigo is not null)
                entity.Codigo = request.Request.Codigo;

            if (request.Request.Nombre is not null)
                entity.Nombre = request.Request.Nombre;

            if (request.Request.Descripcion is not null)
                entity.Descripcion = request.Request.Descripcion;

            if (request.Request.Precio.HasValue)
                entity.Precio = request.Request.Precio.Value;

            if (request.Request.Activo.HasValue)
                entity.Activo = request.Request.Activo.Value;

            if (request.Request.CategoriaId.HasValue)
                entity.CategoriaId = request.Request.CategoriaId.Value;

            entity.FechaActualizacion = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return new ProductoResponse(
                Id: entity.Id,
                Codigo: entity.Codigo,
                Nombre: entity.Nombre,
                Descripcion: entity.Descripcion ?? string.Empty,
                Precio: (double)entity.Precio,
                Activo: entity.Activo,
                CategoriaId: entity.CategoriaId,
                FechaCreacion: entity.FechaCreacion,
                FechaActualizacion: entity.FechaActualizacion,
                CantidadStock: entity.CantidadStock
            );
        }
    }

}
