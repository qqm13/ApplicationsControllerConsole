using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class Task0command : IRequest<IEnumerable<ApplicationDTO>>
    {
        public required int? ApplicantId { get; set; }

        public class Task0commandHandler : IRequestHandler<Task0command, IEnumerable<ApplicationDTO>>
        {


            private readonly Kirillov2010Context db;
            public Task0commandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

       

            public async Task<IEnumerable<ApplicationDTO>> HandleAsync(Task0command request, CancellationToken ct = default)
            {
                return await db.Applications
                   .Where(s => s.Id == request.ApplicantId)
                   .Select(s => new ApplicationDTO
                   {
                       Id = s.Id,
                       RejectionReason = s.RejectionReason,
                       EndDate = s.EndDate,
                       Purpose = s.Purpose,
                       DepartmentId = s.DepartmentId,
                       EmployeeId = s.EmployeeId,
                       ApplicantEmail = s.ApplicantEmail,
                       CreatedAt = s.CreatedAt,
                       UpdatedAt = s.UpdatedAt,
                       ApplicationTypeId = s.ApplicationTypeId,
                       ApplicationType = s.ApplicationType,
                       StatusId = s.StatusId,
                       Status = s.Status
                   }).ToListAsync();
            }
        }
    }
}