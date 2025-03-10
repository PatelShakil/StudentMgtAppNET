using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Student
{
    public int EnrollmentNo { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? Achievement { get; set; }
}
