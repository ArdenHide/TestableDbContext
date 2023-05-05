namespace TestableDbContext.InMemory.Exceptions;

public class DbContextCreationException : InvalidOperationException
{
    public DbContextCreationException(Type dbContextType)
        : base($"Failed to create an instance of '{dbContextType.FullName}'. Ensure the provided type is a DbContext.")
    { }
}
