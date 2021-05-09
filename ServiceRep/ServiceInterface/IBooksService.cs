using Model;
using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRep.ServiceInterface
{
    public interface IBooksService
    {
        Task<IEnumerable<IBooks>> GetBooksAsync();
        Task<IBooks> Edit(IBooks book);
        Task<IBooks> GetOneBookAsync(Guid id);
        Task<bool> Update(IBooks book);
        Task<bool> Delete(Guid id);
    }
}
