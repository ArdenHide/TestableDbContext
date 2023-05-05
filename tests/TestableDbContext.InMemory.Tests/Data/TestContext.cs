using Microsoft.EntityFrameworkCore;

namespace TestableDbContext.InMemory.Tests.Data;

public class TestContext : DbContext, ConfigurableDbContext
{
    public TestContext() { }
    public TestContext(DbContextOptions<TestContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; } = null!;

    public void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder)
    {
        // In this case i throw exception for check if user OnConfiguring method be overridden.
        throw new NotImplementedException();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ConfigureDbContext(optionsBuilder);
    }
}
