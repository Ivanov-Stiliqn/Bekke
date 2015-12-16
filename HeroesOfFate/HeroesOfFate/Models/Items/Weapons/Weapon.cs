using HeroesOfFate.Contracts.Item_Contracts;

namespace HeroesOfFate.Models.Items.Weapons
{
    public class Weapon : Item,IWeapon
    {

        public Weapon(string id, double weaponAttack, decimal price) 
            : base(id, price)
        {
            this.Type = ItemType.MainHand;
            this.WeaponAttack = weaponAttack;
        }

        public bool IsOneH { get; set; }
    }
}