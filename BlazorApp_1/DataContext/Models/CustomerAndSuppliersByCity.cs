using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class CustomerAndSuppliersByCity
{
    public string? City { get; set; }

    public string? CompanyName { get; set; }

    public string? ContactName { get; set; }

    public string? Relationship { get; set; }
}
