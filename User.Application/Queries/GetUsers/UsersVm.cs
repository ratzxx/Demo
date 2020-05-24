using System.Collections.Generic;
using User.Application.Common.Dto;

namespace User.Application.Queries.GetUsers
{
    public class UsersVm
    {
        public IList<UserDto> Users { get; set; }
    }
}
