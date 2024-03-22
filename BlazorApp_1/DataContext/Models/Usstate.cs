using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class Usstate
{
    public short StateId { get; set; }

    public string? StateName { get; set; }

    public string? StateAbbr { get; set; }

    public string? StateRegion { get; set; }
}
