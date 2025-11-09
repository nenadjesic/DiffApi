using DiffApi.Models;

namespace DiffApi.Services;

/// <summary>
/// Service to calculate differences between two byte arrays
/// </summary>
public class DiffService : IDiffService
{
    private readonly ILogger<DiffService> _logger;
    public DiffService(ILogger<DiffService> logger)
    {
        _logger = logger;
    }

    public List<Difference> GetDifferences(byte[] left, byte[] right)
    {
        _logger.LogInformation("Calculating differences between {Left} and {Right}", left, right);

        var differences = new List<Difference>();
        long? diffOffset = null;
        var diffLength = 0L;

        for (var index = 0; index < left.Length; index++)
        {
            if (left[index] != right[index])
            {
                if (diffOffset == null)
                {
                    diffOffset = index;
                    diffLength = 1;
                }
                else
                {
                    diffLength++;
                }
            }
            else if (diffOffset is not null)
            {
                differences.Add(new Difference
                {
                    Offset = diffOffset.Value,
                    Length = diffLength
                });
                diffOffset = null;
                diffLength = 0;
            }
        }

        if (diffOffset is not null)
        {
            differences.Add(new Difference
            {
                Offset = diffOffset.Value,
                Length = diffLength
            });
        }

        _logger.LogInformation("Found {Count} differences", differences.Count);

        return differences;
    }
}
