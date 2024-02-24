using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string? MobileNo { get; set; }

    public int ClinicId { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;
}
