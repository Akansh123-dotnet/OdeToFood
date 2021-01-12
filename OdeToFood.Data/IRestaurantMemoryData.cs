using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
namespace OdeToFood.Data
{
    public class IRestaurantMemoryData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public IRestaurantMemoryData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id=1,Name="Thug",Location="Delhi",Cusine=CusineType.Indian},
                new Restaurant{ Id=2,Name="Thugs",Location="Pune",Cusine=CusineType.Itaian},
                new Restaurant{ Id=3,Name="FUck",Location="Jaipur",Cusine=CusineType.Mexican},
                new Restaurant{ Id=4,Name="Ruit",Location="Bir",Cusine=CusineType.None}


            };
        }
        public Restaurant UpdateRestaurant(Restaurant updatedrestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedrestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedrestaurant.Name;
                restaurant.Location = updatedrestaurant.Location;
                restaurant.Cusine = updatedrestaurant.Cusine;

            }
            return restaurant;
        }
        public Restaurant GetRestaurantById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
    }

        public IEnumerable<Restaurant> GetRestaurants(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant AddRestaurant(Restaurant newrestaurant)
        {
            restaurants.Add(newrestaurant);
            newrestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newrestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == Id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;

        }
    }
}
