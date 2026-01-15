// See https://aka.ms/new-console-template for more information

Console.Clear();
// PSEUDOKOD

// Tänk dig ett program som ber användaren mata in två tal, adderar dem och skriver ut resultatet:

// Skriv pseudokod för programmet som void syakommentarer
// Skriv koden för programmet i C#

// Tänk dig ett program där användaren matar in ett ord. Ordet visas på skärmen och användaren får mata in ytterligare ett ord. Båda orden visas på skärmen osv.
// Detta fortsätter tills användaren matar in "sluta".

// Skriv pseudokod för programmet som kommentarer
// Skriv koden för programmet i C#



// Mata in 2 nummer

// Be användaren mata in ett nummer
// Console.Write("Ang ett nummer: ");
// string num1 = Console.ReadLine();
// int numberOne = int.Parse(num1);
// Console.Write("Ang ett till nummer: ");
// string num2 = Console.ReadLine();
// int numberTwo = int.Parse(num2);

// int result = numberOne + numberTwo;

// Console.WriteLine($"{numberOne} + {numberTwo} = {result}");




// MATA IN ORD

// Definera en variabel som heter slut och sätt den till false
// 3

// Ange en X-koordinat (1-5): 4
// Ange en Y-koordinat (1-5): 3

// y
// 5 *
// 4 *
// 3 *       X
// 2 *
// 1 *
// 0 * * * * * *
// 0 1 2 3 4 5 x

//Be användaren om ett Y koordinat mellan 1 och 5

// Console.Clear();
// Console.Write("Ange en X-koordinat (1-5): ");
// // spara svaret i en variabel
// string xCoordinator = Console.ReadLine();
// int x = int.Parse(xCoordinator);
// //Be användaren om ett X koordinat mellan 1 och 5
// Console.Write("Ange en Y-koordinat (1-5): ");
// // spara svaret i en variabel
// string yCoordinator = Console.ReadLine();
// int y = int.Parse(yCoordinator);

// Console.WriteLine();
// Console.WriteLine("y");

// for (int yPos = 5; yPos >= 0; yPos--)
// {
//     if (yPos > 0)
//     {
//         Console.Write(yPos + " *");
//     }

//     if (yPos == 0)
//     {
//         Console.Write($"{yPos} * * * * * *");
//     }

//     for (int xPos = 1; xPos <= 5; xPos++)
//     {
//         if (xPos == x && yPos == y)
//         {
//             Console.Write(" X");
//         }
//         else
//         {
//             Console.Write("  ");
//         }
//     }
//     Console.WriteLine();
// }

// Console.Write("  ");
// for (int j = 0; j <= 5; j++)
// {
//     Console.Write($"{j}" + " ");
// }
// Console.WriteLine("x");



// STRÄNGAR

// Console.Clear();
// 1. Räkna bokstäver
// Skriv ett program som frågar användaren om deras namn och skriver ut hur många tecken det innehåller.

// 2. Stor eller liten bokstav
// Läs in en mening och skriv ut den i både versaler och gemener.

// 3. Hitta ett ord
// Låt användaren skriva en text. Kolla om texten innehåller ordet C#, och skriv ut ett meddelande beroende på om det gör det eller inte.

// 4. Censur
// Skapa en array med förbjudna ord (t.ex. "dum", "idiot", "korkad"). Låt användaren skriva en mening och censurera de förbjudna orden genom att ersätta dem med stjärnor (t.ex. "****"). Skriv ut den censurerade meningen.


// 1.
// Console.Write("Vad heter du? ");
// string namn = Console.ReadLine();
// Console.WriteLine($"Ditt namn är {namn.Length} bokstäver långt");

// 2.
// Console.Write("Skriv en mening: ");
// string mening = Console.ReadLine();
// Console.WriteLine($"Versalt: {mening.ToUpper()}");
// Console.WriteLine($"Gemener: {mening.ToLower()}");

// 3.
// Console.Write("Skriv en text: ");
// string text = Console.ReadLine().ToLower();

// if (text.Contains("C#".ToLower()))
// {
//     Console.WriteLine("Vi gillar dig");
// }
// else
// {
//     Console.WriteLine("Fuck off!");
// }

// 4.
// string[] forbiddenWords = ["dum", "idiot", "korkad"];

// Console.Write("Skriv en mening: ");
// string text = Console.ReadLine();
// string censuredText = "";

// foreach (var item in forbiddenWords)
// {
//     if (text.Contains(item))
//     {
//         censuredText += text.Replace(item, "****");
//     }
// }
// if (censuredText.Length > 0)
// {
//     Console.WriteLine(censuredText);
// }
// else
// {
//     Console.WriteLine(text);
// }


// FILE

// Räkna rader i en textfil

// Läs in en textfil och räkna hur många rader den innehåller.
// var fileString = File.ReadAllLines("file.txt");
// int fileLength = fileString.Length;
// Console.WriteLine(fileLength);

// foreach (var item in fileString)
// {
// // Visa resultatet i konsolen.
//     Console.WriteLine(item);
// }

// Console.Write("Sök efter ett ord: ");
// string word = Console.ReadLine();
// foreach (var item in fileString)
// {
// // Sök efter ett ord i en textfil
//     Console.WriteLine(item.Contains(word));

// }

// Läs in en textfil och låt användaren skriva in ett ord.

// var fileString2 = File.ReadAllLines("file.txt");
// Console.WriteLine("Skriv ett ord");
// string wordChoice = Console.ReadLine();
// // Räkna hur många gånger ordet förekommer i filen och visa resultatet.
// foreach (var item in fileString2)
// {
//     bool containsWord = item.Contains(wordChoice);

// }
// Utveckling: Visa även vilka rader ordet förekommer på.
// Utveckling 2: Gör sökningen okänslig för versaler/gemener (case insensitive).
// Utveckling 3: Visa raderna där ordet förekommer, med ordet markerat (t.ex. med asterisker *ord*).

// Skapa en sammanfattning av en textfil

// Läs in en textfil och skapa en ny fil som innehåller de första 5 raderna från den ursprungliga filen.
// var fileString3 = File.ReadAllLines("file.txt");
// Console.WriteLine(fileString3.Length);
// string[] fileSummary = new string[0];

// for (int i = 0; i < 5; i++)
// {
//     Array.Resize(ref fileSummary, fileSummary.Length + 1);
//     fileSummary[fileSummary.Length - 1] = fileString3[i];
// }

// // Spara den nya filen med samma namn som den ursprungliga med tillägget "_summary".
// string path = "file_summary.txt";
// File.WriteAllLines(path, fileSummary);


// foreach (var item in fileSummary)
// {
//     Console.WriteLine(item);
// }


// RANDOM

// Slå en tärning

// Slumpa ett tal mellan 1–6 och säg vad tärningskastet blev.
// Utveckling: Slumpa två tärningar, visa båda resultaten och summan.
// Slumpa sten, sax, påse

// Tre utfall i stället för två.
// Eleven kan göra en meny där användaren väljer sitt drag, och datorn slumpas fram.
// Jämför och avgör vinnare.
// Dagens lyckokaka-meddelande

// Ha en array med 5–10 olika "meddelanden" och slumpa fram ett.
// Liknar slantsingling, fast med flera alternativ.
// Gissa talet light

// Datorn slumpar ett tal mellan 1–10.
// Användaren gissar, datorn berättar om det blev rätt eller fel (ingen loop, bara enkel check).
// Slumpa fram väder

// Slumpa mellan "sol", "regn", "snö", "molnigt".
// Kan utvidgas till att slumpa temperatur också.

// int dice = Random.Shared.Next(1, 7);
// Console.WriteLine($"Tärningen slog nummer: {dice}");

// int diceNew = Random.Shared.Next(1, 7);
// int diceNew2 = Random.Shared.Next(1, 7);
// Console.WriteLine($"Tärningarna slog nummrerna: {diceNew} och {diceNew2}. Resultatet är: {diceNew + diceNew2}");

// string[] rockPaperScissors = ["sten", "sax", "påse"];
// int index = Random.Shared.Next(0, 3);
// string computersChoice = rockPaperScissors[index];

// for (int i = 0; i < rockPaperScissors.Length; i++)
// {
//     Console.WriteLine($"{i + 1} = {rockPaperScissors[i]}");
// }
// Console.WriteLine();
// Console.Write("Välj sten, sax eller påse: ");
// string humanChoice = Console.ReadLine();
// int humanChoiceConverted = int.Parse(humanChoice);

// if (humanChoiceConverted == 1)
// {
//     humanChoice = "sten";
// }
// else if (humanChoiceConverted == 2)
// {
//     humanChoice = "sax";
// }
// else if (humanChoiceConverted == 3)
// {
//     humanChoice = "påse";
// }

// Console.WriteLine();

// Console.WriteLine($"Du valde: {humanChoice} och datorn: {computersChoice}");
// Console.WriteLine();

// if (humanChoice == computersChoice)
// {
//     Console.ForegroundColor = ConsoleColor.Blue;
//     Console.WriteLine("Oavgjort");
//     return;
// }

// if (computersChoice == "sten" && humanChoice == "sax")
// {
//     Console.ForegroundColor = ConsoleColor.Red;
//     Console.WriteLine("Datorn van :(");
//     return;
// }
// else if (computersChoice == "sax" && humanChoice == "påse")
// {
//     Console.ForegroundColor = ConsoleColor.Red;
//     Console.WriteLine("Datorn van...");
//     return;
// }
// else if (computersChoice == "påse" && humanChoice == "sten")
// {
//     Console.ForegroundColor = ConsoleColor.Red;
//     Console.WriteLine("Datorn van...");
//     return;
// }
// else
// {
//     Console.ForegroundColor = ConsoleColor.Green;
//     Console.WriteLine("Du vann!!!");
//     return;
// }

// string[] weather = ["sol", "regn", "snö", "molnigt"];
// int weatherIndex = Random.Shared.Next(0, weather.Length);
// string[] temperature = ["17.5", "23.2", "5.6", "12.8"];
// int temperatureIndex = Random.Shared.Next(0, temperature.Length);

// Console.WriteLine($"Idag kommer Sverige ha {weather[weatherIndex]} och det kommer att bli {temperature[temperatureIndex]}°C.");

// string[] bunchOfMessages = [
//     "Du kommer att ha en fantastisk dag!",
//     "Något oväntat kommer att göra dig glad.",
//     "Var snäll mot någon idag, det lönar sig.",
//     "Ett gammalt problem får snart sin lösning.",
//     "Du får ett trevligt besked inom kort.",
//     "Ta en chans - det kan bli en succé!"
// ];

// int index = Random.Shared.Next(0, 6);

// Console.WriteLine(bunchOfMessages[index]);
// Console.WriteLine();

// bool righGuess = false;
// int computerRandomNumber = Random.Shared.Next(1, 11);
// Console.WriteLine(computerRandomNumber);
// Console.Write("Välj ett tal mellan 1 och 10: ");
// string inputNumber = Console.ReadLine();
// int parcedInputNumber = int.Parse(inputNumber);

// if (parcedInputNumber == computerRandomNumber)
// {
//     Console.WriteLine($"{computerRandomNumber} var talet. Rätt gissat!!!");
//     return;
// }
// while (righGuess == false)
// {
//     Console.Write("Fel nummer, välj igen: ");
//     string inputNumber2 = Console.ReadLine();
//     int parcedInputNumber2 = int.Parse(inputNumber2);

//     if (parcedInputNumber2 == computerRandomNumber)
//     {
//         Console.WriteLine($"{computerRandomNumber} var talet. Rätt gissat!!!");
//         righGuess = true;
//     }

// }
