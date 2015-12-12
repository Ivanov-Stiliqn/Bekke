namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Staff : Weapon
    {
        private const bool IsOneH = false;

        public Staff(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}