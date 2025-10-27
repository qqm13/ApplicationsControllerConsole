using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class Task4Command : IRequest<IEnumerable<EmployeeDTO>>
    {
        public int IdDep { get; internal set; }

        public class Task4CommandHandler : IRequestHandler<Task4Command, IEnumerable<EmployeeDTO>>
        {

            private readonly Kirillov2010Context db;
            public Task4CommandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<EmployeeDTO>> HandleAsync(Task4Command request, CancellationToken ct = default)
            {

                var employees = await db.Employees
                .Where(e => e.DepartamentId == request.IdDep)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    DepartamentId = e.DepartamentId,
                }).ToListAsync();

                return employees;



            }
        }
    }
}