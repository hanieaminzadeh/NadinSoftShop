using NadinSoftShop.Application.Contracts.Prodcut;
using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Features.Product.Queries
{
    public class GetProductQueryHandler : IGetProductQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductDto> GetProductHandler(int id, CancellationToken cancellationToken)
            => await _productRepository.Get(id, cancellationToken);
    }
}