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

        public Pokemon(string name)
        {
            Name = name;
        }


        public string StartPokemon()
        {
            Console.WriteLine("Enter StartPokemon name: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
