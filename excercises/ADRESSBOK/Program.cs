using System.Data.Common;
using System.Runtime.ConstrainedExecution;

Console.Clear();
// Mål: Skapa ett konsolprogram som låter användaren hantera en adressbok. Programmet ska fungera ungefär så här:


// ADRESSBOK v1
// ------------
// 1) Lägg till kontakt
// 2) Lista kontakter
// 4) Avsluta

List<string> contactNames = new List<string>();
List<string> contactNumbers = new List<string>();
bool quitMenue = false;
int minLength = Math.Min(contactNames.Count, contactNumbers.Count);
int contactId = 0;


while (quitMenue == false)
{
    Console.WriteLine("ADRESSBOK");
    Console.WriteLine("--------------------");
    Console.WriteLine("1) Lägg till kontakt");
    Console.WriteLine("2) Lista kontakter");
    Console.WriteLine("3) Leta efter en kontakt");
    Console.WriteLine("4) Ändra en kontakt");
    Console.WriteLine("5) Avsluta");
    Console.WriteLine("--------------------");
    Console.Write("Gör ett val från listan: ");
    int menueChoice = int.Parse(Console.ReadLine());

    if (menueChoice == 1)
    {
        AddContact();
    }
    if (menueChoice == 2)
    {
        ListContacts(contactNames, contactNumbers);
    }
    if (menueChoice == 3)
    {
        SearchContact();
        // UpdateContact();
    }
    if (menueChoice == 4)
    {
        UpdateContact();
    }
    if (menueChoice == 5)
    {
        quitMenue = true;
    }
}

void AddContact()
{
    Console.Write("Skriv in ett namn: ");
    string newContactName = Console.ReadLine().Trim();
    Console.Write("Och ett nummer: ");
    string newContactNumber = Console.ReadLine().Trim();

    contactId++;
    contactNames.Add(newContactName);
    contactNumbers.Add(newContactNumber);
    Console.WriteLine($"Contant ID: {contactId}");
}

void ListContacts(List<string> nameList, List<string> numberList)
{
    int minLength = Math.Min(nameList.Count, numberList.Count);

    if (minLength <= 0)
    {
        Console.WriteLine("Inga konakter tillagda ännu");
    }
    else
    {
        for (int i = 0; i < minLength; i++)
            {
                Console.WriteLine($"{nameList[i].Trim()} - {numberList[i].Split(".")[1].Trim()}");
            }
    }
}

void UpdateContact()
{
    ListContacts(contactNumbers, contactNames);
    Console.Write("Vilket namn  vill du ändra på?: ");
    string searchInput = Console.ReadLine().ToLower();
    Console.WriteLine(searchInput);
    var contacts = contactNames.Zip(contactNumbers);

    foreach (var item in contacts)
    {
        Console.WriteLine(item);
        if (contactNames.Contains(searchInput))
        {
            Console.WriteLine(item);
        }
    }
}
void SearchContact()
{
    Console.Write("Vem vill du hitta: ");
    string searchName = Console.ReadLine();

    for (int i = 0; i < contactNames.Count; i++)
    {
        if (contactNames[i].ToLower().Contains(searchName.ToLower()))
        {
            Console.WriteLine($"{i + 1} {contactNames[i].Trim()} - {contactNumbers[i].Split(".")[1].Trim()}");
        }
    }
}


// Val: 2
// Kontakter:
// 1. Anna Svensson - 0701234567
// 2. Kalle Karlsson - 0739876543
// Krav
// Meny
// Programmet ska visa en meny med fyra val:

// Lägg till kontakt
// Lista kontakter
// Sök kontakt
// Avsluta programmet
// Lägg till kontakt
// Användaren ska kunna skriva in namn och telefonnummer. Dessa ska sparas i två listor:

// List<string> för namn
// List<string> för telefonnummer
// Lista kontakter
// Programmet ska skriva ut alla kontakter med nummer, namn och telefonnummer.

// Avsluta
// Om användaren väljer avsluta ska programmet avslutas.

// Tekniska krav
// Använd två listor: en för namn och en för telefonnummer.

// Dela upp programmet i metoder:

// AddContact
// ListContacts
// SearchContact
// Använd while (true)-loop för att visa menyn tills användaren väljer att avsluta.

// Använd if eller else if för att hantera menyval.

// Extra utmaningar (frivilligt)
// Låt användaren kunna ta bort en kontakt.
// Låt användaren kunna uppdatera ett telefonnummer.
// Spara alla kontakter i en fil så att de finns kvar när man startar om programmet.
// Lägg till en sökfunktion som låter användaren söka efter en kontakt baserat på namn eller telefonnummer.