using System.ComponentModel.DataAnnotations;

namespace FoodApi.DTOs.Food;

public class FoodCreate
{
    [StringLength(5)]
    public String Name { get; set; }
}