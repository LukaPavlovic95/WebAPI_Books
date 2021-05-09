using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class BooksEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Guid AuthorsId { get; set; }
        public AuthorsEntity Authors { get; set; }
    }
}
