using System.Collections.Concurrent;
using DiffApi.Enums;
using DiffApi.Models;

namespace DiffApi.Repositories;

public class DiffRepository : IDiffRepository
{
    private static readonly ConcurrentDictionary<long, CompareData> Comparisons = new();
    public CompareData? Get(long id)
    {
        Comparisons.TryGetValue(id, out var compareData);
        return compareData;
    }

    public void Put(long id, Side side, byte[] data)
    {
        Comparisons.AddOrUpdate(id,
            _ => side == Side.Left
                ? new CompareData { Left = data }
                : new CompareData { Right = data },
            (_, existing) =>
            {
                if (side == Side.Left)
                {
                    existing.Left = data;
                }
                else
                {
                    existing.Right = data;
                }

                return existing;
            });
    }
}
