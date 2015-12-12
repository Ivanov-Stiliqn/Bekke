namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Greatsword : Weapon
    {
        private const bool IsOneH = false;

        public Greatsword(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {

        }
    }
}