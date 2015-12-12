namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Sword : Weapon
    {
        public Sword(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = true;
        }
    }
}