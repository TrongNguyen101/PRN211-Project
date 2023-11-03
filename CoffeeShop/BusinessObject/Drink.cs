using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class Drink
{
    [Key]
    public int DrinkId { get; set; }

    [StringLength(50)]
    public string DrinkName { get; set; } = null!;

    public int TypeOfDrink { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int Status { get; set; }

    [InverseProperty("Drink")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
