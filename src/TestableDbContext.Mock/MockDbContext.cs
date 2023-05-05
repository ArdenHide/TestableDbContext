using Moq;
using Microsoft.EntityFrameworkCore;

namespace TestableDbContext.Mock;

public static class MockDbContext<TContext>
    where TContext : DbContext
{
    public static Mock<TContext> GetMockContext(MockBehavior behavior = MockBehavior.Default) =>
        new Mock<TContext>(behavior);
}

public static class MockDbContext
{
    public static Mock<DbSet<TEntity>> GetMockDbSet<TEntity>(IEnumerable<TEntity> data)
        where TEntity : class
    {
        return data.AsQueryable().BuildMockDbSet();
    }
}
