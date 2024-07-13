using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface ICreateProductCommandHandler
    {
        Task<bool> CreateProductHandler(CreateProductDto model, CancellationToken cancellationToken);
    }
}
