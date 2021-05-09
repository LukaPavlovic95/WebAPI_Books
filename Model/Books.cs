using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Books : IBooks
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Guid AuthorsId { get; set; }
        public IAuthors Authors { get; set; }
    }
}
