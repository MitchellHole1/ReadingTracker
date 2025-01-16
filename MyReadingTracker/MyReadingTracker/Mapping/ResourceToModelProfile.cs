using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

using MyReadingTracker.Models;
using MyReadingTracker.Resources.Requests.Books;

namespace MyReadingTracker.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<CreateBookRequest, Book>(); 
        CreateMap<CreateAuthorRequest, Author>();
        CreateMap<CreateReadingSessionRequest, ReadingSession>();
    }
}