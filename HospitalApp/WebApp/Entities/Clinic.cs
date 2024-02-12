using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public string ClinicName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
