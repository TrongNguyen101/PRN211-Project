using BusinessObject;

namespace DataAccess
{
    public class DrinksDAO
    {
        #region Singleton pattern
        private static DrinksDAO instance;
        private static readonly object lockInstance = new object();
        public static DrinksDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new DrinksDAO();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Get Drinks List
        public IEnumerable<Drink> GetDrinksList()
        {
            var drinksList = new List<Drink>();
            try
            {
                using var context = new CoffeeShopContext();
                drinksList = context.Drinks.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return drinksList;
        }
        #endregion

        #region Get Drinks By Id
        public Drink GetDrinksById(int drinksId)
        {
            Drink drink = null;
            try
            {
                using var context = new CoffeeShopContext();
                drink = context.Drinks.SingleOrDefault(d => d.DrinkId == drinksId);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return drink;
        }
        #endregion

        #region Add New Drinks
        public void AddDrinks(Drink drink)
        {
            try
            {
                Drink _drink = GetDrinksById(drink.DrinkId);
                if(_drink == null)
                {
                    using var context = new CoffeeShopContext();
                    context.Drinks.Add(drink);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The drinks is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Drinks
        public void UpdateDrinks(Drink drink)
        {
            try
            {
                Drink _drink = GetDrinksById(drink.DrinkId);
                if(_drink != null)
                {
                    using var context = new CoffeeShopContext();
                    context.Drinks.Update(drink);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The drinks does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Remove Drinks
        public void DeleteDrinks(int drinkId)
        {
            try
            {
                if (drinkId.ToString() != null)
                {
                    Drink drink = GetDrinksById(drinkId);
                    using var context = new CoffeeShopContext();
                    context.Drinks.Remove(drink);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The drinks does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
