// Console.WriteLine("Beställer kaffe...");
// await MakeCoffeeAsync();
// Console.WriteLine("Kaffet serveras!");

// static async Task MakeCoffeeAsync()
// {
//    Console.WriteLine("Brygger");
//    await Task.Delay(2000);
// }

// Console.WriteLine("Startar 3 jobb...");

// Task a = Task.Delay(1000);
// Task b = Task.Delay(2000);
// Task c = Task.Delay(3000);

// Task.WaitAll(a, b, c);

// Console.WriteLine("Alla klara!");


// int seconds = await RandomWaitAndReturnSecondsAsync();
// Console.WriteLine($"Väntade {seconds} sekunder.");

// static async Task<int> RandomWaitAndReturnSecondsAsync()
// {   int waitedSeconds = Random.Shared.Next(1, 5);
//     await Task.Delay(waitedSeconds * 1000);
//     return waitedSeconds;
// }

// Console.Write("Jobbar ");

// var longTask = Task.Delay(4000);

// while (!longTask.IsCompleted)
// {
//     Console.Write(".");
//     await Task.Delay(200);
// }

// Console.WriteLine("\nKlar!");

// Skriv en konsolapp som skapar en Task varje gång användaren trycker på Enter.
// Tasken ska vänta slumpmässigt mellan 1 och 5 sekunder och sen skriva "Task X klar!"
// där X är taskens nummer (1, 2, 3 osv). Appen ska fortsätta skapa tasks tills
// användaren skriver "exit" och trycker Enter.


// int count = 0;
// while (Console.ReadLine() != "exit".ToLower())
// {
//     if (Console.ReadLine() == "exit")
//     {
//         Environment.Exit(0);
//     }

//     await Task.Run(() => DelayTask());
//     Console.Write($"Task {count} klar");
// }

// async Task<int> DelayTask()
// {
//     int waitSeconds = Random.Shared.Next(1, 1000);
//     count++;
//     await Task.Delay(waitSeconds);
//     return count;
// }


// Ladda ner något stort med HTTPClient och rita punkter i konsolen medan
// du väntar på att nedladdningen ska bli klar. Använd följande URL för att
// ladda ner en stor fil: https://ash-speed.hetzner.com/100MB.bin

// HttpClient httpClient = new HttpClient();
// var url = "https://ash-speed.hetzner.com/100MB.bin";

// Task result = httpClient.GetByteArrayAsync(url);

// while(!result.IsCompleted)
// {
//     if (result.IsCompleted)
//     {
//         Environment.Exit(0);
//     }
//     Console.Write(".");
// }

// Ladda ner samma fil som i förra övningen, men denna
// gång med Progress-rapportering. Skriv ut procenten
// nedladdat i konsolen.

HttpClient httpClient = new HttpClient();
var url = "https://ash-speed.hetzner.com/100MB.bin";

var result = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
result.EnsureSuccessStatusCode();
var stream = result.Content.ReadAsStream();
long? total = result.Content.Headers.ContentLength;
byte[] byteArray = new byte[1024];
Memory<byte> memory = new(byteArray);
long totalDownloaded = 0;

Console.Clear();
while(true)
{
    int downlaoded = await stream.ReadAsync(memory);
    if (downlaoded == 0)
    {
        break;
    }

    totalDownloaded += downlaoded;
    Console.SetCursorPosition(0,0);
    Console.WriteLine($"{(float)totalDownloaded / (float)total! * 100:F2}% of {total}");
}