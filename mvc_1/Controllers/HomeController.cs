using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Dog()
    {
        List<Dog> dogs = [
            new("Fido", "Labrador", 18),
            new("Mido", "Pudel", 23),
            new("Pido", "Golden", 3),
        ];
        return View(dogs);
    }
    public IActionResult Cat()
    {
        List<Cat> cats = [
            new("Mimmi", "Labrador", 18),
            new("Fiffi", "Pudel", 23),
            new("Giggi", "Golden", 3),
        ];
        return View(cats);
    }
}

record Dog(string Name, string Breed, int Age);
record Cat(string Name, string Breed, int Age);