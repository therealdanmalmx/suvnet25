namespace entityFramework
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}