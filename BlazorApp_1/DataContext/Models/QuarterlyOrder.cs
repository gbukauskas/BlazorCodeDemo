﻿using System;
using System.Collections.Generic;

namespace mySQLef.northwindDB;

public partial class QuarterlyOrder
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }
}
