using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class PokemonTrener
    {
        public string Name { get; set; }

        public List<Pokemon> pokemons { get; set; }

        public PokemonTrener()
        {
            pokemons = new List<Pokemon>();
        }

        void ChoosestartPokemon()
        {
         foreach(var pokemon in pokemons)
            {
                Console.WriteLine($"{pokemon.Name}");
            }
        }
        public string ChooseName()
        {
            Console.WriteLine("Enter Name: ");
            var name = Console.ReadLine();
            return name;
        }

        void GoToGrass()
        {

        }

        void gotowater()
        {
     
        }

        void EnterPokeShop()
        {

        }

        void PokemonsInventory()
        {

        }

        void potionPokeballsInventory()
        {

        }
    }
}


