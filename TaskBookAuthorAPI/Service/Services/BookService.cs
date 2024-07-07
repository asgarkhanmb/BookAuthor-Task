using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Helpers;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Books;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;


namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorBookRepository _authorBookRepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BookService(IBookRepository bookRepository, IMapper mapper,
            IAuthorBookRepository authorBookRepo,
            AppDbContext context)
        {
            _bookRepo = bookRepository;
            _mapper = mapper;
            _authorBookRepo = authorBookRepo;
            _context = context;
        }


        public async Task CreateAsync(BookCreateDto model)
        {
            var data = _mapper.Map<Book>(model);
            await _bookRepo.CreateAsync(data);

            foreach (var id in model.AuthorIds)
            {
                await _authorBookRepo.CreateAsync(new AuthorBook
                {
                    BookId = data.Id,
                    AuthorId = id
                });
            }

        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var book = await _bookRepo.GetById((int)id);

            if (book is null) throw new NotFoundException("Book not found");

            await _bookRepo.DeleteAsync(_mapper.Map<Book>(book));
        }

        public async Task EditAsync(int? id, BookEditDto model)
        {
            if (id is null) throw new ArgumentNullException();

            var book = await _bookRepo.GetById((int)id);

            if (book is null) throw new NotFoundException("Book not found");

            await _bookRepo.EditAsync(_mapper.Map(model, book));
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {

            var books = await _bookRepo.FindAllWithIncludes()
                                       .Include(b => b.AuthorBooks)
                                       .ThenInclude(m => m.Author)
                                        .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetAllWithInclude()
        {
            var books = await _bookRepo.FindAllWithIncludes()
               .Include(m => m.AuthorBooks)
               .ToListAsync();
            var mappedStudents = _mapper.Map<List<BookDto>>(books);
            return mappedStudents;
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            return _mapper.Map<BookDto>(await _bookRepo.GetById(id));
        }

        public async Task<PaginationResponse<BookDto>> GetPaginateDataAsync(int page, int take)
        {
            var books = await _bookRepo.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)books.Count() / take);

            var mappedDatas = _mapper.Map<IEnumerable<BookDto>>(await _bookRepo.GetPaginateDataAsync(page, take));
            return new PaginationResponse<BookDto>(mappedDatas, totalPage, page);
        }

        public async Task<IEnumerable<BookDto>> SearchAsync(string name)
        {
            return _mapper.Map<IEnumerable<BookDto>>(await _bookRepo.FindAll(m => m.Title.Contains(name)));
        }
    }
}
