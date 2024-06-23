namespace FoodApi.Models;

public class RestaurantFood
{
    public int RestaurantId { get; set; }
    public int FoodId { get; set; }
    public Restaurant Restaurant { get; set; }
    public Food Food { get; set; }
    public ICollection<Order> Orders { get; set; }
}