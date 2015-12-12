namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Wand : Weapon
    {
        public Wand(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = true;
        }
    }
}