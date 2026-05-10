using Gestao.Domain;
using GestaoFinanceira.Client.Libraries.Utilities;

namespace GestaoFinanceira.Data.Repositories
{
    public interface IAccountRepository
    {
        Task Add(Account entity);
        Task Delete(int id);
        Task<Account?> Get(int id);
        Task<List<Account>> GetAll(int companyId);
        Task<PaginatedList<Account>> GetAll(int companyId, int pageIdex, int pageSize, string searchWord);
        Task Update(Account entity);
    }
}