using DiffApi.Enums;

namespace DiffApi.Models;

public class DiffsResult
{
    public DiffResultType DiffResultType { get; set; }
    public List<Difference>? Diffs { get; set; }
}
