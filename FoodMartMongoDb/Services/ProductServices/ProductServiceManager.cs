using AutoMapper;
using FoodMartMongoDb.Dtos.ProductDtos;
using FoodMartMongoDb.Entities;
using FoodMartMongoDb.Settings;
using MongoDB.Driver;

namespace FoodMartMongoDb.Services.ProductServices
{
    public class ProductServiceManager : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductServiceManager(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection=database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value=_mapper.Map<Product>(createProductDto);//bu su anlama gelir! create product dto ile product sinifini eslestir demek1!
            await _productCollection.InsertOneAsync(value);//bu ekleme islemini yapar!
            //once mapper ile essleme sonra ise ekleme yapilir!
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public Task<List<ResultProductDto>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);

        }
    }
}
