using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class ProductsAboveAveragePrice
{
    public string? ProductName { get; set; }

    public double? UnitPrice { get; set; }
}
