using System;
using System.Collections.Generic;

namespace LghLesson10EFCDBFirst.Models;

public partial class LghMember
{
    public long Id { get; set; }

    public string? LghUserName { get; set; }

    public string? LghPassword { get; set; }

    public string? LghFullName { get; set; }

    public string? LghEmail { get; set; }

    public string? LghPhone { get; set; }

    public bool? LghStatus { get; set; }
}
