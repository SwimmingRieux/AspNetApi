using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace FoodApi.Models;

public class Food
{
    public int FoodId { get; set; }
    public string Name { get; set; }
    public ICollection<RestaurantFood> RestaurantFoods { get; set; }

    public Food(String Name)
    {
        this.Name = Name;
        RestaurantFoods = new List<RestaurantFood>();
    }
}