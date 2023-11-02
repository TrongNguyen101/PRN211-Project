using BusinessObject;

namespace DataAccess.Repository
{
    public interface IDrinksRepository
    {
        IEnumerable<Drink> GetAllDrinks();
        Drink GetDrinkbyId(int id);
        void AddDrink(Drink drink);
        void UpdateDrink(Drink drink);
        void DeleteDrink(int drinksId);
    }
}
