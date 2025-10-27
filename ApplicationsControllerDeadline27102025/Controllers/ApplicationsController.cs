using ApplicationsControllerDeadline27102025.CommandList;
using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace ApplicationsControllerDeadline27102025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly Mediator mediator;
        public ApplicationsController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("PersApplicationByEmail")]
        public async Task<IEnumerable<ApplicationDTO>> Task1command(string ApplicantEmail)
        {
            var command = new Task1command { ApplicantEmail = ApplicantEmail };
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpGet("GroupApplicationByEmail")]
        public async Task<IEnumerable<ApplicationDTO>> Task2command(string ApplicantEmail)
        {
            var command = new Task2command { ApplicantEmail = ApplicantEmail };
            var result = await mediator.SendAsync(command);
            return result;
        }
    }
}