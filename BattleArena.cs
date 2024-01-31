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
            Console.WriteLine("[Press any key to start game]");
            Console.ReadLine();
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
            Console.WriteLine("[Press any key to start game]");
            var grassgame = Console.ReadLine();
            var randompokemon = random.Next(0, grassPokemons.Count);
            var pokemon = grassPokemons[randompokemon];
            caughtPokemon = pokemon;
            Console.WriteLine($"Pokemon Found {pokemon.Name}");
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
            return ChoosenPokemon;
        }



        public void UpdateBattleInfo()
        {
            var EnemyFigther = CaughtPokemon();
            int EnemyHealth = EnemyFigther.health();
            int enemydamage = EnemyFigther.damage();
            trainer.PokemonInventory();
            var ChoosenPokemon = UserChoosenInput();
            var Userpokemon = trainer.pokemons.Find(x => x.Name == ChoosenPokemon);
            int UserpokemonHealth = Userpokemon.health();
            int Userpokemondamage = Userpokemon.damage();
            while (EnemyHealth != 0 && UserpokemonHealth != 0)
            {

                Console.WriteLine($"Name: {Userpokemon.Name}  Health: {UserpokemonHealth}  ");
                Console.WriteLine($"Name: {EnemyFigther.Name} Health: {EnemyHealth}");
                Console.WriteLine("Press: (x) too hit Enemy");
                string input = Console.ReadLine();
                if (input == "x")
                {
                    Console.WriteLine($"{Userpokemon} Attacked with [{Userpokemondamage}]");
                    EnemyHealth -= Userpokemondamage;
         
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
                if (input != null)
                {
                    UserpokemonHealth -= enemydamage;
                    Console.WriteLine($"{EnemyFigther.Name} Attacked with [{enemydamage}]");
                }

            }
        }
    }
}

























//hus oppgaven



//Liste av 5 personer
///Du skal lage en konsollapp som lager en liste over 5 personer med navn,
//adresse og alder og printer ut informasjonen til de som er over 30 år.
//La så brukeren kunne legge til en person til slik at funksjonaliteten fremdeles virker som før./