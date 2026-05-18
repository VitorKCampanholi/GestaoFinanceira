using Gestao.Domain;
using Gestao.Domain.Enums;
using Gestao.Domain.Libraries.Utilities;
using GestaoFinanceira.Domain;
using GestaoFinanceira.Domain.Repositories;
using System.Net.Http.Json;

namespace GestaoFinanceira.Client.Services
{
    public class FinancialTransctionService : IFinancialTransactionsRepository
    {

        private readonly HttpClient _httpClient;

        public FinancialTransctionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(FinancialTransction entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FinancialTransction?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransction>> GetAll(int companyId, int pageIdex, int pageSize, TypeFinancialTransction type, string searchWord)
        {
            var url = $"/api/financialtransctions?companyid={companyId}&pageindex={pageIdex}&searchword={searchWord}type={type}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<FinancialTransction>>(url);

            return entities;
        }

        public Task Update(FinancialTransction entity)
        {
            throw new NotImplementedException();
        }
    }
}
