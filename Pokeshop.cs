using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Pokeshop
    {
     public List<Pokeballs> ShopPokeball { get; set; }

     public Random random { get; set; }

     public List<HealthPotions> ShopHealthPotions { get; set;}

     private Pokeballs pokeballClass { get; set; }

     private HealthPotions healthPotions { get; set; }


        public Pokeshop()
        {
            ShopPokeball = new List<Pokeballs>();
            ShopHealthPotions = new List<HealthPotions>();  
            random = new Random();
            pokeballClass = new Pokeballs();
            healthPotions = new HealthPotions();
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
            ShopHealthPotions.Add(healthPotions.createItem("Health Potion", 25));
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



//Pokemon
//Appen du skal lage må ha en pokemontrener. Brukeren skal få velge navn og startpokemon.
//Treneren skal ha mulighet til å gå i forskjellig terreng (grass, vann) der vilkårlige pokemen
//kan dukke opp. Man kan fange eller kjempe mot de ville pokemenna som dukker opp (det
//kan hende de også stikker av). Treneren kan også gå inn i pokeshop for å skaffe seg flere
//pokeballer eller health potions som kan brukes i combat. Man skal ha mulighet til å se hvilke
//pokemen treneren har, og også annen inventory som pokeballer/potions.