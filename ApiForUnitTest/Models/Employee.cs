using System;
using System.Collections.Generic;

namespace ApiForUnitTest.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmployeeCode { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateOfJoin { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }
}
