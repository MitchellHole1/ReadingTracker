using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyReadingTracker.Models;
using MyReadingTracker.Services;

namespace MyReadingTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IGenreService _service;
    
    public GenreController(IMapper mapper, IGenreService service)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<Genre> GetAll()
    {
        var genres = _service.GetAll();
        return genres;
    }
}