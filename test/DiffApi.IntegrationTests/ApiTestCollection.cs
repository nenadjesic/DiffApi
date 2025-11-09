namespace DiffApi.IntegrationTests;

[CollectionDefinition(nameof(ApiTestCollection))]
public class ApiTestCollection : ICollectionFixture<DiffApiApplicationFactory>;
