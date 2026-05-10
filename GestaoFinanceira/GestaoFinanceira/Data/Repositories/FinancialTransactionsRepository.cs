using Gestao.Domain;
using Gestao.Domain.Enums;
using GestaoFinanceira.Client.Libraries.Utilities;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data.Repositories
{
    public class FinancialTransactionsRepository : IFinancialTransactionsRepository
    {
        private readonly ApplicationDbContext _db;

        public FinancialTransactionsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PaginatedList<FinancialTransction>> GetAll(int companyId, int pageIdex, int pageSize, TypeFinancialTransction type, string searchWord = "")
        {

            var items = await _db.FinancialTransctions
                   .Where(a => a.CompanyId == companyId && a.TypeFinancialTransction == type)
                   .Where(a => a.Description.Contains(searchWord))
                   .Skip((pageIdex - 1) * pageSize)
                   .Take(pageSize).ToListAsync();
            ;

            var count = await _db.FinancialTransctions
                    .Where(a => a.CompanyId == companyId && a.TypeFinancialTransction == type)
                    .Where(a => a.Description
                    .Contains(searchWord))
                    .CountAsync();
            int totalPages = (int)Math.Ceiling((decimal)count / pageSize);

            return new PaginatedList<FinancialTransction>(items, pageIdex, totalPages);


        }
        public async Task<FinancialTransction?> Get(int id)
        {
            return await _db.FinancialTransctions.OrderByDescending(a => a.ReferenceDate).Include(a => a.Documents).SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task Add(FinancialTransction entity)
        {
            _db.FinancialTransctions.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(FinancialTransction entity)
        {
            _db.FinancialTransctions.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);

            if (entity is not null)
            {
                _db.FinancialTransctions.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

    }
}

