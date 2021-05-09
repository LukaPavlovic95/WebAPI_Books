using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRep.ServiceInterface
{
    public interface IRegisterService
    {
        Task<IEnumerable<IRegister>> GetUsers();
        Task<IRegister> GetOneUser(int id);
        Task<bool> Register(IRegister regInfo);
        Task<bool> Update(IRegister register);
        Task<bool> Delete(int id);
    }
}
