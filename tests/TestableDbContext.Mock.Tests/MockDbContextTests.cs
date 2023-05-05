using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using TestableDbContext.Mock.Tests.Data;

namespace TestableDbContext.Mock.Tests;

public class MockDbContextTests
{
    [Fact]
    public void GetMockContext()
    {
        var context = MockDbContext<TestContext>.GetMockContext();

        Assert.NotNull(context);
        Assert.IsType<Mock<TestContext>>(context);
        Assert.Null(context.Object.Users);
    }

    [Fact]
    public void GetMockDbSet()
    {
        var users = new List<User>()
        {
            new()
            {
                Id = 0,
                Name = "Alex"
            },
            new()
            {
                Id = 1,
                Name = "Anna"
            }
        };

        var usersDbSet = MockDbContext.GetMockDbSet(users);

        Assert.NotNull(usersDbSet);
        Assert.IsType<Mock<DbSet<User>>>(usersDbSet);
        Assert.Equal(users, usersDbSet.Object.ToList());
    }
}