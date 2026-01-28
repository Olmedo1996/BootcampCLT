using BootcampCLT.Api.Request;
using BootcampCLT.Api.Response;
using MediatR;

namespace BootcampCLT.Application.Command
{
    public record UpdateProductoCommand(int Id, UpdateProductoRequest Request)
        : IRequest<ProductoResponse?>;
}
