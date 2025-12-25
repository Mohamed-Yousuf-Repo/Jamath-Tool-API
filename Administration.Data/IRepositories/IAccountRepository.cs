using Administration.Data.Entities;

namespace Administration.Data.IRepositories
{
    public interface IAccountRepository
    {
        Task CreateDefaultUsers(List<auth> users);
        Task<List<auth>> ExistDefaultUsers();
        Task ResetDefaultUserPassword(List<auth> existDefaultUsers);
    }
}
