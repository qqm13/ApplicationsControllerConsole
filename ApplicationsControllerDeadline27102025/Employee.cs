using System;
using System.Collections.Generic;

namespace ApplicationsControllerDeadline27102025;

public partial class Employee
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public int? DepartamentId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
