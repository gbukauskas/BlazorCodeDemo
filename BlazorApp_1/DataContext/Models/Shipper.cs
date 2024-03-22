using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class Shipper
{
    public short ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }
}
