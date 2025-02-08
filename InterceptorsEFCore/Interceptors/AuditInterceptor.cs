using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InterceptorsEFCore.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            var entries = eventData.Context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
            }
            return base.SavingChanges(eventData, result);
        }
    }
}
