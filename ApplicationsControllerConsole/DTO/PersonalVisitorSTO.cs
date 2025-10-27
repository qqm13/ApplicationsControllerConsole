using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsControllerConsole.DTO
{
    public class PersonalVisitorSTO
    {
        public int Id { get; set; }

        public int? ApplicationId { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Organization { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? PassportSeries { get; set; }

        public string? PassportNumber { get; set; }
    }
}
