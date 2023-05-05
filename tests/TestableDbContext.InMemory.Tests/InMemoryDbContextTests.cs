using Xunit;
using TestableDbContext.InMemory.Tests.Data;

namespace TestableDbContext.InMemory.Tests;

public class InMemoryDbContextTests
{
    [Fact]
    public void Test1()
    {
        var dbName = Guid.NewGuid().ToString();

        var context = InMemoryDbContext<TestContext>.CreateDbContext(dbName);

        Assert.NotNull(context);
        Assert.IsType<TestContext>(context);

        var user = new User()
        {
            Id = 0,
            Name = "Alex"
        };
        context.Users.Add(user);
        context.SaveChanges();

        Assert.Equal(user, context.Users.FirstOrDefault(x => x.Name == "Alex"));
    }
}