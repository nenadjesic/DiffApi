using DiffApi.Enums;
using DiffApi.Models;

namespace DiffApi.Repositories;

public interface IDiffRepository
{
    CompareData? Get(long id);
    void Put(long id, Side side, byte[] data);
}
