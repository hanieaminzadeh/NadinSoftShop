using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NadinSoftShop.Application.Contracts.Prodcut;
using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Infrastructure.Repositories
{
    public class ProductRepositoryDapper : IProductRepositoryDapper
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public ProductRepositoryDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration["ConnectionStrings:ConnectionString"];
        }

        public async Task<List<GetProductDto>> GetAll(int? userId, CancellationToken cancellationToken)
        {
            var query = string.Empty;

            var connection = new SqlConnection(ConnectionString);

            query = userId is null ? "SELECT Id,Name,IsAvailable,ManufactureEmail,ManufacturePhone,ProduceDate FROM Products"
                : $"SELECT Id,Name,IsAvailable,ManufactureEmail,ManufacturePhone,ProduceDate FROM Products WHERE userId = {userId}";

            var result = await connection.QueryAsync<GetProductDto>(query);

            return result.ToList();
        }

        public async Task<GetProductDto> GetById(int id, CancellationToken cancellationToken)
        {
            var connection = new SqlConnection(ConnectionString);

            var query = "SELECT Id,Name,IsAvailable,ManufactureEmail,ManufacturePhone,ProduceDate FROM Products WHERE Id = @Id";

            var parameters = new { Id = id };

            var result = await connection.QueryFirstAsync<GetProductDto>(query, parameters);

            if (result != null)
            {
                return result;
            }

            throw new Exception($"Product with id {id} not found!");
        }
    }
}
