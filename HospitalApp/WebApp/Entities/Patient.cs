using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? AdharNo { get; set; }

    public string Gender { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? MobileNo { get; set; }

    public string? BloodGroup { get; set; }

    public string? Address { get; set; }

    public int? NationalityId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Nationality? Nationality { get; set; }
}
