using AutoMapper;
using FoodMartMongoDb.Dtos.CustomerDtos;
using FoodMartMongoDb.Entities;
using FoodMartMongoDb.Settings;
using MongoDB.Driver;

namespace FoodMartMongoDb.Services.CustomerServices
{
    public class CustomerServiceManager : ICustomerService
    {
        private readonly IMongoCollection<Customer> _mongoCollection;
        private readonly IMapper _mapper;

        public CustomerServiceManager(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var value=_mapper.Map<Customer>(createCustomerDto);
            await _mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.CustomerId==id);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values=await _mongoCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);    


        }

        public Task<GetCustomerByIdDto> GetCustomerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var value = _mapper.Map<Customer>(updateCustomerDto);
            await _mongoCollection.FindOneAndReplaceAsync(x=>x.CustomerId==updateCustomerDto.CustomerId,value);
        }
    }
}
