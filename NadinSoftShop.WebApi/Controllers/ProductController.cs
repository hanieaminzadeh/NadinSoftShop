using NadinSoftShop.Framework;
using Microsoft.AspNetCore.Mvc;
using NadinSoftShop.Domain.Product.Dtos;
using Microsoft.AspNetCore.Authorization;
using NadinSoftShop.Application.Contracts.Prodcut;

namespace NadinSoftShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetAllProductQueryHandler _getAllProductQueryHandler;
        private readonly IDeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly IGetProductQueryHandler _getProductQueryHandler;
        private readonly ICreateProductCommandHandler _createProductCommandHandler;
        private readonly IUpdateProductCommandHandler _updateProductCommandHandler;

        public ProductController(IGetAllProductQueryHandler getAllProductQueryHandler,
            IDeleteProductCommandHandler deleteProductCommandHandler,
            IGetProductQueryHandler getProductQueryHandler,
            ICreateProductCommandHandler createProductCommandHandler,
            IUpdateProductCommandHandler updateProductCommandHandler)
        {
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<GetProductDto> Get(int id, CancellationToken cancellationToken)
        {
            return await _getProductQueryHandler
                .GetProductHandler(id, cancellationToken);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<List<GetProductDto>> GetAll(int? userId, CancellationToken cancellationToken)
        {
            return await _getAllProductQueryHandler
                .GetAllProductHandler(userId, cancellationToken);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

            var isSuccess = await _deleteProductCommandHandler
                .DeleteProductHandler(id, int.Parse(userId), cancellationToken);

            return Ok(isSuccess);
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create(CreateProductDto model, CancellationToken cancellationToken)
        {
            if (!ValidationExtensions.IsValidEmail(model.ManufactureEmail))
                return ValidationProblem();

            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

            model.UserId = int.Parse(userId);

            await _createProductCommandHandler
                .CreateProductHandler(model, cancellationToken);

            return Ok();
        }

        [HttpPut]
        [Route(nameof(Update))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(UpdateProductDto model, CancellationToken cancellationToken)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

            var isSuccess = await _updateProductCommandHandler
                .UpdateProductHandler(model, int.Parse(userId), cancellationToken);

            return Ok(isSuccess);
        }
    }
}
