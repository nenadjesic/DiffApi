using DiffApi.Models;

namespace DiffApi.Services;

public interface IDiffService
{
    List<Difference> GetDifferences(byte[] left, byte[] right);
}
