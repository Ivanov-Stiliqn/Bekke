namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Staff : Weapon
    {
        public Staff(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = false;
        }
    }
}