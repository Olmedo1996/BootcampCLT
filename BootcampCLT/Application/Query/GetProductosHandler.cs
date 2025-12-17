using BootcampCLT.Api.Response;
using BootcampCLT.Application.Query;
using BootcampCLT.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Application.Handlers
{
    public class GetAllProductosHandler : IRequestHandler<GetProductosQuery, List<ProductoResponse>>
    {
        private readonly PostgresDbContext _context;

        public GetAllProductosHandler(PostgresDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoResponse>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            var productos = await _context.Productos
                .Where(p => p.Activo) // Solo productos activos (opcional)
                .OrderBy(p => p.Nombre) // Ordenar por nombre
                .Select(p => new ProductoResponse
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Activo = p.Activo,
                    CategoriaId = p.CategoriaId,
                    CantidadStock = p.CantidadStock,
                    FechaCreacion = p.FechaCreacion,
                    FechaActualizacion = p.FechaActualizacion
                })
                .ToListAsync(cancellationToken);

            return productos;
        }
    }
}