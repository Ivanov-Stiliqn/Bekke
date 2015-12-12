namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Bow : Weapon
    {
        public Bow(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = false;
        }
    }
}