using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    public string StaffName { get; set; } = null!;

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(15)]
    public string Password { get; set; } = null!;

    public int Role { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
