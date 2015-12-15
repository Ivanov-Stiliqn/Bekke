using System.Collections.Generic;
using HeroesOfFate.Events;
using HeroesOfFate.Models.Characters.Heroes;
using HeroesOfFate.Models.Items.Potions;

namespace HeroesOfFate.Contracts
{
    public interface IHero
    {
        string Name { get; set; }

        double Armor { get; set; }

        double Gold { get; set; }

        int Exp { get; set; }

        IEnumerable<IItem> Inventory { get; }

        IEnumerable<IItem> Equipment { get; }

        Race HeroRace { get; set; }

        double MaxHealth { get; set; }

        void AddItemToInventory(IItem item);

        void RemoveItemFromInventory(IItem item);

        void ApplyItemEffect(IItem item);

        void RemoveItemEffect(IItem item);

        void ApplyPotionEffect(Potion potion);

        void RemovePotionEffect(Potion potion);

        void Equip(IItem item);

        void LevelUp(int value);

        void OnLevelChange(object sender, HeroChangeLevelEventArgs eventArgs);
    }
}