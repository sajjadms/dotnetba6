using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentTitle { get; set; }

    public virtual ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();
}
