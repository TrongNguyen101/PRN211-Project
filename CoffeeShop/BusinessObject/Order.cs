using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

[Table("Order")]
public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int TableId { get; set; }

    public int OrderStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    public int? AccountId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Orders")]
    public virtual Account? Account { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
