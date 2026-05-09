using Gestao.Domain;
using GestaoFinanceira.Client.Libraries.Utilities;

namespace GestaoFinanceira.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Category entity);
        Task Delete(int id);
        Task<Category?> Get(int id);
        Task<List<Category>> GetAll(int companyId);
        Task<PaginatedList<Category>> GetAll(int companyId, int pageIdex, int pageSize);
        Task Update(Category entity);
    }
}