using System.Collections.Generic;
using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.NPC
{
    public class Merchant : IMerchant
    {
        public Merchant(List<IItem> items)
        {
            this.MerchantItems = items;
        }

        public List<IItem> MerchantItems { get; set; }

    }
}