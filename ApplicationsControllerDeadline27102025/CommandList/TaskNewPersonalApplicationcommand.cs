using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using ApplicationsControllerDeadline27102025.CommandList;
using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class TaskNewPersonalApplicationcommand : IRequest<Unit>
    {
        public int DepartId { get; set; } = 0;
        public int EmployeeId { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Purpose { get; set; } = "";
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public class TaskNewPersonalApplicationcommandHandler : IRequestHandler<TaskNewPersonalApplicationcommand, Unit>
        {


            private readonly Kirillov2010Context db;

            public TaskNewPersonalApplicationcommandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

            public async Task<Unit> HandleAsync(TaskNewPersonalApplicationcommand request, CancellationToken ct = default)
            {
                db.Applications.Add(new Application
                {
                    ApplicationTypeId = 0, //0 - personal
                    StatusId = 0, //pending
                    RejectionReason = null,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Purpose = request.Purpose,
                    DepartmentId = request.DepartId,
                    EmployeeId = request.EmployeeId,
                    ApplicantEmail = request.Email,
                    CreatedAt = DateTime.Now,

                });

                return Unit.Value;
            }

           
        }
    }
}