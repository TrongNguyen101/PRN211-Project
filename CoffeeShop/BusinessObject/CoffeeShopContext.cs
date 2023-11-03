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

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3RPQQSC\\SQLEXPRESS;Initial Catalog=CoffeeShop;Persist Security Info=True;User ID=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.DrinksId);

            entity.Property(e => e.DrinksName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.TimeOrder).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Drinks).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DrinksId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Drinks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
