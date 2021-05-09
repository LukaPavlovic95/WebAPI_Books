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
    public class LoginService : ILoginService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<AccountEntity> dbSet;

        public LoginService(DBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this.dbSet = _context.Set<AccountEntity>();
        }

        public async Task<string> Login(ILogin regInfo)
        {
            if (_context.Account.Where(m => m.Email == regInfo.Email && m.Password == regInfo.Password).FirstOrDefault() == null)
            {
                return ("error");
            }
            else
            {
                return (regInfo.Email);
            }
        }
    }
}
