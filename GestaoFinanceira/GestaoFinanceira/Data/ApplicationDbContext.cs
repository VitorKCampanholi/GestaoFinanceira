using Gestao.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Company> Campanies { get; set; }
        public DbSet<Account>  Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FinancialTransction> FinancialTransctions { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FinancialTransction>().Property(a => a.Repeat).HasConversion<String>();

            builder.Entity<FinancialTransction>().Property(a => a.TypeFinancialTransction).HasConversion<String>();
        }
    }
}
