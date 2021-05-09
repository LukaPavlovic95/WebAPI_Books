using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class AuthorsEntity
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<BooksEntity> Books { get; set; }

    }
}
