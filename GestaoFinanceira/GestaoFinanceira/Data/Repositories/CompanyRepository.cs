using Gestao.Domain;
using GestaoFinanceira.Client.Libraries.Utilities;

namespace GestaoFinanceira.Data.Repositories
{
    public class CompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }
           
        public PaginatedList<Company> GetAll()
        {
            throw new NotImplementedException();
        }
        public Company Get(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(Company company)
        {
            throw new NotImplementedException();
        }
        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
