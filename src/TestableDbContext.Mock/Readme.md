# TestableDbContext.Mock

Effortless DbContext and DbSet Mocking for Unit Tests

## Description

TestableDbContext.Mock is a lightweight and easy-to-use package that simplifies the process of mocking Entity Framework Core DbContexts and DbSets for unit testing. It uses the Moq framework to create mock instances of DbContext and DbSet, allowing you to focus on writing testable code and ensuring the correctness of your data access layer. With its extension methods and fluent API, TestableDbContext.Mock makes it a breeze to set up and configure mock instances for your data context and entity sets.

## Installation

To install TestableDbContext.Mock, run the following command in your Package Manager Console:

```sh
Install-Package TestableDbContext.Mock
```

Alternatively, you can search for `TestableDbContext.Mock` in the NuGet Package Manager.

## Usage

### Mocking DbContext

To create a mock instance of your DbContext, simply call the `GetMockContext` method:

```csharp
var mockContext = MockDbContext<MyDbContext>.GetMockContext();
```

You can also specify the `MockBehavior` as an optional parameter:

```csharp
var mockContext = MockDbContext<MyDbContext>.GetMockContext(MockBehavior.Strict);
```

### Mocking DbSet

To create a mock instance of a DbSet, first create an `IEnumerable` of your entity type containing the data you want to use for testing, and then call the `GetMockDbSet` method:

```csharp
var testData = new List<MyEntity>
{
    new MyEntity { Id = 1, Name = "Entity1" },
    new MyEntity { Id = 2, Name = "Entity2" }
};

var mockDbSet = MockDbContext.GetMockDbSet(testData);
```

### Assigning Mock DbSet to Mock DbContext

After creating the mock DbSet, assign it to the appropriate property on your mock DbContext:

```csharp
mockContext.Setup(x => x.MyEntities).Returns(mockDbSet.Object);
```

## Example

Here's a complete example of using TestableDbContext.Mock to create a mock DbContext and DbSet for testing:

```csharp
using Moq;
using Xunit;
using TestableDbContext.Mock;
using Microsoft.EntityFrameworkCore;

public class MyDbContextTests
{
    [Fact]
    public void TestMethod()
    {
        // Arrange
        var testData = new List<MyEntity>
        {
            new MyEntity { Id = 1, Name = "Entity1" },
            new MyEntity { Id = 2, Name = "Entity2" }
        };

        var mockDbSet = MockDbContext.GetMockDbSet(testData);

        var mockContext = MockDbContext<MyDbContext>.GetMockContext();
        mockContext.Setup(x => x.MyEntities).Returns(mockDbSet.Object);

        // Act
        // Perform your test operations using the mockContext.Object

        // Assert
        // Verify the expected behavior
    }
}
```

## License

This project is licensed under the MIT License. See the LICENSE file for more information.
