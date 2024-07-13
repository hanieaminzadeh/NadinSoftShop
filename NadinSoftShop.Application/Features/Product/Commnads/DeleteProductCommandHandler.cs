using NadinSoftShop.Application.Contracts.Prodcut;

namespace NadinSoftShop.Application.Features.Product.Commnads
{
    public class DeleteProductCommandHandler : IDeleteProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> DeleteProductHandler(int productId, int userId, CancellationToken cancellationToken)
        {
            return await _productRepository.Delete(productId, userId, cancellationToken);
        }
    }
}
