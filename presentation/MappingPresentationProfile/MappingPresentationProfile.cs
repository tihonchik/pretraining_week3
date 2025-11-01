using AutoMapper;

namespace task4;

public class MappingPresentationProfile : Profile
{
    public MappingPresentationProfile()
    {
        CreateMap<AuthorModel, AuthorCreatedDto>().ReverseMap();
        CreateMap<AuthorModel, AuthorCreatingDto>().ReverseMap();

        CreateMap<BookModel, BookCreatedDto>().ReverseMap();
        CreateMap<BookModel, BookCreatingDto>().ReverseMap();

        CreateMap<AuthorFilterDto, AuthorModelFilter>();
        CreateMap<BookFilterDto, BookModelFilter>();
    }
}