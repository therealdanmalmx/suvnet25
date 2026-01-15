
// Action printDate = () => Console.WriteLine(DateTime.Now.ToLongTimeString());
// Action<DateTime> PrintDateAtTime = (dateTime) => Console.WriteLine(dateTime.ToLongTimeString());
// Action GetDay = () => Console.WriteLine(DateTime.Now.Day);
// Action<DateTime> CheckIfLeapDay = (dateTime) => Console.WriteLine(dateTime.Month == 2 && dateTime.Day == 29);

// printDate();
// GetDay();
// CheckIfLeapDay(DateTime.UtcNow);
// PrintDateAtTime(DateTime.UtcNow);

// Action sayHello = () => Console.WriteLine("Hej!");
// sayHello();

// Action<string> sayHelloAgain = name => Console.WriteLine($"Hello {name}");
// sayHelloAgain("Daniel");

// Action<int, int> addNumbers = (a, b) => Console.WriteLine(a+b);
// addNumbers(2,2);

// Func<int, int> squared = n => n*n;
// Console.WriteLine(squared(2));

// Func<int, int, int> addNumbers = (n1, n2) => n1 + n2;
// Console.WriteLine(addNumbers(2,2));

// Func<int, bool> hasPasses = (n) => n > 65 ? true : false;

// Console.WriteLine(hasPasses(66));

// List<int> numbers = [10, 20, 30, 40, 50];

// bool CountMatching(Func<int, bool> predicate)
// {

//     foreach (var n in numbers)
//     {
//         if (predicate(n))
//         {
//             Console.WriteLine(n);
//         }
//     }

//     return false;
// }

// CountMatching(n => n > 25);

// List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

// List<int> FilterList(List<int> numbers, Func<int, bool> predicate)
// {
//     List<int> evenNumbers = [];
//     foreach (var n in numbers)
//     {
//         if (predicate(n))
//         {
//             evenNumbers.Add(n);
//         }
//     }
//     return evenNumbers;
// }

// List<int> evenList = FilterList(numbers, s => s % 2 == 0);

// List<double> SquaredNumber(List<int> numbers, Func<int, double> transform)
// {
//     List<double> squaredNumber = [];

//     foreach (var n in numbers)
//     {
//         squaredNumber.Add(transform(n));
//     }

//     return squaredNumber;
// }

// List<double> squaredList = SquaredNumber(numbers, n => Math.Pow(n, 2));
// foreach (var n in squaredList)
// {
//     Console.WriteLine(n);
// }

// List<int> randomNumbers = new List<int> { 5, 12, 3, 18, 7, 15, 2, 19, 8, 11 };


// var result = FilterList(randomNumbers, n => n % 2 == 0);
// foreach (var n in result)
// {
//     Console.WriteLine(n);
// }