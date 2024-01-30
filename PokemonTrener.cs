using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pokemon
{
    public class PokemonTrener
    {
        private string Name { get; set; }

        private List<Pokemon> pokemons { get; set; }

        private List<Pokeballs> pokeballsItems { get; set; }

        private List<HealthPotions> potionsItems { get; set; }

        public Pokeshop shop { get; set; }

        Pokemon Pokemon { get; set; }
        public PokemonTrener(string name)
        {
            pokemons = new List<Pokemon>();
            Name = name;
            shop = new Pokeshop();
            Pokemon = new Pokemon(" ");
            pokeballsItems = new List<Pokeballs>();
            potionsItems = new List<HealthPotions>();
        }
    

         string ChooseTrainerName()
        {
            Console.WriteLine("Enter Trainer Name: ");
            string name = Console.ReadLine();
            return  name;
        }

         void NewPokemon()
        {
            string FirstPokemon = Pokemon.StartPokemon();
            pokemons.Add(new Pokemon(FirstPokemon));
        }

         void PokemonTrainerInfo()
        {
            Name = ChooseTrainerName();
            NewPokemon();
        }


        public void PrintInfo()
        {
            PokemonTrainerInfo();
            Console.WriteLine($"Welcome Trainer: " + Name);
            PokemonInventory();
        }

       public void CharacterDetails()
        {
            Console.WriteLine("Character Details");
            Console.WriteLine($"Trainer: {Name}");
            PokemonInventory();
        }

        void PokemonInventory()
        {
            Console.WriteLine("Your [Pokemon] inventory");
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"Pokemon: {pokemon.Name}");
            }
        }


        void GoToGrass()
        {
            // vilkårlige pokemen kan dukke opp, man kan fange eller kjempe mot de ville pokemenna som dukker opp
            // kan hende de også stikker av
        }
 

        void gotowater()
        {
     
        }

        public void buyItem(ShopItem item, HealthPotions potion)
        {

            if (item != null)
            {
                Random rand = new Random();
                var RandomCapture = rand.Next(0, 10);
                if (item.ItemName == "Pokeballs")
                {
                    pokeballsItems.Add(new Pokeballs(item.ItemName, RandomCapture));
                    Console.WriteLine($"Du har kjøpt: -{item.ItemName}");
                }

                if (potion != null)
                {
                    potionsItems.Add(new HealthPotions(potion.Name, potion.Health));
                    Console.WriteLine($"Du har kjøpt: -{potion.Name} [{potion.Health}]");
                }
            }
        }
        




        public void EnterPokeShop()
        {
            ShopItem item = shop.ShopDisplay();
            if (item != null)
            {
                HealthPotions potion = item as HealthPotions;
                buyItem(item,potion);
            }
           
        }



        public void potionPokeballsInventory()
        {
            printPokeballs();
            printHealthPotions();


        }

   void printPokeballs()
        {
            var pokeballCount = pokeballsItems.Count;
            if(pokeballCount > 0)
            {
                Console.WriteLine($"Antall pokeballs:({pokeballCount}) ");
                foreach (var pokeball in pokeballsItems)
                {
                    Console.WriteLine($"-{pokeball.Name}");
                }
                Console.WriteLine();
            }else
            {
                Console.WriteLine("Du er tom for [Pokeballs]!!");
            }
       
        }


        void printHealthPotions()
        {
            
            var healthPotionCount = potionsItems.Count;
            if (healthPotionCount > 0)
            {
                Console.WriteLine($"Antall HealthPotions: ({healthPotionCount})");
                foreach (var potion in potionsItems)
                {
                    Console.WriteLine($"-{potion.Name}[{potion.Health}]");
                }
            }else
            {
                Console.WriteLine("Du er tom for [Health Potions]!!");
            }
     
        }
    }
}



