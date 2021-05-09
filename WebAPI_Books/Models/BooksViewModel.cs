using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Books.Models
{
    public class BooksViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Guid AuthorsId { get; set; }
        public AuthorsViewModel Authors { get; set; }

    }
}
