using Gestao.Domain;
using Gestao.Domain.Enums;
using Gestao.Domain.Libraries.Utilities;
using GestaoFinanceira.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data.Repositories
{
    public class FinancialTransactionsRepository : IFinancialTransactionsRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _Factory;

        public FinancialTransactionsRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _Factory = factory;
        }

        public async Task<PaginatedList<FinancialTransction>> GetAll(int companyId, int pageIdex, int pageSize, TypeFinancialTransction type, string searchWord = "")
        {
            using (var _db = _Factory.CreateDbContext())
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


        }
        public async Task<FinancialTransction?> Get(int id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.FinancialTransctions.OrderByDescending(a => a.ReferenceDate).Include(a => a.Category).Include(a => a.Account).Include(a => a.Documents).SingleOrDefaultAsync(a => a.Id == id);
            }
        }
        public async Task Add(FinancialTransction entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.FinancialTransctions.Add(entity);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Update(FinancialTransction entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.FinancialTransctions.Update(entity);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                var entity = await Get(id);

                if (entity is not null)
                {
                    await Delete(entity);
                }
            }
        }
        public async Task Delete(FinancialTransction entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.FinancialTransctions.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountAssociateTranactionSameGroup(int Id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.FinancialTransctions.Where(a => a.RepeatGroup == Id).OrderBy(a => a.Id).CountAsync();
            }
        }

        public async Task<List<FinancialTransction>> GetTransactionsSameGroup(int Id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.FinancialTransctions.Where(a => a.RepeatGroup == Id).ToListAsync();
            }
        }
    }
}

