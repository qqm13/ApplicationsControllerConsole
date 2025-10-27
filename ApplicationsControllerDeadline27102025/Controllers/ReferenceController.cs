using ApplicationsControllerDeadline27102025.CommandList;
using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace ApplicationsControllerDeadline27102025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {

        private readonly Mediator mediator;
        public ReferenceController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("Third")]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> Task3Command()
        {
            var command = new Task3Command();
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("Fourth")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Task4Command(int idDep)
        {
            var command = new Task4Command { IdDep = idDep };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
    }
}