using AutoMapper;
using FoodMartMongoDb.Dtos.CategoryDtos;
using FoodMartMongoDb.Entities;

namespace FoodMartMongoDb.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, GetCategoryByIdDto>();

            CreateMap<Product,ResultCategoryDto>();
            CreateMap<Product,UpdateCategoryDto>();
            CreateMap<Product,CreateCategoryDto>();
            CreateMap<Product, GetCategoryByIdDto>();

            CreateMap<Customer, ResultCategoryDto>();
            CreateMap<Customer, UpdateCategoryDto>();
            CreateMap<Customer, CreateCategoryDto>();
            CreateMap<Customer, GetCategoryByIdDto>();

        }
    }
}
