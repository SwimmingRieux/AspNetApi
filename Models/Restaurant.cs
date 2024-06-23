namespace FoodApi.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public ICollection<RestaurantFood> RestaurantFoods { get; set; }
}