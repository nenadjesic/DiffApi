using Microsoft.AspNetCore.Mvc;
using DiffApi.Enums;
using DiffApi.Models;
using DiffApi.Repositories;

namespace DiffApi.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class DiffController : ControllerBase
{
    private readonly ILogger<DiffController> _logger;
    private readonly IDiffRepository _diffRepository;

    public DiffController(ILogger<DiffController> logger, IDiffRepository diffRepository)
    {
        _logger = logger;
        _diffRepository = diffRepository;
    }

    [HttpGet]
    [Route("{id:long}")]
    public ActionResult Get(long id)
    {
        var compareData = _diffRepository.Get(id);

        if(compareData is null)
        {
            return NotFound();
        }

        if (compareData.Left == compareData.Right)
        {
            return Ok(new DiffResult()
            {
                DiffResultType = DiffResultType.Equals
            });
        }

        if (compareData.Left?.Length != compareData.Right?.Length)
        {
            return Ok(new DiffResult()
            {
                DiffResultType = DiffResultType.SizeDoNotMatch
            });
        }

        return Ok(new DiffsResult()
        {
            DiffResultType = DiffResultType.ContentDoNotMatch,
            Diffs = GetDifferences(compareData.Left!, compareData.Right!)

        });
    }

    [HttpPut]
    [Route("{id:long}/{side}")]
    public ActionResult Put(long id, Side side, [FromBody] DiffData data)
    {
        if (data.Data is null)
        {
            _logger.LogWarning("Data is null");
            return BadRequest();
        }

        _diffRepository.Put(id, side, data.Data);
        _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

        return Created();
    }

    private List<Difference> GetDifferences(byte[] left, byte[] right)
    {
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
