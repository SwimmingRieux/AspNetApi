namespace FoodApi.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}