namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class HandCrossbow : Weapon
    {
        private const bool IsOneH = true;

        public HandCrossbow(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}