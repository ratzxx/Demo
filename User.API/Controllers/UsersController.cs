using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application.Commands.CreateUser;
using User.Application.Commands.DeleteUser;
using User.Application.Commands.UpdateUser;
using User.Application.Common.Dto;
using User.Application.Queries.GetUser;
using User.Application.Queries.GetUsers;

namespace User.API.Controllers
{
    public class UsersController: ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<UsersVm>> Get()
        {
            return await Mediator.Send(new GetUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            return await Mediator.Send(new GetUserQuery { Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
