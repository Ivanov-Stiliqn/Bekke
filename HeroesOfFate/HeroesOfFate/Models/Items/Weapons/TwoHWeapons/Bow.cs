namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Bow : Weapon
    {
        private const bool IsOneH = false;

        public Bow(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}