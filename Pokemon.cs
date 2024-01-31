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

        private int Damage { get; set; }

        private  Random rand = new Random();

        public Pokemon(string name)
        {
            Name = name;
            Health = 100;
            Damage = rand.Next(0, 50);
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

        public int damage()
        {
            return Damage;
        }

     

    }
}
