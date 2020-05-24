using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Dto;
using User.Application.Common.Interfaces;

namespace User.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .Where(i => i.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
