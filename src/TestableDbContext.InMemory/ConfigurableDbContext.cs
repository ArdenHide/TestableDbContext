using Microsoft.EntityFrameworkCore;

namespace TestableDbContext.InMemory;

public abstract class ConfigurableDbContext : DbContext
{
    protected ConfigurableDbContext() { }

    protected ConfigurableDbContext(DbContextOptions options) : base(options) { }

    public abstract void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder);
}
