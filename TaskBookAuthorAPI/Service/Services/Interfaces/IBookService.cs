using Repository.Helpers;
using Service.DTOs.Admin.Books;


namespace Service.Services.Interfaces
{
    public  interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task CreateAsync(BookCreateDto model);
        Task<IEnumerable<BookDto>> GetAllWithInclude();
        Task DeleteAsync(int? id);
        Task EditAsync(int? id, BookEditDto model);
        Task<IEnumerable<BookDto>> SearchAsync(string name);
        Task<PaginationResponse<BookDto>> GetPaginateDataAsync(int page, int take);
    }
}
