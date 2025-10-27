using System;
using System.Collections.Generic;

namespace ApplicationsControllerDeadline27102025;

public partial class Application
{
    public int Id { get; set; }

    public int? ApplicationTypeId { get; set; }

    public int? StatusId { get; set; }

    public string? RejectionReason { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Purpose { get; set; }

    public int? DepartmentId { get; set; }

    public int? EmployeeId { get; set; }

    public string? ApplicantEmail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ApplicationType? ApplicationType { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<GroupApplicationContact> GroupApplicationContacts { get; set; } = new List<GroupApplicationContact>();

    public virtual ICollection<PersonalVisitor> PersonalVisitors { get; set; } = new List<PersonalVisitor>();

    public virtual Status? Status { get; set; }
}
