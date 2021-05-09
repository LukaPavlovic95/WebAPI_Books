using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRep.ServiceInterface
{
    public interface ILoginService
    {
        Task<string> Login(ILogin regInfo);
    }
}
