﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp_1.DataContext.Models
{
    public partial class sp_employees_rollupResult
    {
        public string City { get; set; }
        [Column("Salary_By_City", TypeName = "decimal(38,2)")]
        public decimal? Salary_By_City { get; set; }
    }
}
