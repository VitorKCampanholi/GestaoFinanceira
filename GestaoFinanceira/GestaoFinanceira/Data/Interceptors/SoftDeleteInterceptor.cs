using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Gestao.Domain.Interfaces;
namespace GestaoFinanceira.Data.Interceptors
    
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            return SoftDeleteAlgoritim(eventData, result);
        }      

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            return SoftDeleteAlgoritim(eventData, result);
        }

        private InterceptionResult<int> SoftDeleteAlgoritim(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;
                    ((ISoftDelete)entry.Entity).DeletedAt = DateTimeOffset.UtcNow;
                }

            }
            return result;
        }
    }
}
