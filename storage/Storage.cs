using System.Collections.Generic;
using System;
using ingredients;
namespace storage{
    public static class Storage{
        private static Dictionary<Enum, int> stock = new Dictionary<Enum, int>();
        static Storage(){
            stock.Add(Bun.Integral, 40);
            stock.Add(Bun.Wheat, 40);
            stock.Add(Bun.Potato, 40);
            stock.Add(Meat.Lamb, 50);
            stock.Add(Meat.Pork, 60);
            stock.Add(Meat.Steak, 70);
            stock.Add(Additionals.Ketchup, 30);
            stock.Add(Additionals.Barbecue, 20);
            stock.Add(Additionals.Salad, 10);
            stock.Add(Additionals.Tomato, 5);   
        }

        public static int removeStock(Enum item, int quantity){
            if(!stock.ContainsKey(item)){ return 0; }// Item exists
            if (stock[item] - quantity >= 0){ // and its available
                Console.WriteLine($"Removing {quantity} {item.ToString()}");
                stock[item] -= quantity;
                return quantity;
            }else{
                int returnValue = stock[item];
                stock[item] = 0; // return all available stock till its empty
                Console.WriteLine($"{item.ToString()} is not available");
                return returnValue;
            }
        }

        public static void addStock(Enum item, int quantity){
            if(stock.ContainsKey(item)){ // Item exists
                if(stock[item] + quantity <=100){ // There is space
                    Console.WriteLine($"Adding {quantity} {item.ToString()}");
                    stock[item] += quantity;
                }else{ // throwing away excessive stock
                    int excess = (stock[item] + quantity) - 100; 
                    stock[item] = 100;
                    Console.WriteLine($"Throwing away {excess} {item.ToString()}");
                }
            }else{
                Console.WriteLine($"Item {item.ToString()} doesn't exist");
            }
        }

        public static void showStock(){
            foreach(KeyValuePair<Enum, int> entry in stock){
                Console.WriteLine($"{entry.Key.ToString()}: {entry.Value}");
            }
            Console.WriteLine("=======================================================");
        }
    
    }
}