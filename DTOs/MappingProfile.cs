using AutoMapper;
using FoodApi.Models;
using FoodApi.DTOs.Food;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Food, FoodCreate>().ReverseMap();
        CreateMap<Food, FoodUpdate>().ReverseMap();
        
    }
}