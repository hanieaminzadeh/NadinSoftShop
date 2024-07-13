using NadinSoftShop.Domain.Product.Dtos;
using System.Threading;
using NadinSoftShop.Domain.Product.Entities;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IProductRepository
    {
        Task<bool> Create(CreateProductDto model, CancellationToken cancellationToken);
        Task<GetProductDto> Get(int id, CancellationToken cancellationToken);
        Task<List<GetProductDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> Delete(int productId, int userId, CancellationToken cancellationToken);
        Task<bool> Update(UpdateProductDto model, int userId, CancellationToken cancellationToken);
    }
}
