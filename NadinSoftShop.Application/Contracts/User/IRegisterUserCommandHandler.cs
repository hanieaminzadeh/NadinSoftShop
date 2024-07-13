using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoftShop.Application.Contracts.User
{
    public interface IRegisterUserCommandHandler
    {
        Task<List<IdentityError>> RegisterUserHandler(string email, string password);
    }
}
