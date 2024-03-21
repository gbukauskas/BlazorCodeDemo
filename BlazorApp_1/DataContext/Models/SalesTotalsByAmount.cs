using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class SalesTotalsByAmount
{
    public double? SaleAmount { get; set; }

    public int? OrderId { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? ShippedDate { get; set; }
}
