using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiffApi.Enums;
using DiffApi.Models;

namespace DiffApi.IntegrationTests;

[Collection(nameof(ApiTestCollection))]
public class DiffApiTests
{
    private readonly DiffApiApplicationFactory _factory;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    public DiffApiTests(DiffApiApplicationFactory factory)
    {
        _factory = factory;
    }

    private HttpClient GetClient() => _factory.CreateClient();

    [Fact]
    public async Task WrongId_ShouldReturn404NotFound()
    {
        using var client = GetClient();
        var response = await client.GetAsync("/v1/diff/999999");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PutLeft_ShouldReturn201Created()
    {
        using var client = GetClient();
        var data = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        var response = await client.PutAsync("/v1/diff/1/left", JsonContent.Create(data));
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task PutRight_ShouldReturn201Created()
    {
        using var client = GetClient();
        var data = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        var response = await client.PutAsync("/v1/diff/1/right", JsonContent.Create(data));
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task SameContent_ShouldReturnDataResultTypeEquals()
    {
        using var client = GetClient();
        var data = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        await client.PutAsync("/v1/diff/2/left", JsonContent.Create(data));
        await client.PutAsync("/v1/diff/2/right", JsonContent.Create(data));
        var response = await client.GetAsync("/v1/diff/2");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var diffResult = await response.Content.ReadFromJsonAsync<DiffResult>(JsonOptions);
        Assert.Equal(DiffResultType.Equals, diffResult.DiffResultType);
    }

    [Fact]
    public async Task DifferentLengthContent_ShouldReturnDataResultTypeSizeDoNotMatch()
    {
        using var client = GetClient();
        var dataLeft = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        var dataRight = new DiffData()
        {
            Data = new byte[] { 0, 0 }
        };
        await client.PutAsync("/v1/diff/3/left", JsonContent.Create(dataLeft));
        await client.PutAsync("/v1/diff/3/right", JsonContent.Create(dataRight));
        var response = await client.GetAsync("/v1/diff/3");
        response.EnsureSuccessStatusCode();
        var diffResult = await response.Content.ReadFromJsonAsync<DiffResult>(JsonOptions);
        Assert.Equal(DiffResultType.SizeDoNotMatch, diffResult.DiffResultType);
    }

    [Fact]
    public async Task DifferentContent_ShouldReturnDataResultTypeContentDoNotMatch()
    {
        using var client = GetClient();
        var dataLeft = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        var dataRight = new DiffData()
        {
            Data = new byte[] { 1, 0, 0, 0 }
        };
        await client.PutAsync("/v1/diff/4/left", JsonContent.Create(dataLeft));
        await client.PutAsync("/v1/diff/4/right", JsonContent.Create(dataRight));
        var response = await client.GetAsync("/v1/diff/4");
        response.EnsureSuccessStatusCode();
        var diffResult = await response.Content.ReadFromJsonAsync<DiffResult>(JsonOptions);
        Assert.Equal(DiffResultType.ContentDoNotMatch, diffResult.DiffResultType);
    }

    [Fact]
    public async Task DifferentContent_ShouldReturnDifferences()
    {
        using var client = GetClient();
        var dataLeft = new DiffData()
        {
            Data = new byte[] { 0, 0, 0, 0 }
        };
        var dataRight = new DiffData()
        {
            Data = new byte[] { 1, 0, 1, 1 }
        };
        await client.PutAsync("/v1/diff/5/left", JsonContent.Create(dataLeft));
        await client.PutAsync("/v1/diff/5/right", JsonContent.Create(dataRight));
        var response = await client.GetAsync("/v1/diff/5");
        response.EnsureSuccessStatusCode();
        var diffResult = await response.Content.ReadFromJsonAsync<DiffResult>(JsonOptions);
        Assert.Equal(DiffResultType.ContentDoNotMatch, diffResult.DiffResultType);
        Assert.Equal(2, diffResult.Diffs.Count);
        var diff1 = diffResult.Diffs[0];
        var diff2 = diffResult.Diffs[1];
        Assert.Equal(0, diff1.Offset);
        Assert.Equal(1, diff1.Length);
        Assert.Equal(2, diff2.Offset);
        Assert.Equal(2, diff2.Length);
    }
}
