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

        public async Task CreateDefaultUsers(List<auth> users)
        {
            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        public async Task<List<auth>> ExistDefaultUsers()
        {
            var defaultUsers = await _context.auths.Where(x => x.Role.Name == "Developer" || x.Role.Name == "Admin").ToListAsync();
            return defaultUsers;
        }
                
        public async Task ResetDefaultUserPassword(List<auth> existDefaultUsers)
        {
            _context.UpdateRange(existDefaultUsers);
            await _context.SaveChangesAsync();
        }
    }
}
