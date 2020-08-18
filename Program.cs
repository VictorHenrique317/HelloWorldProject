using System;
using hamburger;
using ingredients;
using storage;

namespace firstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage.showStock();
            Hamburger hamburger = new HouseHamburger();
            Console.WriteLine(hamburger.getPrice()); // 4
            Storage.showStock();

            hamburger.addAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); //6
            Storage.showStock();

            hamburger.addAdditional(Additionals.Ketchup);
            Console.WriteLine(hamburger.getPrice()); // 7
            Storage.showStock();

            hamburger.removeAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 5
            Storage.showStock();
            
            hamburger.removeAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 5
            Storage.showStock();
            
            hamburger.addAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 7
            Storage.showStock();
            
            hamburger.addAdditional(Additionals.Salad);
            Console.WriteLine(hamburger.getPrice()); // 9
            Storage.showStock();
            
            hamburger.addAdditional(Additionals.DoubleMeat);
            Console.WriteLine(hamburger.getPrice()); // 11
            Storage.showStock();

            hamburger.addAdditional(Additionals.Ketchup);
            Console.WriteLine(hamburger.getPrice()); // 11
            Storage.showStock();    

            Console.WriteLine("/////////////////////////////////////////////////");
            Storage.addStock(Additionals.Tomato, 121);
            Storage.showStock();
        }
    }
}
