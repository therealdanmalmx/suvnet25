using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Blog
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required List<Author> Authors { get; set; }
        public required List<Post> Posts { get; set; }

    }
}