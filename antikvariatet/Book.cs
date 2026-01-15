using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antikvariatet
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public Quality Quality { get; set; } = Quality.Good;
        public required int AuthorId { get; set; }
        public Author Author { get; set; }
        public required int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

    }

    public enum Quality
    {
        New,
        Good,
        Poor
    }
}