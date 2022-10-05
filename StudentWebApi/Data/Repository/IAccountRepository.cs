using StudentWebApi.Models;
using Microsoft.AspNetCore.Identity;

namespace StudentWebApi.Data.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpModel model);
        Task<string> LoginUserAsync(LoginModel model);
    }
}
