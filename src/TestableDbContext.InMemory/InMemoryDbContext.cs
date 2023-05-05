using Microsoft.EntityFrameworkCore;
using TestableDbContext.InMemory.Exceptions;

namespace TestableDbContext.InMemory;

public static class InMemoryDbContext<TContext>
    where TContext : DbContext, ConfigurableDbContext
{
    public static TContext CreateDbContext(string dbName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        optionsBuilder.UseInMemoryDatabase(dbName);

        var context = Activator.CreateInstance(typeof(TContext), optionsBuilder.Options) as TContext;
        if (context == null)
        {
            throw new DbContextCreationException(typeof(TContext));
        }

        return context;
    }
}
