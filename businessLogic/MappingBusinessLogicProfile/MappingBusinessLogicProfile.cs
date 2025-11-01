using AutoMapper;

namespace task4;

public class MappingBusinessLogicProfile : Profile
{
    public MappingBusinessLogicProfile()
    {
        CreateMap<AuthorEntity, AuthorModel>().ReverseMap();

        CreateMap<BookEntity, BookModel>().ReverseMap();

        CreateMap<AuthorModelFilter, AuthorEntityFilter>();
        CreateMap<BookModelFilter, BookEntityFilter>();
    }
}