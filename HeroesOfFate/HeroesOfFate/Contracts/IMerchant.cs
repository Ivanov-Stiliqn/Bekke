using System.Collections.Generic;
using HeroesOfFate.Models;
using HeroesOfFate.Models.Items;

namespace HeroesOfFate.Contracts
{
    public interface IMerchant
    {
        List<Item> MerchantItems { get; set; }
    }
}