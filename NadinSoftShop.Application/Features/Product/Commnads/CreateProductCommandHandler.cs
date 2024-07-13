using NadinSoftShop.Application.Contracts.Prodcut;
using NadinSoftShop.Domain.Product.Dtos;
using System.Text.RegularExpressions;

namespace NadinSoftShop.Application.Features.Product.Commnads
{
    public class CreateProductCommandHandler : ICreateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CreateProductHandler(CreateProductDto model, CancellationToken cancellationToken)
        {
            return await _productRepository.Create(model, cancellationToken);
        }
    }
}
