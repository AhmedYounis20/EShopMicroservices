namespace Ordering.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.CreatedBy = "younis";
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified ||
                entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedAt = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = "younis";
            }
            {
                
            }
        }
    }
}

public static class Extenstions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(e =>
            e.TargetEntry != null && e.TargetEntry.Metadata.IsOwned() && (e.TargetEntry.State == EntityState.Added ||
                                                                          e.TargetEntry.State == EntityState.Modified));
}