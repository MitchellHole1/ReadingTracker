using Microsoft.AspNetCore.Mvc;
using MyReadingTracker.Extensions;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Services;

namespace MyReadingTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : ControllerBase
{
    private readonly ISeriesService _seriesService;

    public SeriesController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var series = _seriesService.GetAll();
        return Ok(series);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var series = _seriesService.GetById(id);
        if (series == null)
        {
            return NotFound();
        }
        return Ok(series);
    }
    
    [HttpPost]
    public IActionResult Save([FromBody] CreateSeriesRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var createdSeries = _seriesService.Save(request);
        
        if (!createdSeries.Success)
            return BadRequest(createdSeries.Message);
        
        return Ok(createdSeries.Series);
    }
}