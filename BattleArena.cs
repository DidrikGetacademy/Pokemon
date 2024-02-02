using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pokemon
{
    public class BattleArena
    {
        private Random random = new Random();


        private Pokemon caughtPokemon;


        private PokemonTrener trainer;

        private Random rand = new Random();
        public BattleArena(PokemonTrener trener)
        {
            this.trainer = trener;
        }

        public List<Pokemon> grassPokemons = new List<Pokemon>
        {
            new Pokemon("Caterpie"),
            new Pokemon("Metapod"),
            new Pokemon("Rattata"),
            new Pokemon("Raticate"),
            new Pokemon("Spearow"),
            new Pokemon("Arbok")
        };

        public List<Pokemon> WaterPokemons = new List<Pokemon>
        {
            new Pokemon("Pikachu"),
            new Pokemon("Balbasaur"),
            new Pokemon("Squrtile"),
            new Pokemon("Charmeleon"),
            new Pokemon("Wartortle"),
            new Pokemon("Blastoise"),
        };

        public void Water()
        {
            Console.WriteLine("You have entered Water Arena");
            Console.WriteLine();
            Console.WriteLine("[Press any key to start game]");
            Console.ReadKey();
            var randompokemon = random.Next(0,WaterPokemons.Count);
            var pokemon = WaterPokemons[randompokemon];
            Console.WriteLine($"Pokemon Found: {pokemon.Name}");
            caughtPokemon = pokemon;
            ArenaMenu();
        }

      public void  ArenaMenu()
        {       
             Console.WriteLine("1.Catch wild Pokemon");
             Console.WriteLine("2.Fight Wild Pokemon");
             string Selected = Console.ReadLine();
            switch(Selected)
            {
                case "1":
                    trainer.Catch();
                    break;

                case "2":
                    trainer.Fight();
                    break;
            } 
        }

        public void grass()
        {
            Console.WriteLine("You have entered Grass Arena");
            Console.WriteLine();
            Console.WriteLine("[Press any key to start game]");
            var grassgame = Console.ReadLine();
            var randompokemon = random.Next(0, grassPokemons.Count);
            var pokemon = grassPokemons[randompokemon];
            caughtPokemon = pokemon;
            Console.WriteLine($"[Pokemon Found {pokemon.Name}]");
            ArenaMenu();
        }


        public Pokemon CaughtPokemon()
        {
            Pokemon result = caughtPokemon;
            return result;
        }



      public string UserChoosenInput()
        {
            Console.WriteLine("Choose Pokemon too fight with ");
            var ChoosenPokemon = Console.ReadLine();
            if (trainer.pokemons.Any(x=> x.Name == ChoosenPokemon))
            {
                return ChoosenPokemon;
            }
           else
            {
                Console.WriteLine("You don't have that pokemon");
                return UserChoosenInput();
            }
        }


        

        public void UpdateBattleInfo()
        {
            var EnemyFigther = CaughtPokemon();
            int EnemyHealth = EnemyFigther.health();
           
            trainer.PokemonInventory();
            var ChoosenPokemon = UserChoosenInput();
            var Userpokemon = trainer.pokemons.Find(x => x.Name == ChoosenPokemon);
            int UserpokemonHealth = Userpokemon.health();          
            int PotionCount = trainer.pokeballHealth();
            string trainername = trainer.TrainerName();
            bool Turn = true;

            while (!Winner())
            {
                int Userpokemondamage = rand.Next(0,45);
                int enemydamage = rand.Next(0, 70);
                Console.WriteLine();
                Console.WriteLine($"Name: {Userpokemon.Name}  Health: {UserpokemonHealth}  ");
                Console.WriteLine($"Name: {EnemyFigther.Name} Health: {EnemyHealth}");
                Console.WriteLine("Press: (x) too hit Enemy");
                Console.WriteLine("Press: (h) too Heal Pokemon");
                string input = Console.ReadLine();

              
                if (input == "x" && Turn)
                {
                    Console.WriteLine($"{Userpokemon.Name} Attacked with [{Userpokemondamage}]");
                    EnemyHealth -= Userpokemondamage;
                    Turn = false;
                }
                

             else  if(input == "h" && UserpokemonHealth <= 100 && Potioncount())
                {
                    trainer.printHealthPotions();
                    Console.WriteLine("Choose potion too use");
                    int choosenHealth = Convert.ToInt32(Console.ReadLine());
                    var selectedpotion = trainer.potionsItems.FirstOrDefault(x => x.Health == choosenHealth);
            

                    if(selectedpotion != null && UserpokemonHealth <= 100)
                    {
                        UserpokemonHealth +=  selectedpotion.Health;
                        Console.WriteLine($"{trainername} healed {Userpokemon.Name} with {selectedpotion.Health}");
                        trainer.potionsItems.Remove(selectedpotion);
                        Turn = false;
                    }else
                    {
                        Console.WriteLine("you don't have this potion in stock, or you already have enough Health");
                    }
                }
                

               else if(input == "h" && !Potioncount()) 
                {
                    Console.WriteLine($"you have {PotionCount} HealPotions");
                    Turn = true;
                }else
                {
                    Console.WriteLine("Wrong Input");
                    Turn = true;
                }
              


                if (Turn == false)
                {
                    UserpokemonHealth -= enemydamage;
                    Console.WriteLine($"{EnemyFigther.Name} Attacked with [{enemydamage}]");
                    Turn = true;
                }



                if (Winner())
                {
                    WinnerStatus();
                }
            }



            void WinnerStatus()
            {
                if (UserpokemonHealth < 0)
                {
                    Console.WriteLine($"{Userpokemon.Name} wins the game!");    
                } else
                {
                    Console.WriteLine($"{EnemyFigther.Name} wins the game!");
                }
            }



            bool Potioncount()
            {
                return PotionCount >= 1;
            }


            bool Winner()
            { 
              return EnemyHealth <= 0 || UserpokemonHealth <= 0; 
            }
        }
    }
}


























