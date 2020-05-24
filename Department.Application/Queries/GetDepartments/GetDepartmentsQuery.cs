using AutoMapper;
using AutoMapper.QueryableExtensions;
using Department.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Department.Application.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<DepartmentsVm>
    {
    }

    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, DepartmentsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentsVm> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return new DepartmentsVm
            {
                Departments = await _context.Departments
                    .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
