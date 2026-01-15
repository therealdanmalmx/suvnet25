using Microsoft.EntityFrameworkCore;
using entityFramework;


internal class Program
{
    private static void Main(string[] args)
    {
        AppDbContext db = new();
        db.SetUpDataBase();
    }
}