namespace BusinessObject;

public partial class Order
{
    public int OrderId { get; set; }

    public int DrinksId { get; set; }

    public int DrinkQuantity { get; set; }

    public string DrinkNote { get; set; } = null!;

    public DateTime TimeOrder { get; set; }

    public decimal Total { get; set; }

    public int StatusOrder { get; set; }

    public int TableId { get; set; }

    public virtual Drink Drinks { get; set; } = null!;
}
