using System.Collections.Generic;
using HeroesOfFate.Contracts;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Models.NPC
{
    public class Merchant : IMerchant
    {
        public Merchant(List<Item>items)
        {
            this.MerchantItems = items;
        }

        public List<Item> MerchantItems { get; set; }

    }
}