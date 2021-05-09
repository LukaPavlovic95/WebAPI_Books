using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Books.Models
{
    public class AuthorsViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<BooksViewModel> Books { get; set; }
    }
}
