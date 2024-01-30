using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class ShopItem 
    {
        public string ItemName { get; set; }

        public ShopItem(string itemName) 
        {
            ItemName = itemName;
            
        }
    }
}
