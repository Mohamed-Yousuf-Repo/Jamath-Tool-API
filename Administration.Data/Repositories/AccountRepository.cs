using Administration.Data.Entities;
using Administration.Data.IRepositories;
using Administration.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Administration.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AdministrationDbContext _context;

        public AccountRepository(AdministrationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task CreateDefaultUsers(List<authuser> users)
        {
            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<authuser>> ExistDefaultUsers()
        {
            var defaultUsers = await _context.authusers.Where(x => x.Role.Name == "Developer" || x.Role.Name == "Admin").ToListAsync();
            return defaultUsers;
        }

        /// <inheritdoc />
        public async Task<authuser?> GetUserByUsername(string username)
        {
            var user = await _context.authusers.Include(i => i.Role).FirstOrDefaultAsync(x => x.Username == username && x.IsActive);
            return user;
        }

        /// <inheritdoc />
        public async Task ResetDefaultUserPassword(List<authuser> existDefaultUsers)
        {
            _context.UpdateRange(existDefaultUsers);
            await _context.SaveChangesAsync();
        }
    }
}
