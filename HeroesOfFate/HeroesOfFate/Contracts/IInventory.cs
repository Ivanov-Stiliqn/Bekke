using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.Models;

namespace HeroesOfFate.Contracts
{
    public interface IInventory
    {
        void AddItemToInventory(Item item);

        void RemoveItemFromInventory(Item item);
    }
}
