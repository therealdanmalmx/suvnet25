using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int BlogId { get; set; }
        public required Blog Blog { get; set; }
        public int AuthorId { get; set; }
        public required Author ¢ { get; set; }
    }
}