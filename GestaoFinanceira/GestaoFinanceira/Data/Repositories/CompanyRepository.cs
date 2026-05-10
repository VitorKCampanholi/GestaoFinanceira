using Gestao.Domain;
using GestaoFinanceira.Client.Libraries.Utilities;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIdex, int pageSize, string searchWord = "")
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
        public async Task<Company?> Get(int id)
        {
            return await _db.Campanies.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task Add(Company entity)
        {
            _db.Campanies.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(Company entity)
        {
            _db.Campanies.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
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
