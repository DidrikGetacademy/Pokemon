using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Pokemon
    {
        public string Name { get; set; }

        private int Health { get; set; }


        public Pokemon(string name)
        {
            Name = name;
            Health = 100;
     
        }

    


        public string StartPokemon()
        {
            Console.WriteLine("Enter Start Pokemon name: ");
            string name = Console.ReadLine();
            return name;
        }

        public string pokemonName()
        {
            return Name;
        }

        public int health()
        {
            return Health;
        }

     

     

    }
}
