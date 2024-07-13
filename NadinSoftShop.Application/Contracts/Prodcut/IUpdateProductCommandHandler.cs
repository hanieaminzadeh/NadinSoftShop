using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NadinSoftShop.Domain.Product.Dtos;

namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IUpdateProductCommandHandler
    {
        Task<bool> UpdateProductHandler(UpdateProductDto model, int userId, CancellationToken cancellationToken);
    }
}
