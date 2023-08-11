using AutoMapper;
using BlazorProject.Shared;

namespace BlazorProject.Client.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BooksDto>();
            CreateMap<BooksDto, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.BookType, opt => opt.Ignore());
        }
    }
}
