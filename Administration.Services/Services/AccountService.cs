using Administration.Data.Entities;
using Administration.Data.IRepositories;
using Administration.Domain.Enums;
using Administration.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;

namespace Administration.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly PasswordHasher<auth> _passwordHasher;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = new PasswordHasher<auth>();
        }

        public async Task CreateDefaultUsers()
        {
            var existDefaultUsers = await _accountRepository.ExistDefaultUsers();
            if (existDefaultUsers.Count > 0)
            {
                existDefaultUsers.ForEach(u =>
                {
                    u.PasswordHash = HashDefaultPassword(u);
                });
                await _accountRepository.ResetDefaultUserPassword(existDefaultUsers);
            }
            else
            {
                var defaultUsers = new List<(string Username, RoleEnum Role)>
                {
                    ("Developer", RoleEnum.Developer),
                    ("Admin", RoleEnum.Admin)
                };

                var authUsers = defaultUsers.Select(u =>
                {
                    var user = new auth
                    {
                        Username = u.Username,
                        RoleId = (int)u.Role,
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    };

                    user.PasswordHash = HashDefaultPassword(user); // Consider using a config or secret
                    return user;
                }).ToList();

                if (authUsers.Any())
                {
                    await _accountRepository.CreateDefaultUsers(authUsers);
                }
            }                
        }

        #region Private Functions
        private string HashDefaultPassword(auth auth)
        {
            var defaultPassword = "Abcd1234*";
            return _passwordHasher.HashPassword(auth, defaultPassword);
        }

        public bool ValidateLogin(auth auth, string enteredPassword)
        {
            if (!auth.IsActive)
                return false;

            var result = _passwordHasher.VerifyHashedPassword(
                auth,
                auth.PasswordHash,
                enteredPassword
            );

            return result == PasswordVerificationResult.Success;
        }
        #endregion
    }
}
