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


                }
            }
        }      
    }
}

//Treneren skal ha mulighet til å gå i forskjellig terreng (grass, vann) der vilkårlige pokemen
//kan dukke opp. Man kan fange eller kjempe mot de ville pokemenna som dukker opp (det
//kan hende de også stikker av). Treneren kan også gå inn i pokeshop for å skaffe seg flere
//pokeballer eller health potions som kan brukes i combat. Man skal ha mulighet til å se hvilke
//pokemen treneren har, og også annen inventory som pokeballer/potions.