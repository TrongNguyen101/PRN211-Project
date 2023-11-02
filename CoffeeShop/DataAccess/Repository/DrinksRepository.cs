using BusinessObject;

namespace DataAccess.Repository
{
    public class DrinksRepository : IDrinksRepository
    {


        public Drink GetDrinkbyId(int id) => DrinksDAO.Instance.GetDrinksById(id);
        public IEnumerable<Drink> GetAllDrinks() => DrinksDAO.Instance.GetDrinksList();
        public void AddDrink(Drink drink) => DrinksDAO.Instance.AddDrinks(drink);
        public void DeleteDrink(int drinksId) => DrinksDAO.Instance.DeleteDrinks(drinksId);
        public void UpdateDrink(Drink drink) => DrinksDAO.Instance.UpdateDrinks(drink);
    }
}
