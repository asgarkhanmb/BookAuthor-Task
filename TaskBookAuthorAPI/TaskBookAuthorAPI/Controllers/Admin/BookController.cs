
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Books;
using Service.Services.Interfaces;

namespace TaskBookAuthorAPI.Controllers.Admin
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;


        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BookCreateDto request)
        {
            await _bookService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new {Response = "Data succesfully created"});
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] BookEditDto request)
        {
            await _bookService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            return Ok(await _bookService.SearchAsync(name));
        }
        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 2)
        {
            return Ok(await _bookService.GetPaginateDataAsync(page, take));
        }

    }
}
