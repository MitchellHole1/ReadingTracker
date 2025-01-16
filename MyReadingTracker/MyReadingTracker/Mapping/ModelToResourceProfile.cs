using AutoMapper;
using MyReadingTracker.Models;
using MyReadingTracker.Resources.Responses.Resources;

namespace MyReadingTracker.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Book, BookAuthorResource>();
    }
}