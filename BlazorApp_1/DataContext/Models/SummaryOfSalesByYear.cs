using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int? OrderId { get; set; }

    public double? Subtotal { get; set; }
}
