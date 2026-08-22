using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;
using GestaoFinanceira.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _Factory;

        public CategoryRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _Factory = factory;
        }

        public async Task<PaginatedList<Category>> GetAll(int companyId, int pageIdex, int pageSize)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                var items = await _db.Categories.Where(a => a.CompanyId == companyId)
                   .OrderBy(a => a.Name)
                   .Skip((pageIdex - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
                ;

                var count = await _db.Categories.Where(a => a.CompanyId == companyId).CountAsync();
                int totalPages = (int)Math.Ceiling((decimal)count / pageSize);

                return new PaginatedList<Category>(items, pageIdex, totalPages);
            }
        }
        public async Task<List<Category>> GetAll(int companyId)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.Categories.Where(a => a.CompanyId == companyId).ToListAsync();
            }
        }

        public async Task<Category?> Get(int id)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                return await _db.Categories.SingleOrDefaultAsync(a => a.Id == id);
            }
        }
        public async Task Add(Category entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.Categories.Add(entity);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Update(Category entity)
        {
            using (var _db = _Factory.CreateDbContext())
            {
                _db.Categories.Update(entity);
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
                    _db.Categories.Remove(entity);
                    await _db.SaveChangesAsync();
                }
            }
        }

    }
}


