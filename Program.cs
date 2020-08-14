using System;
using hamburger;

namespace firstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Hamburger hamburger = new HouseHamburger();
            Console.WriteLine(hamburger.getPrice()); // 4

            hamburger.addAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); //6

            hamburger.addAdditional(Additionals.Ketchup);
            Console.WriteLine(hamburger.getPrice()); // 7

            hamburger.removeAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 5
            
            hamburger.removeAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 5
            
            hamburger.addAdditional(Additionals.Barbecue);
            Console.WriteLine(hamburger.getPrice()); // 7
            
            hamburger.addAdditional(Additionals.Salad);
            Console.WriteLine(hamburger.getPrice()); // 9
            
            hamburger.addAdditional(Additionals.DoubleMeat);
            Console.WriteLine(hamburger.getPrice()); // 11

            hamburger.addAdditional(Additionals.Ketchup);
            Console.WriteLine(hamburger.getPrice()); // 11
        }
    }
}
