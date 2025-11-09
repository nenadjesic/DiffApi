using Microsoft.AspNetCore.Mvc;
using DiffApi.Enums;
using DiffApi.Models;
using DiffApi.Repositories;
using DiffApi.Services;

namespace DiffApi.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class DiffController : ControllerBase
{
    private readonly ILogger<DiffController> _logger;
    private readonly IDiffRepository _diffRepository;
    private readonly IDiffService _diffService;

    public DiffController(ILogger<DiffController> logger, IDiffRepository diffRepository, IDiffService diffService)
    {
        _logger = logger;
        _diffRepository = diffRepository;
        _diffService = diffService;
    }

    [HttpGet]
    [Route("{id:long}")]
    public ActionResult Get(long id)
    {
        var compareData = _diffRepository.Get(id);

        if(compareData is null || compareData.Left is null || compareData.Right is null)
        {
            return NotFound();
        }

        if (compareData.Left.SequenceEqual(compareData.Right))
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

        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.ContentDoNotMatch,
            Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
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
}
