using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class OrderDetail
{
    public short OrderId { get; set; }

    public short ProductId { get; set; }

    public float UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }
}
