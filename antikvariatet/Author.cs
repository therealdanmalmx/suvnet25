using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antikvariatet
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<AuthorBook> AuthorBooks { get; set; }
    }
}