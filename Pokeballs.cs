using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Pokeballs : ShopItem
    {
        public string Name { get; set; }

        public int RandomCapturePercent { get; set; }
        public Pokeballs(string name, int RandomCapture) : base(name)
        {
            Name = name;
            RandomCapturePercent = RandomCapture;
        }

      

        public Pokeballs CreateItem(string name, int random)
        {
            return new Pokeballs(name, random);
        }
    }
}
