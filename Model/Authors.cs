using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Authors : IAuthors
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<IBooks> Books { get; set; }
    }
}
