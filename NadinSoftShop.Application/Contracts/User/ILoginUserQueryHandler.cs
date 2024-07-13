namespace NadinSoftShop.Application.Contracts.User
{
    public interface ILoginUserQueryHandler
    {
        Task<string> LoginUserHandler(string email, string password);
    }
}
