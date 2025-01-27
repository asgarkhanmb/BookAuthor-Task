﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Authors;
using Service.Services.Interfaces;

namespace TaskBookAuthorAPI.Controllers.Admin
{
    [Authorize]
    public class AuthorController :BaseController
    {
        private readonly IAuthorService _authorService;


        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AuthorCreateDto request)
        {
            await _authorService.Create(request);
            return CreatedAtAction(nameof(Create), new { Response = "Data succesfully created" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _authorService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] AuthorEditDto request)
        {
            await _authorService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _authorService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            return Ok(await _authorService.SearchAsync(name));
        }

    }
}
