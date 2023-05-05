using Microsoft.EntityFrameworkCore;

namespace TestableDbContext.InMemory.Tests.Data;

public class TestContext : DbContext
{
    public TestContext() { }
    public TestContext(DbContextOptions<TestContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=localhost;Database=mydatabase;User Id=myusername;Password=mypassword;Initial Catalog=DbName;");
    }
}
