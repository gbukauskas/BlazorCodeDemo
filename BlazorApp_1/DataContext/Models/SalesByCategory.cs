﻿using System;
using System.Collections.Generic;

namespace mySQLef.northwindDB;

public partial class SalesByCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public double? ProductSales { get; set; }
}
