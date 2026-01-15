using System.Net.Mail;
using System.Reflection.Metadata;

namespace Lektion_16;

class Program
{
    static void Main(string[] args)
    {
        // TimeGreetingService greetingService = new();

        // var greeting = greetingService.GetGreeting(new CustomDateTimeProvider());

        // Console.WriteLine(greeting);

        var addressBook = new AddressBook(new RealEmailService(), new FileLogger());

        addressBook.Add(new Contact("Kalle", "Anka", "kalle@anka.se", new DateTime(2025, 10, 15)));
        addressBook.Add(new Contact("Kajsa", "Anka", "kajsa@anka.se", new DateTime(1985, 2, 2)));

        addressBook.SendBirthdayEmails();

        foreach (var c in addressBook.GetAll())
        {
            Console.WriteLine(c);
        }
    }

    class Contact(string firstName, string lastName, string email, DateTime birthDay)
    {
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        public string Email { get; } = email;
        public DateTime BirthDate { get; set; } = birthDay;

    }

    class AddressBook
    {
        private readonly List<Contact> _contacts = new();
        private readonly ILogger _ilogger;
        public IEmailService _emailService;


        public AddressBook(IEmailService emailService, ILogger ilogger)
        {
            _emailService = emailService;
            _ilogger = ilogger;
        }

        public void Add(Contact contact)
        {

            if (string.IsNullOrWhiteSpace(contact.Email) || !contact.Email.Contains("@"))
            {
                return;
            }

            _contacts.Add(contact);

            _ilogger.Log($"Contact {contact.FirstName} {contact.LastName} added");
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? FindByEmail(string email)
        {
            foreach (var c in _contacts)
            {
                if (c.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return c;
                }
            }
            return null;
        }

        public void SendBirthdayEmails()
        {
            foreach (Contact item in _contacts)
            {
                if (item.BirthDate.Month == DateTime.Now.Month && item.BirthDate.Day == DateTime.Now.Day)
                {
                    _emailService.SendEmail(item.Email, "Grattis på födelsedagen!!!", "En liten kongratulation på bemärkelsedagen!");
                }
            }
        }
    }
}

class TestEmailService : IEmailService
{
public void SendEmail(string to, string subject, string body)    {
        string email = $"To: \t\t{to}\nSubject: \t{subject}\nBody: \t\t{body}";
        Console.WriteLine(email);
    }
}

class RealEmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        // string email = $"To: \t\t{to}\nSubject: \t{subject}\nBody: \t\t{body}";

        string mail = $"Detta är ett riktigt email till {to}!";
        Console.WriteLine(mail);
        Console.ResetColor();
    }
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
        File.AppendAllText("logger.txt", message + Environment.NewLine);
    }
}

interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

interface ILogger
{
    void Log(string message);
}