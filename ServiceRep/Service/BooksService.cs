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
    public class BooksService : IBooksService
    {

        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<BooksEntity> dbSet;
        public BooksService(DBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this.dbSet = _context.Set<BooksEntity>();
        }

        public async Task<IEnumerable<IBooks>> GetBooksAsync()
        {
            var booksList =  dbSet.Include(n => n.Authors).ToList();
            return  _mapper.Map<List<BooksEntity>, List<IBooks>>(booksList);
        }
        public async Task<IBooks> GetOneBookAsync(Guid id)
        {
            var book = dbSet.SingleOrDefaultAsync(item => item.ID == id);
            return _mapper.Map<IBooks>(book);
        }
        public async Task<IBooks> Edit(IBooks book)
        {
            book.ID = Guid.NewGuid();
            BooksEntity bookE = _mapper.Map<BooksEntity>(book);
            dbSet.Add(bookE);
            await _context.SaveChangesAsync();
            return _mapper.Map<IBooks>(book);
        }
        public async Task<bool> Update(IBooks book)
        {
            Guid ID = book.ID;
            var bookE = await dbSet.SingleOrDefaultAsync(item => item.ID == ID);
            if (bookE != null)
            {
                bookE.Name = book.Name;
                bookE.DateOfPublication = book.DateOfPublication;
                bookE.AuthorsId = book.AuthorsId;
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
            var bookE = await dbSet.SingleOrDefaultAsync(item => item.ID == id);
            if (bookE != null)
            {
                dbSet.Remove(bookE);
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
