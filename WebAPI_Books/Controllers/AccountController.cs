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
    public class AccountControler : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;
        public AccountControler(ILoginService loginService, IRegisterService registerService, IMapper mapper)
        {
            _loginService = loginService;
            _registerService = registerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterViewModel>>> Get()
        {
            var list = await _registerService.GetUsers();
            return _mapper.Map<List<IRegister>, List<RegisterViewModel>>(list.ToList());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterViewModel>> Get(int id)
        {
            var user = await _registerService.GetOneUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegisterViewModel>(user));
        }
        [HttpPost]
        public async Task<ActionResult<RegisterViewModel>> PostUser([FromBody]RegisterViewModel user)
        {
            var newUser = await _registerService.Register(_mapper.Map<RegisterViewModel, IRegister>(user));
            return CreatedAtAction(nameof(Get), new { id = user.Id }, newUser);
        }
        [HttpPut]
        public async Task<ActionResult> PutAuthors(int id, [FromBody] RegisterViewModel register)
        {
            if (id != register.Id)
            {
                return BadRequest();
            }
            await _registerService.Update(_mapper.Map<IRegister>(register));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _registerService.Delete(id);
            if (userToDelete == false)
            {
                return NotFound();
            }
            await _registerService.Delete(id);
            return NoContent();
        }
    }
}
