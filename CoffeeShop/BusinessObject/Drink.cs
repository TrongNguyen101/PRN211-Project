namespace BusinessObject;

public partial class Drink
{
    public int DrinksId { get; set; }

    public string DrinksName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Status { get; set; }

    public int TypeOfDrinks { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
