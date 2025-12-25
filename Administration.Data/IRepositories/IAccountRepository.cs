using Administration.Data.Entities;

namespace Administration.Data.IRepositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Creates the specified list of default users in the database.
        /// </summary>
        /// <param name="users">A list of <see cref="authuser"/> users to be created.</param>
        /// <returns>Returns representing the asynchronous operation.</returns>
        Task CreateDefaultUsers(List<authuser> users);

        /// <summary>
        /// Checks if the default users already exist in the database.
        /// </summary>
        /// <returns>
        /// Returns list of existing default <see cref="authuser"/> users.
        /// Returns an empty list if none exist.
        /// </returns>
        Task<List<authuser>> ExistDefaultUsers();

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>
        /// Returns the <see cref="authuser"/> entity if a user with the specified username exists; otherwise, <c>null</c>.
        /// </returns>
        Task<authuser?> GetUserByUsername(string username);

        /// <summary>
        /// Resets the passwords of the specified default users to their default values.
        /// </summary>
        /// <param name="existDefaultUsers">A list of existing default <see cref="authuser"/> users whose passwords need to be reset.</param>
        /// <returns>Returns representing the asynchronous operation.</returns>
        Task ResetDefaultUserPassword(List<authuser> existDefaultUsers);
    }
}
