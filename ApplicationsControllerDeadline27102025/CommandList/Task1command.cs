using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class Task1command : IRequest<IEnumerable<ApplicationDTO>>
    {
        public required string? ApplicantEmail { get; set; }

        public class Task1commandHandler : IRequestHandler<Task1command, IEnumerable<ApplicationDTO>>
        {


            private readonly Kirillov2010Context db;
            public Task1commandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<ApplicationDTO>> HandleAsync(Task1command request, CancellationToken ct = default)
            {

                return await db.Applications
                    .Where(s => s.ApplicantEmail == request.ApplicantEmail && s.ApplicationType.Title == "personal")
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
                    }).ToArrayAsync();
            }
        }
    }
}