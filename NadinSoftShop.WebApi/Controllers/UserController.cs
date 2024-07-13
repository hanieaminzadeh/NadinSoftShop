using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadinSoftShop.Application.Contracts.User;
using NadinSoftShop.Framework;

namespace NadinSoftShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterUserCommandHandler _registerCommandHandler;
        private readonly ILoginUserQueryHandler _loginUserQueryHandler;

        public UserController(IRegisterUserCommandHandler registerCommandHandler, ILoginUserQueryHandler loginCommandHandler)
        {
            _registerCommandHandler = registerCommandHandler;
            _loginUserQueryHandler = loginCommandHandler;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(string email, string password)
        {
            if (!ValidationExtensions.IsValidEmail(email))
                return ValidationProblem();

            return Ok(await _registerCommandHandler.RegisterUserHandler(email, password));
        }

        [HttpGet]
        [Route(nameof(Login))]
        public async Task<string> Login(string email, string password)
        {
            return await _loginUserQueryHandler.LoginUserHandler(email, password);
        }
    }
}
