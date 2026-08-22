using Gestao.Domain;
using Gestao.Domain.Enums;
using Gestao.Domain.Libraries.Utilities;

namespace GestaoFinanceira.Domain.Repositories
{
    public interface IFinancialTransactionsRepository
    {
        Task Add(FinancialTransction entity);
        Task Delete(int id);
        Task Delete(FinancialTransction entity);
        Task<FinancialTransction?> Get(int id);
        Task<PaginatedList<FinancialTransction>> GetAll(int companyId, int pageIdex, int pageSize, TypeFinancialTransction type, string searchWord);

        Task<int>GetCountAssociateTranactionSameGroup(int Id);
        Task<List<FinancialTransction>>GetTransactionsSameGroup(int Id);
        Task Update(FinancialTransction entity);
    }
}