using System.Data.Common;
using System.Runtime.ConstrainedExecution;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Contact> contacts = [];
        bool quitMenue = false;

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
                ListContacts(contacts);
            }
            if (menueChoice == 3)
            {
                SearchContact(contacts);
                // UpdateContact();
            }
            if (menueChoice == 4)
            {
                Console.WriteLine("Inte klar ännu");
                // UpdateContact();
            }
            if (menueChoice == 5)
            {
                quitMenue = true;
            }
        }

        void AddContact()
        {
            Contact newContact = new Contact();
            Console.Write("Skriv in ett namn: ");
            newContact.name = Console.ReadLine().Trim();
            Console.Write("Och ett nummer: ");
            newContact.number = Console.ReadLine().Trim();

            contacts.Add(newContact);
        }

        void ListContacts(List<Contact> listContacts)
        {

            Console.WriteLine();
            Console.WriteLine("Kontaktlista");
            Console.WriteLine("-------------------");
            if (listContacts.Count == 0)
            {
                Console.WriteLine("Inga konakter tillagda ännu");
            }
            else
            {

                for (int i = 0; i < listContacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listContacts[i].name.Trim()} - {listContacts[i].number.Trim()}");
                }
            }
            Console.WriteLine("-------------------");
            Console.WriteLine();
        }

        // void UpdateContact()
        // {
        //     ListContacts(contacts);
        //     Console.Write("Vilket namn  vill du ändra på?: ");
        //     string searchInput = Console.ReadLine().ToLower();
        //     Console.WriteLine(searchInput);

        //     foreach (var item in contacts)
        //     {
        //         Console.WriteLine(item);
        //         if (contacts.Contains(searchInput))
        //         {
        //             Console.WriteLine(item);
        //         }
        //     }
        // }
        void SearchContact(List<Contact> contacts)
        {

            Console.Write("Vem vill du hitta: ");
            string searchName = Console.ReadLine();

            while (searchName.Length == 0)
            {

                if (searchName.Length == 0)
                {
                    Console.Write("Du måste skriva ett namn: ");
                    searchName = Console.ReadLine();
                }

            }

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].name.ToLower().Contains(searchName.ToLower()))
                {
                    Console.WriteLine();
                    Console.WriteLine($"{i + 1}. {contacts[i].name} - {contacts[i].number}");
                    Console.WriteLine();
                    continue;
                }
            }
            Console.WriteLine($"Kunde inte hitta {searchName} i adressboken.");
        }
    }
}