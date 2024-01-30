using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System;
using System.Xml.Linq;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Trainer = new PokemonTrener(" ");
            Trainer.PrintInfo(); /*Brukeren skal få velge navn og startpokemon.*/
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menu");
                Console.WriteLine("1.Your Details");
                Console.WriteLine("2.Enter Pokeshop");
                Console.WriteLine("3.Inventory pokeballs/Potions");
                Console.WriteLine("4.Battle in water/grass");
                Console.WriteLine("5.Exit Game");
                var Input = Console.ReadLine();
                switch (Input)
                {
                        case "1":
                        Trainer.CharacterDetails();
                        break;

                        case "2":
                        Trainer.EnterPokeShop();
                        break;



                        case "3":
                        Trainer.potionPokeballsInventory();
                        break;

                        case "4":
                        Trainer.Battle();
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;


                }
            }
        }      
    }
}

