using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
   public class HealthPotions
    {
        public string Name { get; set; }

        public int Health { get; set; } 

        public HealthPotions(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public HealthPotions()
        {

        }

        public HealthPotions createItem(string name, int health)
        {
            return new HealthPotions(name, health);
        }
    }
}
