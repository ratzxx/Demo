using System.Threading.Tasks;
using Department.Application.Commands.CreateDepartment;
using Department.Application.Commands.DeleteDepartment;
using Department.Application.Commands.UpdateDepartment;
using Department.Application.Queries.GetDepartments;
using Microsoft.AspNetCore.Mvc;

namespace Department.API.Controllers
{
      public class DepartmentsController : ApiController
    {
       
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDepartmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<DepartmentsVm>> Get()
        {
            return await Mediator.Send(new GetDepartmentsQuery());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateDepartmentCommand command)
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
            await Mediator.Send(new DeleteDepartmentCommand { Id = id });

            return NoContent();
        }
    }
}