
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener server = new TcpListener(IPAddress.Any, 5050);

server.Start();

Console.WriteLine($"Listening on port 5050");

TcpClient client = server.AcceptTcpClient();

NetworkStream stream = client.GetStream();
byte[] b = new byte[1024];
stream.Read(b, 0, b.Length);
string message = Encoding.UTF8.GetString(b, 0, b.Length);
var splitMessage = message.Split(",");

Console.ForegroundColor = (ConsoleColor)int.Parse(splitMessage[0]);
Console.WriteLine(splitMessage[1]);
Console.ResetColor();