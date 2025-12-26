using Administration.Data.Entities;
using Administration.Data.IRepositories;
using Administration.Domain.Enums;
using Administration.Domain.IServices;
using Administration.Domain.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Administration.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly PasswordHasher<authuser> _passwordHasher;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = new PasswordHasher<authuser>();
        }

        /// <inheritdoc />
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
                    var user = new authuser
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

        /// <inheritdoc />
        public async Task<UserModel?> ValidateUser(string username, string password)
        {
            var user = await _accountRepository.GetUserByUsername(username);
            if (user == null)
                return null;

            if (!ValidateLogin(user, password))
                return null;

            return new UserModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role.Name
            };
        }

        #region Private Functions
        /// <summary>
        /// Hashes the default password for the specified user.
        /// </summary>
        /// <param name="auth">The user entity for which the password will be hashed.</param>
        /// <returns>The hashed password as a <see cref="string"/>.</returns>
        private string HashDefaultPassword(authuser auth)
        {
            var defaultPassword = "Abcd1234*";
            return _passwordHasher.HashPassword(auth, defaultPassword);
        }

        /// <summary>
        /// Validates the login attempt for a given user.
        /// </summary>
        /// <param name="auth">The user entity attempting to log in.</param>
        /// <param name="enteredPassword">The password entered by the user.</param>
        /// <returns>
        /// <c>true</c> if the entered password matches the user's hashed password and the user is active; otherwise, <c>false</c>.
        /// </returns>
        public bool ValidateLogin(authuser auth, string enteredPassword)
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
