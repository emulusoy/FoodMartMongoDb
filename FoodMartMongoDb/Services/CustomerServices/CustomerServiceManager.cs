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
        public Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCustomerByIdDto> GetCustomerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            throw new NotImplementedException();
        }
    }
}
