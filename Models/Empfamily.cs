using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Empfamily
{
    public int Id { get; set; }

    public string? EmployeeCode { get; set; }

    public string? DependencyType { get; set; }

    public string? DependencyDob { get; set; }

    public int? Age { get; set; }

    public string? DependencyOccupation { get; set; }

    public string? DependencyAadhaarNumber { get; set; }

    public string? DependencyPanNumber { get; set; }
}
