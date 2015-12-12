namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Greataxe : Weapon
    {
        public Greataxe(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = false;
        }
    }
}