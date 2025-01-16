using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyReadingTracker.Extensions;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Resources;
using MyReadingTracker.Services;

namespace MyReadingTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMapper _mapper;
    
    public AuthorController(IAuthorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult GetAll([FromQuery] GetAuthorRequest request)
    {
        var authors = _service.GetAll(request);
        return Ok(authors);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var author = _service.GetById(id);
        if(author is not null)
        {
            return Ok(author);
        }

        return NotFound();
    }
    
    [HttpGet("{id}/books")]
    public IEnumerable<BookResource> GetBooksByAuthorId(int id)
    {
        var books = _service.GetBooksByAuthorId(id);
        return  _mapper.Map<IEnumerable<Book>, IEnumerable<BookAuthorResource>>(books);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateAuthorRequest createAuthorRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var newAuthor = _mapper.Map<Author>(createAuthorRequest);
        var createdAuthor = _service.Create(newAuthor);
        
        if (!createdAuthor.Success)
            return BadRequest(createdAuthor.Message);
        
        return Ok(createdAuthor.Author);
    }

}