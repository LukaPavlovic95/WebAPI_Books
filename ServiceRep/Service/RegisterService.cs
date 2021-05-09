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
    public class RegisterService : IRegisterService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<AccountEntity> dbSet;

        public RegisterService(DBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this.dbSet = _context.Set<AccountEntity>();
        }
        public async Task<IEnumerable<IRegister>> GetUsers()
        {
            var usersList = dbSet.ToList();
            return _mapper.Map<List<AccountEntity>, List<IRegister>>(usersList);
        }
        public async Task<IRegister> GetOneUser(int id)
        {
            var user = dbSet.SingleOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<IRegister>(user);
        }
        public async Task<bool> Register(IRegister regInfo)
        {
            if (_context.Account.Where(m => m.Email == regInfo.Email).FirstOrDefault() == null)
                return false;
            var newUser = new AccountEntity();
            dbSet.Add(_mapper.Map<AccountEntity>(regInfo));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(IRegister register)
        {
            int id = register.Id;
            var user = await dbSet.SingleOrDefaultAsync(item => item.Id == id);
            if (user != null)
            {
                user.Email = register.Email;
                user.LastName= register.LastName;
                user.FirstName = register.FirstName;
                user.Password = register.Password;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> Delete(int id)
        {
            var user = await dbSet.SingleOrDefaultAsync(item => item.Id == id);
            if (user != null)
            {
                dbSet.Remove(user);
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
