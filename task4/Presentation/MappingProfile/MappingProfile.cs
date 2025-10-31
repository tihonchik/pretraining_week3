using AutoMapper;

namespace task4;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorCreatedDto>().ReverseMap();
        CreateMap<Author, AuthorCreatingDto>().ReverseMap();
        CreateMap<Book, BookCreatedDto>().ReverseMap();
        CreateMap<Book, BookCreatingDto>().ReverseMap();
    }
}