using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Admin.Authors;
using Service.DTOs.Admin.Books;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookDto>().ForMember(d => d.AuthorsName, opt => opt.MapFrom(s => s.AuthorBooks.Select(m => m.Author.Name)));
            CreateMap<BookEditDto, Book>();

            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorDto>().ForMember(d => d.BooksName, opt => opt.MapFrom(s => s.AuthorBooks.Select(m => m.Book.Title)));
            CreateMap<AuthorEditDto, Author>();


            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();

        }
    }
}
