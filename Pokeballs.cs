using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Pokeballs
    {
        public string Name { get; set; }

        public int RandomCapturePercent { get; set; }
        public Pokeballs(string name, int RandomCapture)
        {
            Name = name;
            RandomCapturePercent = RandomCapture;
        }

        public Pokeballs()
        {

        }

        public Pokeballs CreateItem(string name, int random)
        {
            return new Pokeballs(name, random);
        }
    }
}
