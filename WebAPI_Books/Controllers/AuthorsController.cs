using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.ModelInterface;
using ServiceRep.ServiceInterface;
using WebAPI_Books.Models;

namespace WebAPI_Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsControler : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly IAuthorsService _authorsService;
        private readonly IMapper _mapper;
        public AuthorsControler(IBooksService booksService, IAuthorsService authorsService, IMapper mapper)
        {
            _booksService = booksService;
            _authorsService = authorsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorsViewModel>>> Get()
        {
            var list = await _authorsService.GetAuthorsAsync();
            return _mapper.Map<List<IAuthors>, List<AuthorsViewModel>>(list.ToList());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorsViewModel>> Get(Guid id)
        {
            var author = await _authorsService.GetOneAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorsViewModel>(author));
        }
        [HttpPost]
        public async Task<ActionResult<AuthorsViewModel>> PostAuthors([FromBody]AuthorsViewModel author)
        {
            var newAuthor = await _authorsService.Edit(_mapper.Map<AuthorsViewModel, IAuthors>(author));
            return CreatedAtAction(nameof(Get), new { id = newAuthor.ID }, newAuthor);
        }
        [HttpPut]
        public async Task<ActionResult> PutAuthors(Guid id, [FromBody] AuthorsViewModel author)
        {
            if (id != author.ID)
            {
                return BadRequest();
            }
            await _authorsService.Edit(_mapper.Map<IAuthors>(author));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var bookToDelete = await _authorsService.GetOneAuthorAsync(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            await _authorsService.Delete(id);
            return NoContent();
        }
    }
}
