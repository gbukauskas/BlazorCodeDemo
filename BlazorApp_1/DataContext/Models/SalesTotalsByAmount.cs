using System;
using System.Collections.Generic;

namespace mySQLef.northwindDB;

public partial class SalesTotalsByAmount
{
    public double? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
