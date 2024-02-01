using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pokemon
{
    public class Pokeshop 
    {
     public List<Pokeballs> ShopPokeball { get; set; }

     public Random random { get; set; }

     public List<HealthPotions> ShopHealthPotions { get; set;}

     private Pokeballs pokeballClass { get; set; }

     private HealthPotions healthPotions { get; set; }

       
        public Pokeshop() : base()
        {
            ShopPokeball = new List<Pokeballs>();
            ShopHealthPotions = new List<HealthPotions>();  
            random = new Random();
            pokeballClass = new Pokeballs(" ", 0);
            healthPotions = new HealthPotions(" ", 0);
        }

  
        void AddPokeballToList()
        {
            var randomPercent = random.Next(0, 10);
            ShopPokeball.Add(pokeballClass.CreateItem("Pokeball", randomPercent));
            ShopPokeball.Add(pokeballClass.CreateItem("Pokeball", randomPercent));
            ShopPokeball.Add(pokeballClass.CreateItem("Pokeball", randomPercent));
        }

        void addHealthPotionToList()
        {
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion",25));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 25));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 50));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 50));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 50));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 75));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 75));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 75));
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 75));
        }

  
        public void ShopInventory()
        {
            AddPokeballToList();
            addHealthPotionToList();
            PokeballsList();
            HealthPotionList();
        }


        public ShopItem ShopDisplay()
        {
            ShopInventory();
            Console.WriteLine();
            Console.WriteLine("Choose Item too buy");
            Console.WriteLine("1.-Pokeballs");
            Console.WriteLine("2.-Health Potion");
            int SelectedItem = Convert.ToInt32(Console.ReadLine());

            switch (SelectedItem)
            {

                case 1:
                    if (ShopPokeball.Any())
                    {
                        var pokeball = ShopPokeball.First();
                        ShopPokeball.Remove(pokeball);
                        return new Pokeballs("Pokeballs",pokeball.RandomCapturePercent);
                    }
                    else
                    {
                        Console.WriteLine("Tom på lager.");
                        return null;
                    }


                case 2:
                    if (ShopHealthPotions.Any())
                    {
                        Console.WriteLine("Write Health Number of potion you buy [25],[50],[75]");
                        int healthNumber = Convert.ToInt32(Console.ReadLine());
                        var healthPotionitem = ShopHealthPotions.Find(x => x.Health == healthNumber);

                        if (healthPotionitem != null)
                        {
                            ShopHealthPotions.Remove(healthPotionitem);
                            return new HealthPotions("Health Potion", healthNumber);
                        }
                        else
                        {
                            Console.WriteLine("Tom på lager.");
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Out of stock");
                        return null;
                    }

                default:
                    Console.WriteLine("Wrong Choice");
                    return ShopDisplay();
            }
        }

        void PokeballsList()
        {
            var PokeList = ShopPokeball.FirstOrDefault(x => x.Name == "Pokeball");
                Console.WriteLine( $"-{PokeList.Name}" + $" På lager:({ShopPokeball.Count})" );
            
        }

        void HealthPotionList()
        {
            var healthPotionGroups = ShopHealthPotions.GroupBy(item => item.Health);
            foreach (var group in healthPotionGroups)
            {
                var healthvalue = group.Select(item => item.Health).Distinct();       
                string details = string.Join(", ", healthvalue.Select(health => $"-{group.First(item => item.Health == health).Name}[{health}]"));
                Console.Write(details);
                Console.WriteLine($" På lager:({group.Count()}) ");
            }
        }
    }
}

