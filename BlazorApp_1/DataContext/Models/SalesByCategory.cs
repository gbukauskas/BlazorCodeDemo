using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class SalesByCategory
{
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? ProductName { get; set; }

    public double? ProductSales { get; set; }
}
