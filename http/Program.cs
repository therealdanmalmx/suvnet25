using System.Net;
using System.Text;

HttpListener httpListener = new();
httpListener.Prefixes.Add("http://*:8000/");
httpListener.Start();

Console.WriteLine("Server listening to port 8000");

while (true)
{
    var context = httpListener.GetContext();
    Console.WriteLine($"{context.Request.HttpMethod}: {context.Request.Url.LocalPath}");

    string responseData = "Hello world!";
    byte[] buffer = Encoding.UTF8.GetBytes(responseData);
    context.Response.OutputStream.Write(buffer);

    context.Response.OutputStream.Close();
}