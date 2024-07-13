using NadinSoftShop.Application.Contracts.Prodcut;
using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Features.Product.Queries
{
    public class GetAllProductQueryHandler : IGetAllProductQueryHandler
    {
        private readonly IProductRepositoryDapper _productRepositoryDapper;

        public GetAllProductQueryHandler(IProductRepositoryDapper productRepositoryDapper)
        {
            _productRepositoryDapper = productRepositoryDapper;
        }

        public async Task<List<GetProductDto>> GetAllProductHandler(int? userId, CancellationToken cancellationToken)
            => await _productRepositoryDapper.GetAll(userId, cancellationToken);
    }
}