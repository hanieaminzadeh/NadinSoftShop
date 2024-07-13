using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IProductRepositoryDapper
    {
        Task<List<GetProductDto>> GetAll(int? userId, CancellationToken cancellationToken);
        Task<GetProductDto> GetById(int id, CancellationToken cancellationToken);
    }
}
