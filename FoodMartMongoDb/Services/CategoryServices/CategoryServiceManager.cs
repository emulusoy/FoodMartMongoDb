﻿using AutoMapper;
using FoodMartMongoDb.Dtos.CategoryDtos;
using FoodMartMongoDb.Entities;
using FoodMartMongoDb.Settings;
using MongoDB.Driver;

namespace FoodMartMongoDb.Services.CategoryServices
{
    public class CategoryServiceManager : ICategoryService
    {
        private readonly IMongoCollection<Category> _mongoCollection;
        private readonly IMapper _mapper;

        public CategoryServiceManager(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value=_mapper.Map<Category>(createCategoryDto);
            await _mongoCollection.InsertOneAsync(value);

        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.CategoryID==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values=await _mongoCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            var value=await _mongoCollection.Find(x=>x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCategoryByIdDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values=_mapper.Map<Category>(updateCategoryDto);
            await _mongoCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
        }
    }
}
