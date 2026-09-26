using System;
using System.Collections.Generic;

namespace LeGiaHung2410900041_exam.Models;

public partial class LghStudent
{
    public long Id { get; set; }

    public string? LghName { get; set; }

    public bool? LghGender { get; set; }

    public DateOnly? LghBirthDay { get; set; }

    public string? LghEmail { get; set; }

    public string? LghPhone { get; set; }

    public bool? LghActive { get; set; }
}
