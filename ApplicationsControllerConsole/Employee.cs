using System;
using System.Collections.Generic;

namespace ApplicationsControllerConsole;

public partial class Employee
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public int? DepartamentId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
