using NadinSoftShop.Application.Contracts.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Features.Product.Commnads
{
    public class UpdateProductCommandHandler : IUpdateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> UpdateProductHandler(UpdateProductDto model, int userId, CancellationToken cancellationToken)
        {
           return await _productRepository.Update(model, userId, cancellationToken);
        }
    }
}
