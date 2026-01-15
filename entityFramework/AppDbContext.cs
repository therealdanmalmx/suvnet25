using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace entityFramework
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptionsBuilder options)
        // {
        //     options.UseSqlite("Data Source=app.db");
        // }

        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=app.db");
            options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    };

        public static class DbExtensions
        {
            public static void SetUpDataBase(this AppDbContext db, bool deleteDatabase = true)
            {
                if (deleteDatabase)
                {
                    db.Database.EnsureDeleted();
                }

                db.Database.EnsureCreated();

                if (db.Authors.Any())
                {
                    return;
                }

                Author newAuthor = new() {Name = "Shane 'douch' Sane"};
                Blog newBlog = new() {Title = "On the go with Go", Authors = [newAuthor], Posts = []};
                Post newPost = new() {Title="Best ever", Content = "You will never see nythng like this", Author = newAuthor, Blog = newBlog};

                db.Add(newPost);
                db.SaveChanges();
            }
        }
}

