using Xunit;

namespace Tests
{

    [CollectionDefinition("uow collection")]
    public class InMemoryDbContextFixtureCollection : ICollectionFixture<UnitOfWorkFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}