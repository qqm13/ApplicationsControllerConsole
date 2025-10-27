using System;
using System.Collections.Generic;

namespace ApplicationsControllerConsole;

public partial class Status
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
