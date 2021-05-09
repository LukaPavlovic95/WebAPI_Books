using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ModelInterface
{
    public interface IAuthors
    {
        Guid ID { get; set; }
        string Name { get; set; }
        ICollection<IBooks> Books { get; set; }
    }
}
