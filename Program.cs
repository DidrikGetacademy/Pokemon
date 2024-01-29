using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var shop = new Pokeshop();
            shop.ShopInventory();
        }      
    }
}
