using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using dapper_orm;
internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = File.ReadLines("connection.txt").First();
        using IDbConnection db = new MySqlConnection(connectionString);

        // db.Execute("INSERT INTO Teacher(Name, Email) VALUES('Lasse', 'lasse@maja.com');");

        IEnumerable<Teacher> teachers = db.Query<Teacher>("SELECT Id, Name, Email FROM Teacher").ToList();

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"{teacher.Id}: {teacher.Name} - {teacher.Email}");
        }
        Console.WriteLine();
    }
}

