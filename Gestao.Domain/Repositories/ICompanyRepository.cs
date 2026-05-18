using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;

namespace GestaoFinanceira.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Task Delete(int id);
        Task<Company?> Get(int id);
        Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIdex, int pageSize, string searchWord);
        Task Update(Company company);
    }
}