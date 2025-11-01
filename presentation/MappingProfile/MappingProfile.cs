using AutoMapper;

namespace task4;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorEntity, AuthorCreatedDto>().ReverseMap();
        CreateMap<AuthorEntity, AuthorCreatingDto>().ReverseMap();

        CreateMap<BookEntity, BookCreatedDto>().ReverseMap();
        CreateMap<BookEntity, BookCreatingDto>().ReverseMap();

        CreateMap<AuthorFilterDto, AuthorEntityFilter>();
        CreateMap<BookFilterDto, BookEntityFilter>();
    }
}