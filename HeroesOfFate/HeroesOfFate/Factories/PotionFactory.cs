using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.Contracts;
using HeroesOfFate.Contracts.FactoryContracts;
using HeroesOfFate.Contracts.Item_Contracts;
using HeroesOfFate.Models.Items.Potions;

namespace HeroesOfFate.Factories
{
    public class PotionFactory : IPotionFactory
    {
        public IItem CreatePotion(string potionType, string id, decimal price)
        {
            switch (potionType)
            {
                case"healthPotion":
                    return new HealthPotion(id,price);
                case "attackPotion":
                    return new AttackPotion(id,price);
                case"deffencePotion":
                    return new DefencePotion(id,price);
                default:
                    throw new ArgumentException("There is no such potion in the game");
            }
        }
    }
}
