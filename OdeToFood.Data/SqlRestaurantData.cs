using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant AddRestaurant(Restaurant newrestaurant)
        {
            db.Add(newrestaurant);
            db.SaveChanges();
            return newrestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetRestaurantById(Id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            db.SaveChanges();
            return restaurant;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurants(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name)  || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            db.SaveChanges();
            return restaurant;
        }
    }
}
