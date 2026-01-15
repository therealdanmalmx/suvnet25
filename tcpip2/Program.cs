using System.Net.Sockets;
using System.Text;

// TcpClient client = new TcpClient("127.0.0.1", 5050);
TcpClient client = new TcpClient("10.9.7.152", 8000);
NetworkStream stream = client.GetStream();

while(client.Connected)
{
    Console.WriteLine("What message do you want to send?");
    string message = Console.ReadLine() ?? string.Empty;
    byte[] data = Encoding.UTF8.GetBytes(message);

for (int i = 0; i < 10; i++)
{
    stream.Write(data);
}

    Console.WriteLine("Client connecting");
}

client.Close();