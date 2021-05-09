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
    public class BooksController : ControllerBase
    {

        private readonly IBooksService _booksService;
        private readonly IAuthorsService _authorsService;
        private readonly IMapper _mapper;
        public BooksController(IBooksService booksService, IAuthorsService authorsService, IMapper mapper)
        {
            _booksService = booksService;
            _authorsService = authorsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksViewModel>>> Get()
        {
            var list = await _booksService.GetBooksAsync();
            return _mapper.Map<List<IBooks>, List<BooksViewModel>>(list.ToList());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksViewModel>> Get(Guid id)
        {
            var book = await _booksService.GetOneBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BooksViewModel>(book));
        }
        [HttpPost]
        public async  Task<ActionResult<BooksViewModel>> PostBooks([FromBody]BooksViewModel book)
        {   
                var newbook = await _booksService.Edit(_mapper.Map<BooksViewModel, IBooks>(book));
                return CreatedAtAction(nameof(Get), new { id = newbook.ID}, newbook);          
        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(Guid id,[FromBody] BooksViewModel book)
        {
            if(id != book.ID)
            {
                return BadRequest();
            }
            await _booksService.Edit(_mapper.Map<IBooks>(book));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (Guid id)
        {
            var bookToDelete = await _booksService.GetOneBookAsync(id);
            if(bookToDelete == null)
            {
                return NotFound();
            }
            await _booksService.Delete(id);
            return NoContent();
        }
    }
}
