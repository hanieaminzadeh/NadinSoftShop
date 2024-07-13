using NadinSoftShop.Application.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NadinSoftShop.Domain.User.Entities;

namespace NadinSoftShop.Application.Features.User.Commands
{
    public class RegisterUserCommandHandler : IRegisterUserCommandHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<IdentityError>> RegisterUserHandler(string email, string password)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (List<IdentityError>)result.Errors;
        }
    }
}
