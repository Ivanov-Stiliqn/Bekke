namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Sword : Weapon
    {
        private const bool IsOneH = true;

        public Sword(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}