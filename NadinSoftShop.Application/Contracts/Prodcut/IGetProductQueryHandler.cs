using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IGetProductQueryHandler
    {
        Task<GetProductDto> GetProductHandler(int id, CancellationToken cancellationToken);
    }
}
