using BootcampCLT.Api.Request;
using BootcampCLT.Api.Response;
using MediatR;

namespace BootcampCLT.Application.Command
{
    public record PatchProductoCommand(int Id, PatchProductoRequest Request)
        : IRequest<ProductoResponse?>;
}
