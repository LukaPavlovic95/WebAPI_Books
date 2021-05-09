using AutoMapper;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Model.ModelInterface;
using ServiceRep.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRep.Service
{
    public class AuthorsService : IAuthorsService
    {

        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<AuthorsEntity> dbSet;

        public AuthorsService(DBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this.dbSet = _context.Set<AuthorsEntity>();
        }

        public async Task<IEnumerable<IAuthors>> GetAuthorsAsync()
        {
            var authorsList = dbSet.Include(n => n.Books).ToList();
            return _mapper.Map<List<IAuthors>>(authorsList);
        }
        public async Task<IAuthors> Edit(IAuthors author)
        {
            //var authors = _context.Authors.Where(v => v.Name.Contains(book.AutorId.ToString())).FirstOrDefault();
            author.ID = Guid.NewGuid();
            AuthorsEntity authorE = _mapper.Map<AuthorsEntity>(author);
            dbSet.Add(authorE);
            await _context.SaveChangesAsync();
            return _mapper.Map<IAuthors>(author);
        }
        public async Task<IAuthors> GetOneAuthorAsync(Guid id)
        {
            var author = await dbSet.SingleOrDefaultAsync(item => item.ID == id);
            return _mapper.Map<IAuthors>(author);
        }
        public async Task<bool> Update(IAuthors author)
        {
            Guid ID = author.ID;
            var authorE = await dbSet.SingleOrDefaultAsync(item => item.ID == ID);
            if (authorE != null)
            {
                authorE.Name = author.Name;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> Delete(Guid id)
        {
            var authorE = await dbSet.SingleOrDefaultAsync(item => item.ID == id);
            if (authorE != null)
            {
                dbSet.Remove(authorE);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
