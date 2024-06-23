namespace FoodApi.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int RestaurantFoodId { get; set; }
    public User User { get; set; }
    public RestaurantFood RestaurantFood { get; set; }
}