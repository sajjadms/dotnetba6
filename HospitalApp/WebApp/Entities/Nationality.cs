using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Nationality
{
    public int NationalityId { get; set; }

    public string NationalityName { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
