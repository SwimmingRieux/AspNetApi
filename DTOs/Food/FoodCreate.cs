using System.ComponentModel.DataAnnotations;

namespace FoodApi.Schemas.Food;

public class FoodCreate
{
    [StringLength(5)]
    public String Name { get; set; }
}