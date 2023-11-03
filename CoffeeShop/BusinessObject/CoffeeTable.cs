using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class CoffeeTable
{
    [Key]
    public int TableId { get; set; }

    public int TableNumber { get; set; }

    [InverseProperty("Table")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
