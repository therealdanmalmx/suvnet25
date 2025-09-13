class Program
{
    static void Main() //Ok nått är fel med progammet, det startar inte ens. Hinner inte fixa, har möte med chefen om 5 min. //Pelle Programmerare
    {
        Console.Clear();
        bool quit = false;
        string taxNumber;
        bool memberOfChurch;

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

                Console.Write("Vilken kommun bor du i?: ");
                string city = Console.ReadLine().Trim();

                GetCityTaxRate(city);

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

                PrintTaxDetails(fullName, taxNumber, income, city, memberOfChurch);


                // Bra kod för att beräkna skatt för en person kommer här. Efter fikapausen. //Pelle Programmerare
            }
            else if (input == 2)
            {
                string[] personsList = File.ReadAllLines("personer.csv");

                foreach (string item in personsList)
                {
                    string[] splitString = item.Split(",");

                    taxNumber = splitString[0];
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

                    PrintTaxDetails(name, taxNumber, income, city, memberOfChurch);
                }
            }
            else if (input == 3)
            {
                quit = true;
                //Här ska progarmmet avslutas men vet inte exakt hur. Kanske inte är så viktigt heller. //Pelle Programmerare
            }
        }
    }

    static void PrintTaxDetails(string name, string taxNumber, Int64 income, string city, bool memberOfChurch)
    {
        Console.WriteLine("SKATTEKVITTERING");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Namn: {name}");
        Console.WriteLine($"Personnummer: {taxNumber}");
        Console.WriteLine($"Inkomst: {income} kr");
        Console.WriteLine($"Kyrkotillhörighet: {((memberOfChurch == true) ? "Ja" : "Nej")}");
        Console.WriteLine($"Kommun: {city} (skattesatts: {Math.Round(GetCityTaxRate(city)*100, 4)}%)");
        Console.WriteLine();
        Console.WriteLine($"Kommunalskatt: {CalculateCommuneTax(income, taxNumber, city)} kr");
        Console.WriteLine($"Statlig skatt: {CalculateStateTax(income, taxNumber)} kr");
        Console.WriteLine($"Kyrkoavgift: {CalculateChurchTax(income, memberOfChurch)} kr");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Totalt att betala: {CalculateTotal(income, taxNumber, city, memberOfChurch)} kr");
    }
    static Int64 CalculateCommuneTax(Int64 income, string taxNumber, string city)
    {
        double communeTaxRate = GetCityTaxRate(city);

        Console.WriteLine($"Commune tax: {communeTaxRate}");
        int taxFreeAmountNormal = 24900;
        int taxFreeAmountPensioner = 65300;
        double calculateTax;

        if (CalculateAge(taxNumber) > 65)
        {
            calculateTax = (income - taxFreeAmountPensioner) <= 0 ? 0 : (income - taxFreeAmountPensioner) * communeTaxRate;
        }
        else
        {
            calculateTax = (income - taxFreeAmountNormal) <= 0 ? 0 : (income - taxFreeAmountNormal) * communeTaxRate;
        }
        return (Int64)calculateTax;
    }

    static Int64 CalculateStateTax(Int64 income, string taxNumber)
    {
        int stateTaxLimit = 625800;
        double stateTaxRate = 0.3;
        int taxFreeAmountNormal = 24900;
        int taxFreeAmountPensioner = 65300;
        double calculateTax;

        if (CalculateAge(taxNumber) > 65)
        {
            calculateTax = (income - taxFreeAmountPensioner - stateTaxLimit) <= 0 ? 0 : (income - taxFreeAmountPensioner - stateTaxLimit) * stateTaxRate;
        }
        else
        {
            calculateTax = (income - taxFreeAmountNormal - stateTaxLimit) <= 0 ? 0 : (income - taxFreeAmountNormal - stateTaxLimit) * stateTaxRate;
        }
        return (Int64)calculateTax;
    }
    static Int64 CalculateChurchTax(Int64 income, bool memberOfChurch)
    {
        if (memberOfChurch)
        {
            float churchTax = 0.01f;
            float calculateTax = income * churchTax;

            return (Int64)calculateTax;
        }
        else
        {
            return 0;
        }
    }

    static Int64 CalculateTotal(Int64 income, string taxNumber, string city, bool memberOfChurch)
    {
        Int64 commune = CalculateCommuneTax(income, taxNumber, city);
        Int64 state = CalculateStateTax(income, taxNumber);
        Int64 church = CalculateChurchTax(income, memberOfChurch);

        return (Int64)(commune + state + church);
    }
    static int CalculateAge(string taxNumber)
    {
        string birthDay = taxNumber.Substring(0, 4);
        int yearNow = DateTime.Today.Year;
        int age = yearNow - int.Parse(birthDay);

        return age;
    }

    static double GetCityTaxRate(string city)
    {
        string[] cityList = File.ReadAllLines("skattesatser.csv".ToLower().Trim());
        double cityTaxRate = 0;

        for (int i = 0; i < cityList.Length; i++)
        {
            if (cityList[i].ToLower().Split(",")[0].Trim() == city.ToLower())
            {
                cityTaxRate = Math.Round(double.Parse(cityList[i].ToLower().Split(",")[1].Trim()) / 100, 4);
            }
        }
        Console.WriteLine(cityTaxRate);
        return cityTaxRate;
    }
}