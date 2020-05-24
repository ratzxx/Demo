using AutoMapper;
using User.Application.Common.Mappings;

namespace User.Application.Common.Dto
{
    public class UserDto : IMapFrom<Domain.Entities.User>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int DepartmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}
