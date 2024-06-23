using AutoMapper;
using FoodApi.Models;
using FoodApi.Schemas.Food;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Food, FoodCreate>().ReverseMap();
        CreateMap<Food, FoodUpdate>().ReverseMap();
        
    }
}