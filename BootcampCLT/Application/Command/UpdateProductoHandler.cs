using BootcampCLT.Api.Response;
using BootcampCLT.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace BootcampCLT.Application.Command
{
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand, ProductoResponse?>
    {
        private readonly PostgresDbContext _context;

        public UpdateProductoHandler(PostgresDbContext postgresDbContex)
        {
            _context = postgresDbContex;
        }

        public async Task<ProductoResponse?> Handle(
            UpdateProductoCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Productos
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                return null;

            entity.Codigo = request.Request.Codigo;
            entity.Nombre = request.Request.Nombre;
            entity.Descripcion = request.Request.Descripcion;
            entity.Precio = request.Request.Precio;
            entity.Activo = request.Request.Activo;
            entity.CategoriaId = request.Request.CategoriaId;
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
