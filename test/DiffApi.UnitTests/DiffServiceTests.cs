using DiffApi.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace DiffApi.UnitTests;

public class DiffServiceTests
{
    [Fact]
    public void EqualArrays_ShouldReturnEmptyList()
    {
        var service = new DiffService(new NullLogger<DiffService>());
        var left = new byte[] { 0, 0, 0, 0 };
        var right = new byte[] { 0, 0, 0, 0 };
        var differences = service.GetDifferences(left, right);

        Assert.Empty(differences);
    }

    [Fact]
    public void DifferentFirstByte_ShouldReturnSingleDifference()
    {
        var service = new DiffService(new NullLogger<DiffService>());
        var left = new byte[] { 0, 0, 0, 0 };
        var right = new byte[] { 1, 0, 0, 0 };
        var differences = service.GetDifferences(left, right);

        Assert.Single(differences);
        var difference = differences[0];
        Assert.Equal(0, difference.Offset);
        Assert.Equal(1, difference.Length);
    }

    [Fact]
    public void SecondByteEqual_ShouldReturnTwoDifferences()
    {
        var service = new DiffService(new NullLogger<DiffService>());
        var left = new byte[] { 0, 0, 0, 0 };
        var right = new byte[] { 1, 0, 1, 1 };
        var differences = service.GetDifferences(left, right);

        Assert.Equal(2, differences.Count);
        var difference1 = differences[0];
        var difference2 = differences[1];

        Assert.Equal(0, difference1.Offset);
        Assert.Equal(1, difference1.Length);
        Assert.Equal(2, difference2.Offset);
        Assert.Equal(2, difference2.Length);
    }
}
