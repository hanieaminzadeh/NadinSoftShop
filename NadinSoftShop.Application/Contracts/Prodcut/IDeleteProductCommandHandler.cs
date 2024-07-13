namespace NadinSoftShop.Application.Contracts.Prodcut
{
    public interface IDeleteProductCommandHandler
    {
        Task<bool> DeleteProductHandler(int productId, int userId, CancellationToken cancellationToken);
    }
}
