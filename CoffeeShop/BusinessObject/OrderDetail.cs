using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

[PrimaryKey("OrderId", "DrinkId")]
[Table("OrderDetail")]
public partial class OrderDetail
{
    [Key]
    public int OrderId { get; set; }

    [Key]
    public int DrinkId { get; set; }

    public int Quantity { get; set; }

    [StringLength(50)]
    public string DrinkNote { get; set; } = null!;

    [ForeignKey("DrinkId")]
    [InverseProperty("OrderDetails")]
    public virtual Drink Drink { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;
}
