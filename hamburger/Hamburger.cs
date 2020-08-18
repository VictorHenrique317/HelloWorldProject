using System.Collections.Generic;
using System;
using ingredients;
using storage;
namespace hamburger{
    public abstract class Hamburger{
        protected readonly object lockSync = new Object();
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
            if (Storage.removeStock(Bun.Wheat, 1) != 0){ this.bun = Bun.Wheat; price += priceTable[this.bun];} 
            if (Storage.removeStock(Meat.Steak, 1) != 0) { this.meat = Meat.Steak; price += priceTable[this.meat];}            
            this.additionals = new HashSet<Additionals>();
        }

        public override bool addAdditional(Additionals additional){
            if(additionals.Contains(additional)){
                Console.WriteLine($"Additional {additional.ToString()} is already on hamburger");
                return false;
            }

            if (additional == Additionals.DoubleMeat){ // Verifies for double meat
                if(Storage.removeStock(this.meat, 1) != 0){ // there is meat on stock
                    price += priceTable[meat]; // add the meat price     
                    additionals.Add(additional);            
                    return true;   
                }
            }else{
                if(Storage.removeStock(additional, 1) != 0){ // there is items on the stock
                    price += priceTable[additional];
                    additionals.Add(additional);
                    return true;
                }
            }
            return false;   
        }

        public override bool removeAdditional(Additionals additional){
            if (!additionals.Contains(additional)){
                Console.WriteLine($"Additional {additional.ToString()} isn't on the hamburger");
                return false;
            }

            additionals.Remove(additional);
            if (additional == Additionals.DoubleMeat){
                price -= priceTable[meat]; // subtract the meat price
                Storage.addStock(this.meat, 1);
            }else{
                price -= priceTable[additional];
                Storage.addStock(additional, 1);
            }
            return true; 
        }


    }
}
