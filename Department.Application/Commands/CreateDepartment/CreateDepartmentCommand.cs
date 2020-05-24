using Department.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Department.Application.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDepartmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Department
            {
                Title = request.Title
            };

            _context.Departments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
