using Microsoft.AspNetCore.Mvc.Testing;

namespace DiffApi.IntegrationTests;

[CollectionDefinition("ApiTests")]
public class DiffApiApplicationFactory : WebApplicationFactory<Program>
{

}
