using System.Collections.Generic;
using HeroesOfFate.Models;

namespace HeroesOfFate.Contracts
{
    public interface IMerchant
    {
        List<Item> MerchantItems { get; set; }
    }
}