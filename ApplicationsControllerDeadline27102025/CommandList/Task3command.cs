using ApplicationsControllerDeadline27102025.DTO;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace ApplicationsControllerDeadline27102025.CommandList
{
    public class Task3Command : IRequest<IEnumerable<DepartmentDTO>>
    {

        public class Task3CommandHandler : IRequestHandler<Task3Command, IEnumerable<DepartmentDTO>>
        {


            private readonly Kirillov2010Context db;
            public Task3CommandHandler(Kirillov2010Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<DepartmentDTO>> HandleAsync(Task3Command request, CancellationToken ct = default)
            {

                return await db.Departments
                    .Select(s => new DepartmentDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Code = s.Code
                    }).ToArrayAsync();
            }
        }
    }
}