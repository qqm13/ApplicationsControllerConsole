using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsControllerDeadline27102025.DTO
{
    public class GroupApplicationContactDTO
    {
        public int Id { get; set; }

        public int? ApplicationId { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public string? Organization { get; set; }
    }
}
