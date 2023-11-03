using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class CoffeeShopContext : DbContext
{
    public CoffeeShopContext()
    {
    }

    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CoffeeTable> CoffeeTables { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3RPQQSC\\SQLEXPRESS;Initial Catalog=CoffeeShop;Persist Security Info=True;User ID=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.Account).WithMany(p => p.Orders).HasConstraintName("FK_Order_Accounts");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_CoffeeTables");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasOne(d => d.Drink).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Drinks");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
