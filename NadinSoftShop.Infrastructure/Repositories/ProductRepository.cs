using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using NadinSoftShop.Domain.Product.Dtos;
using NadinSoftShop.Infrastructure.Common;
using NadinSoftShop.Domain.Product.Entities;
using NadinSoftShop.Application.Contracts.Prodcut;

namespace NadinSoftShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductRepository> _logger;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext appDbContext,
            ILogger<ProductRepository> logger,
            IMapper mapper)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateProductDto model, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(model);
            product.ProduceDate = DateTime.Now;

            try
            {
                await _appDbContext.Products.AddAsync(product, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }

        }

        public async Task<GetProductDto> Get(int id, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<GetProductDto>
            (await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken));

            if (product != null)
                return product;

            throw new Exception($"Product with id {id} not found!");
        }

        public async Task<List<GetProductDto>>? GetAll(CancellationToken cancellationToken)
        {
            var products = _mapper.Map<List<GetProductDto>>
                (await _appDbContext.Products.ToListAsync(cancellationToken));

            return products;
        }

        public async Task<bool> Delete(int productId, int userId, CancellationToken cancellationToken)
        {
            var product = await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);

            if (product.UserId == userId)
            {
                try
                {
                    if (product != null)
                    {
                        _appDbContext.Products.Remove(product);
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
            }
            else
            {
                throw new Exception($"UserId {userId} not access to product id {product.Id}!");
            }

            return false;
        }

        public async Task<bool> Update(UpdateProductDto model, int userId, CancellationToken cancellationToken)
        {
            var product = await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);

            if (product.UserId == userId)
            {
                try
                {
                    if (product != null)
                    {
                        product.Name = model.Name;
                        product.ManufacturePhone = model.ManufacturePhone;
                        product.IsAvailable = model.IsAvailable;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
            }
            else
            {
                throw new Exception($"UserId {userId} not access to product id {product.Id}!");
            }
            return false;
        }
    }
}
