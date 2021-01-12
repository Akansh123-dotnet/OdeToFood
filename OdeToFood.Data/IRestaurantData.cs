using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurants(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        Restaurant AddRestaurant(Restaurant newrestaurant);

        Restaurant Delete(int Id);
    }
}
