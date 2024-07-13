using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IGetAllProductQueryHandler
    {
        Task<List<GetProductDto>> GetAllProductHandler(int? userId, CancellationToken cancellationToken);
    }
}
