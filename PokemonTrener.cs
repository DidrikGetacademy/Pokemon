using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.Design;

namespace Pokemon
{
    public class PokemonTrener
    {
        private string Name { get; set; }

        public List<Pokemon> pokemons { get; set; }

        private List<Pokeballs> pokeballsItems { get; set; }

        public List<HealthPotions> potionsItems { get; set; }

        private BattleArena arena { get; set; }
        public Pokeshop shop { get; set; }

    

        Pokemon Pokemon { get; set; }
        public PokemonTrener(string name)
        {
            pokemons = new List<Pokemon>();
            Name = name;
            shop = new Pokeshop();
            Pokemon = new Pokemon("");
            pokeballsItems = new List<Pokeballs>();
            potionsItems = new List<HealthPotions>();
            arena = new BattleArena(this);
        }
    
        public int pokeballHealth()
        {
            var result = potionsItems.Count;
            return result;
        }


         string ChooseTrainerName()
        {
            Console.WriteLine("Enter Trainer Name: ");
            string name = Console.ReadLine();
            return  name;
        }

       public string TrainerName()
        {
            return Name;
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
            Console.WriteLine();
           
        }

       public void CharacterDetails()
        {
            Console.WriteLine("[Character Details]");
            Console.WriteLine($"Trainer: {Name}");
            PokemonInventory();
        }

      public  void PokemonInventory()
        {
           
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"-Pokemon: {pokemon.Name}");
            }
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
                    Console.WriteLine($"you bought: -{item.ItemName}");
                }

                if (potion != null)
                {
                    potionsItems.Add(new HealthPotions(potion.Name, potion.Health));
                    Console.WriteLine($"you bought: -{potion.Name} [{potion.Health}]");
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

      public void printPokeballs()
        {
            var pokeballCount = pokeballsItems.Count;
            if(pokeballCount > 0)
            {
                Console.WriteLine($"Count: pokeballs:({pokeballCount}) ");
                foreach (var pokeball in pokeballsItems)
                {
                    Console.WriteLine($"-{pokeball.Name}");
                }
                Console.WriteLine();
            }else
            {
                Console.WriteLine("you have 0 [Pokeballs]!");
            }
        }


       public void printHealthPotions()
        {
            var healthPotionCount = potionsItems.Count;
            if (healthPotionCount > 0)
            {
                Console.WriteLine($"Count: HealthPotions: ({healthPotionCount})");
                foreach (var potion in potionsItems)
                {
                    Console.WriteLine($"-{potion.Name}[{potion.Health}]");
                }
            }
            else
            {
                Console.WriteLine("you have 0 [Health Potions]!!");
            }
     
        }






        public void Battle()
        {
            Console.WriteLine("1.Enter Grass");
            Console.WriteLine("2.Enter Water ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    arena.grass();
                    break;
                case "2":
                    arena.Water();
                    break;
               default: Console.WriteLine("Wrong Input"); break;
            }
        }



        public void Catch() 
        {
          
           
            if (pokeballsItems.Count > 0)
            {
                Pokeballs pokeball = pokeballsItems[0];
                Random rand = new Random();
                int catchPercentage = rand.Next(0,10);
                if(catchPercentage >= pokeball.RandomCapturePercent)
                {
                    pokeballsItems.RemoveAt(0);
                    Pokemon caughtPokemon = arena.CaughtPokemon();
                    Console.WriteLine($"Nice! you caught {caughtPokemon.Name}");
                    pokemons.Add(caughtPokemon);
                }else 
                {
                    Console.WriteLine("Pokemon left, nice try! ");
                }
            }
                else if(pokeballsItems.Count <= 0)
            {
                Console.WriteLine("no avaiable pokeballs. enter pokeshop too buy one!");
                }
            
        }

        public void Fight()
        {
            
            arena.UpdateBattleInfo();
          
        }

   
    }
}