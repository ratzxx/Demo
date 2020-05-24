using MediatR;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Interfaces;

namespace User.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public int DepartmentId { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.User
            {
                UserName = request.UserName,
                DepartmentId = request.DepartmentId
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
