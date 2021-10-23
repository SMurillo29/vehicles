using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicles.API.Data.Entities;
using vehicles.API.Models;

namespace vehicles.API.Helpers
{
    public interface IUserHelper
    {
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<IdentityResult> DeleteUserAsync(User user);

        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(Guid id);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


    }
}
