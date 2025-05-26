using AutoMapper;
using FoodMartMongoDb.Dtos.CategoryDtos;
using FoodMartMongoDb.Entities;

namespace FoodMartMongoDb.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<Product,ResultCategoryDto>().ReverseMap();
            CreateMap<Product,UpdateCategoryDto>().ReverseMap();
            CreateMap<Product,CreateCategoryDto>().ReverseMap();
            CreateMap<Product, GetCategoryByIdDto>().ReverseMap();

            CreateMap<Customer, ResultCategoryDto>().ReverseMap();
            CreateMap<Customer, UpdateCategoryDto>().ReverseMap();
            CreateMap<Customer, CreateCategoryDto>().ReverseMap();
            CreateMap<Customer, GetCategoryByIdDto>().ReverseMap();

        }
    }
}
