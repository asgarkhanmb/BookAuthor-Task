using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Authors;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;


namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository,
                              IMapper mapper)
        {
            _authorRepo = authorRepository;
            _mapper = mapper;

        }
        public async Task Create(AuthorCreateDto model)
        {
            await _authorRepo.CreateAsync(_mapper.Map<Author>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var author = await _authorRepo.GetById((int)id);

            if (author is null) throw new NotFoundException("Auhtor not found");

            await _authorRepo.DeleteAsync(_mapper.Map<Author>(author));
        }

        public async Task EditAsync(int? id, AuthorEditDto model)
        {
            if (id is null) throw new ArgumentNullException();

            var author = await _authorRepo.GetById((int)id);

            if (author is null) throw new NotFoundException("Auhtor not found");

            await _authorRepo.EditAsync(_mapper.Map(model, author));

        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var authors = await _authorRepo.FindAllWithIncludes()
                                       .Include(m=>m.AuthorBooks)
                                       .ThenInclude(m => m.Book)
                                       .ToListAsync();


            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetById(int id)
        {
            return _mapper.Map<AuthorDto>(await _authorRepo.GetById(id));
        }

        public async Task<IEnumerable<AuthorDto>> SearchAsync(string name)
        {
           return _mapper.Map<IEnumerable<AuthorDto>>(await _authorRepo.FindAll(m=>m.Name.Contains(name)));
        }
    }
}
