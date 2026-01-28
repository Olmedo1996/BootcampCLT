using BootcampCLT.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Application.Command
{
    public class DeleteProductoHandler
    : IRequestHandler<DeleteProductoCommand, bool>
    {
        private readonly PostgresDbContext _context;

        public DeleteProductoHandler(PostgresDbContext postgresDbContex)
        {
            _context = postgresDbContex;
        }

        public async Task<bool> Handle(
            DeleteProductoCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Productos
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                return false;

            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
