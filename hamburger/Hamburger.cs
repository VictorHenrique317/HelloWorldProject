using System.Collections.Generic;
using System;
namespace hamburger{
    public abstract class Hamburger{
        protected double price;
        protected Bun bun;
        protected Meat meat;
        protected HashSet<Additionals> additionals;
        protected static Dictionary<Enum, Double> priceTable = new Dictionary<Enum, double>();

        static Hamburger(){
            priceTable.Add(Bun.Wheat, 2);
            priceTable.Add(Bun.Potato, 3);
            priceTable.Add(Bun.Integral, 4);
            priceTable.Add(Meat.Lamb, 4);
            priceTable.Add(Meat.Pork, 3);
            priceTable.Add(Meat.Steak, 2);
            priceTable.Add(Additionals.Ketchup, 1);
            priceTable.Add(Additionals.Barbecue, 2);
            priceTable.Add(Additionals.Salad, 2);
            priceTable.Add(Additionals.Tomato, 1);
        }  

        public abstract bool addAdditional(Additionals additional);
        public abstract bool removeAdditional(Additionals additional); 
        public double getPrice() => this.price;
        public void buy(int quantity){
            // ?
        }

    }

    public class HouseHamburger: Hamburger{
        public HouseHamburger(){
            this.bun = Bun.Wheat; 
            this.meat = Meat.Steak;
            this.additionals = new HashSet<Additionals>();
            price += priceTable[this.bun];
            price += priceTable[this.meat];

        }

        public override bool addAdditional(Additionals additional){
            if(additionals.Contains(additional)){
                Console.WriteLine($"Additional {additional.ToString()} is already on hamburger");
                return false;
            }

            additionals.Add(additional);
            if (additional == Additionals.DoubleMeat){
                    price += priceTable[meat]; // add the meat price
                }else{
                    price += priceTable[additional];
                }
            return true;   
        }

        public override bool removeAdditional(Additionals additional){
            if (!additionals.Contains(additional)){
                Console.WriteLine($"Additional {additional.ToString()} isn't on the hamburger");
                return false;
            }

            additionals.Remove(additional);
             if (additional == Additionals.DoubleMeat){
                    price -= priceTable[meat]; // subtract the meat price
                }else{
                    price -= priceTable[additional];
                }
            return true; 
        }


    }
}
