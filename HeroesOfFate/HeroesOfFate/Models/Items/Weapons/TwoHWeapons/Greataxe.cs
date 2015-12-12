namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Greataxe : Weapon
    {
        private const bool IsOneH = false;

        public Greataxe(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}