namespace HeroesOfFate.Models.Items.Weapons.TwoHWeapons
{
    public class Greatsword : Weapon
    {
        public Greatsword(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = false;
        }
    }
}