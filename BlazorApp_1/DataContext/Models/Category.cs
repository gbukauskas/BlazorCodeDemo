using System;
using System.Collections.Generic;

namespace BlazorApp_1.DataContext.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual Product? Product { get; set; }
}
