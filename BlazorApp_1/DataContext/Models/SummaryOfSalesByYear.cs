﻿using System;
using System.Collections.Generic;

namespace mySQLef.northwindDB;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public double? Subtotal { get; set; }
}
