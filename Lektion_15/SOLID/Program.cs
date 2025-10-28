using System.Security.Cryptography.X509Certificates;

namespace SOLID;

class Program
{
    static void Main(string[] args)
    {
        // var items = new List<OrderItem>
        // {
        //     new("Bok", 2, 120m),
        //     new("Penna", 5, 10m)
        // };

        // var orderCalculate = new OrderCalculate();
        // var orderPrint = new OrderPrint();
        // orderCalculate.Add(items);
        // orderPrint.PrintReceipt(orderCalculate); // Skriver ut totalsumma + rader    }

        var items = new List<OrderItem>
        {
            new("Bok", 8, 120m),
            new("Penna", 7, 10m)
        };

        DiscountPolicy discount = new ItemCountDiscount(items, 0.2m); // byt här till andra rabatter
        var checkout = new Checkout(discount);

        var total = checkout.Total(items);
        Console.WriteLine($"Totalt att betala: {total:C}");

    }
}

// class OrderItem
// {
//     public string Name { get; }
//     public int Quantity { get; }
//     public decimal UnitPrice { get; }
//     public OrderItem(string name, int qty, decimal price)
//         => (Name, Quantity, UnitPrice) = (name, qty, price);
// }

// class OrderCalculate
// {
//     public readonly List<OrderItem> _items = new();

//     public void Add(IEnumerable<OrderItem> items) => _items.AddRange(items);

//     // ANSVAR 1: beräkningar
//     public decimal CalculateSubtotal()
//     {
//         decimal sum = 0;
//         foreach (var i in _items) sum += i.UnitPrice * i.Quantity;
//         return sum;
//     }

//     public decimal CalculateVat(decimal rate = 0.25m)
//     {
//         return CalculateSubtotal() * rate;
//     }

//     public decimal CalculateTotal(decimal rate = 0.25m)
//     {
//         return CalculateSubtotal() + CalculateVat(rate);
//     }

// }

// class OrderPrint
// {
//     // ANSVAR 2: presentation/utskrift
//     public void PrintReceipt(OrderCalculate calculate)
//     {
//         Console.WriteLine("KVITTO");
//         foreach (var i in calculate._items)
//             Console.WriteLine($"{i.Name} x{i.Quantity} á {i.UnitPrice:C} = {(i.UnitPrice * i.Quantity):C}");
//             Console.WriteLine($"Delsumma: {calculate.CalculateSubtotal():C}");
//             Console.WriteLine($"Moms (25%): {calculate.CalculateVat():C}");
//             Console.WriteLine($"Totalt: {calculate.CalculateTotal():C}");
//     }

// }

class OrderItem
{
    public string Name { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }

    public OrderItem(string name, int qty, decimal price)
        => (Name, Quantity, UnitPrice) = (name, qty, price);
}

// Abstrakt basklass för rabatter
abstract class DiscountPolicy
{
    // Virtuell metod som kan overridas i subklasser
    public virtual decimal Apply(decimal subtotal) => subtotal;

    // Hjälpmetod som kan användas av alla subklasser
    protected decimal PercentageOff(decimal subtotal, decimal percent)
        => subtotal * (1 - percent);
}

// --- Konkreta rabattklasser ---
class NoDiscount : DiscountPolicy
{
    // Ärver standardbeteende (ingen rabatt)
}

class PercentageDiscount : DiscountPolicy
{
    private readonly decimal _percent;
    public PercentageDiscount(decimal percent) => _percent = percent;
    public override decimal Apply(decimal subtotal) => PercentageOff(subtotal, _percent);
}

class ThresholdDiscount : DiscountPolicy
{
    private readonly decimal _threshold;
    private readonly decimal _percent;

    public ThresholdDiscount(decimal threshold, decimal percent)
    {
        _threshold = threshold;
        _percent = percent;
    }

    public override decimal Apply(decimal subtotal)
    {
        if (subtotal >= _threshold)
            return PercentageOff(subtotal, _percent);
        return subtotal;
    }
}

class ItemCountDiscount : DiscountPolicy
{
    private readonly List<OrderItem> _items;
    private decimal _percent;

    public ItemCountDiscount(List<OrderItem> items, decimal percent)
    {
        _items = items;
        _percent = percent;
    }
    public override decimal Apply(decimal subtotal)
    {
        int totalQuantity = 0;
        foreach (var item in _items)
        {
            totalQuantity += item.Quantity;
        }
        Console.WriteLine($"Total quantity: {totalQuantity}");
        if (totalQuantity > 10)
        {
            return _percent = 0.1m;
        }
        return _percent;
    }
}

// --- Checkoutklass som är OCP-kompatibel ---
class Checkout
{
    private readonly DiscountPolicy _discount;
    public Checkout(DiscountPolicy discount) => _discount = discount;

    public decimal Total(IEnumerable<OrderItem> items, decimal vatRate = 0.25m)
    {
        decimal subtotal = 0;
        foreach (var i in items)
            subtotal += i.UnitPrice * i.Quantity;

        var discounted = _discount.Apply(subtotal);
        var vat = discounted * vatRate;
        return discounted + vat;
    }
}