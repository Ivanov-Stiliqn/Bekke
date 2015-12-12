namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Axe : Weapon
    {
        private const bool IsOneH = true;

        public Axe(ItemType type, double weaponAttack, string id, decimal price) : base(type, weaponAttack, id, price, IsOneH)
        {
            
        }
    }
}