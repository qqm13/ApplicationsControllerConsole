using ApplicationsControllerDeadline27102025.CommandList;
using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace ApplicationsControllerDeadline27102025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly Mediator mediator;
        public ApprovalController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("Fifth")]
        public async Task<IEnumerable<ApplicationDTO>> Task5Command(int idDep)
        {
            var command = new Task5Command { IdDep = idDep };
            var result = await mediator.SendAsync(command);
            return result;
        }
    }
}
