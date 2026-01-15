using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace transaction;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = File.ReadLines("connection.txt").First();
        Console.WriteLine(connectionString);
        using IDbConnection db = new MySqlConnection(connectionString);

        db.Open();

        int customerId = 1;
        List<int> products = [3];

        using var transaction = db.BeginTransaction();

        int orderId = db.ExecuteScalar<int>("INSERT INTO COrder(ODateTime, CustomerId) VALUES (NOW(), @CustomerId); SELECT LAST_INSERT_ID();",  new {CustomerId = customerId}, transaction);

        foreach (int product in products)
        {
            db.Execute("INSERT INTO ProductToOrder(corderid, productid, quantity) VALUES (@OrderId, @ProductId, @Quantity);", new {OrderId = orderId, ProductId = product, Quantity = 4}, transaction);
        }

        transaction.Commit();

    }
}
