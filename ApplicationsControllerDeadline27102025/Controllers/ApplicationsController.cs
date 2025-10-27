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

        [HttpGet("ApplicationById")]
        public async Task<IEnumerable<ApplicationDTO>> Task0command(int applicantId)
        {
            var command = new Task0command { ApplicantId = applicantId };
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpGet("NewPersonalApplication")]
        public async Task<ActionResult> TaskNewPersonalApplicationcommand(DateTime startdate, DateTime enddate, string purpose, int departid, int employeeid, string email)
        {
            var command = new TaskNewPersonalApplicationcommand { StartDate = startdate, EndDate = enddate, Purpose = purpose, DepartId = departid, Email = email, EmployeeId = employeeid };
            var result = await mediator.SendAsync(command);
            return Ok();
        }

        [HttpGet("NewGroupApplication")]
        public async Task<ActionResult> TaskNewGroupApplication(DateTime startdate, DateTime enddate, string purpose, int departid, int employeeid, string email)
        {
            var command = new TaskNewGroupApplicationcommand { StartDate = startdate, EndDate = enddate, Purpose = purpose, DepartId = departid, Email = email, EmployeeId = employeeid };
            var result = await mediator.SendAsync(command);
            return Ok();
        }


    }
}