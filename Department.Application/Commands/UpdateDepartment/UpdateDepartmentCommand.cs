using Department.Application.Common.Exceptions;
using Department.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Department.Application.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDepartmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Department), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
