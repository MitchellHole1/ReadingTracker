using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyReadingTracker.Extensions;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Services;

namespace MyReadingTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ReadingSessionController : ControllerBase
{
    private readonly IReadingSessionService _service;
    private readonly IMapper _mapper;
    
    public ReadingSessionController(IReadingSessionService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<ReadingSession> GetAll()
    {
        return _service.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<ReadingSession> GetById(int id)
    {
        var readingSession = _service.GetById(id);
        if (readingSession is null)
        {
            return NotFound();
        }
        
        return readingSession;
    }
    
    [HttpPost]
    public ActionResult<ReadingSession> Create([FromBody] CreateReadingSessionRequest createReadingSessionRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var readingSession = _mapper.Map<ReadingSession>(createReadingSessionRequest);
        var createdReadingSession = _service.Create(readingSession);
        
        if (!createdReadingSession.Success)
            return BadRequest(createdReadingSession.Message);
        
        return Ok(createdReadingSession.ReadingSession);
    }
    
    [HttpPatch("{id}")]
    public ActionResult<ReadingSession> Update(int id, [FromBody] UpdateReadingSessionRequest updateReadingSessionRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var updatedReadingSession = _service.Update(id, updateReadingSessionRequest);
        
        if (!updatedReadingSession.Success)
            return BadRequest(updatedReadingSession.Message);
        
        return Ok(updatedReadingSession.ReadingSession);
    }
}