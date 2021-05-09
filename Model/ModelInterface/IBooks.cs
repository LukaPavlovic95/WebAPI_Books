using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ModelInterface
{
    public interface IBooks
    {
        Guid ID { get; set; }
        string Name { get; set; }
        DateTime DateOfPublication { get; set; }
        Guid AuthorsId { get; set; }
        IAuthors Authors { get; set; }
    }
}
