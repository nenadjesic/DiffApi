namespace DiffApi.Models;

public class DiffData
{
    public byte[]? Data { get; set; }
    public List<Difference>? Diffs { get; set; }
}
