using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class Territory
{
    public string TerritoryId { get; set; } = null!;

    public char TerritoryDescription { get; set; }

    public short RegionId { get; set; }
}
