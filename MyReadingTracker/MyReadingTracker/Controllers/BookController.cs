using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using MyReadingTracker.Extensions;
using MyReadingTracker.Infrastructure.CloudStorage;
using MyReadingTracker.Models;
using MyReadingTracker.Resources;
using MyReadingTracker.Resources.Requests;
using MyReadingTracker.Resources.Requests.Books;
using MyReadingTracker.Resources.Responses.Resources;
using MyReadingTracker.Services;

namespace MyReadingTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;
    private readonly IMapper _mapper;
    private readonly ICloudStorage _cloudStorage;
    
    public BookController(IBookService service, IMapper mapper, ICloudStorage cloudStorage)
    {
        _service = service;
        _mapper = mapper;
        _cloudStorage = cloudStorage;
    }
    
    // create an endpoint that gets a file from the cloud storage
    [HttpGet("{id}/cover-image")]
    public async Task<IActionResult> GetCoverImage(int id)
    {
        var fileName = _service.GetCoverImageFileName(id);
        if (fileName == null)
        {
            return NotFound();
        }
        var stream = await _cloudStorage.GetFile(fileName);
        return File(stream, "image/jpeg");
    }

    [HttpPatch("{id}/cover-image")]
    public async Task<IActionResult> UpdateCoverImage(int id, IFormFile file)
    {
        var book = _service.GetById(id);
        if (book == null)
        {
            return NotFound();
        }
        
        var fileName = file.FileName;
        await _cloudStorage.UploadFile(file);

        book.CoverImageFileName = fileName;
        _service.Update(book);

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] GetBooksRequest request)
    {
        var books = _service.GetAll(request);
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public ActionResult<BookAuthorResource> GetById(int id)
    {
        var book = _service.GetById(id);
        if(book is not null)
        {
            return _mapper.Map<Book, BookAuthorResource>(book);
        }

        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateBookRequest createBookRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var createdBook = _service.Create(createBookRequest);
        
        if (!createdBook.Success)
            return BadRequest(createdBook.Message);
        
        return Ok(createdBook.BookResource);
    }

    
    /*[HttpPut("{id}")]
    public IActionResult Update(int id, Book updatedBook)
    {
        if(id != updatedBook.Id)
        {
            return BadRequest();
        }
        
        var existingBook = _service.GetById(id);
        if(existingBook is null)
        {
            return NotFound();
        }
        
        _service.Update(updatedBook);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _service.GetById(id);
        if(book is null)
        {
            return NotFound();
        }
        
        _service.DeleteById(id);
        
        return NoContent();
    }*/
}