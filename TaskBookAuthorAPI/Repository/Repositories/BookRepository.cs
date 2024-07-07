using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BookRepository :BaseRepostiory<Book>,IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Book>> GetPaginateDataAsync(int page, int take)
        {
            return await _entities.Skip((page - 1) * take).Take(take).ToListAsync();
        }
    }
}
