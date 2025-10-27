using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class Task5Command : IRequest<IEnumerable<ApplicationDTO>>
    {
        public int IdDep { get; internal set; }

        public class Task5CommandHandler : IRequestHandler<Task5Command, IEnumerable<ApplicationDTO>>
        {

            private readonly Kirillov2010Context db;
            public Task5CommandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<ApplicationDTO>> HandleAsync(Task5Command request, CancellationToken ct = default)
            {

                var applications = await db.Applications
                .Where(e => e.DepartmentId == request.IdDep)
                .Select(e => new ApplicationDTO
                {
                    Id = e.Id,
                    ApplicationType = e.ApplicationType,
                    Status = e.Status,
                    RejectionReason = e.RejectionReason,
                    EndDate = e.EndDate,
                    StartDate = e.StartDate,
                    Purpose = e.Purpose,
                    DepartmentId = e.DepartmentId,
                    EmployeeId = e.EmployeeId,
                    ApplicantEmail = e.ApplicantEmail,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                }).ToListAsync();

                return applications;



            }
        }
    }
}