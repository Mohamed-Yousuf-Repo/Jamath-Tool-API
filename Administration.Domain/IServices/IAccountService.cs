using Administration.Domain.Models.DTOs;

namespace Administration.Domain.IServices
{
    public interface IAccountService
    {
        /// <summary>
        /// Creates the default users "Admin" and "Developer" in the system.
        /// If these users already exist, their passwords may be reset to the default value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateDefaultUsers();

        /// <summary>
        /// Validates the user credentials and returns the corresponding user details if successful.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>
        /// A <see cref="Task{UserModel}"/> representing the asynchronous operation. 
        /// Returns the <see cref="UserModel"/> of the authenticated user if credentials are valid; otherwise, returns <c>null</c>.
        /// </returns>
        Task<UserModel?> ValidateUser(string username, string password);



    }
}
