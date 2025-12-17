using BootcampCLT.Api.Response;
using MediatR;

namespace BootcampCLT.Application.Query
{
    // Query sin parámetros para obtener todos los productos
    public record GetProductosQuery : IRequest<List<ProductoResponse>>;
}