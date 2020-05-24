using MediatR;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Exceptions;
using User.Application.Common.Interfaces;

namespace User.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int DepartmentId { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }

            entity.UserName = request.UserName;
            entity.DepartmentId = request.DepartmentId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
