using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antikvariatet
{
    public class AuthorBook
    {
        public int Id { get; set; }

        public required List<Book> Books { get; set; }
        public required List<Author> Authors { get; set; }
    }
}