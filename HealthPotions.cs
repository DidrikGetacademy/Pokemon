using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
   public class HealthPotions : ShopItem
    {
        public string Name { get; set; }

        public int Health { get; set; } 

        public HealthPotions(string name, int health) : base(name)
        {
            Name = name;
            Health = health;
        }

    

        public HealthPotions createItem(string name, int health)
        {
            return new HealthPotions(name, health);
        }
    }
}
