class Program
{

    static bool memberOfChurch;
    static int taxFreeAmountNormal = 24900;
    static string taxNumber = "0000";
    static int taxFreeAmountPensioner = 65300;
    static float calculateTax = 0;

    static void Main() //Ok nått är fel med progammet, det startar inte ens. Hinner inte fixa, har möte med chefen om 5 min. //Pelle Programmerare
    {
        Console.Clear();
        bool quit = false;

        while (quit == false)
        {
            Console.WriteLine("VÄLKOMMEN TILL SKATTEVERKET 1.0\n");
            Console.WriteLine("1) Beräkna skatt för en person");
            Console.WriteLine("2) Beräkna skatt för flera personer från fil");
            Console.WriteLine("3) Avsluta\n");
            Console.Write("Val: ");

            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Write("Vad är ditt namn?: ");
                string fullName = Console.ReadLine();
                if (string.IsNullOrEmpty(fullName))
                {
                    Console.Write("Du måste skriva ditt namn: ");
                    fullName = Console.ReadLine();
                }
                Console.Write("Vad är ditt personnummer, 12 siffror?: ");
                taxNumber = Console.ReadLine();
                if (taxNumber.Length <= 3)
                {
                    Console.Write("För kort. Minst födelseår. Hälst 12 siffror (xxxxxxxx-xxxx). Skriv igen: ");
                    taxNumber = Console.ReadLine();
                }
                Console.Write("Hur mycket tjänar du per år?: ");
                int income = int.Parse(Console.ReadLine());
                Console.Write("Är du medlem i Svenska kyrkan?: (y/n)");
                string churchMember = Console.ReadLine();

                if (churchMember.ToLower() == "y")
                {
                    memberOfChurch = true;
                }
                else
                {
                    memberOfChurch = false;
                }

                PrintTaxDetails(fullName, taxNumber, income, memberOfChurch);


                // Bra kod för att beräkna skatt för en person kommer här. Efter fikapausen. //Pelle Programmerare
            }
            else if (input == 2)
            {
                string[] personsList = File.ReadAllLines("personer.csv");

                foreach (string item in personsList)
                {
                    string[] splitString = item.Split(",");

                    string taxNumber = splitString[0];
                    string name = splitString[1];
                    string city = splitString[2];
                    Int64 income = Int64.Parse(splitString[3]);
                    string churchMember = splitString[4];

                    if (churchMember.ToLower() == "y")
                    {
                        memberOfChurch = true;
                    }
                    else
                    {
                        memberOfChurch = false;
                    }
                    // Console.WriteLine($"{taxNumber} {name} {income} {memberOfChurch}");

                    PrintTaxDetails(name, taxNumber, income, memberOfChurch);
                }
            }
            else if (input == 3)
            {
                quit = true;
                //Här ska progarmmet avslutas men vet inte exakt hur. Kanske inte är så viktigt heller. //Pelle Programmerare
            }
        }
    }

    static void PrintTaxDetails(string name, string taxNumber, Int64 income, bool memberOfChurch)
    {
        Console.WriteLine("SKATTEKVITTERING");
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Namn: {name}");
        Console.WriteLine($"Personnummer: {taxNumber}");
        Console.WriteLine($"Inkomst: {income} kr");
        Console.WriteLine($"Kyrkotillhörighet: {((memberOfChurch == true) ? "Ja" : "Nej")}");
        Console.WriteLine();
        Console.WriteLine($"Kommunalskatt: {CalculateCommuneTax(income)} kr");
        Console.WriteLine($"Statlig skatt: {CalculateStateTax(income)} kr");
        Console.WriteLine($"Kyrkoavgift: {CalculateChurchTax(income)} kr");
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Totalt att betala: {CalculateCommuneTax(income) + CalculateStateTax(income) + CalculateChurchTax(income)} kr");
    }

    static int CalculateCommuneTax(Int64 income)
    {
        int taxFreeAmountNormal = 24900;
        int taxFreeAmountPensioner = 65300;
        float communeTaxRate = 0.2f;

        if (CalculateAge(taxNumber) > 65)
        {
            calculateTax = (income - taxFreeAmountPensioner) * communeTaxRate;
        }
        else
        {
            calculateTax = (income - taxFreeAmountNormal) * communeTaxRate;
        }
        return (int)calculateTax;
    }

    static int CalculateStateTax(Int64 income)
    {
        int stateTaxLimit = 625800;
        float stateTaxRate = 0.3f;

        if (CalculateAge(taxNumber) > 65)
        {
            calculateTax = (income - stateTaxLimit <= 0 ? 0 : (income - taxFreeAmountPensioner)) * stateTaxRate;
        }
        else
        {
            calculateTax = (income - stateTaxLimit <= 0 ? 0 : (income - taxFreeAmountNormal)) * stateTaxRate;
        }
        return (int)calculateTax;
    }
    static int CalculateChurchTax(Int64 income)
    {
        if (memberOfChurch)
        {
            float churchTax = 0.01f;
            float calculateTax = income * churchTax;
            return (int)calculateTax;
        }
        else
        {
            return 0;
        }
    }
    static int CalculateAge(string taxNumber)
    {
        string birthDay = taxNumber.Substring(0, 4);
        int yearNow = DateTime.Today.Year;
        int age = yearNow - int.Parse(birthDay);

        return age;
    }

}