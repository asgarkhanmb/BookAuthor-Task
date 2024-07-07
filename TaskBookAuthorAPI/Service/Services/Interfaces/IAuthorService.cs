using Service.DTOs.Admin.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAuthorService
    {
        Task Create(AuthorCreateDto model);
        Task<IEnumerable<AuthorDto>> GetAll();
        Task EditAsync(int? id, AuthorEditDto model);
        Task DeleteAsync(int? id);
        Task<AuthorDto> GetById(int id);
        Task<IEnumerable<AuthorDto>> SearchAsync(string name);
    }
}
