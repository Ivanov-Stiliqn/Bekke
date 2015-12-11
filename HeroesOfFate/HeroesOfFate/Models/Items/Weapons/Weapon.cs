namespace HeroesOfFate.Models.Items
{
    public class Weapon : Item
    {
        protected Weapon(ItemType type, string id, double weaponAttack, decimal price) : base(type, id, price)
        {
            WeaponAttack = weaponAttack;
        }

        public double WeaponAttack { get; set; }
    }
}