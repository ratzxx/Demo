using AutoMapper;
using AutoMapper.QueryableExtensions;
using User.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Dto;

namespace User.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UsersVm>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                Users = await _context.Users
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.UserName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
