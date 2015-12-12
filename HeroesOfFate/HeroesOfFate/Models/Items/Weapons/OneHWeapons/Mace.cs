namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Mace : Weapon
    {
        private const bool IsOneH = true;

        public Mace(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}