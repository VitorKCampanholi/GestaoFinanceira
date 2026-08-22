using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;
using GestaoFinanceira.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _Factory;

        public CompanyRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _Factory = factory;
        }

        public async Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIdex, int pageSize, string searchWord = "")
        {
            using (var _db = _Factory.CreateDbContext())
            {
                var items = await _db.Campanies
                   .Where(a => a.UserId == applicationUserId)
                   .Where(a => a.TradeName
                   .Contains(searchWord) || a.LegalName
                   .Contains(searchWord))
                   .OrderBy(a => a.TradeName)
                   .Skip((pageIdex - 1) * pageSize)
                   .Take(pageSize).ToListAsync();
                ;

                var count = await _db.Campanies
                      .Where(a => a.UserId == applicationUserId)
                      .Where(a => a.TradeName
                      .Contains(searchWord) || a.LegalName
                      .Contains(searchWord))
                      .CountAsync();
                int totalPages = (int)Math.Ceiling((decimal)count / pageSize);

                return new PaginatedList<Company>(items, pageIdex, totalPages);
            }


        }
        public async Task<Company?> Get(int id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.Campanies.SingleOrDefaultAsync(a => a.Id == id);
            }
        }
        public async Task Add(Company entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.Campanies.Add(entity);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Update(Company entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.Campanies.Update(entity);
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
                    _db.Campanies.Remove(entity);
                    await _db.SaveChangesAsync();
                }
            }
        }

    }
}
