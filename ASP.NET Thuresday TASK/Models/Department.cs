using System;
using System.Collections.Generic;

namespace ASP.NET_Thuresday_TASK.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? DepartmentName { get; set; }

    public string? DepartmentManger { get; set; }

    public string? Location { get; set; }

    public decimal? Budget { get; set; }
}
